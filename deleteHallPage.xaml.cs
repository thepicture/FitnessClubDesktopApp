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
    /// Interaction logic for deleteHallPage.xaml
    /// </summary>
    public partial class deleteHallPage : Page
    {
        public deleteHallPage()
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
                hallRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void textBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            btnDeleteHall.IsEnabled = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING))
                {
                    SqlCommand command =
                    new SqlCommand("select * from HALL where H_ID = '" + textBoxID.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        textBoxName.Text = (read["H_NAME"].ToString());
                        FillDataGrid();
                    }
                    read.Close();
                }
            }
            catch
            {

            }
        }

        private void btnDeleteHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "DELETE FROM HALL WHERE H_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxName.Text = "";
                btnDeleteHall.IsEnabled = false;
                MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Удалить зал";
        }

        private void btnDeleteHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void hallRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)hallRelation.SelectedItems[0];
            textBoxID.Text = row["H_ID"].ToString();
        }
    }
}
