using BDD_Test_Framework.Config;
using BDD_Test_Framework.Driver;

namespace BDD_Test_Framework.Factories
{
    /// <summary>
    /// Factory to create driver manager of chosen web driver type.
    /// </summary>
    public class DriverManagerFactory
    {
        private readonly ConfigurationManager configManager;

        public DriverManagerFactory(ConfigurationManager configManager)
        {
            this.configManager = configManager;
        }

        /// <summary>
        /// Create driver manager.
        /// </summary>
        /// <returns>Driver manager for configured as chosen driver type.</returns>
        public DriverManager CreateConfiguredDriverManager()
        {
            var configuredDriverType = this.configManager.UtilityConfig.SelectedDriverByDefault;
            return this.CreateDriverManager(configuredDriverType);
        }

        /// <summary>
        /// Create driver manager.
        /// </summary>
        /// <param name="driverType">Web driver type to be encapsulated into Driver Manager.</param>
        /// <returns>Driver manager for chosen driver type.</returns>
        public DriverManager CreateDriverManager(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.GoogleChrome:
                    {
                        return new DriverManager(
                            DriverTypes.DriverTypesDictionary[DriverType.GoogleChrome],
                            this.configManager.DriverConfig);
                    }

                case DriverType.Firefox:
                    {
                        return new DriverManager(
                            DriverTypes.DriverTypesDictionary[DriverType.Firefox],
                            this.configManager.DriverConfig);
                    }

                case DriverType.InternetExplorer:
                    {
                        return new DriverManager(
                            DriverTypes.DriverTypesDictionary[DriverType.InternetExplorer],
                            this.configManager.DriverConfig);
                    }

                default:
                    {
                        return new DriverManager(
                            DriverTypes.DriverTypesDictionary[DriverType.InternetExplorer],
                            this.configManager.DriverConfig);
                    }
            }
        }
    }
}
