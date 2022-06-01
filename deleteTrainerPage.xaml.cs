using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for DeleteTrainerPage.xaml
    /// </summary>
    public partial class DeleteTrainerPage : Page
    {
        public DeleteTrainerPage()
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
                trainerRelation.ItemsSource = dt.DefaultView;
            }
        }


        private void TextBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            textBoxSkill.Text = "";
            BtnDeleteTrainer.IsEnabled = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING))
                {
                    SqlCommand command =
                    new SqlCommand("select * from TRAINER where T_ID = '" + textBoxID.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        textBoxName.Text = (read["T_NAME"].ToString());
                        textBoxSkill.Text = (read["T_SKILL"].ToString());
                        MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        FillDataGrid();
                    }
                    read.Close();
                }
            }
            catch
            {
                MessageBox.Show("Информация не обновлена. Нет данных для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteTrainer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "DELETE FROM TRAINER WHERE T_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxName.Text = "";
                textBoxSkill.Text = "";
                BtnDeleteTrainer.IsEnabled = false;
                FillDataGrid();
            }
            catch (Exception)
            {

            }
        }

        private void BtnDeleteTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Удалить тренера";
        }

        private void BtnDeleteTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TrainerRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)trainerRelation.SelectedItems[0];
            textBoxID.Text = row["T_ID"].ToString();
        }
    }
}
