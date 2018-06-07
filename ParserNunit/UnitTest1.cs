using System;
using System.IO;
using NUnit.Framework;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace ParserNunit
{
    [TestFixture]
    class Test
    {
        public IWebDriver driver { set; get; }
        public static string Project { set; get; }
        public static string URL { set; get; }
        public static string sURL { set; get; }

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void TestFixtureSetUp()
        {
            Project = Environment.GetEnvironmentVariable("PROJECT");
            //Project = "тур";
            //URL = "https://turovart.com/ar/";
            URL = Environment.GetEnvironmentVariable("URL");
            //sURL = "news";
            sURL = Environment.GetEnvironmentVariable("SURL");
        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void TestFixtureTearDown()
        {
            //driver.Quit();
        }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            // ТУТ КОД
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            // ТУТ КОД
        }

        [Test]
        public void GC()
        {
            ChromeOptions co = new ChromeOptions();
            co.AddExtension(@"C:\Users\Adblocker-Genesis-Plus_v1.0.6.crx");

            //using (var driver = new ChromeDriver(co))
            //{
            var driver = new ChromeDriver(co);
            GSaS act = new GSaS(driver, Project);
            act.Dir();
            GParser pars = new GParser(driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            //}
            Assert.NotNull(pars.urls.Count);
        }

        [Test]
        public void FF()
        {
            //using (var driver = new FirefoxDriver())
            //{
            var driver = new FirefoxDriver();
            FSaS act = new FSaS(driver, Project);
            act.Dir();
            FParser pars = new FParser(driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            //}
            Assert.NotNull(pars.urls.Count);
        }

        [Test]
        public void IE()
        {
            //using (var driver = new InternetExplorerDriver())
            //{
            var driver = new InternetExplorerDriver();
            ISaS act = new ISaS(driver, Project);
            act.Dir();
            IParser pars = new IParser(driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            //}
            Assert.NotNull(pars.urls.Count);
        }

        [Test]
        public void EDGE()
        {
            //using (var driver = new InternetExplorerDriver())
            //{
            var driver = new EdgeDriver(@"C:\Users\r.merikanov\Downloads");
            ESaS act = new ESaS(driver, Project);
            act.Dir();
            EParser pars = new EParser(driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            //}
            Assert.NotNull(pars.urls.Count);
        }
    }
}
