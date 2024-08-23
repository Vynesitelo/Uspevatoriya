use sqlUspevatoriya
go

-- ���������� ������� Role (����)
INSERT INTO Roles (Name) VALUES 
(N'�������������'),
(N'�������������'),
(N'�������'),
(N'��������')

-- ���������� ������� Users (������������)
INSERT INTO Users (IDRoles, Name, Surname, Patronymic, Phone, IndentificstionDocument, Login, Password) VALUES 
(1, N'����', N'������', N'��������', '123456789', '2451423618', 'admin1', 'adminpass1'),
(2, N'����', N'������', N'��������', '987654321', '2451423619', 'teacher1', 'teacherpass1'),
(3, N'����', N'��������', N'��������', '555555555', '2451423620', 'student1', 'studentpass1'),
(4, N'�����', N'�������', N'���������', '111111111', '2451423621', 'parent1', 'parentpass1'),
(1, N'�����', N'�������', N'��������', '222222222', '2451423622', 'admin2', 'adminpass2'),
(2, N'�������', N'�������', N'��������', '333333333', '2451423623', 'teacher2', 'teacherpass2'),
(3, N'�������', N'�����', N'��������������', '444444444', '2451423624', 'student2', 'studentpass2'),
(4, N'�����', N'���������', N'������������', '666666666', '2451423625', 'parent2', 'parentpass2'),
(2, N'��������', N'�������', N'����������', '777777777', '2451423626', 'teacher3', 'teacherpass3'),
(3, N'�������', N'�������', N'�����������', '888888888', '2451423627', 'student3', 'studentpass3'),
(1, N'���������', N'������', N'�������������', '999999999', '2451423628', 'admin3', 'adminpass3'),
(2, N'�������', N'�������', N'��������', '101010101', '2451423629', 'teacher4', 'teacherpass4'),
(3, N'�����', N'�������', N'����������', '121212121', '2451423630', 'student4', 'studentpass4'),
(4, N'����', N'��������', N'��������', '131313131', '2451423631', 'parent3', 'parentpass3'),
(1, N'��������', N'���������', N'����������', '141414141', '2451423632', 'admin4', 'adminpass4'),
(2, N'������', N'��������', N'�������������', '151515151', '2451423633', 'teacher5', 'teacherpass5'),
(3, N'�����', N'������', N'��������', '161616161', '2451423634', 'student5', 'studentpass5'),
(4, N'������', N'��������', N'��������', '171717171', '2451423635', 'parent4', 'parentpass4'),
(1, N'�����', N'����������', N'��������', '181818181', '2451423636', 'admin5', 'adminpass5'),
(2, N'�����', N'�������', N'�������������', '191919191', '2451423637', 'teacher6', 'teacherpass6'),
(3, N'��������', N'�������', N'���������', '202020202', '2451423638', 'student6', 'studentpass6'),
(4, N'�����', N'��������', N'��������', '212121212', '2451423639', 'parent5', 'parentpass5'),
(1, N'��������', N'������', N'��������', '222222222', '2451423640', 'admin6', 'adminpass6'),
(2, N'����', N'�������', N'�������������', '232323232', '2451423641', 'teacher7', 'teacherpass7'),
(3, N'�����', N'�������', N'������������', '242424242', '2451423642', 'student7', 'studentpass7'),
(4, N'�������', N'���������', N'���������', '252525252', '2451423643', 'parent6', 'parentpass6'),
(1, N'�����', N'�������', N'����������', '262626262', '2451423644', 'admin7', 'adminpass7'),
(2, N'���������', N'�������', N'��������', '272727272', '2451423645', 'teacher8', 'teacherpass8'),
(3, N'����������', N'��������', N'��������', '282828282', '2451423646', 'student8', 'studentpass8'),
(4, N'������', N'������', N'���������', '292929292', '2451423647', 'parent7', 'parentpass7'),
(1, N'�������', N'������', N'�������������', '303030303', '2451423648', 'admin8', 'adminpass8'),
(2, N'�������', N'�������', N'��������', '313131313', '2451423649', 'teacher9', 'teacherpass9'),
(3, N'�������', N'��������', N'��������', '323232323', '2451423650', 'student9', 'studentpass9'),
(4, N'�����', N'��������', N'����������', '333333333', '2451423651', 'parent8', 'parentpass8'),
(1, N'��������', N'�������', N'��������', '343434343', '2451423652', 'admin9', 'adminpass9'),
(2, N'��������', N'�������', N'��������', '353535353', '2451423653', 'teacher10', 'teacherpass10'),
(3, N'���������', N'�������', N'�������������', '363636363', '2451423654', 'student10', 'studentpass10'),
(4, N'����', N'������', N'����������', '373737373', '2451423655', 'parent9', 'parentpass9'),
(1, N'����', N'��������', N'��������', '383838383', '2451423656', 'admin10', 'adminpass10'),
(2, N'����', N'������', N'��������', '393939393', '2451423657', 'teacher11', 'teacherpass11');

-- ���������� ������� ParentsChild
INSERT INTO ParentsChild (IDParent, IDChildren) VALUES 
(4, 3),  -- ��������: ����� �������, ������: ���� ��������
(4, 31), -- ��������: ����� �������, ������: �������� ������
(4, 32), -- ��������: ����� �������, ������: ������� �������
(8, 33), -- ��������: ����� ���������, ������: ������� ��������
(8, 34), -- ��������: ����� ���������, ������: ����� ��������
(12, 35), -- ��������: �������� ���������, ������: �������� �������
(16, 36), -- ��������: ����� �������, �������: �������� �������
(16, 37), -- ��������: ����� �������, �������: ��������� �������
(20, 38), -- ��������: �������� �������, �������: ���� ������
(20, 39), -- ��������: �������� �������, �������: ���� ��������
(24, 40); -- ��������: ������� �������, �������: ���� ������

