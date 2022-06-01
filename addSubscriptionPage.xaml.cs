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
    /// Interaction logic for addSubscriptionPage.xaml
    /// </summary>
    public partial class addSubscriptionPage : Page
    {
        public addSubscriptionPage()
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
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void btnAddSubscription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "INSERT INTO SUBSCRIPTION (S_STARTDATE, S_ENDDATE) VALUES ('" + startDatePick.Text + "','" + endDatePick.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Абонемент успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                FillDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Абонемент не добавлен. Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DatePicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            startDatePick.Text = startDatePick.Text;
        }

        private void StartDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            endDatePick.Text = startDatePick.Text;
        }

        private void btnAddSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Добавить абонемент";
        }

        private void btnAddSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = $"SELECT * FROM SUBSCRIPTION WHERE S_STARTDATE LIKE '%{txtBoxSearch.Text}%' OR S_ENDDATE LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Subscription");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
