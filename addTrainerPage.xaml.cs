using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for AddTrainerPage.xaml
    /// </summary>
    public partial class AddTrainerPage : Page
    {
        public AddTrainerPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = "SELECT * FROM TRAINER";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Trainer");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void BtnAddTrainer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "INSERT INTO TRAINER (T_NAME, T_SKILL) VALUES ('" + textBoxName.Text + "','" + textBoxSkill.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                MessageBox.Show("Тренер успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                createCommand.ExecuteNonQuery();
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Тренер не добавлен. Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Добавить тренера";
        }

        private void BtnAddTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = $"SELECT * FROM TRAINER WHERE T_NAME LIKE '%{txtBoxSearch.Text}%' OR T_SKILL LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Trainer");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
