using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
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
                Project = "test";
                URL = "https://www.soglasie.ru/";
                sURL = "";

                //ChromePars();
                //FirefoxPars();
                IEPars();
                //EdgePars();

                void EdgePars()
                {
                    using (var driver = new EdgeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Helper")))
                    {
                        GlobalFunctions glob = new GlobalFunctions(driver, Project);
                        glob.Dir();
                        //EAct act = new EAct(driver, Project);
                        //act.Dir();
                        EParser pars = new EParser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }

                void ChromePars()
                {
                    ChromeOptions co = new ChromeOptions();
                    Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                    co.AddExtension(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Helper\Adblocker-Genesis-Plus_v1.0.6.crx"));

                    using (var driver = new ChromeDriver(co))
                    {
                        GlobalFunctions glob = new GlobalFunctions(driver, Project);
                        glob.Dir();
                        //Act act = new Act(driver, Project);
                        //act.Dir();
                        Parser pars = new Parser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }

                void FirefoxPars()
                {
                    using (var driver = new FirefoxDriver())
                    {
                        GlobalFunctions glob = new GlobalFunctions(driver, Project);
                        glob.Dir();
                        //Fact act = new Fact(driver, Project);
                        //act.Dir();
                        FParser pars = new FParser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }

                void IEPars()
                {
                    using (var driver = new InternetExplorerDriver())
                    {
                        GlobalFunctions glob = new GlobalFunctions(driver, Project);
                        glob.Dir();
                        //IEact act = new IEact(driver, Project);
                        //act.Dir();
                        IEParser pars = new IEParser(driver, Project, URL, sURL);
                        pars.GoUrl();
                        pars.Parsing();
                    }
                }
            }
        }
    }
}
