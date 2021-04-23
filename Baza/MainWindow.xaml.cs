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

namespace Baza
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Klub> kluby = new List<Klub>();
        public MainWindow()
        {
            InitializeComponent();

            LoadKluby();

            klubyListBox.ItemsSource = null;
            klubyListBox.ItemsSource = kluby;
            klubyListBox.DisplayMemberPath = "Kluby";

            LoadKluby();
        }
        private void LoadKluby()
        {
            kluby = SQLiteDataAccess.LoadKlub();
        }
    }
}
