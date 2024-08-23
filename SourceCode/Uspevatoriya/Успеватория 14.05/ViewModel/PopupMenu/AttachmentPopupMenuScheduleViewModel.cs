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
    public class AttachmentPopupMenuScheduleViewModel : BasePopupViewModel
    {
        public int idUser { get; set; }
        public ObservableCollection<MenuItemViewModel> Items { get; set; }


        #region Constructor
        //Конструктор 
        public AttachmentPopupMenuScheduleViewModel()
        {
            InitializeCommands();
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel {
                        Text = "Меню отчётов...",
                        Type = MenuItemType.Header},
                    new MenuItemViewModel { Text = "Импорт расписания в EXCEL", Icon = IconType.File,
                    Command = ReportScheduleCommand}
                })
            };
        }
        #endregion

        public ICommand ReportScheduleCommand { get; set; }
        public void InitializeCommands()
        {
            ReportScheduleCommand = new RelayCommand(ReportSchedule);
        }
        private async void ReportSchedule()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";
            using (var context = new sqlUspevatoriyaEntities())
            {
                var query = from lesson in context.Lessons
                            join academicPerformance in context.AcademicPerfomances on lesson.ID equals academicPerformance.IDLessons
                            join courseStudent in context.CourseStudents on academicPerformance.IDCousrseStudent equals courseStudent.ID
                            where courseStudent.IDCourse == 1
                            select new { id = lesson.ID, DateTime = lesson.DateTime };
                var resultList = query.ToList();
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Урок номер", typeof(string));
                dataTable.Columns.Add("Дата и время урока", typeof(string));

                // Заполнение DataTable результатами запроса
                foreach (var result in resultList)
                {
                    dataTable.Rows.Add(result.id, result.DateTime);
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

