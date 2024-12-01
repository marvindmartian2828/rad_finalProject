namespace MyListOrganizer
{
    partial class EditTaskForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTaskName;
        private Label lblDueDate;
        private Label lblCategory;
        private Label lblNotes;
        private Label lblPriority;
        private Button btnUpdate;
        private Button btnCancel;
        private TextBox txtTaskName;
        private TextBox txtNotes;
        private DateTimePicker dateTimePicker;
        private RadioButton radioLow;
        private RadioButton radioMedium;
        private RadioButton radioHigh;
        private ComboBox comboCategory;
        private Label lblReminder;
        private ComboBox comboReminder;  // New ComboBox for reminders
        private Label lblStatus;
        private CheckBox chkCompleted;

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
            lblTaskName = new Label();
            lblDueDate = new Label();
            lblCategory = new Label();
            lblNotes = new Label();
            lblPriority = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            txtTaskName = new TextBox();
            txtNotes = new TextBox();
            dateTimePicker = new DateTimePicker();
            radioLow = new RadioButton();
            radioMedium = new RadioButton();
            radioHigh = new RadioButton();
            comboCategory = new ComboBox();
            lblReminder = new Label();
            comboReminder = new ComboBox();
            lblStatus = new Label();
            chkCompleted = new CheckBox();
            SuspendLayout();
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.BackColor = Color.Transparent;
            lblTaskName.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblTaskName.Location = new Point(85, 77);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(139, 30);
            lblTaskName.TabIndex = 0;
            lblTaskName.Text = "Task Name:";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.BackColor = Color.Transparent;
            lblDueDate.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblDueDate.Location = new Point(89, 150);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(119, 30);
            lblDueDate.TabIndex = 1;
            lblDueDate.Text = "Due Date:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblCategory.Location = new Point(589, 152);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(118, 30);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.Transparent;
            lblNotes.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblNotes.Location = new Point(589, 226);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(84, 30);
            lblNotes.TabIndex = 3;
            lblNotes.Text = "Notes:";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.BackColor = Color.Transparent;
            lblPriority.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblPriority.Location = new Point(89, 220);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(104, 30);
            lblPriority.TabIndex = 4;
            lblPriority.Text = "Priority:";
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnUpdate.Location = new Point(144, 446);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(156, 46);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(339, 446);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(138, 46);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtTaskName
            // 
            txtTaskName.Font = new Font("Segoe UI", 10F);
            txtTaskName.Location = new Point(230, 77);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(699, 34);
            txtTaskName.TabIndex = 8;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(713, 226);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(216, 165);
            txtNotes.TabIndex = 9;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 10F);
            dateTimePicker.Location = new Point(230, 147);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(295, 34);
            dateTimePicker.TabIndex = 10;
            // 
            // radioLow
            // 
            radioLow.AutoSize = true;
            radioLow.BackColor = Color.Transparent;
            radioLow.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioLow.Location = new Point(228, 218);
            radioLow.Name = "radioLow";
            radioLow.Size = new Size(75, 32);
            radioLow.TabIndex = 11;
            radioLow.TabStop = true;
            radioLow.Text = "Low";
            radioLow.UseVisualStyleBackColor = false;
            // 
            // radioMedium
            // 
            radioMedium.AutoSize = true;
            radioMedium.BackColor = Color.Transparent;
            radioMedium.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioMedium.Location = new Point(314, 219);
            radioMedium.Name = "radioMedium";
            radioMedium.Size = new Size(115, 32);
            radioMedium.TabIndex = 12;
            radioMedium.TabStop = true;
            radioMedium.Text = "Medium";
            radioMedium.UseVisualStyleBackColor = false;
            // 
            // radioHigh
            // 
            radioHigh.AutoSize = true;
            radioHigh.BackColor = Color.Transparent;
            radioHigh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioHigh.Location = new Point(435, 220);
            radioHigh.Name = "radioHigh";
            radioHigh.Size = new Size(82, 32);
            radioHigh.TabIndex = 13;
            radioHigh.TabStop = true;
            radioHigh.Text = "High";
            radioHigh.UseVisualStyleBackColor = false;
            // 
            // comboCategory
            // 
            comboCategory.Font = new Font("Segoe UI", 10F);
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(713, 144);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(216, 36);
            comboCategory.TabIndex = 14;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.BackColor = Color.Transparent;
            lblReminder.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblReminder.Location = new Point(89, 303);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(214, 30);
            lblReminder.TabIndex = 16;
            lblReminder.Text = "Current Reminder:";
            // 
            // comboReminder
            // 
            comboReminder.Font = new Font("Segoe UI", 10F);
            comboReminder.FormattingEnabled = true;
            comboReminder.Items.AddRange(new object[] { "No Reminder", "5 minutes before", "10 minutes before", "1 hour before", "2 days before" });
            comboReminder.Location = new Point(309, 297);
            comboReminder.Name = "comboReminder";
            comboReminder.Size = new Size(216, 36);
            comboReminder.TabIndex = 17;
            comboReminder.Text = "Edit Reminder";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblStatus.Location = new Point(589, 435);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(88, 30);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "Status:";
            // 
            // chkCompleted
            // 
            chkCompleted.AutoSize = true;
            chkCompleted.BackColor = Color.Transparent;
            chkCompleted.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkCompleted.Location = new Point(715, 435);
            chkCompleted.Name = "chkCompleted";
            chkCompleted.Size = new Size(221, 32);
            chkCompleted.TabIndex = 20;
            chkCompleted.Text = "Mark as Completed";
            chkCompleted.UseVisualStyleBackColor = false;
            // 
            // EditTaskForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1050, 533);
            Controls.Add(chkCompleted);
            Controls.Add(lblStatus);
            Controls.Add(comboReminder);
            Controls.Add(lblReminder);
            Controls.Add(comboCategory);
            Controls.Add(radioHigh);
            Controls.Add(radioMedium);
            Controls.Add(radioLow);
            Controls.Add(dateTimePicker);
            Controls.Add(txtNotes);
            Controls.Add(txtTaskName);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(lblPriority);
            Controls.Add(lblNotes);
            Controls.Add(lblCategory);
            Controls.Add(lblDueDate);
            Controls.Add(lblTaskName);
            Name = "EditTaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Task";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
