------------------------------------------------------------
-- 1. Views Assignments
------------------------------------------------------------

-- Assignment 1 – Student Department View
CREATE VIEW vw_StudentDepartment
AS
SELECT s.StudentID,
       (s.FirstName + ' ' + s.LastName) AS StudentName,
       d.DepartmentName,
       s.AdmissionDate
FROM dbo.Students s
JOIN dbo.Departments d ON s.DepartmentID = d.DepartmentID;
GO

-- Retrieve all records
SELECT * FROM vw_StudentDepartment;

-- Filter students from Computer Science department
SELECT * FROM vw_StudentDepartment
WHERE DepartmentName = 'Computer Science';

-- Drop the view
DROP VIEW vw_StudentDepartment;
GO


-- Assignment 2 – Student Course Enrollment View
CREATE VIEW vw_StudentCourses
AS
SELECT (s.FirstName + ' ' + s.LastName) AS StudentName,
       c.CourseName,
       e.EnrollmentDate
FROM dbo.Students s
JOIN dbo.Enrollments e ON s.StudentID = e.StudentID
JOIN dbo.Courses c ON e.CourseID = c.CourseID;
GO

-- Show courses taken by StudentID = 5
SELECT * FROM vw_StudentCourses
WHERE StudentName IN (
    SELECT (FirstName + ' ' + LastName)
    FROM dbo.Students WHERE StudentID = 5
);

-- Count courses taken by each student
SELECT StudentName, COUNT(*) AS CourseCount
FROM vw_StudentCourses
GROUP BY StudentName;

-- List students enrolled after 2024
SELECT * FROM vw_StudentCourses
WHERE YEAR(EnrollmentDate) > 2024;

-- Drop the view
DROP VIEW vw_StudentCourses;
GO


-- Assignment 3 – Exam Result View
CREATE VIEW vw_ExamResults
AS
SELECT (s.FirstName + ' ' + s.LastName) AS StudentName,
       c.CourseName,
       ex.ExamType,
       m.MarksObtained
FROM dbo.Students s
JOIN dbo.Marks m ON s.StudentID = m.StudentID
JOIN dbo.Exams ex ON m.ExamID = ex.ExamID
JOIN dbo.Courses c ON ex.CourseID = c.CourseID;
GO

-- Students scoring more than 80
SELECT * FROM vw_ExamResults
WHERE MarksObtained > 80;

-- Top scorers in each exam
SELECT ExamType, MAX(MarksObtained) AS TopScore
FROM vw_ExamResults
GROUP BY ExamType;

-- Students who failed (< 40 marks)
SELECT * FROM vw_ExamResults
WHERE MarksObtained < 40;

-- Drop the view
DROP VIEW vw_ExamResults;
GO


-- Assignment 4 – Aggregate View
CREATE VIEW vw_DepartmentStudentCount
AS
SELECT d.DepartmentName,
       COUNT(s.StudentID) AS TotalStudents
FROM dbo.Students s
JOIN dbo.Departments d ON s.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentName;
GO

-- Departments with more than 10 students
SELECT * FROM vw_DepartmentStudentCount
WHERE TotalStudents > 10;

-- Sort departments by highest student count
SELECT * FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;

-- Drop the view
DROP VIEW vw_DepartmentStudentCount;
GO


------------------------------------------------------------
-- 2. Stored Procedures Assignments
------------------------------------------------------------

