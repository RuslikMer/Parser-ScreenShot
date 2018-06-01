using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using OpenQA.Selenium.Appium.Interfaces;


namespace BrowserStuckParser
{
    class Act
    {
        IWebDriver driver { set; get; }
        public string Project { set; get; }
        public int w { set; get; }
        public string path { set; get; }
        public double i { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 10);

        public Act(IWebDriver driver, string Project)
        {
            this.driver = driver;
            this.Project = Project;
        }

        void GetSize()
        {
            //определение размера
            //w = driver.Manage().Window.Size.Height;
            var size = ((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");
            w = Convert.ToInt32(size);
            float b = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.TagName("body"))).Size.Height;
            //расчет повторений
            double n = b / w;
            i = Math.Ceiling(n);
        }

        public void Action()
        {
            GetSize();
            //NewDirectory();

            for (int k = 0; k <= i; k++)
            {
                //IJavaScriptExecutor js = driver;
                string x = Convert.ToString(w * k);
                ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0, " + x + ")");
                //Screen();
                Task.Delay(500).Wait();
            }
        }
    }
}
