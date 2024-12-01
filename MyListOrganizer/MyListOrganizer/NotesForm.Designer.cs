using System.Windows.Forms;

namespace MyListOrganizer
{
    partial class NotesForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNotes; // TextBox to display notes

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Dispose of components to free resources
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNotes = new TextBox();
            SuspendLayout();
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.MintCream;
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(20, 36);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ReadOnly = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(360, 220);
            txtNotes.TabIndex = 0;
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(400, 300);
            Controls.Add(txtNotes);
            Name = "NotesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Notes";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
