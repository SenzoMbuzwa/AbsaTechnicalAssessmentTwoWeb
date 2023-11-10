using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaTechAssessment.ReusableMethods
{
    public class PageActions : Base
    {
        //Using JavaScript to check the document.readyState property, which should be "complete" when the page has fully loaded.
        public void WaitUntilPageIsCompletelyLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                Console.WriteLine("The page has completely loaded!");
            }
            catch
            {
                Console.WriteLine("The page has completely loaded!");
            }
        }

        //wait Until Element is Visible
        public static void WaitUntilElementIsVisible(By targetXPath, int waitTime)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(targetXPath);
                    return elementToBeDisplayed.Displayed;
                }

                catch (StaleElementReferenceException)
                {
                    return false;
                }

                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static string GetElementText(By targetXPath)
        {
            var text = driver.FindElement(targetXPath).Text;
            return text.Trim();
        }

        public static void Click(By targetXPath)
        {
            Thread.Sleep(1000);
            driver.FindElement(targetXPath).Click();
            Thread.Sleep(1000);
        }

        public static void EnterText(By targetXPath, string text)
        {
            driver.FindElement(targetXPath).Clear();
            Thread.Sleep(1000);
            driver.FindElement(targetXPath).SendKeys(text);
            Thread.Sleep(1000);
        }

        public static void DropdownSelect(By targetXPath, string text)
        {
            IWebElement dropdown = driver.FindElement(targetXPath);

            SelectElement select = new SelectElement(dropdown);

            select.SelectByText(text);
        }
    }
}
