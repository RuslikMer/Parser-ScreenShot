using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using Selenium.Helper;

namespace Romanov
{
    class GlobalFunctions
    {
        public IWebDriver driver { set; get; }
        public string Project { set; get; }
        public string Browser { set; get; }
        public int w { set; get; }
        public string path { set; get; }
        public double i { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 10);

        public GlobalFunctions(FirefoxDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
            Browser = "FF";
        }

        public GlobalFunctions(ChromeDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
            Browser = "GC";
        }

        public GlobalFunctions(InternetExplorerDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
            Browser = "IE";
        }

        public GlobalFunctions(EdgeDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
            Browser = "EDGE";
        }

        public void Action()
        {
            GetSize();
            NewDirectory();

            for (int k = 0; k <= i; k++)
            {
                string x = Convert.ToString(w * k);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + x + ");");
                Screen();
                Task.Delay(500).Wait();
            }
        }

        void GetSize()
        {
            //определение размера

            var size = ((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");
            Console.WriteLine(size);
            w = Convert.ToInt32(size);
            var size1 = ((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");
            float b = Convert.ToInt32(size1);
            Console.WriteLine(b);
            //расчет повторений
            double n = b / w;
            i = Math.Ceiling(n);
        }

        void Screen()
        {
            string screenname = "";
            Random randsn = new Random();
            for (int v = 0; v < 5; v++)
            {
                screenname += Convert.ToChar(randsn.Next(97, 122));
            }
            //var screenShot = driver.GetScreenshot();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path + screenname + ".png", ScreenshotImageFormat.Png);
        }

        public void Dir()
        {
            path = "Z:\\test\\test\\" + Project + "\\" + Browser + "\\";

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                bool directoryExists = Directory.Exists(path);
                Console.WriteLine("The directory was deleted successfully.");
            }

            Directory.CreateDirectory(path);
        }

        void NewDirectory()
        {
            string T = driver.SwitchTo().Window(driver.WindowHandles.ToList().Last()).Title;
            string U = driver.SwitchTo().Window(driver.WindowHandles.ToList().Last()).Url;

            if (String.IsNullOrEmpty(T))
            {
                T = "NoTitle";
            }

            //Encoding ascii = Encoding.ASCII;
            //ascii();
            Console.WriteLine(T);

            char[] ch = new Char[] { '|', '*', '"', '?', ';', ':', ',', '.', '/', '[', ']', '{', '}', '=', '-', '_', '+', '#', '@', '!', '$', '%', '^', '&', '№' };

            //string[] arr = new string[]
            //{
            //    "|",
            //    "?"
            //};

            foreach (char s in ch)
            {
                if (T.IndexOf(s) != -1)
                {
                    T = T.Remove(T.IndexOf(s));

                    if (T.IndexOf(" ") != -1)
                    {
                        int count = T.ToCharArray().Where(i => i == ' ').Count();
                        //Console.WriteLine(count);

                        T = T.Remove(T.LastIndexOf(" "));
                    }
                }
            }

            path = "Z:\\test\\test\\" + Project + "\\" + Browser + "\\" + T + "\\";

            try
            {
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                    TXTFile(U);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        void TXTFile(string url)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(path + "URL.txt");

                //Write a line of text
                sw.WriteLine(url);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
