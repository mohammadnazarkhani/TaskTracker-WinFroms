using System;
using System.Collections.Generic;

namespace TaskTracker.UI.Models
{
    /// <summary>
    /// Represents an interface for the TaskTracker repository in the TaskTracker application.
    /// </summary>
    /// <remarks>
    /// Implement this interface to define the contract for interacting with the TaskTracker repository.
    /// The repository is responsible for managing and providing access to TaskItem instances.
    /// </remarks>
    public interface ITaskTrackerRepository
    {
        /// <summary>
        /// Gets or sets the list of TaskItems in the repository.
        /// </summary>
        List<TaskItem> TaskItems { get; set; }

        /// <summary>
        /// Checks whether the repository contains a TaskItem with the specified ID.
        /// </summary>
        /// <param name="id">The ID to check for.</param>
        /// <returns>True if the repository contains a TaskItem with the specified ID; otherwise, false.</returns>
        bool ContainsId(int id);

        /// <summary>
        /// Gets the TaskItem with the specified ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the TaskItem to retrieve.</param>
        /// <returns>The TaskItem with the specified ID, or null if not found.</returns>
        int GetIndexWithId(int id);
    }
}
