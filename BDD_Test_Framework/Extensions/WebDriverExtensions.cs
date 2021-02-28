using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using BDD_Test_Framework.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD_Test_Framework.Extensions
{
    // <summary>
    /// Find element with explicit waits.
    /// </summary>
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementWithWaiting(this IWebDriver driver, By by, int timeInMilliseconds)
        {
            if (timeInMilliseconds <= 0)
            {
                return driver.FindElement(by);
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            return wait.Until(drv => drv.FindElement(by));
        }

        public static IWebElement FindElementWithWaiting(this IWebDriver driver, By by, Func<IWebDriver, IWebElement> waitUntill, int timeInMilliseconds)
        {
            if (timeInMilliseconds <= 0)
            {
                return driver.FindElement(by);
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            return wait.Until(waitUntill);
        }

        public static void WaitForDisappearance(this IWebDriver driver, Func<bool> method)
        {
            SpinWait.SpinUntil(() =>
            {
                return method();
            });
        }

        public static ReadOnlyCollection<IWebElement> FindElementsWithRetry(this IWebDriver driver, By by, RetryPolicyFactory policyFactory)
        {
            return policyFactory.CreateConfiguredRetryPolicy<NoSuchElementException, ReadOnlyCollection<IWebElement>>(
                (collection) => collection.Count == 0)
                .Execute(() =>
                {
                    var result = driver.FindElements(by);
                    return result;
                });
        }

        public static IWebElement FindElementWithRetry(this IWebDriver driver, By by, RetryPolicyFactory policyFactory)
        {
            return policyFactory.CreateConfiguredRetryPolicy<NoSuchElementException, IWebElement>(
                 (elem) => !elem.Displayed)
                .Execute(() =>
                {
                    var result = driver.FindElement(by);
                    return result;
                });
        }

        public static void SwitchToNewestWindowAndMaximize(this IWebDriver webDriver)
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
            webDriver.Manage().Window.Maximize();
        }
    }
}
