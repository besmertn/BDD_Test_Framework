using System.Collections.Generic;
using BDD_Test_Framework.Factories;
using OpenQA.Selenium;

namespace BDD_Test_Framework.Pages
{
    /// <summary>
    /// Base class for implementation particular pages.
    /// </summary>
    public abstract class BasePage
    {
        public RetryPolicyFactory RetryPolicyFactory { get; }

        protected BasePage(IWebDriver driver, RetryPolicyFactory retryPolicyFactory)
        {
            this.PageElements = new Dictionary<string, By>();
            this.WrappedDriver = driver;
            this.RetryPolicyFactory = retryPolicyFactory;
        }

        public virtual By IFrameLocator { get; }

        public IWebDriver WrappedDriver { get; }

        /// <summary>
        /// Gets all elements that exists on the particular page.
        /// </summary>
        protected IDictionary<string, By> PageElements { get; private set; }

        /// <summary>
        /// Get 'By' identity of selected element on current page.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementType">Element type.</param>
        /// <returns>Mechanism to find element within a page.</returns>
        public By GetByForElement(string elementName, string elementType = null)
        {
            var elementFullName = $"{elementName} {elementType ?? string.Empty}";
            if (this.PageElements.TryGetValue(elementFullName.Trim(), out var elementBy))
            {
                return elementBy;
            }

            throw new NotFoundException($"Page does not contain the element '{elementName}'.");
        }
    }
}
