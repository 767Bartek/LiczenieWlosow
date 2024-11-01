using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiczenieWlosow


{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Glowa glowa;

        public MainWindow()
        {
            InitializeComponent();
            glowa = new Glowa(); // Tworzymy instancję klasy Glowa
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(GestoscWlosow.Text, out double gestosc) &&
                double.TryParse(ObwodGlowy.Text, out double obwod) &&
                double.TryParse(WysokoscCzola.Text, out double wysokoscCzola))
            {
                glowa.UstawWartosci(gestosc, obwod, wysokoscCzola);
                double liczbaWlosow = glowa.ObliczLiczbeWlosow();

                MessageBox.Show($"Szacunkowa liczba włosów na głowie: {liczbaWlosow}");
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić prawidłowe wartości.");
            }
        }
    }

    public class Glowa
    {
        private double gestosc;
        private double obwod;
        private double wysokoscCzola;

        public Glowa()
        {
            gestosc = 200;
            obwod = 55;
            wysokoscCzola = 6;
        }

        public void UstawWartosci(double gestosc, double obwod, double wysokoscCzola)
        {
            this.gestosc = gestosc;
            this.obwod = obwod;
            this.wysokoscCzola = wysokoscCzola;
        }

        // Metoda obliczająca liczbę włosów
        public double ObliczLiczbeWlosow()
        {
            double powierzchnia = obwod * wysokoscCzola; // Przybliżona powierzchnia na podstawie obwodu i wysokości
            return gestosc * powierzchnia;
        }
    }
}