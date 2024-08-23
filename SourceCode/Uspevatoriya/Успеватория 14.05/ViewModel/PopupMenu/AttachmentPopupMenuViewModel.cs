using Microsoft.Win32;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    public class AttachmentPopupMenuViewModel : BasePopupViewModel
    {
        public int idUser { get; set; }
        public ObservableCollection<MenuItemViewModel> Items { get; set; }


        #region Constructor
        //Конструктор 
        public AttachmentPopupMenuViewModel()
        {
            InitializeCommands();
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel {
                        Text = "Меню отчётов...",
                        Type = MenuItemType.Header},
                    new MenuItemViewModel { Text = "Отчёт студента по всем курсам", Icon = IconType.File,
                    Command = ReportAllCoursesCommand},
                    new MenuItemViewModel { Text = "Отчёт среднего балла студента по курсам", Icon = IconType.Picture,
                    }
                })
            };
        }
        #endregion

        public ICommand ReportAllCoursesCommand { get; set; }
        public ICommand ReportAVGMarkCom { get; set; }
        public void InitializeCommands()
        {
            ReportAllCoursesCommand = new RelayCommand(ReportAllCoursesCommandExecute);
            ReportAVGMarkCom = new RelayCommand(ReportAVGMarkCommand);
        }
        private async void ReportAllCoursesCommandExecute()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";
            using (var context = new sqlUspevatoriyaEntities())
            {
                var query = from user in context.Users
                            join courseStudent in context.CourseStudents on user.ID equals courseStudent.IDStudent
                            join course in context.Courses on courseStudent.IDCourse equals course.ID
                            join courseName in context.CourseNames on course.IDCourseName equals courseName.ID
                            join academicPerformance in context.AcademicPerfomances on courseStudent.ID equals academicPerformance.IDCousrseStudent
                            join lesson in context.Lessons on academicPerformance.IDLessons equals lesson.ID
                            where user.ID == idUser
                            orderby courseName.Name
                            select new
                            {
                                CourseName = courseName.Name,
                                UserName = user.Name,
                                UserSurname = user.Surname,
                                UserPatronymic = user.Patronymic,
                                LessonDateTime = lesson.DateTime,
                                PerformanceGrade = academicPerformance.Grade
                            };
                var resultList = query.ToList();
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Фамилия", typeof(string));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Отчество", typeof(string));
                dataTable.Columns.Add("Наименование курса", typeof(string));
                dataTable.Columns.Add("Дата и время урока", typeof(string));
                dataTable.Columns.Add("Оценка", typeof(string));

                // Заполнение DataTable результатами запроса
                foreach (var result in resultList)
                {
                    dataTable.Rows.Add(result.UserSurname, result.UserName, result.UserPatronymic, result.CourseName,
                        result.LessonDateTime.ToString(), result.PerformanceGrade);
                }
                if (saveFile.ShowDialog() == true)
                {
                    CreateFile(saveFile.FileName, storeUserData.idSelectedUserSidePanel, dataTable);
                }
            }

        }
        private async void ReportAVGMarkCommand()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";
            using (var context = new sqlUspevatoriyaEntities())
            {
                var query = from user in context.Users
                            join courseStudent in context.CourseStudents on user.ID equals courseStudent.IDStudent
                            join course in context.Courses on courseStudent.IDCourse equals course.ID
                            join courseName in context.CourseNames on course.IDCourseName equals courseName.ID
                            join academicPerformance in context.AcademicPerfomances on courseStudent.ID equals academicPerformance.IDCousrseStudent
                            join lesson in context.Lessons on academicPerformance.IDLessons equals lesson.ID
                            where user.ID == idUser
                            orderby courseName.Name
                            select new
                            {
                                CourseName = courseName.Name,
                                UserName = user.Name,
                                UserSurname = user.Surname,
                                UserPatronymic = user.Patronymic,
                                LessonDateTime = lesson.DateTime,
                                PerformanceGrade = academicPerformance.Grade
                            };
                var resultList = query.ToList();
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Фамилия", typeof(string));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Отчество", typeof(string));
                dataTable.Columns.Add("Наименование курса", typeof(string));
                dataTable.Columns.Add("Дата и время урока", typeof(string));
                dataTable.Columns.Add("Оценка", typeof(string));

                // Заполнение DataTable результатами запроса
                foreach (var result in resultList)
                {
                    dataTable.Rows.Add(result.UserSurname, result.UserName, result.UserPatronymic, result.CourseName,
                        result.LessonDateTime.ToString(), result.PerformanceGrade);
                }
                var groupedRows = dataTable.AsEnumerable().GroupBy(row => row.Field<string>("Наименование курса"));
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("Наименование курса", typeof(string));
                resultTable.Columns.Add("Средняя оценка", typeof(double));

                // Заполнение новой DataTable данными из сгруппированных строк
                foreach (var group in groupedRows)
                {
                    // Проверка на наличие строк в группе, не равных "Н"
                    if (group.Any(row => row.Field<string>("Оценка") != "Н"))
                    {
                        // Вычисление средней оценки для группы
                        double averageGrade = group.Where(row => row.Field<string>("Оценка") != "Н")
                            .Average(row => double.Parse(row.Field<string>("Оценка")));

                        // Добавление новой строки в результирующую таблицу
                        resultTable.Rows.Add(group.Key, averageGrade);
                    }
                    else
                    {
                        // Добавление новой строки в результирующую таблицу с пустым значением средней оценки
                        resultTable.Rows.Add(group.Key, null);
                    }
                }
                if (saveFile.ShowDialog() == true)
                {
                    CreateFile(saveFile.FileName, storeUserData.idSelectedUserSidePanel, resultTable);
                }
            }
        }


        public void CreateFile(string path, int idUser, DataTable dataTable)
        {
            if (path != string.Empty)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Создание новой книги Excel
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Создание нового листа
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Лист1");

                    // ... (код для создания и заполнения DataTable)
                    worksheet.Cells.LoadFromDataTable(dataTable, true);

                    // Автоматический подбор ширины столбцов
                    worksheet.Cells.AutoFitColumns();

                    FileInfo excelFile = new FileInfo(path);
                    using (FileStream stream = excelFile.Create())
                    {
                        package.SaveAs(stream);
                    }
                }

            }
        }
    }

}

