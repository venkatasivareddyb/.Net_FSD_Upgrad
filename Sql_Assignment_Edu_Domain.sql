-- 1. Departments
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) UNIQUE,
    Location VARCHAR(100)
);

-- 2. Teachers
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    DepartmentID INT,
    HireDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- 3. Students
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Gender CHAR(1) CHECK (Gender IN ('M','F')),
    DepartmentID INT,
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- 4. Courses
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT CHECK (Credits BETWEEN 1 AND 5),
    DepartmentID INT,
    TeacherID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

-- 5. Enrollments
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- 6. Exams
CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- 7. Marks
CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT CHECK (MarksObtained BETWEEN 0 AND 100),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);
--Assignment 3
Alter table Students add phonenumber varchar(20)
Alter table Teachers add Salary int
Alter table Teachers add constraint chk_TeacherSalary
Check(Salary>20000)
Alter table Teachers drop constraint chk_TeacherSalary
alter table Students drop column Phonenumber
EXEC sp_rename 'Students.PhoneNumber', 'ContactNumber', 
'COLUMN';
sp_help Teachers
--Assignment 4
INSERT INTO Departments (DepartmentID, DepartmentName, Location)
VALUES
(1, 'Computer Science', 'Block A'),
(2, 'Mathematics', 'Block B'),
(3, 'Physics', 'Block C'),
(4, 'Chemistry', 'Block D'),
(5, 'English', 'Block E');

INSERT INTO Teachers (TeacherID, TeacherName, Email, DepartmentID, HireDate, Salary)
VALUES
(1, 'Alice Johnson', 'alice.johnson@edu.com', 1, '2020-01-15', 45000),
(2, 'Bob Smith', 'bob.smith@edu.com', 2, '2019-03-10', 38000),
(3, 'Carol White', 'carol.white@edu.com', 3, '2021-07-01', 50000),
(4, 'David Brown', 'david.brown@edu.com', 4, '2018-11-20', 60000),
(5, 'Emma Davis', 'emma.davis@edu.com', 5, '2022-02-05', 42000),
(6, 'Frank Wilson', 'frank.wilson@edu.com', 1, '2017-09-12', 55000),
(7, 'Grace Lee', 'grace.lee@edu.com', 2, '2020-05-30', 47000),
(8, 'Henry Clark', 'henry.clark@edu.com', 3, '2016-08-18', 65000),
(9, 'Ivy Lewis', 'ivy.lewis@edu.com', 4, '2019-12-25', 39000),
(10, 'Jack Hall', 'jack.hall@edu.com', 5, '2021-04-14', 52000);

INSERT INTO Students (StudentID, FirstName, LastName, DateOfBirth, Gender, DepartmentID, AdmissionDate, ContactNumber)
VALUES
(1, 'John', 'Miller', '2002-05-10', 'M', 1, '2021-08-01', '9876543210'),
(2, 'Sophia', 'Taylor', '2003-07-22', 'F', 2, '2021-08-01', '9876543211'),
(3, 'Liam', 'Anderson', '2001-11-15', 'M', 3, '2020-08-01', '9876543212'),
(4, 'Olivia', 'Thomas', '2002-01-05', 'F', 4, '2021-08-01', '9876543213'),
(5, 'Noah', 'Jackson', '2003-03-18', 'M', 5, '2022-08-01', '9876543214'),
(6, 'Emma', 'Harris', '2002-09-09', 'F', 1, '2021-08-01', '9876543215'),
(7, 'James', 'Martin', '2001-12-30', 'M', 2, '2020-08-01', '9876543216'),
(8, 'Ava', 'Garcia', '2003-04-25', 'F', 3, '2022-08-01', '9876543217'),
(9, 'Ethan', 'Martinez', '2002-06-14', 'M', 4, '2021-08-01', '9876543218'),
(10, 'Isabella', 'Robinson', '2001-10-01', 'F', 5, '2020-08-01', '9876543219'),
(11, 'Mason', 'Clark', '2002-02-20', 'M', 1, '2021-08-01', '9876543220'),
(12, 'Mia', 'Rodriguez', '2003-08-11', 'F', 2, '2022-08-01', '9876543221'),
(13, 'Lucas', 'Lewis', '2001-09-29', 'M', 3, '2020-08-01', '9876543222'),
(14, 'Charlotte', 'Walker', '2002-12-12', 'F', 4, '2021-08-01', '9876543223'),
(15, 'Benjamin', 'Hall', '2003-05-07', 'M', 5, '2022-08-01', '9876543224'),
(16, 'Amelia', 'Allen', '2002-07-19', 'F', 1, '2021-08-01', '9876543225'),
(17, 'Elijah', 'Young', '2001-03-03', 'M', 2, '2020-08-01', '9876543226'),
(18, 'Harper', 'King', '2003-09-21', 'F', 3, '2022-08-01', '9876543227'),
(19, 'Alexander', 'Scott', '2002-11-02', 'M', 4, '2021-08-01', '9876543228'),
(20, 'Evelyn', 'Green', '2001-01-17', 'F', 5, '2020-08-01', '9876543229');

