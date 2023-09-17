using Microsoft.Win32;
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
    /// Logika interakcji dla klasy Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

     

        private void Plog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AppData;Integrated Security=True;");
                con.Open();
                string check_data = "SELECT * FROM [dbo].[Klient] where Log_in=@Log_in and Haslo=@Haslo";
                SqlCommand cmd = new SqlCommand(check_data, con);


                cmd.Parameters.AddWithValue("@Log_in", login.Text);
                cmd.Parameters.AddWithValue("@Haslo", Haslo.Text);
                cmd.ExecuteNonQuery();

                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();


                if (Count > 0)
                {
                    Widok Wi = new Widok();
                    this.Close();
                    Wi.Show();
                }
                else
                {
                    MessageBox.Show("Login albo hasło jest niepoprawne!");
                }
            }
            catch
            {
                MessageBox.Show("Konto utworzone! Uruchom ponownie aplikację!");
            }
        }

        private void Prejestr_Click(object sender, RoutedEventArgs e)
        {
            Rejestracaja re = new Rejestracaja();
            this.Close();
            re.Show();
        }

        private void Haslo_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
