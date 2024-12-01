namespace MyListOrganizer
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnWorkTasks;
        private Button btnPersonalTasks;
        private Button btnCreateTask;
        private Panel panelTasks;
        private Label lblTodayReminder;
        private ListView listViewTasks;
        private MonthCalendar monthCalendar;
        private Panel panelDateTasks;
        private Label lblTaskListTitle;
        private Button btnViewAllTasks;
        private Button btnEditTask;
        private Button btnDeleteTask;
        private ComboBox comboTheme;
        private Label label2;
        private Label lblWelcome;
        private Label lblSearch;
        private TextBox txtSearch; // Search TextBox for filtering tasks
        private Label lblReminder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnWorkTasks = new Button();
            btnPersonalTasks = new Button();
            btnCreateTask = new Button();
            panelTasks = new Panel();
            lblReminder = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            lblTodayReminder = new Label();
            listViewTasks = new ListView();
            monthCalendar = new MonthCalendar();
            panelDateTasks = new Panel();
            lblTaskListTitle = new Label();
            btnViewAllTasks = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            comboTheme = new ComboBox();
            label2 = new Label();
            lblWelcome = new Label();
            panelTasks.SuspendLayout();
            SuspendLayout();
            // 
            // btnWorkTasks
            // 
            btnWorkTasks.BackColor = Color.FromArgb(100, 149, 237);
            btnWorkTasks.FlatStyle = FlatStyle.Flat;
            btnWorkTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnWorkTasks.Location = new Point(54, 311);
            btnWorkTasks.Name = "btnWorkTasks";
            btnWorkTasks.Size = new Size(180, 78);
            btnWorkTasks.TabIndex = 1;
            btnWorkTasks.Text = "Work Tasks";
            btnWorkTasks.UseVisualStyleBackColor = false;
            btnWorkTasks.Click += btnWorkTasks_Click;
            // 
            // btnPersonalTasks
            // 
            btnPersonalTasks.BackColor = Color.FromArgb(255, 160, 122);
            btnPersonalTasks.FlatStyle = FlatStyle.Flat;
            btnPersonalTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPersonalTasks.Location = new Point(54, 438);
            btnPersonalTasks.Name = "btnPersonalTasks";
            btnPersonalTasks.Size = new Size(180, 76);
            btnPersonalTasks.TabIndex = 3;
            btnPersonalTasks.Text = "Personal Tasks";
            btnPersonalTasks.UseVisualStyleBackColor = false;
            btnPersonalTasks.Click += btnPersonalTasks_Click;
            // 
            // btnCreateTask
            // 
            btnCreateTask.BackColor = Color.LightSkyBlue;
            btnCreateTask.FlatStyle = FlatStyle.Flat;
            btnCreateTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCreateTask.Location = new Point(416, 818);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(180, 60);
            btnCreateTask.TabIndex = 4;
            btnCreateTask.Text = "Create Task";
            btnCreateTask.UseVisualStyleBackColor = false;
            btnCreateTask.Click += BtnCreateTask_Click;
            // 
            // panelTasks
            // 
            panelTasks.BackColor = Color.White;
            panelTasks.BorderStyle = BorderStyle.FixedSingle;
            panelTasks.Controls.Add(lblReminder);
            panelTasks.Controls.Add(txtSearch);
            panelTasks.Controls.Add(lblSearch);
            panelTasks.Controls.Add(lblTodayReminder);
            panelTasks.Controls.Add(listViewTasks);
            panelTasks.Location = new Point(267, 125);
            panelTasks.Name = "panelTasks";
            panelTasks.Size = new Size(919, 630);
            panelTasks.TabIndex = 5;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.BackColor = Color.Red;
            lblReminder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReminder.ForeColor = Color.White;
            lblReminder.Location = new Point(30, 59);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(132, 32);
            lblReminder.TabIndex = 9;
            lblReminder.Text = "Reminder:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(667, 36);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(230, 37);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSearch.Location = new Point(525, 36);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(140, 30);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "Search Task:";
            // 
            // lblTodayReminder
            // 
            lblTodayReminder.AutoSize = true;
            lblTodayReminder.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTodayReminder.ForeColor = Color.Black;
            lblTodayReminder.Location = new Point(30, 114);
            lblTodayReminder.Name = "lblTodayReminder";
            lblTodayReminder.Size = new Size(186, 30);
            lblTodayReminder.TabIndex = 0;
            lblTodayReminder.Text = "Tasks due today!";
            // 
            // listViewTasks
            // 
            listViewTasks.FullRowSelect = true;
            listViewTasks.GridLines = true;
            listViewTasks.Location = new Point(10, 178);
            listViewTasks.Name = "listViewTasks";
            listViewTasks.Size = new Size(896, 433);
            listViewTasks.TabIndex = 6;
            listViewTasks.UseCompatibleStateImageBehavior = false;
            listViewTasks.View = View.Details;
            // 
            // monthCalendar
            // 
            monthCalendar.BackColor = Color.WhiteSmoke;
            monthCalendar.FirstDayOfWeek = Day.Sunday;
            monthCalendar.Font = new Font("Arial", 9F, FontStyle.Bold);
            monthCalendar.ForeColor = Color.Black;
            monthCalendar.Location = new Point(1282, 126);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 7;
            monthCalendar.TitleBackColor = Color.LightSkyBlue;
            monthCalendar.TitleForeColor = Color.White;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // panelDateTasks
            // 
            panelDateTasks.BackColor = Color.WhiteSmoke;
            panelDateTasks.BorderStyle = BorderStyle.FixedSingle;
            panelDateTasks.Location = new Point(1213, 450);
            panelDateTasks.Name = "panelDateTasks";
            panelDateTasks.Size = new Size(420, 261);
            panelDateTasks.TabIndex = 8;
            // 
            // lblTaskListTitle
            // 
            lblTaskListTitle.AutoSize = true;
            lblTaskListTitle.BackColor = Color.Transparent;
            lblTaskListTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTaskListTitle.ForeColor = Color.Black;
            lblTaskListTitle.Location = new Point(1213, 409);
            lblTaskListTitle.Name = "lblTaskListTitle";
            lblTaskListTitle.Size = new Size(192, 38);
            lblTaskListTitle.TabIndex = 0;
            lblTaskListTitle.Text = "Task by Date:";
            // 
            // btnViewAllTasks
            // 
            btnViewAllTasks.BackColor = Color.FromArgb(255, 165, 0);
            btnViewAllTasks.FlatStyle = FlatStyle.Flat;
            btnViewAllTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewAllTasks.Location = new Point(54, 569);
            btnViewAllTasks.Name = "btnViewAllTasks";
            btnViewAllTasks.Size = new Size(180, 76);
            btnViewAllTasks.TabIndex = 9;
            btnViewAllTasks.Text = "View All Tasks";
            btnViewAllTasks.UseVisualStyleBackColor = false;
            btnViewAllTasks.Click += btnViewAllTasks_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.BackColor = Color.LightSkyBlue;
            btnEditTask.FlatStyle = FlatStyle.Flat;
            btnEditTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditTask.Location = new Point(637, 818);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(180, 60);
            btnEditTask.TabIndex = 11;
            btnEditTask.Text = "Update Task";
            btnEditTask.UseVisualStyleBackColor = false;
            btnEditTask.Click += BtnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.LightSkyBlue;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDeleteTask.Location = new Point(854, 818);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(180, 60);
            btnDeleteTask.TabIndex = 12;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += BtnDelete_Click;
            // 
            // comboTheme
            // 
            comboTheme.Font = new Font("Segoe UI", 11F);
            comboTheme.FormattingEnabled = true;
            comboTheme.Location = new Point(1357, 782);
            comboTheme.Name = "comboTheme";
            comboTheme.Size = new Size(237, 38);
            comboTheme.TabIndex = 13;
            comboTheme.Text = "Select Theme";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(1251, 787);
            label2.Name = "label2";
            label2.Size = new Size(97, 32);
            label2.TabIndex = 14;
            label2.Text = "Theme:";
            // 
            // lblWelcome
            // 
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(100, 23);
            lblWelcome.TabIndex = 15;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1694, 952);
            Controls.Add(label2);
            Controls.Add(comboTheme);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnEditTask);
            Controls.Add(lblTaskListTitle);
            Controls.Add(btnViewAllTasks);
            Controls.Add(panelDateTasks);
            Controls.Add(monthCalendar);
            Controls.Add(panelTasks);
            Controls.Add(btnCreateTask);
            Controls.Add(btnPersonalTasks);
            Controls.Add(btnWorkTasks);
            Controls.Add(lblWelcome);
            MaximizeBox = false;
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyList Organizer - Dashboard";
            panelTasks.ResumeLayout(false);
            panelTasks.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
