using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for DeleteSubscriptionPage.xaml
    /// </summary>
    public partial class DeleteSubscriptionPage : Page
    {
        public DeleteSubscriptionPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = "SELECT * FROM SUBSCRIPTION";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Subscription");
                sda.Fill(dt);
                subscriptionRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void TextBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxStartDate.Text = "";
            textBoxEndDate.Text = "";
            BtnDeleteSubscription.IsEnabled = true;
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

        private void BtnDeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "DELETE FROM SUBSCRIPTION WHERE S_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxStartDate.Text = "";
                textBoxEndDate.Text = "";
                BtnDeleteSubscription.IsEnabled = false;
                MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Удалить абонемент";
        }

        private void BtnDeleteSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void SubscriptionRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)subscriptionRelation.SelectedItems[0];
            textBoxID.Text = row["S_ID"].ToString();
        }
    }
}
