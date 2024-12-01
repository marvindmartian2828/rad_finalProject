using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyListOrganizer
{
    partial class TaskCreationForm
    {
        private IContainer components = null;

        private Label lblTaskName;
        private Label lblDueDate;
        private Label lblCategory;
        private Label lblNotes;
        private Label lblPriority;
        private Button btnCreate;
        private Button btnCancel;
        private TextBox txtTaskName;
        private TextBox txtNotes;
        private DateTimePicker dateTimePicker;
        private RadioButton radioLow;
        private RadioButton radioMedium;
        private RadioButton radioHigh;
        private ComboBox comboBox1; // Category ComboBox
        private Label lblReminder;
        private ComboBox comboReminder; // Reminder ComboBox

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
            btnCreate = new Button();
            btnCancel = new Button();
            txtTaskName = new TextBox();
            txtNotes = new TextBox();
            dateTimePicker = new DateTimePicker();
            radioLow = new RadioButton();
            radioMedium = new RadioButton();
            radioHigh = new RadioButton();
            comboBox1 = new ComboBox();
            lblReminder = new Label();
            comboReminder = new ComboBox();
            SuspendLayout();

            // Task Name Label
            lblTaskName.AutoSize = true;
            lblTaskName.BackColor = Color.Transparent;
            lblTaskName.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblTaskName.ForeColor = Color.Black;
            lblTaskName.Location = new Point(85, 77);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(139, 30);
            lblTaskName.TabIndex = 0;
            lblTaskName.Text = "Task Name:";

            // Due Date Label
            lblDueDate.AutoSize = true;
            lblDueDate.BackColor = Color.Transparent;
            lblDueDate.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblDueDate.ForeColor = Color.Black;
            lblDueDate.Location = new Point(89, 150);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(119, 30);
            lblDueDate.TabIndex = 1;
            lblDueDate.Text = "Due Date:";

            // Category Label
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblCategory.ForeColor = Color.Black;
            lblCategory.Location = new Point(597, 148);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(118, 30);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";

            // Notes Label
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.Transparent;
            lblNotes.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblNotes.ForeColor = Color.Black;
            lblNotes.Location = new Point(606, 242);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(84, 30);
            lblNotes.TabIndex = 3;
            lblNotes.Text = "Notes:";

            // Priority Label
            lblPriority.AutoSize = true;
            lblPriority.BackColor = Color.Transparent;
            lblPriority.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblPriority.ForeColor = Color.Black;
            lblPriority.Location = new Point(89, 220);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(104, 30);
            lblPriority.TabIndex = 4;
            lblPriority.Text = "Priority:";

            // Create Button
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCreate.Location = new Point(141, 406);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(156, 46);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create Task";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            // Cancel Button
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(372, 406);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(156, 46);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // Task Name TextBox
            txtTaskName.Font = new Font("Segoe UI", 10F);
            txtTaskName.Location = new Point(230, 77);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(707, 34);
            txtTaskName.TabIndex = 8;

            // Notes TextBox
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(721, 242);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(216, 201);
            txtNotes.TabIndex = 9;

            // Due Date Picker
            dateTimePicker.Font = new Font("Segoe UI", 10F);
            dateTimePicker.Location = new Point(230, 147);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(280, 34);
            dateTimePicker.TabIndex = 10;

            // Priority RadioButtons
            radioLow.AutoSize = true;
            radioLow.BackColor = Color.Transparent;
            radioLow.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            radioLow.ForeColor = Color.Black;
            radioLow.Location = new Point(230, 218);
            radioLow.Name = "radioLow";
            radioLow.Size = new Size(76, 29);
            radioLow.TabIndex = 11;
            radioLow.TabStop = true;
            radioLow.Text = "Low";
            radioLow.UseVisualStyleBackColor = false;

            radioMedium.AutoSize = true;
            radioMedium.BackColor = Color.Transparent;
            radioMedium.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            radioMedium.ForeColor = Color.Black;
            radioMedium.Location = new Point(318, 219);
            radioMedium.Name = "radioMedium";
            radioMedium.Size = new Size(113, 29);
            radioMedium.TabIndex = 12;
            radioMedium.TabStop = true;
            radioMedium.Text = "Medium";
            radioMedium.UseVisualStyleBackColor = false;

            radioHigh.AutoSize = true;
            radioHigh.BackColor = Color.Transparent;
            radioHigh.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            radioHigh.ForeColor = Color.Black;
            radioHigh.Location = new Point(450, 220);
            radioHigh.Name = "radioHigh";
            radioHigh.Size = new Size(81, 29);
            radioHigh.TabIndex = 13;
            radioHigh.TabStop = true;
            radioHigh.Text = "High";
            radioHigh.UseVisualStyleBackColor = false;

            // Category ComboBox
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(721, 140);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(216, 36);
            comboBox1.TabIndex = 14;

            // Reminder Label
            lblReminder.AutoSize = true;
            lblReminder.BackColor = Color.Transparent;
            lblReminder.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblReminder.ForeColor = Color.Black;
            lblReminder.Location = new Point(89, 303);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(125, 30);
            lblReminder.TabIndex = 16;
            lblReminder.Text = "Reminder:";

            // Reminder ComboBox
            comboReminder.Font = new Font("Segoe UI", 10F);
            comboReminder.FormattingEnabled = true;
            comboReminder.Items.AddRange(new object[] { "No Reminder", "5 minutes before", "10 minutes before", "1 hour before", "2 days before" });
            comboReminder.Location = new Point(230, 302);
            comboReminder.Name = "comboReminder";
            comboReminder.Size = new Size(216, 36);
            comboReminder.TabIndex = 17;

            // Task Creation Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1050, 533);
            Controls.Add(comboReminder);
            Controls.Add(lblReminder);
            Controls.Add(comboBox1);
            Controls.Add(radioHigh);
            Controls.Add(radioMedium);
            Controls.Add(radioLow);
            Controls.Add(dateTimePicker);
            Controls.Add(txtNotes);
            Controls.Add(txtTaskName);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(lblPriority);
            Controls.Add(lblNotes);
            Controls.Add(lblCategory);
            Controls.Add(lblDueDate);
            Controls.Add(lblTaskName);
            Name = "TaskCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Task";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
