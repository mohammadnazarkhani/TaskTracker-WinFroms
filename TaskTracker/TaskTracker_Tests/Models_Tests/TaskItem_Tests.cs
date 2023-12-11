using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTracker.UI.Models;
using TaskTracker.UI.Globals.Constants;

namespace TaskTracker_Tests.Models_Tests
{
    [TestClass]
    public class TaskItem_Tests
    {
        // ... [ClassInitialize], [ClassCleanup], [TestInitialize], [TestCleanup] and other attributes ...

        [TestMethod]
        public void TaskItem_Creation_Populates_All_Properties()
        {
            // Arrange
            DateTime dueDate = DateTime.Now;
            TaskItem task;

            // Act
            task = new TaskItem(1, "title", "description", dueDate);

            // Assert
            Assert.AreEqual(task.Id, 1);
            Assert.AreEqual(task.Title, "title");
            Assert.AreEqual(task.Description, "description");
            Assert.AreEqual(task.DueDate, dueDate);
        }

        [TestMethod]
        public void TaskItem_ToString_Returns_Correct_CSV_Formatted_String()
        {
            // Arrange
            DateTime dueDate = DateTime.Now;
            var task = new TaskItem(1, "title", "description", dueDate);

            // Act
            string csvRepresentation = task.ToString();

            // Assert
            Assert.AreEqual(string.Format("1,title,description,{0}", dueDate), csvRepresentation);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TaskItem_Creation_Throws_Exception_On_Negative_Id_Value()
        {
            // Arrange
            int negativeId = -1;
            string title = "title";
            string description = "description";
            DateTime dueDate = DateTime.Now;

            // Act
            var task = new TaskItem(negativeId, title, description, dueDate);

            // The test should throw an InvalidOperationException, if it does, the test should pass.
        }

        [TestMethod]
        public void TaskItem_Comparation_Returns_Correct_Result_Based_On_TaskItems_DueDate()
        {
            // Arrange
            int id = 1;
            string title = "title";
            string description = "description";
            DateTime lowerDueDate = DateTime.Now;
            DateTime upperDueDate = lowerDueDate.AddMilliseconds(1);
            var smallerTask = new TaskItem(id, title, description, lowerDueDate);
            var biggerTask = new TaskItem(id, title, description, upperDueDate);

            // Act
            int result = smallerTask.CompareTo(biggerTask);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
