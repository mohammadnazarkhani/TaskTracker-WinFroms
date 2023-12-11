using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTracker.UI.Models;
using TaskTracker.UI.Utilities;

namespace TaskTracker_Tests.Utilities_Tests
{
    /// <summary>
    /// Summary description for CsvParser_Tests
    /// </summary>
    [TestClass]
    public class CsvParser_Tests
    {
        [TestMethod]
        public void Parse_Populates_Values()
        {
            // Arrange
            int id = 1;
            string title = "title";
            string description = "description";
            DateTime dueDate = DateTime.Now;
            var csv = string.Format("{0},{1},{2},{3}", id, title, description, dueDate);
            var taskItem = new TaskItem();
            var parser = new CsvParser<TaskItem>();

            // Act
            taskItem = parser.Parse(csv);

            // Assert
            Assert.AreEqual(id, taskItem.Id);
            Assert.AreEqual(title, taskItem.Title);
            Assert.AreEqual(description, taskItem.Description);
            TimeSpan tolerance = TimeSpan.FromSeconds(1);
            Assert.IsTrue((taskItem.DueDate - dueDate).Duration() <= tolerance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_Invalid_Csv_Throws_Exception()
        {
            // Arrange
            int id = 1;
            string title = "title";
            string description = "description";
            DateTime dueDate = DateTime.Now;
            var csv = string.Format("{0},{1},{2}", id, title, description);
            var parser = new CsvParser<TaskItem>();

            // Act
            parser.Parse(csv);

            // This should throw a ArgumentException, if it does, then the test passes
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parser_Passing_Empty_String_Throws_Exception()
        {
            var csv = string.Empty;
            var parser = new CsvParser<TaskItem>();

            // Act
            parser.Parse(csv);

            // This should throw a ArgumentNullException, if it does, then the test passes
        }
    }
}
