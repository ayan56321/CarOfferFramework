using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOfferFramework.Config;
using CarOfferFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace CarOfferFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {

            Browser = browser;

        }


        public void InitializeSettings()
        {
            // Set all Settinsg for Framework
            ConfigReader.SetFrameworkSettings();

            LogHelpers.CreateLogFile();

            OpenBrowser(BrowserType.Chrome);
            LogHelpers.Write("Initialized Browser..");
        }


        private void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver("C:\\Users\\ayanc\\source\\repos\\SeleniumCSharpNetCore\\Drivers");
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Application is Launched " + Settings.AUT);
        }



    }
}
