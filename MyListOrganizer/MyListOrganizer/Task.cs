public class Task
{
    public int TaskID { get; set; }
    public string TaskName { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } // Indicates if the task is completed

    // Reminder properties
    public bool IsReminderEnabled { get; set; } // Whether a reminder is set for the task
    public DateTime? ReminderTime { get; set; } // Nullable DateTime for when the reminder should occur

    // Default constructor
    public Task() { }

    // Constructor to initialize task with all properties
    public Task(int taskId, string taskName, DateTime dueDate, string category, string notes, string priority, bool isCompleted, bool isReminderEnabled, DateTime? reminderTime)
    {
        TaskID = taskId;
        TaskName = taskName;
        DueDate = dueDate;
        Category = category;
        Notes = notes;
        Priority = priority;
        IsCompleted = isCompleted;
        IsReminderEnabled = isReminderEnabled;
        ReminderTime = reminderTime;
    }
}
