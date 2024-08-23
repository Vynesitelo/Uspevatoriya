use sqlUspevatoriya
go

create trigger OnAddLessons
on Lessons
after insert 
as
begin
declare @idLessons int, @idCourse int, @maxIdCS int,@idCS int
set @idLessons = (select max(id) from Lessons)
set @idCourse = (select IDCourse from Lessons where id = @idLessons)
set @maxIdCS = (select max(ID) from CourseStudent)
while(@maxIdCS != 0)
begin
if exists(select * from CourseStudent where ID = @maxIdCS and IDCourse = @idCourse)
begin
set @idCS = (select ID from CourseStudent where ID = @maxIdCS)
insert into AcademicPerfomances(IDLessons, IDCousrseStudent)
values(@idLessons, @idCS)
end
set @maxIdCS= @maxIdCS-1
end
end
go

create TRIGGER PreventDuplicateCourseStudent 
ON CourseStudent
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE NOT EXISTS (
            SELECT 1
            FROM Users u
            WHERE u.ID = i.IDStudent
            AND u.IDRoles = 3 
        )
    )
    BEGIN
        RAISERROR ('Only students with role ID 3 are allowed to be added to courses.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE EXISTS (
            SELECT 1
            FROM CourseStudent cs
            WHERE cs.IDCourse = i.IDCourse
            AND cs.IDStudent = i.IDStudent
        )
    )
    BEGIN
        RAISERROR ('Duplicate course and student combination is not allowed.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        INSERT INTO CourseStudent (IDCourse, IDStudent)
        SELECT IDCourse, IDStudent
        FROM inserted
    END
ENd
go


CREATE TRIGGER AllowOnlyTeachersToAddCourses
ON Courses
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE NOT EXISTS (
            SELECT 1
            FROM Users u
            WHERE u.ID = i.IDTeacher
            AND u.IDRoles = 2
        )
    )
    BEGIN
        RAISERROR ('Only users with role ID 2 (teacher) are allowed to add courses.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        INSERT INTO Courses (IDCourseName, IDTeacher, DateBegin, DateEnd)
        SELECT IDCourseName, IDTeacher, DateBegin, DateEnd
        FROM inserted
    END
END
go