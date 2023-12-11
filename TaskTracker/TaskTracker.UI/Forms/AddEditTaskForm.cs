using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTracker.UI.Models;
using TaskTracker.UI.Services;
using TaskTracker.UI.Globals.Constants;

namespace TaskTracker.UI.Forms
{
    public partial class AddEditTaskForm : BaseForm
    {
        ITaskTrackerRepository repo;
        TaskItem record;

        public AddEditTaskForm(ITaskTrackerRepository repo)
        {
            InitializeComponent();

            this.repo = repo;
        }

        public AddEditTaskForm(ITaskTrackerRepository repo, TaskItem record)
        {
            InitializeComponent();

            this.repo = repo;

            this.record = record;

            txtBoxTitle.Text = record.Title;
            rchTxtBoxDescription.Text = record.Description;
            dateTimePickerDueDate.Value = record.DueDate;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDueDate.Value < DateTime.Now.Subtract(TimeSpan.FromMinutes(TaskConstants.MinDueDateDifferenceMinutes)))
            {
                MessageBox.Show("The due date can't be less than " + TaskConstants.MinDueDateDifferenceMinutes + " minutes from the current date.", "Invalid DueDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (record == null)
            {
                this.record = new TaskItemBuilder()
                .WithId(repo.TaskItems.Count)
                .WithTitle(txtBoxTitle.Text)
                .WithDescription(rchTxtBoxDescription.Text)
                .WithDueDate(dateTimePickerDueDate.Value)
                .Build();

                while (repo.ContainsId(record.Id))
                    record.Id++;

                repo.TaskItems.Add(record);
            }
            else
            {
                int editionIndex = repo.GetIndexWithId(record.Id);
                if (editionIndex >= 0)
                {
                    repo.TaskItems[editionIndex] = new TaskItemBuilder()
                        .WithId(repo.TaskItems[editionIndex].Id)
                        .WithTitle(txtBoxTitle.Text)
                        .WithDescription(rchTxtBoxDescription.Text)
                        .WithDueDate(dateTimePickerDueDate.Value)
                        .Build();
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
