using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Romanov
{
    class Fact
    {
        public FirefoxDriver driver { set; get; }
        public string Project { set; get; }
        public string Browser { set; get; }
        public int w { set; get; }
        public string path { set; get; }
        public double i { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 45);
        
        public Fact(FirefoxDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
            Browser = "FF";
        }

        void GetSize()
        {
            //определение размера
            w = driver.Manage().Window.Size.Height;
            float b = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.TagName("body"))).Size.Height;
            //расчет повторений
            double n = b / w;
            i = Math.Ceiling(n);
        }

        public void Action()
        {
            GetSize();
            NewDirectory();

            for (int k = 0; k <= i; k++)
            {
                IJavaScriptExecutor js = driver;
                string x = Convert.ToString(w * k);
                js.ExecuteScript("scroll(0, " + x + ")");
                Screen();
                Task.Delay(500).Wait();
            }
        }

        void Screen()
        {
            string screenname = "";
            Random randsn = new Random();
            for (int v = 0; v < 5; v++)
            {
                screenname += Convert.ToChar(randsn.Next(97, 122));
            }
            var screenShot = driver.GetScreenshot();
            screenShot.SaveAsFile(path + screenname + ".png", ScreenshotImageFormat.Png);
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
            if (String.IsNullOrEmpty(T))
            {
                T = "NoTitle";
            }

            char[] ch = new Char[] { '|', '*', '"', '?', ';', ':', ',', '.', '/', '[', ']', '{', '}', '=', '-', '_', '+', '#', '@', '!', '$', '%', '^', '&', '№' };

            foreach (char s in ch)
            {
                if (T.IndexOf(s) != -1)
                {
                    T = T.Remove(T.IndexOf(s));

                    if (T.IndexOf(" ") != -1)
                    {
                        int count = T.ToCharArray().Where(i => i == ' ').Count();
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
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }
    }
}
