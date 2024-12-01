using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyListOrganizer
{
    public partial class TaskCreationForm : Form
    {
        private DatabaseHelper dbHelper;
        private Action onTaskCreated;
        private System.Windows.Forms.Timer reminderTimer;
        private DateTime? reminderTime;

        public TaskCreationForm(Action onTaskCreated)
        {
            InitializeComponent();
            this.onTaskCreated = onTaskCreated;
            dbHelper = new DatabaseHelper();
            LoadCategories();
            ApplyTheme(Theme.CurrentTheme);

            // Set up reminder timer to check every minute
            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 60000;
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();
        }

        private void LoadCategories()
        {
            comboBox1.Items.Add("Work");
            comboBox1.Items.Add("Personal");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            DateTime dueDate = dateTimePicker.Value;

            // Validate Task Name
            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Task Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Category selection
            string category = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Priority selection
            string priority = GetSelectedPriority();
            if (priority == "Not Specified")
            {
                MessageBox.Show("Please select a priority.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Reminder selection
            string reminder = comboReminder.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reminder) || reminder == "No Reminder")
            {
                MessageBox.Show("Please select a reminder time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string notes = txtNotes.Text; // Notes are optional
            DateTime? reminderTime = GetReminderTimeFromComboBox(dueDate);

            Task newTask = new Task
            {
                TaskName = taskName,
                DueDate = dueDate,
                Category = category,
                Notes = notes,
                Priority = priority,
                IsCompleted = false, // Default to not completed
                ReminderTime = reminderTime,
            };

            // Save task to the database
            if (dbHelper.CreateTask(newTask))
            {
                MessageBox.Show("Task created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onTaskCreated?.Invoke(); // Notify parent form
                this.Close();
            }
            else
            {
                MessageBox.Show("Error creating task. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedPriority()
        {
            if (radioLow.Checked) return "Low";
            if (radioMedium.Checked) return "Medium";
            if (radioHigh.Checked) return "High";
            return "Not Specified";
        }

        private DateTime? GetReminderTimeFromComboBox(DateTime dueDate)
        {
            var selectedReminder = comboReminder.SelectedItem?.ToString();
            if (selectedReminder == "No Reminder")
            {
                return null;
            }
            else if (selectedReminder == "5 minutes before")
            {
                return dueDate.AddMinutes(-5);
            }
            else if (selectedReminder == "10 minutes before")
            {
                return dueDate.AddMinutes(-10);
            }
            else if (selectedReminder == "1 hour before")
            {
                return dueDate.AddHours(-1);
            }
            else if (selectedReminder == "2 days before")
            {
                return dueDate.AddDays(-2);
            }

            return null;
        }

        private void ApplyTheme(Theme theme)
        {
            theme.ApplyTheme(this);
            this.ForeColor = Color.Black;
            txtTaskName.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            txtNotes.BackColor = Color.White;
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            if (reminderTime.HasValue && DateTime.Now >= reminderTime.Value)
            {
                ShowReminderNotification();
                reminderTimer.Stop(); // Stop the timer after reminder is shown
            }
        }

        private void ShowReminderNotification()
        {
            MessageBox.Show("Reminder: " + txtTaskName.Text, "Task Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form without saving
        }
    }
}
