using System.Collections.Generic;
using TaskTracker.UI.Models;

namespace TaskTracker.UI.Models
{
    /// <summary>
    /// Singleton repository for managing TaskItem instances in the TaskTracker application.
    /// </summary>
    public class TaskTrackerRepository : ITaskTrackerRepository
    {
        private static TaskTrackerRepository instance;

        /// <summary>
        /// Gets or sets the list of TaskItems stored in the repository.
        /// </summary>
        public List<TaskItem> TaskItems { get; set; }

        /// <summary>
        /// Private constructor to prevent external instantiation.
        /// </summary>
        private TaskTrackerRepository()
        {
            // Initialize the TaskItems list, or perform any necessary setup.
        }

        /// <summary>
        /// Retrieves the singleton instance of the TaskTrackerRepository.
        /// </summary>
        /// <returns>The singleton instance of TaskTrackerRepository.</returns>
        public static TaskTrackerRepository That()
        {
            if (instance == null)
                instance = new TaskTrackerRepository();

            return instance;
        }

        /// <summary>
        /// Checks if the repository contains a TaskItem with the specified ID.
        /// </summary>
        /// <param name="id">The ID to check for in the repository.</param>
        /// <returns>True if a TaskItem with the specified ID exists; otherwise, false.</returns>
        public bool ContainsId(int id)
        {
            foreach (var item in TaskItems)
                if (item.Id == id)
                    return true;

            return false;
        }

        /// <summary>
        /// Retrieves a TaskItem with the specified ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the TaskItem to retrieve.</param>
        /// <returns>The TaskItem with the specified ID, or null if not found.</returns>
        public int GetIndexWithId(int id)
        {
            for (int i = 0; i < TaskItems.Count; i++)
                if (TaskItems[i].Id == id)
                    return i;

            return -1;
        }
    }
}
