using System.Threading.Tasks;
using BDD_Test_Framework.Helpers;
using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Steps
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        public CommonSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [Given(@"the application is available")]
        public void GivenTheApplicationIsAvailable()
        {
            // This step is used for the readability purpose only
        }

        [When(@"the user clicks on the ""(.*)"" (field|button) on the ""(.*)"" page")]
        public async Task WhenTheUserClicksOnTheButtonOnThePage(string elementName, string elementType, string pageName)
        {
            var element = $"{elementName} {elementType ?? string.Empty}".ConvertToElement(this.GetPageInstance(pageName));
            element.Click();
            await Task.Delay(1000);
        }

        [Then(@"the ""(.*)"" (field|button|list) is displayed on the ""(.*)"" page")]
        public void ThenTheSerachFieldIsDisplayedOnTheSearchPage(string elementName, string elementType, string pageName)
        {
            var element = $"{elementName} {elementType ?? string.Empty}".ConvertToElement(this.GetPageInstance(pageName));
            Assert.IsTrue(element.Displayed);
        }
    }
}
