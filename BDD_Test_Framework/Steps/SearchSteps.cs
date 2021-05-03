using BDD_Test_Framework.Pages;
using BoDi;
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

        [When(@"the user opens the Search page")]
        public void WhenTheUserOpensTheSearchPage()
        {
            // This step is used for the readability purpose only
        }
    }
}
