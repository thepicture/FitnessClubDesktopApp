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
    /// Interaction logic for deleteSubscriptionPage.xaml
    /// </summary>
    public partial class deleteSubscriptionPage : Page
    {
        public deleteSubscriptionPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = "SELECT * FROM SUBSCRIPTION";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Subscription");
                sda.Fill(dt);
                subscriptionRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void textBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxStartDate.Text = "";
            textBoxEndDate.Text = "";
            btnDeleteSubscription.IsEnabled = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING))
                {
                    SqlCommand command =
                    new SqlCommand("select * from SUBSCRIPTION where S_ID = '" + textBoxID.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        textBoxStartDate.Text = (read["S_STARTDATE"].ToString());
                        textBoxEndDate.Text = (read["S_ENDDATE"].ToString());
                        FillDataGrid();
                    }
                    read.Close();
                }
            }
            catch
            {

            }
        }

        private void btnDeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "DELETE FROM SUBSCRIPTION WHERE S_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxStartDate.Text = "";
                textBoxEndDate.Text = "";
                btnDeleteSubscription.IsEnabled = false;
                MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Удалить абонемент";
        }

        private void btnDeleteSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void subscriptionRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)subscriptionRelation.SelectedItems[0];
            textBoxID.Text = row["S_ID"].ToString();
        }
    }
}
