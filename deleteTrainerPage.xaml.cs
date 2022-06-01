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
    /// Interaction logic for deleteTrainerPage.xaml
    /// </summary>
    public partial class deleteTrainerPage : Page
    {
        public deleteTrainerPage()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = "SELECT * FROM TRAINER";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Trainer");
                sda.Fill(dt);
                trainerRelation.ItemsSource = dt.DefaultView;
            }
        }


        private void textBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            textBoxSkill.Text = "";
            btnDeleteTrainer.IsEnabled = true;
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

        private void btnDeleteTrainer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "DELETE FROM TRAINER WHERE T_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                textBoxName.Text = "";
                textBoxSkill.Text = "";
                btnDeleteTrainer.IsEnabled = false;
                FillDataGrid();
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Удалить тренера";
        }

        private void btnDeleteTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void trainerRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)trainerRelation.SelectedItems[0];
            textBoxID.Text = row["T_ID"].ToString();
        }
    }
}
