using System;
using TaskTracker.UI.Globals.Constants;

namespace TaskTracker.UI.Models
{
    /// <summary>
    /// Represents a task item in the TaskTracker application.
    /// </summary>
    /// <remarks>
    /// This class implements the IRecord interface and is comparable based on the DueDate property.
    /// </remarks>
    public class TaskItem : IComparable<TaskItem>, IRecord
    {
        private int id;

        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if a negative value is set as the ID.</exception>
        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("You can't pass a negative value as the ID.");

                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date of the task.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the due date is set to a value less than a specified minimum difference from the current date.
        /// </exception>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Initializes a new instance of the TaskItem class.
        /// </summary>
        public TaskItem()
        {
            // Default constructor.
        }

        /// <summary>
        /// Initializes a new instance of the TaskItem class with specified values.
        /// </summary>
        /// <param name="id">The unique identifier for the task.</param>
        /// <param name="title">The title of the task.</param>
        /// <param name="description">The description of the task.</param>
        /// <param name="dueDate">The due date of the task.</param>
        public TaskItem(int id, string title, string description, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
        }

        /// <summary>
        /// Returns a string representation of the TaskItem.
        /// </summary>
        public override string ToString()
        {
            object[] values = { Id, Title, Description, DueDate };
            string stRepresentation = string.Format("{0},{1},{2},{3}", values);

            return stRepresentation;
        }

        /// <summary>
        /// Compares the current instance with another TaskItem based on their due dates.
        /// </summary>
        /// <param name="other">The TaskItem to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared.
        /// </returns>
        public int CompareTo(TaskItem other)
        {
            return this.DueDate.CompareTo(other.DueDate);
        }
    }
}
