using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Collections;

namespace Romanov
{
    class EParser
    {
        public EdgeDriver driver { set; get; }
        public string Project { set; get; }
        public string URL { set; get; }
        public string sURL { set; get; }
        public string Url { set; get; }
        public int a { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 45);
        public IList urls = new List<string>();

        public EParser(EdgeDriver driver, string Project, string URLL, string sURLL)
        {
            this.driver = driver;
            this.Project = Project;
            URL = URLL;
            sURL = sURLL;
        }

        public void GoUrl()
        {
            urls.Add(URL + sURL);
            a = 1;
            Url = Convert.ToString(urls[0]);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }

        void NextUrl()
        {
            int k = a++;
            Console.WriteLine(k);

            try
            {
                if (k == (urls.Count - 1))
                {
                    string url = Convert.ToString(urls[k]);
                    driver.Navigate().GoToUrl(url);
                }
                else if (k == urls.Count)
                {
                    driver.Quit();
                }
                else
                {
                    string url = Convert.ToString(urls[k + 1]);
                    driver.Navigate().GoToUrl(url);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                driver.Quit();
            }
        }

        void Action()
        {
            NextUrl();
            Console.WriteLine(urls.Count);
            Parsing();
        }

        char[] ch = new Char[] { '|', '*', '"', '?', ';', ':', ',', '.', '/', '[', ']', '{', '}', '=', '-', '_', '+', '#', '@', '!', '$', '%', '^', '&', '№' };

        public void Parsing()
        {
            GlobalFunctions glob = new GlobalFunctions(driver, Project);

            try
            {
                var elements = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("a")));
                glob.Action();

                for (int i = 0; i <= elements.Count; i++)
                {
                    try
                    {
                        var collections = elements[i].GetAttribute("href");

                        foreach (char s in ch)
                        {
                            if (collections.IndexOf(s) != -1)
                            {
                                collections = collections.Remove(collections.IndexOf(s));
                            }
                        }
                        if (collections.StartsWith(URL) == true && urls.Contains(collections) == false)
                        {
                            urls.Add(collections);

                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Action();
                    }
                    catch (NullReferenceException)
                    {
                        Action();
                    }
                    catch (StackOverflowException)
                    {
                        driver.Close();
                        driver = new EdgeDriver(@"C:\Users\r.merikanov\Downloads");
                        Action();
                    }
                }
            }
            catch (NoSuchElementException)
            {
                Action();
            }
            catch (WebDriverTimeoutException)
            {
                glob.Action();
                Action();
            }
            catch (WebDriverException)
            {
                driver.Quit();
            }
        }
    }
}
