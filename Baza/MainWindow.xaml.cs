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
        public Składy składy = null;
        List<Klub> kluby = new List<Klub>();
        List<Pracownik> pracownik = new List<Pracownik>();
        public List<Druzyna> druzyny = new List<Druzyna>();
        List<Test> test = new List<Test>();
        public List<Test> test2 = new List<Test>();
        int pom_klub;
        public int pom_druzyna;
        public MainWindow()
        {
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
            ListBox.DisplayMemberPath = "Testowy1";


        }
        private void Wybor_Zawodnikow()
        {
            Title = "3/3 Wybór Zawodników";
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
                ListBox.Margin = new Thickness(61, 60, 471, 109);
                ListBox2.Visibility = Visibility.Visible;
                Dodaj.Visibility = Visibility.Visible;
                Usun.Visibility = Visibility.Visible;
                UsunWszystko.Visibility = Visibility.Visible;
                Kapitan.Visibility = Visibility.Visible;
                Rezerwa.Visibility = Visibility.Visible;
                Aktualizuj.Visibility = Visibility.Visible;
                tytul1.Visibility = Visibility.Visible;
                tytul2.Visibility = Visibility.Visible;
                Trenerzy.Visibility = Visibility.Hidden;
                pom_druzyna = Int32.Parse(ListBox.SelectedValue.ToString());
                Wybor_Testowy();
            }
            else if (Title == "3/3 Wybór Zawodników" && test2.Count != 0)
            {
                if (składy != null)
                {
                    //Wstecz.IsEnabled = true;
                    //Dodaj.IsEnabled = true;
                    //Aktualizuj.IsEnabled = true;
                    //Usun.IsEnabled = true;
                    //UsunWszystko.IsEnabled = true;
                    //Kapitan.IsEnabled = true;
                    //Rezerwa.IsEnabled = true;
                    składy.Close();
                }
                else
                {
                    //Wstecz.IsEnabled = false;
                    //Dodaj.IsEnabled = false;
                    //Aktualizuj.IsEnabled = false;
                    //Usun.IsEnabled = false;
                    //UsunWszystko.IsEnabled = false;
                    //Kapitan.IsEnabled = false;
                    //Rezerwa.IsEnabled = false;
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
                ListBox.Margin = new Thickness(241, 60, 241, 109);
                ListBox2.Visibility = Visibility.Hidden;
                test2 = new List<Test>();
                ListBox2.ItemsSource = null;
                Dodaj.Visibility = Visibility.Hidden;
                Usun.Visibility = Visibility.Hidden;
                UsunWszystko.Visibility = Visibility.Hidden;
                Kapitan.Visibility = Visibility.Hidden;
                Rezerwa.Visibility = Visibility.Hidden;
                Aktualizuj.Visibility = Visibility.Hidden;
                tytul1.Visibility = Visibility.Hidden;
                tytul2.Visibility = Visibility.Hidden;
                Trenerzy.Visibility = Visibility.Visible;
                Wybor_Druzyny();
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            foreach (Test t in test)
            {
                if (t.ID == Int32.Parse(ListBox.SelectedValue.ToString()))
                {
                    foreach (Test i in test2)
                    {
                        if (t.ID == i.ID)
                            return;
                    }
                    test2.Add(t);
                    
                    if (Kapitan.IsChecked == true)
                    {
                        test2[test2.Count-1].Kapitan = "(C)";
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

                    //test2.Sort((x, y) => x.Numer_Koszulki.CompareTo(y.Numer_Koszulki));
                    test2 = test2.OrderBy(p => p.Rezerwowy).ThenBy(p => p.Pozycja != "Bramkarz").ThenBy(p => p.Numer_Koszulki).ToList();
                }
            }
            
            ListBox2.ItemsSource = null;
            ListBox2.ItemsSource = test2;
            ListBox2.DisplayMemberPath = "Testowy2";
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
            ListBox2.DisplayMemberPath = "Testowy2";
        }

        private void UsunWszystko_Click(object sender, RoutedEventArgs e)
        {
            test2 = new List<Test>();
            ListBox2.ItemsSource = test2;
        }

        private void Rezerwa_Click(object sender, RoutedEventArgs e)
        {
            Kapitan.IsChecked = false;
        }

        private void Kapitan_Click(object sender, RoutedEventArgs e)
        {
            Rezerwa.IsChecked = false;
        }

        private void Aktualizuj_Click(object sender, RoutedEventArgs e)
        {
            foreach (Test t in test2)
            {
                if (ListBox2.SelectedIndex >= 0)
                {
                    if (Kapitan.IsChecked == true)
                        test2[ListBox2.SelectedIndex].Kapitan = "(C)";
                    else
                        test2[ListBox2.SelectedIndex].Kapitan = null;

                    if (Rezerwa.IsChecked == true)
                        test2[ListBox2.SelectedIndex].Rezerwowy = "R";
                    else
                        test2[ListBox2.SelectedIndex].Rezerwowy = null;

                }
            }

            test2 = test2.OrderBy(p => p.Rezerwowy).ThenBy(p => p.Pozycja != "Bramkarz").ThenBy(p => p.Numer_Koszulki).ToList();
            ListBox2.ItemsSource = null;
            ListBox2.ItemsSource = test2;
            ListBox2.DisplayMemberPath = "Testowy2";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (składy != null)
                składy.Close();
        }
    }
}
