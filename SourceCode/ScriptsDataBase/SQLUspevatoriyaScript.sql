create database sqlUspevatoriya
go

use sqlUspevatoriya
go

create table Roles(
	ID int identity(1,1) primary key,
	Name nvarchar(255),
)
go

Create table Users(
	ID int identity(1,1) primary key,
	IDRoles int foreign key references Roles(ID),
	Name nvarchar(255) not null,
	Surname nvarchar(255) not null,
	Patronymic nvarchar(255),
	Phone nvarchar(255),
	IndentificstionDocument nvarchar(255) not null unique,
	Login nvarchar(255) not null unique,
	Password nvarchar(255) not null,
)
go

create table ParentsChild(
	ID int identity(1,1) primary key,
	IDParent int foreign key references Users(ID) not null , 
	IDChildren int foreign key references Users(ID) not null,

)
go

create table CourseName(
	ID int identity(1,1) primary key,
	Name nvarchar(255) not null,
)
go

create table Courses(
	ID int identity(1,1) primary key,
	IDCourseName int foreign key references CourseName(ID) not null,
	IDTeacher int foreign key references Users(ID),
	DateBegin datetime default getdate(),
	DateEnd datetime,
)
go

create table CourseStudent(
	ID int identity(1,1) primary key,
	IDCourse int foreign key references Courses(ID) not null,
	IDStudent int foreign key references Users(ID) ON DELETE CASCADE not null,
)
go

create table Lessons(
	ID int identity(1,1) primary key,
	IDCourse int foreign key references Courses(ID) not null,
	DateTime datetime default getdate(),
	LessonTopic nvarchar(255)
)
go

create table AcademicPerfomances(
	ID int identity(1,1) primary key,
	IDLessons int foreign key references Lessons(ID) not null,
	IDCousrseStudent int foreign key references CourseStudent(ID) ON DELETE CASCADE not null,
	Grade nvarchar(1)
)
go