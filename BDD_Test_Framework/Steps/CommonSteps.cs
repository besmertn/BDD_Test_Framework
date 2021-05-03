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

        [Then(@"the ""(.*)"" (field|button) is displayed on the ""(.*)"" page")]
        public void ThenTheSerachFieldIsDisplayedOnTheSearchPage(string elementName, string elementType, string pageName)
        {
            var element = $"{elementName} {elementType ?? string.Empty}".ConvertToElement(this.GetPageInstance(pageName));
            Assert.IsTrue(element.Displayed);
        }
    }
}
