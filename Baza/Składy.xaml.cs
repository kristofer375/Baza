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

            Pierwszy.Content = ((MainWindow)Application.Current.MainWindow).test2[0].Numer_Koszulki.ToString().PadLeft(4 - ((MainWindow)Application.Current.MainWindow).test2[0].Numer_Koszulki.ToString().Length, ' ') + ".";
            Pierwszy.Content += "\n" + ((MainWindow)Application.Current.MainWindow).test2[1].Numer_Koszulki.ToString().PadLeft(4 - ((MainWindow)Application.Current.MainWindow).test2[1].Numer_Koszulki.ToString().Length, ' ') + ".";
            Pierwszy.Content += "\n" + ((MainWindow)Application.Current.MainWindow).test2[2].Numer_Koszulki.ToString().PadLeft(4 - ((MainWindow)Application.Current.MainWindow).test2[2].Numer_Koszulki.ToString().Length, ' ') + ".";
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
