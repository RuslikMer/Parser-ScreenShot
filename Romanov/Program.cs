using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Data.OleDb;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using System.IO;
using System.Linq;

namespace Romanov
{
    class Program
    {
        public class Test
        {
            public static string Project { set; get; }
            public static string URL { set; get; }
            public static string sURL { set; get; }

            static void Main(string[] args)
            {
                Project = "Hilti";
                URL = "http://www.eurofox.at/";
                sURL = "sitemap";

                ChromePars();
                FirefoxPars();
                IEPars();

                void ChromePars()
                {
                    ChromeOptions co = new ChromeOptions();
                    co.AddExtension(@"C:\Users\Adblocker-Genesis-Plus_v1.0.6.crx");

                    using (var driver = new ChromeDriver(co))
                    {
                        Act act = new Act(driver, Project);
                        act.Dir();
                        Parser pars = new Parser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }

                void FirefoxPars()
                {
                    //FirefoxOptions fo = new FirefoxOptions();
                    //FirefoxProfile Fp = new FirefoxProfile();
                    //Fp.AddExtension(@"C:\Users\Adblocker-Genesis-Plus_v1.0.6.crx");

                    using (var driver = new FirefoxDriver())
                    {
                        Fact act = new Fact(driver, Project);
                        act.Dir();
                        FParser pars = new FParser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }

                void IEPars()
                {
                    using (var driver = new InternetExplorerDriver())
                    {
                        IEact act = new IEact(driver, Project);
                        act.Dir();
                        IEParser pars = new IEParser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }
            }
        }
    }
}