-- Assignment 1 – Insert Student Procedure
CREATE PROCEDURE sp_InsertStudent
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Gender NVARCHAR(10),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO dbo.Students (FirstName, LastName, Gender, DepartmentID, AdmissionDate)
    VALUES (@FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
GO

-- Execute procedure
EXEC sp_InsertStudent 'John','Doe','Male',2,'2025-01-10';


-- Assignment 2 – Get Students By Department
CREATE PROCEDURE sp_GetStudentsByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT StudentID,
           (FirstName + ' ' + LastName) AS StudentName,
           AdmissionDate
    FROM dbo.Students
    WHERE DepartmentID = @DepartmentID;
END;

GO

-- Execute procedure
EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;


-- Assignment 3 – Course Enrollment Procedure
CREATE PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO dbo.Enrollments (StudentID, CourseID, EnrollmentDate)
    VALUES (@StudentID, @CourseID, GETDATE());
END;
GO


-- Assignment 4 – Student Marks Procedure
CREATE PROCEDURE sp_GetStudentMarks
    @StudentID INT
AS
BEGIN
    SELECT (s.FirstName + ' ' + s.LastName) AS StudentName,
           c.CourseName,
           ex.ExamType,
           m.MarksObtained
    FROM dbo.Students s
    JOIN dbo.Marks m ON s.StudentID = m.StudentID
    JOIN dbo.Exams ex ON m.ExamID = ex.ExamID
    JOIN dbo.Courses c ON ex.CourseID = c.CourseID
    WHERE s.StudentID = @StudentID;
END;
GO


-- Assignment 5 – Update Student Marks
CREATE PROCEDURE sp_UpdateMarks
    @MarkID INT,
    @NewMarks INT
AS
BEGIN
    UPDATE dbo.Marks
    SET MarksObtained = @NewMarks
    WHERE MarkID = @MarkID;

    SELECT * FROM dbo.Marks WHERE MarkID = @MarkID;
END;
GO


-- Assignment 6 – Delete Enrollment
CREATE PROCEDURE sp_DeleteEnrollment
    @EnrollmentID INT
AS
BEGIN
    DELETE FROM dbo.Enrollments
    WHERE EnrollmentID = @EnrollmentID;

    SELECT * FROM dbo.Enrollments WHERE EnrollmentID = @EnrollmentID;
END;
GO


------------------------------------------------------------
-- 3. User Defined Functions Assignments
------------------------------------------------------------

-- Assignment 1 – Calculate Grade (Scalar Function)
CREATE FUNCTION fn_GetGrade (@MarksObtained INT)
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @Grade NVARCHAR(10);
    IF @MarksObtained >= 90 SET @Grade = 'A';
    ELSE IF @MarksObtained >= 75 SET @Grade = 'B';
    ELSE IF @MarksObtained >= 60 SET @Grade = 'C';
    ELSE SET @Grade = 'Fail';
    RETURN @Grade;
END;
GO

-- Use in exam results
SELECT StudentName, CourseName, ExamType, MarksObtained,
       dbo.fn_GetGrade(MarksObtained) AS Grade
FROM vw_ExamResults;


-- Assignment 2 – Student Age Function
CREATE FUNCTION fn_GetStudentAge (@DateOfBirth DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @DateOfBirth, GETDATE());
END;
GO

-- Example usage
SELECT StudentID, FirstName, LastName,
       dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM dbo.Students;


-- Assignment 3 – Total Marks Function
CREATE FUNCTION fn_GetTotalMarks (@StudentID INT)
RETURNS INT
AS
BEGIN
    DECLARE @Total INT;
    SELECT @Total = SUM(MarksObtained)
    FROM dbo.Marks
    WHERE StudentID = @StudentID;
    RETURN @Total;
END;
GO

-- Example usage
SELECT StudentID, dbo.fn_GetTotalMarks(StudentID) AS TotalMarks
FROM dbo.Students;


-- Assignment 4 – Student Courses Function (Table Valued)
CREATE FUNCTION fn_GetStudentCourses (@StudentID INT)
RETURNS TABLE
AS
RETURN (
    SELECT c.CourseName, e.EnrollmentDate
    FROM dbo.Enrollments e
    JOIN dbo.Courses c ON e.CourseID = c.CourseID
    WHERE e.StudentID = @StudentID
);
GO

-- Example usage
SELECT * FROM dbo.fn_GetStudentCourses(5);


-- Assignment 5 – Department Students Function (Table Valued)
CREATE FUNCTION fn_GetDepartmentStudents (@DepartmentID INT)
RETURNS TABLE
AS
RETURN (
    SELECT s.StudentID,
           (s.FirstName + ' ' + s.LastName) AS StudentName,
           s.AdmissionDate
    FROM dbo.Students s
    WHERE s.DepartmentID = @DepartmentID
);
GO

-- Example usage
SELECT * FROM dbo.fn_GetDepartmentStudents(2);