INSERT INTO Courses (CourseID, CourseName, Credits, DepartmentID, TeacherID)
VALUES
(1, 'Data Structures', 4, 1, 1),
(2, 'Algorithms', 3, 1, 6),
(3, 'Linear Algebra', 4, 2, 2),
(4, 'Calculus', 3, 2, 7),
(5, 'Quantum Mechanics', 4, 3, 3),
(6, 'Optics', 3, 3, 8),
(7, 'Organic Chemistry', 4, 4, 4),
(8, 'Inorganic Chemistry', 3, 4, 9),
(9, 'English Literature', 3, 5, 5),
(10, 'Creative Writing', 2, 5, 10);

INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES
(1, 1, 1), (2, 2, 3), (3, 3, 5), (4, 4, 7), (5, 5, 9),
(6, 6, 2), (7, 7, 4), (8, 8, 6), (9, 9, 8), (10, 10, 10),
(11, 11, 1), (12, 12, 3), (13, 13, 5), (14, 14, 7), (15, 15, 9),
(16, 16, 2), (17, 17, 4), (18, 18, 6), (19, 19, 8), (20, 20, 10),
(21, 1, 2), (22, 2, 4), (23, 3, 6), (24, 4, 8), (25, 5, 10),
(26, 6, 1), (27, 7, 3), (28, 8, 5), (29, 9, 7), (30, 10, 9);

INSERT INTO Exams (ExamID, CourseID, ExamDate, ExamType)
VALUES
(1, 1, '2023-12-01', 'Midterm'),
(2, 3, '2023-12-05', 'Final'),
(3, 5, '2023-12-10', 'Midterm'),
(4, 7, '2023-12-15', 'Final'),
(5, 9, '2023-12-20', 'Midterm');

INSERT INTO Marks (MarkID, StudentID, ExamID, MarksObtained)
VALUES
(1, 1, 1, 85),
(2, 2, 2, 78),
(3, 3, 3, 92),
(4, 4, 4, 67),
(5, 5, 5, 74),
(6, 6, 1, 88),
(7, 7, 2, 81),
(8, 8, 3, 95),
(9, 9, 4, 72),
(10, 10, 5, 69),
(11, 11, 1, 90),
(12, 12, 2, 76),
(13, 13, 3, 84),
(14, 14, 4, 63),
(15, 15, 5, 79),
(16, 16, 1, 86),
(17, 17, 2, 80),
(18, 18, 3, 91),
(19, 19, 4, 70),
(20, 20, 5, 75),
(21, 1, 2, 82),
(22, 2, 3, 88),
(23, 3, 4, 77),
(24, 4, 5, 69),
(25, 5, 1, 93),
(26, 6, 2, 85),
(27, 7, 3, 90),
(28, 8, 4, 73),
(29, 9, 5, 68),
(30, 10, 1, 87);
--Assignment 5

-- 1. Show students in the Computer Science department
SELECT *
FROM Students s
INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID
WHERE d.DepartmentName = 'Computer Science';

-- 2. Show teachers hired after 2022
SELECT *
FROM Teachers
WHERE DATEPART(yy, HireDate) > 2022;

-- 3. Show students whose first name starts with 'A'
SELECT *
FROM Students
WHERE FirstName LIKE 'A%';

-- 4. Show courses with more than 3 credits
SELECT *
FROM Courses
WHERE Credits > 3;

-- 5. Show students born between 2005 and 2008
SELECT *
FROM Students
WHERE YEAR(DateOfBirth) BETWEEN 2005 AND 2008;

-- 6. Show students not in Chemistry department
SELECT *
FROM Students s
INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID
WHERE d.DepartmentName != 'Chemistry';

-- 7. Show teachers with salary between 40,000 and 70,000
SELECT *
FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

-- 8. Show courses not taught by TeacherID = 3
SELECT *
FROM Teachers
WHERE TeacherID <> 3;

-- Assignment 6 – Grouping Data (Aggregate Functions)


-- 1. Count students in each department
SELECT DepartmentID, COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID;

-- 2. Find average marks per exam
SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;

-- 3. Find total students enrolled per course
SELECT CourseID, COUNT(StudentID) AS TotalEnrolled
FROM Enrollments
GROUP BY CourseID;

-- 4. Find maximum marks scored in each exam
SELECT ExamID, MAX(MarksObtained) AS MaxMarks
FROM Marks
GROUP BY ExamID;

