using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for BindTrainerHallPage.xaml
    /// </summary>
    public partial class BindTrainerHallPage : Page
    {
        public BindTrainerHallPage()
        {
            InitializeComponent();
            FillDataGrid("SELECT * FROM TRAINER", trainerRelation, "Trainer");
            FillDataGrid("SELECT * FROM HALL", HallRelation, "Hall");
        }

        private void FillDataGrid(string data, DataGrid o, string name)
        {
            using (SqlConnection con = new SqlConnection(Properties.Resources.CONNECTION_STRING))
            {
                string CmdString = data;
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(name);
                sda.Fill(dt);
                o.ItemsSource = dt.DefaultView;
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);


                connection.Open();
                string cmd = "INSERT INTO TRAINER_HALL (TRAINER_T_ID, HALL_H_ID) VALUES ('" + textBoxTrainerID.Text + "','" + textBoxHallID.Text + "')";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Информация не обновлена. Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "Назначить зал тренеру";
        }

        private void BtnAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBarFree.StatusBar.Content = "";
        }

        private void TrainerRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)trainerRelation.SelectedItems[0];
            textBoxTrainerID.Text = row["T_ID"].ToString();
        }

        private void HallRelation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)HallRelation.SelectedItems[0];
            textBoxHallID.Text = row["H_ID"].ToString();
        }
    }
}
