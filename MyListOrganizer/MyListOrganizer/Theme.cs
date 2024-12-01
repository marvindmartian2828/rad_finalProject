using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyListOrganizer
{
    public class Theme
    {
        // Background images for different forms
        public Image? MainDashboardBackground { get; }
        public Image? TaskCreationBackground { get; }
        public Image? EditTaskBackground { get; }
        public Image? NotesBackground { get; }

        // Button color and text color
        public Color ButtonColor { get; }
        public Color ButtonTextColor { get; }

        // Current theme for the application
        public static Theme? CurrentTheme { get; private set; }

        // Constructor to initialize theme properties
        public Theme(
            Image? mainDashboardBackground,
            Color buttonColor,
            Color buttonTextColor,
            Image? taskCreationBackground,
            Image? editTaskBackground,
            Image? notesBackground)
        {
            MainDashboardBackground = mainDashboardBackground;
            TaskCreationBackground = taskCreationBackground;
            EditTaskBackground = editTaskBackground;
            NotesBackground = notesBackground;
            ButtonColor = buttonColor;
            ButtonTextColor = buttonTextColor;
        }

        // Set the current theme
        public static void SetCurrentTheme(Theme theme)
        {
            CurrentTheme = theme;
        }

        // Apply the theme to the given form
        public void ApplyTheme(Form form)
        {
            if (CurrentTheme != null)
            {
                // Apply background image based on form type
                if (form is MainDashboard)
                    form.BackgroundImage = CurrentTheme.MainDashboardBackground;
                else if (form is TaskCreationForm)
                    form.BackgroundImage = CurrentTheme.TaskCreationBackground;
                else if (form is EditTaskForm)
                    form.BackgroundImage = CurrentTheme.EditTaskBackground;
                else if (form is NotesForm)
                    form.BackgroundImage = CurrentTheme.NotesBackground;

                form.BackgroundImageLayout = ImageLayout.Stretch; // Stretch the background image

                // Apply button colors
                foreach (Control control in form.Controls)
                {
                    if (control is Button button)
                    {
                        button.BackColor = CurrentTheme.ButtonColor;
                        button.ForeColor = CurrentTheme.ButtonTextColor;
                    }
                }

                // Apply background color to specific panels
                var panelDateTasksControl = form.Controls.Find("panelDateTasks", true).FirstOrDefault() as Panel;
                if (panelDateTasksControl != null)
                {
                    panelDateTasksControl.BackColor = CurrentTheme.ButtonColor; // Set panel background color
                }
            }
        }
    }
}
