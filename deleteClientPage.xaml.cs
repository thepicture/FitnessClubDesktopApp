using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for DeleteClientPage.xaml
    /// </summary>
    public partial class DeleteClientPage : Page
    {
        public DeleteClientPage()
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


        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);

                connection.Open();
                string cmd = "DELETE FROM CLIENT WHERE C_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxName.Text = "";
                textBoxPassNum.Text = "";
                textBoxPassCode.Text = "";
                BtnDeleteClient.IsEnabled = false;
                MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            textBoxPassNum.Text = "";
            textBoxPassCode.Text = "";
            BtnDeleteClient.IsEnabled = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING))
                {
                    SqlCommand command =
                    new SqlCommand("select * from CLIENT where C_ID = '" + textBoxID.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        textBoxName.Text = (read["C_NAME"].ToString());
                        textBoxPassNum.Text = (read["C_PASSNUM"].ToString());
                        textBoxPassCode.Text = (read["C_PASSCODE"].ToString());
                    }
                    read.Close();
                }
            }
            catch
            {

            }
        }

        private void BtnDeleteClient_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Удалить клиента";
        }

        private void BtnDeleteClient_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void ClientRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)clientRelation.SelectedItems[0];
            textBoxID.Text = row["C_ID"].ToString();
        }
    }
}
