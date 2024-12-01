using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyListOrganizer
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=LENLEN_I\\SQLEXPRESS;Database=MyListOrganizer;Integrated Security=True;";

        // Get all tasks from the database
        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tasks"; // Select all tasks
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            TaskID = reader.GetInt32(reader.GetOrdinal("TaskID")),
                            TaskName = reader.GetString(reader.GetOrdinal("TaskName")),
                            DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                            Category = GetCategoryName(reader.GetInt32(reader.GetOrdinal("CategoryID"))),
                            Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? string.Empty : reader.GetString(reader.GetOrdinal("Notes")),
                            Priority = reader.GetString(reader.GetOrdinal("Priority")),
                            IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                            ReminderTime = reader.IsDBNull(reader.GetOrdinal("ReminderTime")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReminderTime"))
                        });
                    }
                }
            }

            return tasks;
        }

        // Get the category name for a given category ID
        public string GetCategoryName(int categoryId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    var result = command.ExecuteScalar();
                    return result?.ToString() ?? "Unknown Category";
                }
            }
        }

        // Get CategoryID by category name
        public int GetCategoryId(string categoryName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; // Return -1 if category not found
                }
            }
        }

        // Create a new task in the database
        public bool CreateTask(Task task)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (TaskName, DueDate, CategoryID, Notes, Priority, IsCompleted, ReminderTime) " +
                               "VALUES (@TaskName, @DueDate, @CategoryID, @Notes, @Priority, @IsCompleted, @ReminderTime)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskName", task.TaskName);
                    command.Parameters.AddWithValue("@DueDate", task.DueDate);
                    command.Parameters.AddWithValue("@Notes", task.Notes);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    command.Parameters.AddWithValue("@CategoryID", GetCategoryId(task.Category));
                    command.Parameters.AddWithValue("@ReminderTime", task.ReminderTime.HasValue ? (object)task.ReminderTime.Value : DBNull.Value);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Update an existing task in the database
        public bool UpdateTask(Task task)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tasks SET TaskName = @TaskName, DueDate = @DueDate, CategoryID = @CategoryID, " +
                               "Notes = @Notes, Priority = @Priority, IsCompleted = @IsCompleted, ReminderTime = @ReminderTime " +
                               "WHERE TaskID = @TaskID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskName", task.TaskName);
                    command.Parameters.AddWithValue("@DueDate", task.DueDate);
                    command.Parameters.AddWithValue("@Notes", task.Notes);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    command.Parameters.AddWithValue("@TaskID", task.TaskID);
                    command.Parameters.AddWithValue("@CategoryID", GetCategoryId(task.Category));

                    command.Parameters.AddWithValue("@ReminderTime", task.ReminderTime.HasValue ? task.ReminderTime.Value : (object)DBNull.Value);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Delete a task from the database
        public bool DeleteTask(int taskId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if task is deleted
                }
            }
        }
    }
}
