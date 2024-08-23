using System.ComponentModel;
using System.Linq;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    public class GroupTableItemViewModel : BaseViewModel
    {
        #region Private Members

        private readonly IRepository<AcademicPerfomance> repositoryAP;
        public string editGrade;
        public string editInitials;
        public string editDateTime;
        public string editidAP;
        private string _dgGrade;
        private string _dgInitials;
        private string _dgDateTime;
        private string _idAP;

        #endregion
        #region Public Properties

        public string id
        {
            get { return _idAP; }
            set
            {
                _idAP = value;
                OnPropertyChangeds("idAP");
            }
        }
        /// <summary>
        /// ФИО студента
        /// </summary>
        public string dgInitials
        {
            get { return _dgInitials; }
            set
            {
                _dgInitials = value;
                OnPropertyChangeds("dgInitials");
            }
        }
        /// <summary>
        /// Оценка
        /// </summary>
        public string dgGrade
        {
            get { return _dgGrade; }
            set
            {
                _dgGrade = value;
                OnPropertyChangeds("dgGrade");
                if (string.IsNullOrEmpty(_dgGrade))
                {

                }
            }
        }
        /// <summary>
        /// Дата урока
        /// </summary>
        public string dgDateTime
        {
            get { return _dgDateTime; }
            set
            {
                _dgDateTime = value;
                OnPropertyChangeds("dgDateTime");
            }
        }
        #endregion
        #region Constructor
        public GroupTableItemViewModel()
        {
            repositoryAP = DI.RepositoryAcademicPerfomance;

        }
        #endregion

        public event PropertyChangedEventHandler PropertyChangeds;

        protected void OnPropertyChangeds(string propertyName)
        {
            PropertyChangeds?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //Запись изменяемых данных
            switch (propertyName)
            {
                case "dgDateTime": editDateTime = dgDateTime; break;
                case "dgInitials": editInitials = dgInitials; break;
                case "dgGrade": editGrade = dgGrade; break;
                case "idAP": editidAP = id; break;
            }
            if (!string.IsNullOrEmpty(dgGrade))
            {
                if (dgGrade != "2" && dgGrade != "3" && dgGrade != "4" && dgGrade != "5" && dgGrade != "Н" && dgGrade != "н" && dgGrade != " ")
                {
                    DI.UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        Title = "Ошибка",
                        Message = "Проверьте верность введёных значений",
                        OkText = "OK",
                    });
                    dgGrade = " ";
                }
                else
                {
                    try
                    {
                        if (id != null)
                        {
                            var selected = repositoryAP.Items.Where(item => item.ID.ToString() == id).FirstOrDefault();

                            selected.Grade = editGrade;
                            repositoryAP.Update(selected);
                        }
                    }
                    catch
                    {
                        DI.UI.ShowMessage(new MessageBoxDialogViewModel
                        {
                            Title = "Ошибка",
                            Message = "Проверьте верность введёных значений",
                            OkText = "OK",
                        });
                    }
                }

            }


        }
    }

}
