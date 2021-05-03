using BDD_Test_Framework.Pages;
using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Steps
{
    [Binding]
    public class SearchResultSteps : BaseSteps
    {
        private SearchResultPage SearchResultPage => (SearchResultPage)this.Page;

        public SearchResultSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
            this.PageName = PagesNaming.SearchResultPage;
        }

        [Then(@"""(.*)"" search results are displayed on the Search Result page")]
        public void ThenSearchResultsAreDisplayedOnTheSearchResultPage(int expectedAmount)
        {
            Assert.AreEqual(expectedAmount, SearchResultPage.SearchResultElements.Count);
            foreach (var element in SearchResultPage.SearchResultElements)
            {
                Assert.IsTrue(element.Displayed);
            }
        }
    }
}
