using System.IO;

namespace TaskTracker.UI.Services
{
    /// <summary>
    /// Static class responsible for handling data storage configuration.
    /// </summary>
    public static class DataStorageHandler
    {
        /// <summary>
        /// Gets the path to the data directory.
        /// </summary>
        public static string DataDirectoryPath { get { return "Data"; } }

        /// <summary>
        /// Gets the path to the data file.
        /// </summary>
        public static string DataFilePath { get { return DataDirectoryPath + Path.DirectorySeparatorChar + "data.txt"; } }

        /// <summary>
        /// Initializes the data storage configuration, creating necessary directories and files.
        /// </summary>
        public static void InitialDataStorageConfiguration()
        {
            // Create the data directory if it doesn't exist.
            if (!Directory.Exists(DataDirectoryPath))
                Directory.CreateDirectory(DataDirectoryPath);

            // Create the data file if it doesn't exist.
            if (!File.Exists(DataFilePath))
                File.Create(DataFilePath);
        }
    }
}
