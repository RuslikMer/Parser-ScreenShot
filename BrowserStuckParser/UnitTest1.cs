using System;
using System.IO;
using NUnit.Framework;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace BrowserStuckParser
{
    
    [TestFixture]
    public class Test 
    {
        public IWebDriver driver { set; get; }
        public static string Project { set; get; }
        public static string URL { set; get; }
        public static string sURL { set; get; }

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void TestFixtureSetUp()
        {
            Project = Environment.GetEnvironmentVariable("PROJECT");
            //Project = "pp";
            //URL = "http://xn--e1aliadgiil4bl.xn--p1ai/";
            URL = Environment.GetEnvironmentVariable("URL");
            sURL = "";
        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void TestFixtureTearDown()
        {
            driver.Quit();
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
        public void Iphone7()
        {
            Devices D = new Devices(driver);
            D.Iphone7();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Iphone7P()
        {
            Devices D = new Devices(driver);
            D.Iphone7P();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void IphoneX()
        {
            Devices D = new Devices(driver);
            D.IphoneX();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void IphoneSE()
        {
            Devices D = new Devices(driver);
            D.IphoneSE();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Iphone8()
        {
            Devices D = new Devices(driver);
            D.Iphone8();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Iphone8P()
        {
            Devices D = new Devices(driver);
            D.Iphone8P();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Ipad5()
        {
            Devices D = new Devices(driver);
            D.Ipad5();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void IpadPro()
        {
            Devices D = new Devices(driver);
            D.IpadPro();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void GalaxyNote8()
        {
            Devices D = new Devices(driver);
            D.GalaxyNote8();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void GalaxyS8P()
        {
            Devices D = new Devices(driver);
            D.GalaxyS8P();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Pixel()
        {
            Devices D = new Devices(driver);
            D.Pixel();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void Nexus5()
        {
            Devices D = new Devices(driver);
            D.Nexus5();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
        [Test]
        public void MotorolaX2Gen()
        {
            Devices D = new Devices(driver);
            D.MotorolaX2Gen();
            Parser pars = new Parser(D.driver, Project, URL, sURL);
            pars.GoUrl();
            pars.Parsing();
            Assert.NotNull(pars.urls.Count);
        }
    }
}
