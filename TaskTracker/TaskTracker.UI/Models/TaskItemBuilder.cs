using System;
using TaskTracker.UI.Models;

namespace TaskTracker.UI.Models
{
    /// <summary>
    /// Builder class for creating instances of the TaskItem class with specific properties.
    /// </summary>
    public class TaskItemBuilder
    {
        private TaskItem taskItem;

        /// <summary>
        /// Initializes a new instance of the TaskItemBuilder class.
        /// </summary>
        public TaskItemBuilder()
        {
            taskItem = new TaskItem();
        }

        /// <summary>
        /// Sets the unique identifier for the task.
        /// </summary>
        /// <param name="id">The unique identifier for the task.</param>
        /// <returns>The current instance of TaskItemBuilder for method chaining.</returns>
        public TaskItemBuilder WithId(int id)
        {
            taskItem.Id = id;
            return this;
        }

        /// <summary>
        /// Sets the title for the task.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        /// <returns>The current instance of TaskItemBuilder for method chaining.</returns>
        public TaskItemBuilder WithTitle(string title)
        {
            taskItem.Title = title;
            return this;
        }

        /// <summary>
        /// Sets the description for the task.
        /// </summary>
        /// <param name="description">The description of the task.</param>
        /// <returns>The current instance of TaskItemBuilder for method chaining.</returns>
        public TaskItemBuilder WithDescription(string description)
        {
            taskItem.Description = description;
            return this;
        }

        /// <summary>
        /// Sets the due date for the task.
        /// </summary>
        /// <param name="dueDate">The due date of the task.</param>
        /// <returns>The current instance of TaskItemBuilder for method chaining.</returns>
        public TaskItemBuilder WithDueDate(DateTime dueDate)
        {
            taskItem.DueDate = dueDate;
            return this;
        }

        /// <summary>
        /// Builds and returns the TaskItem with the specified properties.
        /// </summary>
        /// <returns>An instance of TaskItem with the specified properties.</returns>
        public TaskItem Build()
        {
            return taskItem;
        }
    }
}
