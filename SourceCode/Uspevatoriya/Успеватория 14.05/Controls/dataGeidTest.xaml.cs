using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для dataGeidTest.xaml
    /// </summary>
    public partial class dataGeidTest : UserControl
    {
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }
        public dataGeidTest()
        {
            InitializeComponent();
            List<Phone> phonesList = new List<Phone>
{
    new Phone { Title="iPhone 6S", Company="Apple", Price=54990 },
    new Phone {Title="Lumia 950", Company="Microsoft", Price=39990 },
    new Phone {Title="Nexus 5X", Company="Google", Price=29990 }
};
            phonesGrid.ItemsSource = phonesList;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
