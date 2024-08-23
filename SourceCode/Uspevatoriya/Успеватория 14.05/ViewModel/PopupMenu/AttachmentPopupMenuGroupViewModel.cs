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
    public class AttachmentPopupMenuGroupViewModel : BasePopupViewModel
    {
        public int idUser { get; set; }
        public ObservableCollection<MenuItemViewModel> Items { get; set; }


        #region Constructor
        //Конструктор 
        public AttachmentPopupMenuGroupViewModel()
        {
            InitializeCommands();
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel {
                        Text = "Меню отчётов...",
                        Type = MenuItemType.Header},
                    new MenuItemViewModel { Text = "Отчёт успеваемости группы", Icon = IconType.File,
                    Command = ReportGroupCommand}
                })
            };
        }
        #endregion

        public ICommand ReportGroupCommand { get; set; }
        public void InitializeCommands()
        {
            ReportGroupCommand = new RelayCommand(ReportGroup);
        }
        private async void ReportGroup()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";
            using (var context = new sqlUspevatoriyaEntities())
            {
                var query = from academicPerfomance in context.AcademicPerfomances
                            join courseStudent in context.CourseStudents on academicPerfomance.IDCousrseStudent equals courseStudent.ID
                            join user in context.Users on courseStudent.IDStudent equals user.ID
                            join lesson in context.Lessons on academicPerfomance.IDLessons equals lesson.ID
                            where courseStudent.IDCourse == storeUserData.idSelectedGroupSidePanel
                            select new
                            {
                                Surname = user.Surname,
                                Name = user.Name,
                                Patronymic = user.Patronymic,
                                Grade = academicPerfomance.Grade,
                                DateTime = lesson.DateTime
                            };
                var resultList = query.ToList();
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Фамилия", typeof(string));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Отчество", typeof(string));
                dataTable.Columns.Add("Оценка", typeof(string));
                dataTable.Columns.Add("Дата и время урока", typeof(string));

                // Заполнение DataTable результатами запроса
                foreach (var result in resultList)
                {
                    dataTable.Rows.Add(result.Surname, result.Name, result.Patronymic, result.Grade,
                        result.DateTime.ToString());
                }
                if (saveFile.ShowDialog() == true)
                {
                    CreateFile(saveFile.FileName, storeUserData.idSelectedUserSidePanel, dataTable);
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

