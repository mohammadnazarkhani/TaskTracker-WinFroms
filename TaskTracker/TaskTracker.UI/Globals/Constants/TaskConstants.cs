using System;

namespace TaskTracker.UI.Globals.Constants
{
    /// <summary>
    /// Contains constants related to tasks in the TaskTracker application.
    /// </summary>
    public class TaskConstants
    {
        /// <summary>
        /// The minimum allowed difference (in minutes) between the due date of a task
        /// and the current date and time.
        /// </summary>
        /// <remarks>
        /// Tasks with due dates less than this minimum difference are considered invalid.
        /// Adjust this value according to the specific requirements of the TaskTracker application.
        /// </remarks>
        public const short MinDueDateDifferenceMinutes = 10;
    }
}
