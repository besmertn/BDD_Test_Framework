using System.Collections.Generic;
using BDD_Test_Framework.Extensions;
using BDD_Test_Framework.Factories;
using BDD_Test_Framework.Helpers;
using OpenQA.Selenium;

namespace BDD_Test_Framework.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver, RetryPolicyFactory retryPolicyFactory) : base(driver, retryPolicyFactory)
        {
        }

        public override By IFrameLocator => null;

        [ElementName(@"Search field")]
        public IWebElement SearchField => this.WrappedDriver
            .FindElementWithRetry(By.Id("sb_form_q"), this.RetryPolicyFactory);

        [ElementName(@"Search button")]
        public IWebElement SearchButton => this.WrappedDriver
            .FindElementWithRetry(By.CssSelector(".search.icon.tooltip"), this.RetryPolicyFactory);

        [ElementName(@"Search Suggestion elements")]
        public IReadOnlyCollection<IWebElement> SerachSuggestionElements => this.WrappedDriver
            .FindElementsWithRetry(By.CssSelector(".sa_sg"), this.RetryPolicyFactory);
    }
}
