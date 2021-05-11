using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        
        public Składy składy = null;
        List<Klub> kluby = new List<Klub>();
        List<Pracownik> pracownik = new List<Pracownik>();
        public List<Druzyna> druzyny = new List<Druzyna>();
        public List<Test> test = new List<Test>();
        int pom_klub;
        public int pom_druzyna;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            
            Wybor_Klubu();
        }
       
        private void LoadKluby()
        {
            kluby = SQLiteDataAccess.LoadKlub();
        }
        private void LoadPracownicy(int a)
        {
            pracownik = SQLiteDataAccess.LoadPracownik(a);
        }
        private void LoadDruzyny(int a)
        {
            druzyny = SQLiteDataAccess.LoadDruzyna(a);
        }
        private void LoadTest(int a)
        {
            test = SQLiteDataAccess.LoadTestowy(a);
        }
        private void Wybor_Klubu()
        {
            Title = "1/3 Wybór Klubu";

            LoadKluby();

            ListBox.ItemsSource = null;
            ListBox.ItemsSource = kluby;
            ListBox.DisplayMemberPath = "Kluby";
            ListBox.SelectedValuePath = "ID";

            LoadKluby();
        }
        private void Wybor_Druzyny()
        {
            Title = "2/3 Wybór Drużyny";

            LoadDruzyny(pom_klub);

            ListBox.ItemsSource = null;
            ListBox.ItemsSource = druzyny;
            ListBox.DisplayMemberPath = "Druzyny";

            LoadDruzyny(pom_klub);

            LoadPracownicy(pom_klub);
            Trenerzy.ItemsSource = null;
            Trenerzy.ItemsSource = pracownik;
            Trenerzy.DisplayMemberPath = "Pracownicy";
            Trenerzy.SelectedIndex = 0;
            LoadPracownicy(pom_klub);

        }
        private void Wybor_Testowy()
        {
            Title = "3/3 Wybór Zawodników";

            LoadTest(pom_druzyna);

            ListBox.ItemsSource = null;
            ListBox.ItemsSource = test;
            tabelka.ItemsSource = test;
            ListBox.DisplayMemberPath = "Testowy1";


        }
        
        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (Title == "1/3 Wybór Klubu" && ListBox.SelectedIndex >= 0)
            {
                Wstecz.IsEnabled = true;
                pom_klub = Int32.Parse(ListBox.SelectedValue.ToString());
                Trenerzy.Visibility = Visibility.Visible;
                Wybor_Druzyny();
            }
            else if (Title == "2/3 Wybór Drużyny" && ListBox.SelectedIndex >= 0)
            {
                Wstecz.IsEnabled = true;
                ListBox.Visibility = Visibility.Hidden;
                tabelka.Visibility = Visibility.Visible;
                Trenerzy.Visibility = Visibility.Hidden;
                pom_druzyna = Int32.Parse(ListBox.SelectedValue.ToString());
                Wybor_Testowy();
            }
            else if (Title == "3/3 Wybór Zawodników" && test.Count != 0)
            {
                if (składy != null)
                {
                    
                    składy.Close();
                }
                else
                {
                    test = test.OrderBy(p => p.Rezerwowy).ThenBy(p => p.Pozycja != "Bramkarz").ThenBy(p => p.Numer_Koszulki).ToList();
                    składy = new Składy();
                    składy.Show();
                }
            }


        }
        private void Wstecz_Click(object sender, RoutedEventArgs e)
        {
            if (Title == "1/3 Wybór Klubu")
            {

            }
            else if (Title == "2/3 Wybór Drużyny")
            {
                Wstecz.IsEnabled = false;
                Trenerzy.Visibility = Visibility.Hidden;
                Wybor_Klubu();
            }
            else if (Title == "3/3 Wybór Zawodników")
            {
                ListBox.Visibility = Visibility.Visible;
                tabelka.Visibility = Visibility.Hidden;
                Trenerzy.Visibility = Visibility.Visible;
                Wybor_Druzyny();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (składy != null)
                składy.Close();
        }
    }
}
