using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for AddSubscriptionPage.xaml
    /// </summary>
    public partial class AddSubscriptionPage : Page
    {
        public AddSubscriptionPage()
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
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void BtnAddSubscription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);

                connection.Open();
                string cmd = "INSERT INTO SUBSCRIPTION (S_STARTDATE, S_ENDDATE) VALUES ('" + startDatePick.Text + "','" + endDatePick.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Абонемент успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Абонемент не добавлен. Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            endDatePick.Text = startDatePick.Text;
        }

        private void BtnAddSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Добавить абонемент";
        }

        private void BtnAddSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = $"SELECT * FROM SUBSCRIPTION WHERE S_STARTDATE LIKE '%{txtBoxSearch.Text}%' OR S_ENDDATE LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Subscription");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
