using System;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace AbsaTechAssessment.ReusableMethods
{
    public class Base
    {
        [ThreadStatic]
        public static IWebDriver driver = default;

        public static void OpenBrowser(string browser)
        {
            InitBrowser(browser);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.way2automation.com/angularjs-protractor/webtables/");
        }

        public static void InitBrowser(string browser) 
        {
            switch (browser)
            {
                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("no-sandbox");
                    //edgeOptions.AddArgument("--headless");
                    driver = new EdgeDriver();
                    break;

                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("no-sandbox");
                    //chromeOptions.AddArguments("--headless");
                    driver = new ChromeDriver();
                    break;
            }
        }
    }
}
