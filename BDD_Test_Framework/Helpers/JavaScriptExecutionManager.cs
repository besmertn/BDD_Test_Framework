using OpenQA.Selenium;

namespace BDD_Test_Framework.Helpers
{
    /// <summary>
    /// The wrapper for java script common script execution.
    /// </summary>
    public class JavaScriptExecutionManager
    {
        public IJavaScriptExecutor JavaScriptExecutor { get; }

        public JavaScriptExecutionManager(IWebDriver webDriver)
        {
            this.JavaScriptExecutor = (IJavaScriptExecutor)webDriver;
        }

        /// <summary>
        /// Emit java script click event for element.
        /// </summary>
        /// <param name="element">Element to emit JS click.</param>
        public void Click(IWebElement element)
        {
            this.JavaScriptExecutor.ExecuteScript("arguments[0].click()", element);
        }

        public void SetValueInField(IWebElement element, string value)
        {
            this.JavaScriptExecutor.ExecuteScript("arguments[0].value='" + value + "'", element);
        }
    }
}
