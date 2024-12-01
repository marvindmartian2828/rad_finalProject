-- Create the database
CREATE DATABASE MyListOrganizer;
GO

-- Switch to the MyListOrganizer database
USE MyListOrganizer;
GO

/******************************************************************************* 
   CREATE TABLES 
********************************************************************************/

-- Categories Table: Stores task categories like Work and Personal
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL UNIQUE
);

-- Tasks Table: Stores task details including task name, due date, category, and reminder
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    TaskName NVARCHAR(100) NOT NULL,
    DueDate DATETIME NOT NULL,  
    CategoryID INT NOT NULL,
    Notes NVARCHAR(MAX),
    Priority NVARCHAR(20) CHECK (Priority IN ('Low', 'Medium', 'High')),
    IsCompleted BIT DEFAULT 0,  
    CreatedAt DATETIME DEFAULT GETDATE(),
    ReminderTime DATETIME NULL, 
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

/******************************************************************************* 
   Populate Tables 
********************************************************************************/

-- Insert Categories: Adding Work and Personal categories
INSERT INTO Categories (CategoryName)
VALUES 
('Work'), 
('Personal');

-- Insert Tasks: Adding sample tasks with DueDate and ReminderTime (ReminderTime can be NULL)
INSERT INTO Tasks (TaskName, DueDate, CategoryID, Notes, Priority, IsCompleted, ReminderTime)
VALUES 
('Complete project report', '2024-11-10', 1, 'Finalize the project report and share with the team.', 'High', 0, NULL), 
('Team meeting preparation', '2024-11-15', 1, 'Prepare slides and agenda for the team meeting.', 'Medium', 0, NULL), 
('Client follow-up calls', '2024-11-12', 1, 'Call clients to follow up on recent projects.', 'Low', 0, NULL), 
('Submit budget proposal', '2024-11-22', 1, 'Complete and submit the budget proposal for next quarter.', 'Medium', 0, NULL), 
('Grocery shopping', '2024-11-16', 2, 'Buy groceries for the week.', 'Low', 0, NULL), 
('Clean the house', '2024-11-18', 2, 'Complete the weekly cleaning tasks.', 'Medium', 0, NULL), 
('Exercise', '2024-11-20', 2, 'Go for a run or workout session.', 'High', 0, NULL), 
('Read a book', '2024-11-24', 2, 'Finish reading the current book.', 'Low', 0, NULL);

/******************************************************************************* 
   Check Data 
********************************************************************************/

-- Check Categories: Retrieve all categories
SELECT * FROM Categories;

-- Check Tasks: Retrieve all tasks
SELECT * FROM Tasks;

-- Retrieve a specific task by TaskID
SELECT TaskID, TaskName, DueDate, ReminderTime FROM Tasks WHERE TaskID = 14;

-- Update task with TaskID 14: Modify DueDate and ReminderTime
UPDATE Tasks
SET 
    DueDate = '2024-12-05 09:50:00.000',
    ReminderTime = '2024-12-05 09:45:00.000'
WHERE TaskID = 14;
