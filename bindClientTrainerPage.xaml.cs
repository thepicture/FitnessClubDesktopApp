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
    /// Interaction logic for bindClientTrainerPage.xaml
    /// </summary>
    public partial class bindClientTrainerPage : Page
    {
        public bindClientTrainerPage()
        {
            InitializeComponent();
            FillDataGrid("SELECT * FROM CLIENT", clientRelation, "Client");
            FillDataGrid("SELECT * FROM TRAINER", trainerRelation, "Trainer");
        }

        private void FillDataGrid(string data, DataGrid o, string name)
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = data;
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(name);
                sda.Fill(dt);
                o.ItemsSource = dt.DefaultView;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "INSERT INTO CLIENT_TRAINER (TRAINER_T_ID, CLIENT_C_ID) VALUES ('" + this.textBoxTrainerID.Text + "','" + this.textBoxClientID.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);

                createCommand.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Записать клиента к тренеру";
        }

        private void btnAddTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";
        }

        private void clientRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)clientRelation.SelectedItems[0];
            textBoxClientID.Text = row["C_ID"].ToString();
        }

        private void trainerRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)trainerRelation.SelectedItems[0];
            textBoxTrainerID.Text = row["T_ID"].ToString();
        }
    }
}
