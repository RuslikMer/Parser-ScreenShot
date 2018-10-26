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
        public static string GChrome { set; get; }
        public static string FFox { set; get; }
        public static string IExplorer { set; get; }
        public static string Edge { set; get; }


        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void TestFixtureSetUp()
        {
            //Project = "Согласие";
            //URL = "https://www.soglasie.ru/";
            //sURL = "sitemap";
            //GChrome = "SURL";
            //FFox = "SURL";
            //IExplorer = "T";

            Project = Environment.GetEnvironmentVariable("PROJECT");
            URL = Environment.GetEnvironmentVariable("URL");
            sURL = Environment.GetEnvironmentVariable("SURL");
            GChrome = Environment.GetEnvironmentVariable("GC");
            FFox = Environment.GetEnvironmentVariable("FF");
            IExplorer = Environment.GetEnvironmentVariable("IE");
            Edge = Environment.GetEnvironmentVariable("EDGE");
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
            if (GChrome == "T")
            {
                ChromeOptions co = new ChromeOptions();
                //co.AddExtension(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Helper\Adblocker-Genesis-Plus_v1.0.6.crx"));
                co.AddExtension(@"C:\Users\Adblocker-Genesis-Plus_v1.0.6.crx");

                //using (var driver = new ChromeDriver(co))
                //{
                var driver = new ChromeDriver(co);
                //GSaS act = new GSaS(driver, Project);
                //act.Dir();
                GlobalFunctions glob = new GlobalFunctions(driver, Project);
                glob.Dir();
                GParser pars = new GParser(driver, Project, URL, sURL);
                pars.GoUrl();
                pars.Parsing();
                //}
                Assert.NotNull(pars.urls.Count);
            }
            else
            {
                Assert.AreEqual(1,1);
            }
        }

        [Test]
        public void FF()
        {
            if (FFox == "T")
            {
                //using (var driver = new FirefoxDriver())
                //{
                var driver = new FirefoxDriver();
                //FSaS act = new FSaS(driver, Project);
                //act.Dir();
                GlobalFunctions glob = new GlobalFunctions(driver, Project);
                glob.Dir();
                FParser pars = new FParser(driver, Project, URL, sURL);
                pars.GoUrl();
                pars.Parsing();
                //}
                Assert.NotNull(pars.urls.Count);
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        [Test]
        public void IE()
        {
            if (IExplorer == "T")
            {
                //using (var driver = new InternetExplorerDriver())
                //{
                var driver = new InternetExplorerDriver();
                //ISaS act = new ISaS(driver, Project);
                //act.Dir();
                GlobalFunctions glob = new GlobalFunctions(driver, Project);
                glob.Dir();
                IParser pars = new IParser(driver, Project, URL, sURL);
                pars.GoUrl();
                pars.Parsing();
                //}
                Assert.NotNull(pars.urls.Count);
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        [Test]
        public void EDGE()
        {
            if (Edge == "T")
            {
                //using (var driver = new InternetExplorerDriver())
                //{
                var driver = new EdgeDriver(@"C:\Users\r.merikanov\Downloads");
                //ESaS act = new ESaS(driver, Project);
                //act.Dir();
                GlobalFunctions glob = new GlobalFunctions(driver, Project);
                glob.Dir();
                EParser pars = new EParser(driver, Project, URL, sURL);
                pars.GoUrl();
                pars.Parsing();
                //}
                Assert.NotNull(pars.urls.Count);
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }
    }
}

