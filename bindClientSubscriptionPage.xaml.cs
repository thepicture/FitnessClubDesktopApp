using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for BindClientSubscriptionPage.xaml
    /// </summary>
    public partial class BindClientSubscriptionPage : Page
    {
        public BindClientSubscriptionPage()
        {
            InitializeComponent();
            FillDataGrid("SELECT * FROM CLIENT", clientRelation, "Client");
            FillDataGrid("SELECT * FROM SUBSCRIPTION", subscriptionRelation, "Subscription");
        }

        private void FillDataGrid(string data, DataGrid o, string name)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = data;
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(name);
                sda.Fill(dt);
                o.ItemsSource = dt.DefaultView;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "INSERT INTO CLIENT_SUBSCRIPTION (CLIENT_C_ID, SUBSCRIPTION_S_ID) VALUES ('" + textBoxClientID.Text + "','" + textBoxSubscriptionID.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Назначить клиенту абонемент";
        }

        private void BtnAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void ClientRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)clientRelation.SelectedItems[0];
            textBoxClientID.Text = row["C_ID"].ToString();
        }

        private void SubscriptionRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)subscriptionRelation.SelectedItems[0];
            textBoxSubscriptionID.Text = row["S_ID"].ToString();
        }
    }
}
