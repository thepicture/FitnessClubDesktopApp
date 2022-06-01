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
    /// Interaction logic for modifyClientPage.xaml
    /// </summary>
    public partial class modifyClientPage : Page
    {
        public modifyClientPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()

        {

            SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                CmdString = "SELECT * FROM CLIENT";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Client");
                sda.Fill(dt);
                clientRelation.ItemsSource = dt.DefaultView;
            }
        }

        private void textBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxName.Text = "";
            textBoxPassNum.Text = "";
            textBoxPassCode.Text = "";
            btnDeleteClient.IsEnabled = true;
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

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJFGR01\SQLEXPRESS; Initial Catalog=Fitness_club; Integrated Security=true");

                connection.Open();
                string cmd = "UPDATE CLIENT SET C_NAME='" + textBoxName.Text + "', C_PASSNUM='" + textBoxPassNum.Text + "', C_PASSCODE='" + textBoxPassCode.Text + "' WHERE C_ID='" + textBoxID.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                FillDataGrid();
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "Изменить данные клиента";
        }

        private void btnDeleteClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarFree.statusbar.Content = "";

        }

        private void clientRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)clientRelation.SelectedItems[0];
            textBoxID.Text = row["C_ID"].ToString();
        }
    }
}
