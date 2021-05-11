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
using System.Windows.Shapes;

namespace Baza
{
    /// <summary>
    /// Logika interakcji dla klasy Składy.xaml
    /// </summary>
    public partial class Składy : Window
    {
        public Składy()
        {
            InitializeComponent();
            Pierwszy.Content = "";
            Rezerwa.Content = "";
            foreach (Druzyna d in ((MainWindow)Application.Current.MainWindow).druzyny)
            {
                if (d.ID == ((MainWindow)Application.Current.MainWindow).pom_druzyna)
                {
                    NazwaDruzyny.Content = d.Nazwa;
                    break;
                }
            }
            foreach (Test t in ((MainWindow)Application.Current.MainWindow).test)
            {
                if (t.CzyGra == true)
                {
                    if (t.CzyRezerwowy == false)
                    {
                        Pierwszy.Content += t.Numer_Koszulki.ToString().PadLeft(4 - t.Numer_Koszulki.ToString().Length, ' ') + $". { t.Nazwisko } { t.Imie } {(t.CzyKapitan ? "(C)" : "")}\n";
                    }
                    else
                    {
                        Rezerwa.Content += t.Numer_Koszulki.ToString().PadLeft(4 - t.Numer_Koszulki.ToString().Length, ' ') + $". { t.Nazwisko } { t.Imie }\n";
                    }
                }
            }
            Trener.Content = "\n\n\n\n\n\n\n\n\n\nTrener - " + ((MainWindow)Application.Current.MainWindow).Trenerzy.SelectedValue;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).składy = null;
            }
            catch
            {

            }
        }
    }
}
