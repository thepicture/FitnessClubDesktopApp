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
    /// Interaction logic for addTrainerPage.xaml
    /// </summary>
    public partial class addTrainerPage : Page
    {
        public addTrainerPage()
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
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void btnAddTrainer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "INSERT INTO TRAINER (T_NAME, T_SKILL) VALUES ('" + this.textBoxName.Text + "','" + this.textBoxSkill.Text + "')";
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

        private void btnAddTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Добавить тренера";
        }

        private void btnAddTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = $"SELECT * FROM TRAINER WHERE T_NAME LIKE '%{txtBoxSearch.Text}%' OR T_SKILL LIKE '%{txtBoxSearch.Text}%'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Trainer");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }
    }
}