-- ���������� ������� CourseName (�������������)
INSERT INTO CourseName (Name) VALUES 
(N'����������'),
(N'������'),
(N'����������'),
(N'�����'),
(N'�������'),
(N'��������'),
(N'���������'),
(N'�����������')

-- ���������� ������� Courses (�����)
INSERT INTO Courses (IDCourseName, IDTeacher, DateBegin, DateEnd) VALUES 
(1, 2, 2023-06-30, 2023-11-30), -- ����������, �������������: ������� �������
(2, 6, 2023-06-30, 2023-11-30), -- ������, �������������: ����� �������
(3, 9, 2023-06-30, 2023-11-30), -- ����������, �������������: ���� ��������
(4, 12, 2023-06-30, 2023-11-30), -- �����, �������������: �������� ������
(5, 16, 2023-06-30, 2023-11-30), -- �������, �������������: ���� �������
(6, 20, 2023-06-30, 2023-11-30), -- ��������, �������������: ������� �������
(7, 24, 2023-06-30, 2023-11-30), -- ���������, �������������: ����� �������
(8, 28, 2023-06-30, 2023-11-30), -- ����������� ����, �������������: ���� ��������
(8, 32, 2023-06-30, 2023-11-30),
(1, 36, 2023-06-30, 2023-11-30),
(2, 40, 2023-06-30, 2023-11-30),
(3, 40, 2023-06-30, 2023-11-30),
(4, 40, 2023-06-30, 2023-11-30),
(5, 2, 2023-06-30, 2023-11-30),
(6, 2,2023-06-30, 2023-11-30),
(7, 2, 2023-06-30, 2023-11-30),
(8, 6, 2023-06-30, 2023-11-30),
(1, 9, 2023-06-30, 2023-11-30),
(2, 9, 2023-06-30, 2023-11-30),
(3, 9, 2023-06-30, 2023-11-30),
(4, 16, 2023-06-30, 2023-11-30),
(5, 24, 2023-06-30, 2023-11-30),
(6, 20, 2023-06-30, 2023-11-30),
(7, 12, 2023-06-30, 2023-11-30),
(8, 32, 2023-06-30, 2023-11-30),
(1, 36, 2023-06-30, 2023-11-30),
(2, 2, 2023-06-30, 2023-11-30),
(3, 32, 2023-06-30, 2023-11-30),
(4, 36, 2023-06-30, 2023-11-30),
(5, 2, 2023-06-30, 2023-11-30),
(6, 12, 2023-06-30, 2023-11-30),
(7, 16, 2023-06-30, 2023-11-30),
(8, 24, 2023-06-30, 2023-11-30),
(1, 28, 2023-06-30, 2023-11-30),
(2, 32, 2023-06-30, 2023-11-30),
(3, 36, 2023-06-30, 2023-11-30),
(4, 40, 2023-06-30, 2023-11-30),
(5, 2, 2023-06-30, 2023-11-30),
(6, 2, 2023-06-30, 2023-11-30);

-- ���������� ������� CourseStudent (�������������)
INSERT INTO CourseStudent (IDCourse, IDStudent) VALUES 
(1, 3), 
(1, 7),
(1, 10),
(2, 13),
(2, 10),
(2, 21),
(3, 25),
(3, 29),
(3, 33),
(4, 37),
(4, 33),
(4, 21),
(5, 3),
(5, 33),
(5, 10),
(6, 37),
(6, 33),
(6, 13),
(7, 37),
(7, 10),
(7, 33),
(8, 10),
(8, 17),
(8, 21),
(1, 33),
(1, 25),
(1, 37),
(2, 3),
(2, 37),
(2, 17),
(3, 17),
(3, 10),
(3, 3),
(4, 3),
(4, 10),
(4, 25),
(5, 37),
(5, 7),
(5, 25),
(6, 3),
(6, 25),
(7, 3),
(7, 17),
(7, 25),
(8, 7),
(8, 3),
(8, 25);

-- ���������� ������� Lessons (�������)
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(1, '2023-01-01 08:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(2, '2023-01-02 09:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(3, '2023-01-03 10:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(4, '2023-01-04 11:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(5, '2023-01-05 12:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(6, '2023-01-06 13:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(7, '2023-01-07 14:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(8, '2023-01-08 15:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(1, '2023-01-01 08:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(2, '2023-01-02 09:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(3, '2023-01-03 10:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(4, '2023-01-04 11:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(5, '2023-01-05 12:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(6, '2023-01-06 13:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(7, '2023-01-07 14:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(8, '2023-01-08 15:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(1, '2023-01-01 08:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(2, '2023-01-02 09:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(3, '2023-01-03 10:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(4, '2023-01-04 11:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(5, '2023-01-05 12:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(6, '2023-01-06 13:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(7, '2023-01-07 14:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(8, '2023-01-08 15:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(1, '2023-01-01 08:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(2, '2023-01-02 09:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(3, '2023-01-03 10:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(4, '2023-01-04 11:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(5, '2023-01-05 12:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(6, '2023-01-06 13:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(7, '2023-01-07 14:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(8, '2023-01-08 15:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(1, '2023-01-01 08:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(2, '2023-01-02 09:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(3, '2023-01-03 10:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(4, '2023-01-04 11:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(5, '2023-01-05 12:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(6, '2023-01-06 13:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(7, '2023-01-07 14:00:00')
INSERT INTO Lessons (IDCourse, DateTime) VALUES
(8, '2023-01-08 15:00:00')
