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
    /// Interaction logic for bindHallSubscriptionPage.xaml
    /// </summary>
    public partial class bindHallSubscriptionPage : Page
    {
        public bindHallSubscriptionPage()
        {
            InitializeComponent();
            FillDataGrid("SELECT * FROM SUBSCRIPTION", subscriptionRelation, "Subscription");
            FillDataGrid("SELECT * FROM HALL", HallRelation, "Hall");
        }

        private void FillDataGrid(string data, DataGrid o, string name)
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = data;
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(name);
                sda.Fill(dt);
                o.ItemsSource = dt.DefaultView;
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "INSERT INTO HALL_SUBSCRIPTION (HALL_H_ID, SUBSCRIPTION_S_ID) VALUES ('" + this.textBoxHallID.Text + "','" + this.textBoxSubscriptionID.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Назначить зал абонементу";
        }

        private void btnAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void subscriptionRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)subscriptionRelation.SelectedItems[0];
            textBoxSubscriptionID.Text = row["S_ID"].ToString();
        }

        private void HallRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)HallRelation.SelectedItems[0];
            textBoxHallID.Text = row["H_ID"].ToString();
        }
    }
}
