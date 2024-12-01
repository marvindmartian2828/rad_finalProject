using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyListOrganizer
{
    public partial class NotesForm : Form
    {
        public Task CurrentTask { get; private set; }

        public NotesForm(Task task)
        {
            InitializeComponent();
            CurrentTask = task ?? throw new ArgumentNullException(nameof(task)); // Ensure task is not null

            // Bind task notes to the TextBox
            txtNotes.DataBindings.Add("Text", CurrentTask, "Notes", true, DataSourceUpdateMode.OnPropertyChanged);

            // Apply the selected theme
            ApplyTheme(Theme.CurrentTheme);
        }

        private void ApplyTheme(Theme theme)
        {
            // Apply the current theme to the form
            theme.ApplyTheme(this);

            // Set background image if available
            if (theme.NotesBackground != null)
            {
                this.BackgroundImage = theme.NotesBackground;
            }

            // Stretch the background image to fit the form
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            // Apply the theme again when the form loads
            ApplyTheme(Theme.CurrentTheme);
        }
    }
}
