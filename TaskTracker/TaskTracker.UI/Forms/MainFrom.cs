using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskTracker.UI.Models;
using TaskTracker.UI.Services;

namespace TaskTracker.UI.Forms
{
    public partial class MainFrom : BaseForm
    {
        public MainFrom()
        {
            InitializeComponent();
            PopulateListBoxItemsFromRepo();
        }

        private void PopulateListBoxItemsFromRepo()
        {
            IEnumerable<string> items =
                from value in TaskTrackerRepository.That().TaskItems
                orderby value.DueDate
                select value.Title;

            this.listBoxTasks.Items.Clear();
            this.listBoxTasks.Items.AddRange(items.ToArray());
        }

        private TaskItem GetRepoSelectedTask(int id)
        {
            IEnumerable<TaskItem> tasks =
                from value in TaskTrackerRepository.That().TaskItems
                orderby value.DueDate
                select value;

            return tasks.ToList()[id];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditTaskForm add = new AddEditTaskForm(TaskTrackerRepository.That());
            add.ShowDialog();
            PopulateListBoxItemsFromRepo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                int selectedIndex = listBoxTasks.SelectedIndex;

                AddEditTaskForm edit = new AddEditTaskForm(TaskTrackerRepository.That(), GetRepoSelectedTask(selectedIndex));
                edit.ShowDialog();
                PopulateListBoxItemsFromRepo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                int selectedIndex = listBoxTasks.SelectedIndex;
                TaskItem selectedTask = GetRepoSelectedTask(selectedIndex);

                DialogResult result;
                string messageText = "Are you sure you want to delete the " + selectedTask.Title + " task?";
                string caption = "Delete a Task";
                result = MessageBox.Show(messageText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    TaskTrackerRepository.That().TaskItems.Remove(selectedTask);
                    PopulateListBoxItemsFromRepo();
                }
            }
        }

        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            RepositoryHandler repoHandler = new RepositoryHandler();
            repoHandler.SaveRepository();
        }
    }
}
