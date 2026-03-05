create database Assignments
use Assignments
--WORKER TABLE
CREATE TABLE Worker (
	WORKER_ID INT PRIMARY KEY IDENTITY(1,1),
	FIRST_NAME VARCHAR(25),
	LAST_NAME VARCHAR(25),
	SALARY INT,
	JOINING_DATE DATETIME,
	DEPARTMENT CHAR(25)
);
-- Insert data into Worker table
INSERT INTO Worker (FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT)
VALUES
('Monika', 'Arora', 100000, '2014-02-20 09:00:00', 'HR'),
('Niharika', 'Verma', 80000, '2014-06-11 09:00:00', 'Admin'),
('Vishal', 'Singhal', 300000, '2014-02-20 09:00:00', 'HR'),
('Amitabh', 'Singh', 500000, '2014-02-20 09:00:00', 'Admin'),
('Vivek', 'Bhati', 500000, '2014-06-11 09:00:00', 'Admin'),
('Vipul', 'Diwan', 200000, '2014-06-11 09:00:00', 'Account'),
('Satish', 'Kumar', 75000, '2014-01-20 09:00:00', 'Account'),
('Geetika', 'Chauhan', 90000, '2014-04-11 09:00:00', 'Admin');

--BONUS TABLE
CREATE TABLE Bonus (
	WORKER_REF_ID INT,
	BONUS_AMOUNT INT,
	BONUS_DATE DATETIME,
	FOREIGN KEY (WORKER_REF_ID)REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);
-- Insert data into Bonus table
INSERT INTO Bonus (WORKER_REF_ID, BONUS_DATE, BONUS_AMOUNT)
VALUES
(1, '2016-02-20 00:00:00', 5000),
(2, '2016-06-11 00:00:00', 3000),
(3, '2016-02-20 00:00:00', 4000),
(1, '2016-02-20 00:00:00', 4500),
(2, '2016-06-11 00:00:00', 3500);
--TITLE TABLE
CREATE TABLE Title (
	WORKER_REF_ID INT,
	WORKER_TITLE CHAR(25),
	AFFECTED_FROM DATETIME,
	FOREIGN KEY (WORKER_REF_ID) REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);
INSERT INTO Title (WORKER_REF_ID, WORKER_TITLE, AFFECTED_FROM)
VALUES
(1, 'Manager', '2016-02-20 00:00:00'),
(2, 'Executive', '2016-06-11 00:00:00'),
(8, 'Executive', '2016-06-11 00:00:00'),
(5, 'Manager', '2016-06-11 00:00:00'),
(4, 'Asst. Manager', '2016-06-11 00:00:00'),
(7, 'Executive', '2016-06-11 00:00:00'),
(6, 'Lead', '2016-06-11 00:00:00'),
(3, 'Lead', '2016-06-11 00:00:00');

--1
select FIRST_NAME AS Worker_Name from Worker
--2
SELECT UPPER(FIRST_NAME) AS FIRST_NAME_UPPER
FROM Worker;
--3
select distinct(DEPARTMENT) FROM Worker
--4
select substring(FIRST_NAME,1,3) AS Sub_String from Worker
--5
select charindex('a',FIRST_NAME) as indexs from Worker where FIRST_NAME='Amitabh'
--6
select RTRIM(FIRST_NAME) AS TRIMMEDNAME FROM Worker
--7
select LTRIM(DEPARTMENT) AS LTRIMMED FROM Worker
--8
SELECT DISTINCT DEPARTMENT,LEN(DEPARTMENT) AS LENG FROM Worker 
--9
select REPLACE(FIRST_NAME, 'a', 'A') AS ModifiedName
FROM Worker;
--10
select CONCAT(FIRST_NAME, ' ', LAST_NAME) AS COMPLETE_NAME
FROM Worker;
--11
select * from Worker order by FIRST_NAME ASC
--12
select * from Worker order by FIRST_NAME ASC,
DEPARTMENT DESC
--13
select *
from Worker
WHERE FIRST_NAME IN ('Vipul', 'Satish');
--14
select *
from Worker
WHERE FIRST_NAME not IN ('Vipul', 'Satish');
--15
select * from Worker where DEPARTMENT = 'Admin'
--16
select * from Worker where FIRST_NAME LIKE '%a%'
--17
select * from Worker where FIRST_NAME LIKE '%a'
--18
select * from Worker where FIRST_NAME LIKE '%h' 
and len(FIRST_NAME)=6
--19
select * from Worker where SALARY 
Between 100000 and 500000
--20
select * from Worker where JOINING_DATE Between 
'2014-02-01' AND '2014-02-28';
--21
select FIRST_NAME,SALARY FROM Worker where SALARY BETWEEN 
50000 AND 100000
--22
select DEPARTMENT,COUNT(*)as Num_worker FROM Worker 
group by DEPARTMENT order by Num_worker Desc
--23
select w.*,t.WORKER_TITLE FROM Worker w left join 
Title t on w.WORKER_ID=t.WORKER_REF_ID
--24
SELECT GETDATE() AS CurrentDateTime
--25
select top 5 * from Worker