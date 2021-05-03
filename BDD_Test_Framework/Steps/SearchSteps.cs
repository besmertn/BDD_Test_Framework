using BDD_Test_Framework.Pages;
using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Steps
{
    [Binding]
    public class SearchSteps : BaseSteps
    {
        private SearchPage SearchPage => (SearchPage)this.Page;

        public SearchSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
            this.PageName = PagesNaming.SearchPage;
        }

        [Given(@"the user is on the Search page")]
        [When(@"the user opens the Search page")]
        public void WhenTheUserOpensTheSearchPage()
        {
            // This step is used for the readability purpose only
        }

        [Given(@"the search field containt the ""(.*)"" text")]
        [When(@"the user types ""(.*)"" text in the Search field")]
        public void WhenTheUserTypesTextInTheSearchField(string text)
        {
            SearchPage.SearchField.SendKeys(text);
        }


        [Then(@"""(.*)"" search suggestions are displayed on the Search page")]
        public void ThenSearchSuggestionsAreDisplayedOnTheSearchPage(int expectedAmount)
        {
            Assert.AreEqual(expectedAmount, SearchPage.SerachSuggestionElements.Count);
            foreach(var element in SearchPage.SerachSuggestionElements)
            {
                Assert.IsTrue(element.Displayed);
            }
        }

        [Then(@"all search suggestions started from the text ""(.*)""")]
        public void ThenAllSearchSuggestionsStartedFromTheText(string expectedText)
        {
            foreach (var element in SearchPage.SerachSuggestionElements)
            {
                Assert.IsTrue(element.Text.StartsWith(expectedText));
            }
        }

    }
}
