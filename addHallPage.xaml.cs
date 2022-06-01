using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for addHallPage.xaml
    /// </summary>
    public partial class addHallPage : Page
    {
        public addHallPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = "SELECT * FROM HALL";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Hall");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void btnAddHall_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "INSERT INTO HALL (H_NAME) VALUES ('" + this.textBoxName.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Зал успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Зал не добавлен. Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Добавить зал";
        }

        private void btnAddHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = $"SELECT * FROM HALL WHERE H_NAME LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Hall");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
