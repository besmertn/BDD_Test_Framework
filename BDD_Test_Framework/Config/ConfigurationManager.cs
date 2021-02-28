using BDD_Test_Framework.Config.Readers;

namespace BDD_Test_Framework.Config
{
    /// <summary>
    /// Unit of all configuration readers. Gives user opportunity to read configuration settings.
    /// </summary>
    public class ConfigurationManager
    {
        private DriverConfigReader driverConfigReader;
        private UtilityConfigReader utilityConfigReader;

        public DriverConfigReader DriverConfig => this.driverConfigReader ??= new DriverConfigReader();

        public UtilityConfigReader UtilityConfig => this.utilityConfigReader ??= new UtilityConfigReader();
    }
}
