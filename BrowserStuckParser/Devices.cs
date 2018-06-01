using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace BrowserStuckParser
{
    public class Devices
    {
        public IWebDriver driver { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 30);

        public Devices(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NDriver(DesiredCapabilities capability)
        {
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Iphone7()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone 7");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "10.3");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Iphone7P()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone 7 Plus");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "10.3");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void IphoneX()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone X");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void IphoneSE()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone SE");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.2");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Iphone8()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone 8");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Iphone8P()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone 8 Plus");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Ipad5()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPad");
            capability.SetCapability("device", "iPad 5th");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void IpadPro()
        {
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserName", "iPad");
            capability.SetCapability("device", "iPad Pro");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "11.2");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void GalaxyNote8()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "android");
            capability.SetCapability("device", "Samsung Galaxy Note 8");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "7.1");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void GalaxyS8P()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "android");
            capability.SetCapability("device", "Samsung Galaxy S8 Plus");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "7.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Pixel()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "android");
            capability.SetCapability("device", "Google Pixel");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "8.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void Nexus5()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "android");
            capability.SetCapability("device", "Google Nexus 5");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "4.4");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }

        public void MotorolaX2Gen()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "android");
            capability.SetCapability("device", "Motorola Moto X 2nd Gen");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "5.0");
            capability.SetCapability("browserstack.user", "sergeysmirnov5");
            capability.SetCapability("browserstack.key", "Vy1SMbqKGC1seqotD7fb");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
        }
    }
}
