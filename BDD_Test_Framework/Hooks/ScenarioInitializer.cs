using System.Threading.Tasks;
using BDD_Test_Framework.Config;
using BDD_Test_Framework.Config.Readers;
using BDD_Test_Framework.Driver;
using BDD_Test_Framework.Factories;
using BDD_Test_Framework.Helpers;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Hooks
{
    [Binding]
    public class ScenarioInitializer : TechTalk.SpecFlow.Steps
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver webDriver;

        public ScenarioInitializer(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [Before(Order = 1)]
        public void CreatWebDriver()
        {
            var configManager = this.objectContainer.Resolve<ConfigurationManager>();
            var driverManagerFactory = this.objectContainer.Resolve<DriverManagerFactory>();
            var driverManager = driverManagerFactory.CreateConfiguredDriverManager();
            this.webDriver = driverManager.WebDriver;
            var javaScriptExecutionManager = new JavaScriptExecutionManager(this.webDriver);

            this.webDriver.Manage().Window.Maximize();
            this.webDriver.Manage().Timeouts().ImplicitWait = configManager.UtilityConfig.WaitInMilliseconds.Medium;
            this.webDriver.Manage().Timeouts().PageLoad = configManager.UtilityConfig.WaitInMilliseconds.Long;

            this.objectContainer.RegisterInstanceAs<IWebDriver>(this.webDriver);
            this.objectContainer.RegisterInstanceAs<DriverManager>(driverManager);
            this.objectContainer.RegisterInstanceAs<JavaScriptExecutionManager>(javaScriptExecutionManager);
        }

        [Before(Order = 2)]
        public void DeleteAlLCookies()
        {
            this.webDriver.Manage().Cookies.DeleteAllCookies();
        }

        [Before(Order = 3)]
        public async Task NavigateToBaseUrl()
        {
            this.webDriver.Navigate().GoToUrl(this.objectContainer.Resolve<UtilityConfigReader>().BaseUrl);
            await Task.Delay(1000);
            this.webDriver.Navigate().Refresh();
        }

        [After(Order = 1)]
        public void CloseWebDriver()
        {
            // Correctly close the webdriver instance using its driver manager
            var driverManager = this.objectContainer.Resolve<DriverManager>();
            driverManager.QuitWebDriver();
        }
    }
}
