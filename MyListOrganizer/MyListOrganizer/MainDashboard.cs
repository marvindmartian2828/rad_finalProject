using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyListOrganizer
{
    public partial class MainDashboard : Form
    {
        private List<Task> tasks;
        private DatabaseHelper dbHelper;
        private BindingSource bindingSource;
        private readonly Dictionary<string, Theme> themes = new Dictionary<string, Theme>();
        private System.Windows.Forms.Timer reminderTimer;

        public MainDashboard()
        {
            InitializeComponent();

            tasks = new List<Task>();
            dbHelper = new DatabaseHelper();
            bindingSource = new BindingSource();
            LoadTasksFromDatabase();
            SetupListView();
            UpdateTodayReminder();
            SetupThemes();
            InitializeThemeComboBox();
            ApplyTheme("Select Theme");
            InitializeMonthCalendar();

            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 60000;
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();

            listViewTasks.ColumnClick += listViewTasks_ColumnClick;
            this.FormClosing += MainDashboard_FormClosing;
        }

        // Sort tasks based on the clicked column
        private void listViewTasks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortOrder sortOrder = listViewTasks.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listViewTasks.ListViewItemSorter = new ListViewItemComparer(e.Column, sortOrder);
            listViewTasks.Sorting = sortOrder;
        }

        // Custom comparer for sorting ListView columns
        public class ListViewItemComparer : IComparer
        {
            private int columnIndex;
            private SortOrder sortOrder;

            public ListViewItemComparer(int columnIndex, SortOrder sortOrder)
            {
                this.columnIndex = columnIndex;
                this.sortOrder = sortOrder;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                if (itemX == null || itemY == null) return 0;

                string textX = itemX.SubItems[columnIndex].Text;
                string textY = itemY.SubItems[columnIndex].Text;

                if (columnIndex == 3)
                {
                    int priorityX = GetPriorityValue(textX);
                    int priorityY = GetPriorityValue(textY);
                    int result = priorityX.CompareTo(priorityY);
                    return sortOrder == SortOrder.Descending ? -result : result;
                }
                else
                {
                    int result = string.Compare(textX, textY);
                    return sortOrder == SortOrder.Descending ? -result : result;
                }
            }

            private int GetPriorityValue(string priority)
            {
                return priority switch
                {
                    "Low" => 0,
                    "Medium" => 1,
                    "High" => 2,
                    _ => 0,
                };
            }
        }

        // Timer tick event to check task reminders
        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            CheckTaskReminders();
        }

        // Check if any task reminders are due
        private void CheckTaskReminders()
        {
            var tasks = dbHelper.GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.ReminderTime.HasValue && task.ReminderTime.Value <= DateTime.Now)
                {
                    ShowReminderNotification(task);
                }
            }
        }

        // Show reminder notification
        private void ShowReminderNotification(Task task)
        {
            string formattedDueDate = task.DueDate.ToString("MMMM dd, yyyy hh:mm tt");
            MessageBox.Show($"Reminder: {task.TaskName} is due at {formattedDueDate}.", "Task Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Stop the reminder timer when the form is closing
        private void MainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            reminderTimer.Stop();
        }

        // Set up themes
        private void SetupThemes()
        {
            themes.Add("Select Theme", new Theme(null, Color.LightGray, Color.Black, null, null, null));
            themes.Add("Winter", new Theme(GetImage("mainwinter.png"), Color.CadetBlue, Color.White, GetImage("addwinter.png"), GetImage("editwinter.png"), GetImage("noteswinter.png")));
            themes.Add("Spring", new Theme(GetImage("mainspring.png"), Color.Honeydew, Color.Black, GetImage("addspring.png"), GetImage("editspring.png"), GetImage("notesspring.png")));
            themes.Add("Summer", new Theme(GetImage("mainsummer.png"), Color.SteelBlue, Color.White, GetImage("addsummer.png"), GetImage("editsummer.png"), GetImage("notessummer.png")));
            themes.Add("Fall", new Theme(GetImage("mainfall.png"), Color.Coral, Color.White, GetImage("addfall.png"), GetImage("editfall.png"), GetImage("notesfall.png")));
        }

        // Helper method to get images from resources
        private static Image GetImage(string fileName)
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string resourceName = $"MyListOrganizer.Images.{fileName}";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        return Image.FromStream(stream);
                    }
                    else
                    {
                        MessageBox.Show($"Image file '{fileName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new Bitmap(1, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image '{fileName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Bitmap(1, 1);
            }
        }

        // Initialize theme combo box
        private void InitializeThemeComboBox()
        {
            comboTheme.Items.Clear();
            comboTheme.Items.AddRange(themes.Keys.ToArray());

            if (comboTheme.Items.Count > 0)
            {
                comboTheme.SelectedIndex = 0;
            }

            comboTheme.SelectedIndexChanged += ComboTheme_SelectedIndexChanged;
        }

        // Apply selected theme
        private void ComboTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTheme = comboTheme.SelectedItem?.ToString();
            ApplyTheme(selectedTheme);
        }

        // Apply the theme to the form
        public void ApplyTheme(string themeName)
        {
            if (themeName == "Select Theme" || string.IsNullOrEmpty(themeName))
            {
                ResetToDefaultTheme();
            }
            else if (themes.TryGetValue(themeName, out Theme theme))
            {
                theme.ApplyTheme(this);
                Theme.SetCurrentTheme(theme);

                panelTasks.BackColor = theme.ButtonColor;
                lblReminder.ForeColor = theme.ButtonTextColor;
                lblReminder.BackColor = Color.Firebrick;
                lblTodayReminder.ForeColor = theme.ButtonTextColor;
                panelDateTasks.BackColor = theme.ButtonColor;

                foreach (Control control in this.Controls)
                {
                    if (control is Button button)
                    {
                        button.BackColor = theme.ButtonColor;
                        button.ForeColor = theme.ButtonTextColor;
                        button.Enabled = true;
                    }
                }

                this.BackgroundImage = theme.MainDashboardBackground;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show($"Theme '{themeName}' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reset to default theme
        private void ResetToDefaultTheme()
        {
            this.BackgroundImage = null;
            panelTasks.BackColor = Color.LightGray;
            lblReminder.BackColor = Color.LightGray;
            lblTodayReminder.ForeColor = Color.Black;

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.LightGray;
                    button.ForeColor = Color.Black;
                    button.Enabled = true;
                }
            }

            this.Refresh();
        }

        // Load tasks from the database and display them
        private void LoadTasksFromDatabase()
        {
            tasks = dbHelper.GetAllTasks();
            bindingSource.DataSource = tasks;
            LoadTasks("All");
        }

        // Set up ListView columns
        private void SetupListView()
        {
            listViewTasks.Columns.Clear();
            listViewTasks.Columns.Add("Task Name", 300);
            listViewTasks.Columns.Add("Due Date", 120);
            listViewTasks.Columns.Add("Category", 100);
            listViewTasks.Columns.Add("Priority", 90);
            listViewTasks.Columns.Add("Completed", 110);
            listViewTasks.Columns.Add("Action", 175);
            listViewTasks.View = View.Details;
            listViewTasks.FullRowSelect = true;
            listViewTasks.MouseClick += listViewTasks_MouseClick;
        }

        // Update today reminder label
        private void UpdateTodayReminder()
        {
            var todayTasks = tasks.Where(t => t.DueDate.Date == DateTime.Now.Date).ToList();
            lblTodayReminder.Text = todayTasks.Any() ? $"Tasks due today: {string.Join(", ", todayTasks.Select(t => t.TaskName))}" : "No tasks due today.";
        }

        // Handle button click for "Work" tasks
        private void btnWorkTasks_Click(object sender, EventArgs e) => LoadTasks("Work");

        // Handle button click for "Personal" tasks
        private void btnPersonalTasks_Click(object sender, EventArgs e) => LoadTasks("Personal");

        // Handle button click to view all tasks
        private void btnViewAllTasks_Click(object sender, EventArgs e) => LoadTasks("All");

        // Filter tasks based on category and search
        private void LoadTasks(string category)
        {
            listViewTasks.Items.Clear();

            var filteredTasks = tasks.AsQueryable().Where(t =>
                (category == "All" || t.Category == category) &&
                (string.IsNullOrEmpty(txtSearch.Text) || t.TaskName.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            foreach (var task in filteredTasks)
            {
                var listItem = new ListViewItem(new[] {
                    task.TaskName,
                    task.DueDate.ToShortDateString(),
                    task.Category,
                    task.Priority,
                    task.IsCompleted ? "Yes" : "No",
                    "Click to View Notes"
                })
                {
                    Tag = task
                };

                listViewTasks.Items.Add(listItem);
            }

            UpdateTodayReminder();
        }

        // Search tasks as text is typed
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTasks("All");
        }

        // Handle mouse click event on ListView to view task notes
        private void listViewTasks_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItems.Count > 0)
            {
                var selectedItem = listView.SelectedItems[0];
                if (selectedItem != null)
                {
                    if (e.X >= selectedItem.SubItems[5].Bounds.Left && e.X <= selectedItem.SubItems[5].Bounds.Right &&
                        e.Y >= selectedItem.Bounds.Top && e.Y <= selectedItem.Bounds.Bottom)
                    {
                        var task = selectedItem.Tag as Task;
                        ShowNotes(task);
                    }
                }
            }
        }

        // Show task notes in a new form
        private void ShowNotes(Task task)
        {
            if (task != null)
            {
                var notesForm = new NotesForm(task);
                notesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Task is null. Unable to display notes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle edit task button click
        private void BtnEditTask_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                var task = selectedItem.Tag as Task;

                if (task != null)
                {
                    using (var editTaskForm = new EditTaskForm(task))
                    {
                        if (editTaskForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadTasksFromDatabase();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selected task is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle delete task button click
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                var task = selectedItem.Tag as Task;

                if (task != null)
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        if (dbHelper.DeleteTask(task.TaskID))
                        {
                            MessageBox.Show("Task deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTasksFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Error deleting task. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selected task is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle month calendar date change
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadTasksByDate(monthCalendar.SelectionStart);
        }

        // Display tasks for the selected date
        private void LoadTasksByDate(DateTime selectedDate)
        {
            panelDateTasks.Controls.Clear();
            lblTaskListTitle.Visible = true;

            ListView listViewCalendarTasks = new ListView
            {
                Location = new Point(10, 20),
                Size = new Size(400, 220),
                View = View.Details
            };
            listViewCalendarTasks.Columns.Add("Task Name", 275);
            listViewCalendarTasks.Columns.Add("Due Date", 120);
            panelDateTasks.Controls.Add(listViewCalendarTasks);

            var dueTasks = tasks.Where(t => t.DueDate.Date == selectedDate.Date).ToList();
            foreach (var task in dueTasks)
            {
                ListViewItem item = new ListViewItem(task.TaskName);
                item.SubItems.Add(task.DueDate.ToShortDateString());
                listViewCalendarTasks.Items.Add(item);
            }

            if (!dueTasks.Any())
            {
                listViewCalendarTasks.Items.Add(new ListViewItem("No tasks due on this date."));
            }
        }

        // Handle create task button click
        private void BtnCreateTask_Click(object sender, EventArgs e)
        {
            TaskCreationForm taskCreationForm = new TaskCreationForm(LoadTasksFromDatabase);
            taskCreationForm.ShowDialog();
        }

        // Initialize MonthCalendar properties
        private void InitializeMonthCalendar()
        {
            monthCalendar.BackColor = Color.WhiteSmoke;
            monthCalendar.ForeColor = Color.Black;
            monthCalendar.TitleBackColor = Color.LightSkyBlue;
            monthCalendar.TitleForeColor = Color.White;
            monthCalendar.FirstDayOfWeek = Day.Sunday;

            monthCalendar.DateSelected += MonthCalendar_DateSelected;
            monthCalendar.ShowToday = true;
            monthCalendar.ShowTodayCircle = true;
        }

        // Change MonthCalendar background on date selection
        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.BackColor = Color.LightCyan;
        }
    }
}
