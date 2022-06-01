using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = "SELECT * FROM CLIENT";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Client");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);

                connection.Open();
                string cmd = $"INSERT INTO CLIENT (C_NAME, C_PASSNUM, C_PASSCODE) VALUES ('{textBoxName.Text}','{textBoxPassNum.Text}','{textBoxPassCode.Text}')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Клиент успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Клиент не добавлен. Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Добавить клиента";
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = $"SELECT * FROM CLIENT WHERE C_NAME LIKE '%{txtBoxSearch.Text}%' OR C_PASSNUM LIKE '%{txtBoxSearch.Text}%' OR C_PASSCODE LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Client");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
