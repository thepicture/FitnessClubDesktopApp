using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for DeleteHallPage.xaml
    /// </summary>
    public partial class DeleteHallPage : Page
    {
        public DeleteHallPage()
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
                hallRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void TextBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            BtnDeleteHall.IsEnabled = true;
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

        private void BtnDeleteHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "DELETE FROM HALL WHERE H_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxName.Text = "";
                BtnDeleteHall.IsEnabled = false;
                MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteHall_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Удалить зал";
        }

        private void BtnDeleteHall_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void HallRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)hallRelation.SelectedItems[0];
            textBoxID.Text = row["H_ID"].ToString();
        }
    }
}
