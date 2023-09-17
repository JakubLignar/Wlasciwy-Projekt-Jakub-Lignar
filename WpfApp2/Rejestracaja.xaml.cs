using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy Rejestracaja.xaml
    /// </summary>
    public partial class Rejestracaja : Window
    {
       

        public Rejestracaja()
        {

            InitializeComponent();

        }

        private void rejestracja_login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rejestracja_haslo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rejestracja_adres_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Rejestracja_nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rejestracja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True");
                con.Open();

                string add_data= "INSERT INTO dbo.Klient (Id_Klienta, Haslo, Imie, Nazwisko) VALUES (@Id_Klienta, @Haslo, @Imie, @Nazwisko)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Id_Klienta", rejestracja_login.Text);
                cmd.Parameters.AddWithValue("@Haslo", rejestracja_haslo.Text);
                cmd.Parameters.AddWithValue("@Imie", rejestracja_Imie.Text);
                cmd.Parameters.AddWithValue("@Nazwisko", Rejestracja_nazwisko.Text);
                cmd.ExecuteNonQuery();


                con.Close();
                rejestracja_login.Text = "";
                rejestracja_haslo.Text = "";
                rejestracja_Imie.Text = "";
                Rejestracja_nazwisko.Text = "";
                Logowanie log = new Logowanie();
                this.Close();
                log.Show();
            }
            catch
            {
                MessageBox.Show("Błąd!");
            }
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            Logowanie log = new Logowanie();
            this.Close();
            log.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zostałem pokonany przez środowisko");
        }
    }
}