-- 5. Find minimum marks per course
SELECT e.CourseID, MIN(m.MarksObtained) AS MinMarks
FROM Marks m
JOIN Exams e ON m.ExamID = e.ExamID
GROUP BY e.CourseID;

-- 6. Find departments having more than 5 students
SELECT DepartmentID, COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;


-- Assignment 7 – Joins


-- 1. Show students with department names
SELECT s.StudentID, s.FirstName, s.LastName, d.DepartmentName
FROM Students s
JOIN Departments d ON s.DepartmentID = d.DepartmentID;

-- 2. Show courses with teacher names
SELECT c.CourseID, c.CourseName, t.TeacherName
FROM Courses c
JOIN Teachers t ON c.TeacherID = t.TeacherID;

-- 3. Show student name and enrolled courses
SELECT s.StudentID, s.FirstName, s.LastName, c.CourseName
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;

-- 4. Show students with exam marks
SELECT s.StudentID, s.FirstName, s.LastName, e.ExamType, m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID;

-- 5. Show all courses and teachers (even if no teacher assigned)
SELECT c.CourseID, c.CourseName, t.TeacherName
FROM Courses c
LEFT JOIN Teachers t ON c.TeacherID = t.TeacherID;

-- 6. Show teachers who are not assigned to any course
SELECT t.TeacherID, t.TeacherName
FROM Teachers t
LEFT JOIN Courses c ON t.TeacherID = c.TeacherID
WHERE c.TeacherID IS NULL;



-- Assignment 8 – Subqueries


-- 1. Find students whose marks are greater than average marks
SELECT s.StudentID, s.FirstName, s.LastName
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
WHERE m.MarksObtained > (SELECT AVG(MarksObtained) FROM Marks);

-- 2. Find courses with maximum credits
SELECT *
FROM Courses
WHERE Credits = (SELECT MAX(Credits) FROM Courses);

-- 3. Find students enrolled in more than 2 courses
SELECT s.StudentID, s.FirstName, s.LastName
FROM Students s
WHERE s.StudentID IN (
    SELECT StudentID
    FROM Enrollments
    GROUP BY StudentID
    HAVING COUNT(CourseID) > 2
);

-- 4. Find teachers working in the same department as teacher 'John'
SELECT *
FROM Teachers
WHERE DepartmentID = (
    SELECT DepartmentID
    FROM Teachers
    WHERE TeacherName = 'John'
);

-- 5. Find students who scored highest marks in an exam
SELECT s.StudentID, s.FirstName, s.LastName, m.MarksObtained, e.ExamID
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID
WHERE m.MarksObtained = (
    SELECT MAX(MarksObtained)
    FROM Marks
    WHERE ExamID = e.ExamID
);

-- 6. Find departments having maximum number of students
SELECT DepartmentID
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) = (
    SELECT MAX(StudentCount)
    FROM (
        SELECT COUNT(*) AS StudentCount
        FROM Students
        GROUP BY DepartmentID
    ) AS DeptCounts
);


------------------------------------------------------------
-- Assignment 9 – Views
------------------------------------------------------------

-- View 1: Student basic information with department name
CREATE VIEW vw_StudentBasicInfo
AS
SELECT s.StudentID,
       (s.FirstName + ' ' + s.LastName) AS StudentName,
       d.DepartmentName
FROM Students s
JOIN Departments d ON s.DepartmentID = d.DepartmentID;
GO

-- Query View 1
SELECT * FROM vw_StudentBasicInfo;
GO

-- View 2: Student course enrollment view
CREATE VIEW vw_StudentCourseEnrollment
AS
SELECT (s.FirstName + ' ' + s.LastName) AS StudentName,
       c.CourseName,
       e.EnrollmentDate
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;
GO

-- Query View 2
SELECT * FROM vw_StudentCourseEnrollment;
GO

-- View 3: Exam result view
CREATE VIEW vw_ExamResults
AS
SELECT (s.FirstName + ' ' + s.LastName) AS StudentName,
       c.CourseName,
       ex.ExamType,
       m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams ex ON m.ExamID = ex.ExamID
JOIN Courses c ON ex.CourseID = c.CourseID;
GO

-- Query View 3
SELECT * FROM vw_ExamResults;
GO

-- Update data through view (possible only if view maps directly to base table columns)
-- Example: Update student name via vw_StudentBasicInfo
-- Note: This works only if the view is updatable (no aggregates, joins, etc.)
-- For demonstration:
-- UPDATE vw_StudentBasicInfo
-- SET StudentName = 'John Updated'
-- WHERE StudentID = 1;

-- Drop Views
DROP VIEW vw_StudentBasicInfo;
DROP VIEW vw_StudentCourseEnrollment;
DROP VIEW vw_ExamResults;
GO