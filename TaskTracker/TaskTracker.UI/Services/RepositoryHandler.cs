using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.UI.Models;
using TaskTracker.UI.Utilities;

namespace TaskTracker.UI.Services
{
    /// <summary>
    /// Class responsible for handling the iteraction between the TaskTrackerRepository and FileHandler
    /// </summary>
    public class RepositoryHandler
    {
        /// <summary>
        /// Saves the TaskTrackerRepository data to a file using the FileHandler.
        /// </summary>
        public void SaveRepository()
        {
            FileHandler handler = new FileHandler();
            handler.SaveData(TaskTrackerRepository.That());
        }

        /// <summary>
        /// Populates the TaskTrackerRepository with data from a file using the FileHandler and CsvParser.
        /// </summary>
        public void PopulateRepository()
        {
            FileHandler handler = new FileHandler();

            // Using LINQ to convert each string value form the file to a TaskItem and populate the repository
            var convertToRepo =
                from value in handler.GetData()
                select new CsvParser<TaskItem>().Parse(value);

            TaskTrackerRepository.That().TaskItems = convertToRepo.ToList();
        }
    }
}
