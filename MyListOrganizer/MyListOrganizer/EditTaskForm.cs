using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyListOrganizer
{
    public partial class EditTaskForm : Form
    {
        private Task _task; // Store the task to be edited

        public EditTaskForm(Task task)
        {
            InitializeComponent();
            _task = task ?? throw new ArgumentNullException(nameof(task)); // Ensure task is not null

            // Populate the form fields with the task details
            txtTaskName.Text = _task.TaskName;
            dateTimePicker.Value = _task.DueDate;
            txtNotes.Text = _task.Notes;
            comboCategory.Text = _task.Category;

            // Set priority radio buttons
            switch (_task.Priority)
            {
                case "Low":
                    radioLow.Checked = true;
                    break;
                case "Medium":
                    radioMedium.Checked = true;
                    break;
                case "High":
                    radioHigh.Checked = true;
                    break;
            }

            // Load categories into the combo box
            LoadCategories();

            // Set reminder combo box value
            if (_task.ReminderTime.HasValue)
            {
                comboReminder.SelectedItem = GetReminderString(_task.ReminderTime.Value);
            }
            else
            {
                comboReminder.SelectedItem = "No Reminder"; // Default value if no reminder is set
            }

            // Set the completion status from the checkbox
            chkCompleted.Checked = _task.IsCompleted;

            // Apply the theme to the form
            ApplyTheme(Theme.CurrentTheme);
        }

        private void LoadCategories()
        {
            // Populate the category combo box
            comboCategory.Items.Add("Work");
            comboCategory.Items.Add("Personal");

            // Set the selected category to the task's category if available
            comboCategory.SelectedItem = _task.Category;
        }

        private void ApplyTheme(Theme theme)
        {
            // Apply the current theme to the form
            theme.ApplyTheme(this);

            // Set text color based on theme
            this.ForeColor = theme.ButtonColor == Color.SpringGreen ? Color.White : Color.Black;

            // Set background color for input fields
            txtTaskName.BackColor = Color.White;
            comboCategory.BackColor = Color.White;
            txtNotes.BackColor = Color.White;
        }

        private string GetReminderString(DateTime reminderTime)
        {
            // Return a human-readable string for the reminder time
            return reminderTime switch
            {
                _ when reminderTime == _task.DueDate.AddMinutes(-5) => "5 minutes before",
                _ when reminderTime == _task.DueDate.AddMinutes(-10) => "10 minutes before",
                _ when reminderTime == _task.DueDate.AddHours(-1) => "1 hour before",
                _ when reminderTime == _task.DueDate.AddDays(-2) => "2 days before",
                _ => "No Reminder"
            };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                MessageBox.Show("Task Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboCategory.Text))
            {
                MessageBox.Show("Category is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radioLow.Checked && !radioMedium.Checked && !radioHigh.Checked)
            {
                MessageBox.Show("Please select a priority.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update task details
            _task.TaskName = txtTaskName.Text;
            _task.DueDate = dateTimePicker.Value;
            _task.Notes = txtNotes.Text;
            _task.Category = comboCategory.Text;
            _task.Priority = radioLow.Checked ? "Low" : radioMedium.Checked ? "Medium" : "High";
            _task.IsCompleted = chkCompleted.Checked;

            // Set the reminder time based on the selected option
            if (comboReminder.SelectedItem != null && comboReminder.SelectedItem.ToString() != "No Reminder")
            {
                _task.ReminderTime = comboReminder.SelectedItem.ToString() switch
                {
                    "5 minutes before" => _task.DueDate.AddMinutes(-5),
                    "10 minutes before" => _task.DueDate.AddMinutes(-10),
                    "1 hour before" => _task.DueDate.AddHours(-1),
                    "2 days before" => _task.DueDate.AddDays(-2),
                    _ => null
                };
            }
            else
            {
                _task.ReminderTime = null;
            }

            // Save updated task to the database
            DatabaseHelper dbHelper = new DatabaseHelper();
            if (dbHelper.UpdateTask(_task))
            {
                MessageBox.Show("Task updated successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update task.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Close the form without saving changes
        }
    }
}
