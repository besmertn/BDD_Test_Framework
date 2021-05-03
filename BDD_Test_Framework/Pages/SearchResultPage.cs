using System.Collections.Generic;
using BDD_Test_Framework.Extensions;
using BDD_Test_Framework.Factories;
using BDD_Test_Framework.Helpers;
using OpenQA.Selenium;

namespace BDD_Test_Framework.Pages
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver, RetryPolicyFactory retryPolicyFactory) : base(driver, retryPolicyFactory)
        {
        }

        public override By IFrameLocator => null;

        [ElementName(@"Result list")]
        public IWebElement ResultList => this.WrappedDriver
            .FindElementWithRetry(By.Id("b_results"), this.RetryPolicyFactory);

        [ElementName(@"Search field")]
        public IWebElement SearchField => this.WrappedDriver
            .FindElementWithRetry(By.Id("sb_form_q"), this.RetryPolicyFactory);

        [ElementName(@"Search Result elements")]
        public IReadOnlyCollection<IWebElement> SearchResultElements => this.WrappedDriver
            .FindElementsWithRetry(By.CssSelector("li.b_algo"), this.RetryPolicyFactory);
    }
}
