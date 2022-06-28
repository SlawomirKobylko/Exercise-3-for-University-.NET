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

namespace Exercise_3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public MainWindow()
        {
            DataContext = model;
            InitializeComponent();
        }

        private void DisplayProperties_Click(object sender, RoutedEventArgs e)
        {
            ListBox listPersons = (ListBox)this.FindName("DataList");
            Films forWhom = (Films)listPersons.SelectedItem;
            if (forWhom != null)
                (new DetailWindow(forWhom)).Show();
        }

        private void NewElement(object sender, RoutedEventArgs e)
        {
            Films newfilm = model.AddnewPerson();
            ListBox listofPersons = (ListBox)this.FindName("DataList");
            (new DetailWindow(newfilm)).Show();
        }
    }
}
