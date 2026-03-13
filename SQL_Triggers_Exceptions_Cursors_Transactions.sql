------------------------------------------------------------
-- 1. Triggers Assignments
------------------------------------------------------------

-- Assignment 1 – Audit Trigger for Students
CREATE TABLE StudentAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ActionType NVARCHAR(20),
    ActionDate DATETIME
);
GO

CREATE TRIGGER trg_StudentInsertAudit
ON dbo.Students
AFTER INSERT
AS
BEGIN
    INSERT INTO StudentAudit (StudentID, ActionType, ActionDate)
    SELECT i.StudentID, 'INSERT', GETDATE()
    FROM inserted i;
END;
GO


-- Assignment 2 – Prevent Deleting Students
CREATE TRIGGER trg_PreventStudentDelete
ON dbo.Students
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM deleted d
        JOIN Enrollments e ON d.StudentID = e.StudentID
    )
    BEGIN
        RAISERROR('Student has course enrollments and cannot be deleted',16,1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        DELETE FROM dbo.Students
        WHERE StudentID IN (SELECT StudentID FROM deleted);
    END
END;
GO


-- Assignment 3 – Update Marks Trigger
CREATE TABLE MarksAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    OldMarks INT,
    NewMarks INT,
    UpdatedDate DATETIME
);
GO

CREATE TRIGGER trg_UpdateMarksAudit
ON dbo.Marks
AFTER UPDATE
AS
BEGIN
    INSERT INTO MarksAudit (StudentID, ExamID, OldMarks, NewMarks, UpdatedDate)
    SELECT d.StudentID, d.ExamID, d.MarksObtained, i.MarksObtained, GETDATE()
    FROM deleted d
    JOIN inserted i ON d.MarkID = i.MarkID;
END;
GO


------------------------------------------------------------
-- 2. Exception Handling Assignments
------------------------------------------------------------

-- Assignment 1 – Insert Student Procedure with Exception Handling
GO
CREATE PROCEDURE sp_AddStudent
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DepartmentID INT,
    @Gender NVARCHAR(10),
    @AdmissionDate DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO dbo.Students (FirstName, LastName, DepartmentID, Gender, AdmissionDate)
        VALUES (@FirstName, @LastName, @DepartmentID, @Gender, @AdmissionDate);
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- Assignment 2 – Marks Validation Procedure
GO
CREATE PROCEDURE sp_InsertMarks
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN
    IF @MarksObtained < 0 OR @MarksObtained > 100
    BEGIN
        RAISERROR('Invalid Marks',16,1);
        RETURN;
    END

    INSERT INTO dbo.Marks (StudentID, ExamID, MarksObtained)
    VALUES (@StudentID, @ExamID, @MarksObtained);
END;
GO

-- Assignment 3 – Safe Delete Procedure
GO
CREATE PROCEDURE sp_DeleteStudent
    @StudentID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM dbo.Students WHERE StudentID = @StudentID;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO


------------------------------------------------------------
-- 3. Cursors Assignments
------------------------------------------------------------

-- Assignment 1 – Display Student Names
GO
CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN
    DECLARE @StudentID INT, @StudentName NVARCHAR(100);

    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, (FirstName + ' ' + LastName) AS StudentName
    FROM dbo.Students;

    OPEN student_cursor;
    FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT CAST(@StudentID AS NVARCHAR(10)) + ' - ' + @StudentName;
        FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName;
    END

    CLOSE student_cursor;
    DEALLOCATE student_cursor;
END;
GO

-- Assignment 2 – Calculate Total Marks Per Student
GO
CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN
    DECLARE @StudentID INT, @StudentName NVARCHAR(100), @TotalMarks INT;

    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, (FirstName + ' ' + LastName) AS StudentName
    FROM dbo.Students;

    OPEN student_cursor;
    FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @TotalMarks = SUM(MarksObtained)
        FROM dbo.Marks WHERE StudentID = @StudentID;

        PRINT @StudentName + ' - Total Marks: ' + CAST(ISNULL(@TotalMarks,0) AS NVARCHAR(10));

        FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName;
    END

    CLOSE student_cursor;
    DEALLOCATE student_cursor;
END;
GO

-- Assignment 3 – Update Course Credits
GO
CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN
    DECLARE @CourseID INT, @Credits INT;

    DECLARE course_cursor CURSOR FOR
    SELECT CourseID, Credits FROM dbo.Courses WHERE Credits < 3;

    OPEN course_cursor;
    FETCH NEXT FROM course_cursor INTO @CourseID, @Credits;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE dbo.Courses
        SET Credits = @Credits + 1
        WHERE CourseID = @CourseID;

        FETCH NEXT FROM course_cursor INTO @CourseID, @Credits;
    END

    CLOSE course_cursor;
    DEALLOCATE course_cursor;
END;
GO


------------------------------------------------------------
-- 4. Transactions Assignments
------------------------------------------------------------

-- Assignment 1 – Student Enrollment Transaction
GO
CREATE PROCEDURE sp_EnrollStudentTransaction
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO dbo.Enrollments (StudentID, CourseID, EnrollmentDate)
        VALUES (@StudentID, @CourseID, GETDATE());

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- Assignment 2 – Exam Marks Transaction
GO
CREATE PROCEDURE sp_RecordExamMarks
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO dbo.Marks (StudentID, ExamID, MarksObtained)
        VALUES (@StudentID, @ExamID, @MarksObtained);

        UPDATE dbo.Exams
        SET ExamDate = GETDATE()
        WHERE ExamID = @ExamID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- Assignment 3 – Department Transfer Transaction
GO
CREATE PROCEDURE sp_TransferStudentDepartment
    @StudentID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM dbo.Departments WHERE DepartmentID = @NewDepartmentID)
        BEGIN
            UPDATE dbo.Students
            SET DepartmentID = @NewDepartmentID
            WHERE StudentID = @StudentID;

            COMMIT TRANSACTION;
        END
        ELSE
        BEGIN
            RAISERROR('Department does not exist',16,1);
            ROLLBACK TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO