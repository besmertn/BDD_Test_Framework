using BDD_Test_Framework.Config;
using BDD_Test_Framework.Factories;
using BoDi;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Hooks
{
    [Binding]
    public class TestRunInitializer
    {
        private static IObjectContainer objectContainer;

        [BeforeTestRun(Order = 1)]
        public static void SetUpEnvironment(IObjectContainer objectContainer)
        {
            TestRunInitializer.objectContainer = objectContainer;

            var configManager = new ConfigurationManager();
            var retryPolicyFactory = new RetryPolicyFactory(configManager.UtilityConfig);
            var driverManagerFactory = new DriverManagerFactory(configManager);

            // Register all instances that can be useful in steps implementation
            objectContainer.RegisterInstanceAs<RetryPolicyFactory>(retryPolicyFactory);
            objectContainer.RegisterInstanceAs<ConfigurationManager>(configManager);
            objectContainer.RegisterInstanceAs<DriverManagerFactory>(driverManagerFactory);
        }
    }
}