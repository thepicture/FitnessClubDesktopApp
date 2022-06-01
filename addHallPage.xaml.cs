using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for AddHallPage.xaml
    /// </summary>
    public partial class AddHallPage : Page
    {
        public AddHallPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = "SELECT * FROM HALL";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Hall");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void BtnAddHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                connection.Open();
                string cmd = "INSERT INTO HALL (H_NAME) VALUES ('" + textBoxName.Text + "')";
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

        private void BtnAddHall_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Добавить зал";
        }

        private void BtnAddHall_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = $"SELECT * FROM HALL WHERE H_NAME LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Hall");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
