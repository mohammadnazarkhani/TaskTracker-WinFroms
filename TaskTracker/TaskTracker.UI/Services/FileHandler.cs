using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaskTracker.UI.Models;

namespace TaskTracker.UI.Services
{
    /// <summary>
    /// Class responsible for handling file operations related to task data.
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Saves task data from the given repository to a file.
        /// </summary>
        /// <param name="repo">The repository containing task data to be saved.</param>
        public void SaveData(ITaskTrackerRepository repo)
        {
            // Using File.WriteAllLines to write each task's ToString representation as a line in the file.
            File.WriteAllLines(DataStorageHandler.DataFilePath, repo.TaskItems.Select(x => x.ToString()));
        }

        /// <summary>
        /// Reads task data from the file and returns a list of strings.
        /// </summary>
        /// <returns>A list of strings representing task data.</returns>
        public List<String> GetData()
        {
            List<string> data = new List<string>();

            // Using StreamReader to read each line from the file and add it to the list.
            using (FileStream fs = new FileStream(DataStorageHandler.DataFilePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }
            }

            return data;
        }
    }
}
