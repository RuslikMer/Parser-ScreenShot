using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Romanov
{
    public static class WebElementExtension
    {

        //public static IWebElement FindElement(this IWebDriver driver, By by, Func<IWebElement, bool> predicate)
        //{
        //    return driver.FindElements(by, predicate).First();
        //}

        //public static ReadOnlyCollection<string> ClassList(this IWebElement element)
        //{
        //    ReadOnlyCollection<string> classList;
        //    try
        //    {
        //        char[] arraySeparators = { ' ', '\n', '\t' };
        //        classList = element
        //            .GetAttribute("class")
        //            .Split(arraySeparators, StringSplitOptions.RemoveEmptyEntries)
        //            .ToReadOnlyCollection<string>();
        //    }
        //    catch (Exception)
        //    {
        //        classList = new ReadOnlyCollection<string>(new List<string>());
        //    }
        //    return classList;
        //}

        public static void MouseMove(this IWebElement element)
        {
            RemoteWebElement webElement = element as RemoteWebElement;
            RemoteWebDriver webDriver = webElement.WrappedDriver as RemoteWebDriver;
            webDriver.Mouse.MouseMove(webElement.Coordinates);
        }

        public static void ContextClick(this IWebElement element)
        {
            RemoteWebElement webElement = element as RemoteWebElement;
            RemoteWebDriver webDriver = webElement.WrappedDriver as RemoteWebDriver;
            webDriver.Mouse.ContextClick(webElement.Coordinates);
        }
    }
}
