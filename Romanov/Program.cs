using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Romanov
{
    class Program
    {
        public class Test
        {
            public string Smail { get; set; }
            public string Nmail { get; set; }

            static void Main(string[] args)
            {
                using (var driver = new ChromeDriver())
                {
                    TimeSpan timeout = new TimeSpan(00, 00, 20);
                    Random rand = new Random();
                    string s = "";
                    driver.Navigate().GoToUrl("http://romanovvodka.com/ru/");
                    driver.Manage().Window.Maximize();

                    Actions actions = new Actions(driver);
                    
                    var age = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"choices__inner\"]/div/div")));
                    age.Click();

                    age = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"page-enter__frame-content\"]/form/div[2]/div[1]/div/div[2]/div/div[2]/input")));
                    age.SendKeys("18");
                    SendKeys.SendWait("{ENTER}");

                    /*var country = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"page-enter__frame-content\"]/form/div[2]/div[2]/div/div[2]/div/div[1]/div/div")));
                    country.Click();                                                                                         
                    country = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"page-enter__frame-content\"]/form/div[2]/div[2]/div/div[2]/div/div[2]/input")));
                    country.SendKeys("Russia");                                                                            
                    SendKeys.SendWait("{ENTER}");

                    var login = driver.FindElementByXPath("//*[@class=\"page-enter__frame-content\"]/form/div[3]/div[2]/button/div/div[2]/div/span");
                    login.Click();*/

                    var label = driver.SwitchTo().Window(driver.WindowHandles.ToList().First()).Url; ;


                    var Results = new List<Test>
                    {
                        new Test
                        {
                            Nmail = "http://romanovvodka.com/ru/",
                            Smail = label
                        }
                    };
                    DisplayInExcel(Results);

                }
                void DisplayInExcel(IEnumerable<Test> test)
                {
                    var excelApp = new Excel.Application();
                    Object missing = Type.Missing;
                    excelApp.Visible = true;
                    excelApp.Workbooks.Add(missing);
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    //обЪединение ячеек
                    Excel.Range oRange1;
                    oRange1 = workSheet.Range[workSheet.Cells[1, 2], workSheet.Cells[1, 3]];
                    oRange1.Merge(Type.Missing);

                    string[] Arr2 = new string[] { "A", "B", "C" };
                    string[] Arr3 = new string[] { "Результат", "Проверка" };
                    string[] Arr4 = new string[] { "ожидание", " факт " };
                    for (int i = 0; i < Arr3.Length; i++)
                    {
                        workSheet.Cells[1, Arr2[i]] = Arr3[i];
                    }
                    workSheet.Cells[2, 2] = Arr4[0];
                    workSheet.Cells[2, 3] = Arr4[1];

                    foreach (var t in test)
                    {
                        workSheet.Cells[3, "B"] = t.Nmail;
                        workSheet.Cells[3, "C"] = t.Smail;
                    }

                    //редактирование ячеек 
                    workSheet.Range["A1", "C3"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
                    workSheet.Range["A1", "C3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //цвет ячейки   
                    Excel.Range rng2 = workSheet.get_Range("A3");
                    if (workSheet.Cells[3, "B"].FormulaLocal == workSheet.Cells[3, "C"].FormulaLocal)
                    {
                        workSheet.Cells[3, "A"] = "True";
                        rng2.get_Range("A1", "A1").Interior.ColorIndex = 4;
                    }
                    else
                    {
                        workSheet.Cells[3, "A"] = "False";
                        rng2.get_Range("A1", "A1").Interior.ColorIndex = 3;
                    }

                    //границы ячеек 
                    for (int i = 1; i < 4; i++)
                    {
                        Excel.Range rt = workSheet.get_Range("A" + i, "C" + i);
                        rt.Borders.ColorIndex = 0;
                        rt.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rt.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    //сохранение отчета
                    excelApp.DisplayAlerts = false;
                    Directory.CreateDirectory("C:\\Users\\r.merikanov\\Test");
                    workSheet.SaveAs(string.Format("C:\\Users\\r.merikanov\\Test\\Test.xlsx", Environment.CurrentDirectory));

                    //workSheet.SaveAs(string.Format(@"{0}\Test.xlsx", Environment.CurrentDirectory));
                    Console.ReadKey();
                }
            }
        }
    }
}
