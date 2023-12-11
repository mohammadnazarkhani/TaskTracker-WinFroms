using TaskTracker.UI.Services;

namespace TaskTracker.UI.Services
{
    /// <summary>
    /// Configurator class responsible for initializing the application.
    /// </summary>
    public class AppConfigurator
    {
        /// <summary>
        /// Performs the initial configuration of the application.
        /// </summary>
        public void InitialConfigruation()
        {
            // Initialize the data storage configuration.
            DataStorageHandler.InitialDataStorageConfiguration();

            // Create an instance of RepositoryHandler and populate the repository.
            var repoHandler = new RepositoryHandler();
            repoHandler.PopulateRepository();
        }
    }
}
