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
        List<Druzyna> druzyny = new List<Druzyna>();
        List<Test> test = new List<Test>();
        List<Test> test2 = new List<Test>();
        int pom_klub;
        int pom_druzyna;
        public MainWindow()
        {
            InitializeComponent();

            Wybor_Klubu();
        }
       
        private void LoadKluby()
        {
            kluby = SQLiteDataAccess.LoadKlub();
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
            ListBox2.SelectedValuePath = "ID";

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

        }
        private void Wybor_Testowy()
        {
            Title = "3/3 Wybór Zawodników";

            LoadTest(pom_druzyna);

            ListBox.ItemsSource = null;
            ListBox.ItemsSource = test;
            ListBox.DisplayMemberPath = "Testowy";

            LoadTest(pom_druzyna);


        }
        private void Wybor_Zawodnikow()
        {
            Title = "3/3 Wybór Zawodników";
        }
        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex >= 0)
            {
                Wstecz.IsEnabled = true;
                if (Title == "1/3 Wybór Klubu")
                {
                    pom_klub = Int32.Parse(ListBox.SelectedValue.ToString());
                    Wybor_Druzyny();
                }
                else if (Title == "2/3 Wybór Drużyny")
                {
                    ListBox.Margin = new Thickness(61, 60, 471, 109);
                    ListBox2.Visibility = Visibility.Visible;
                    Dodaj.Visibility = Visibility.Visible;
                    Usun.Visibility = Visibility.Visible;
                    UsunWszystko.Visibility = Visibility.Visible;
                    Kapitan.Visibility = Visibility.Visible;
                    Rezerwa.Visibility = Visibility.Visible;
                    pom_druzyna = Int32.Parse(ListBox.SelectedValue.ToString());
                    Wybor_Testowy();
                }
                else if (Title == "3/3 Wybór Zawodników")
                {
                    MessageBox.Show(ListBox.SelectedValue.ToString());
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
                Wybor_Klubu();
            }
            else if (Title == "3/3 Wybór Zawodników")
            {
                ListBox.Margin = new Thickness(241, 60, 241, 109);
                ListBox2.Visibility = Visibility.Hidden;
                test2 = new List<Test>();
                ListBox2.ItemsSource = null;
                Dodaj.Visibility = Visibility.Hidden;
                Usun.Visibility = Visibility.Hidden;
                UsunWszystko.Visibility = Visibility.Hidden;
                Kapitan.Visibility = Visibility.Hidden;
                Rezerwa.Visibility = Visibility.Hidden;
                Wybor_Druzyny();
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            foreach (Test t in test)
            {
                if (t.ID == Int32.Parse(ListBox.SelectedValue.ToString()))
                {
                    test2.Add(t);
                    if (Kapitan.IsChecked == true)
                    {
                        test2[test2.Count-1].Kapitan = "C";
                    }
                    else
                    {
                        test2[test2.Count - 1].Kapitan = null;
                    }
                    if (Rezerwa.IsChecked == true)
                    {
                        test2[test2.Count - 1].Rezerwowy = "R";
                    }
                    else
                    {
                        test2[test2.Count - 1].Rezerwowy = null;
                    }
                }
            }
            
            ListBox2.ItemsSource = null;
            ListBox2.ItemsSource = test2;
            ListBox2.DisplayMemberPath = "Testowy";
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            foreach (Test t in test2)
            {
                if (ListBox2.SelectedValue != null && t.ID == Int32.Parse(ListBox2.SelectedValue.ToString()))
                {
                    test2.Remove(t);
                    break;
                }
            }

            ListBox2.ItemsSource = null;
            ListBox2.ItemsSource = test2;
            ListBox2.DisplayMemberPath = "Testowy";
        }

        private void UsunWszystko_Click(object sender, RoutedEventArgs e)
        {
            test2 = new List<Test>();
            ListBox2.ItemsSource = test2;
        }
    }
}
