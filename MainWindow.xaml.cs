using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace FitnessClubDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            childFormLoader.Content = new HelloPage();
            StatusBarFree.StatusBar = statusBar;

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);

                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Подключение к базе данных неуспешно. Проверьте настройки сети.");
                Application.Current.Shutdown();
            }
        }


        private void BtnMainPage_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Перейти на главную страницу";
        }

        private void BtnMainPage_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnAddClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить клиента в базу данных";
        }

        private void BtnAddClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnDeleteClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить клиента из базы данных";
        }

        private void BtnDeleteClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnModifyClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Модифицировать или просмотреть данные о существующих клиентах";
        }

        private void BtnModifyClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnAddTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить тренера в базу данных";
        }

        private void BtnAddTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnDeleteTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить тренера из базы данных";
        }

        private void BtnDeleteTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnAddHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить зал в базу данных";
        }

        private void BtnAddHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnDeleteHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить зал из базы данных";
        }

        private void BtnDeleteHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnAddSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить абонемент в базу данных";
        }

        private void BtnAddSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnDeleteSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить абонемент из базы данных";
        }

        private void BtnDeleteSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnBindClientTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Записать клиента к тренеру";
        }

        private void BtnBindClientTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnBindClientSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить клиенту абонемент";
        }

        private void BtnBindClientSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnBindSubscriptionHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить зал абонементу";
        }

        private void BtnBindSubscriptionHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnBindHallSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить абонементу зал";
        }

        private void BtnBindHallSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnBindTrainerHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить зал тренеру";
        }

        private void BtnBindTrainerHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void BtnMainPage_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new HelloPage();
            titleLabel.Content = "Главная";
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new AddClientPage();
            titleLabel.Content = "Добавить клиента";
        }

        private void CheckboxSelect_Unchecked(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new HelloPage();
            titleLabel.Content = "Главная";
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new DeleteClientPage();
            titleLabel.Content = "Удалить клиента";
        }

        private void BtnModifyClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new ModifyClientPage();
            titleLabel.Content = "Изменить данные о клиенте";
        }

        private void BtnAddTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new AddTrainerPage();
            titleLabel.Content = "Добавить тренера";
        }

        private void BtnDeleteTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new DeleteTrainerPage();
            titleLabel.Content = "Удалить тренера";
        }

        private void BtnAddHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new AddHallPage();
            titleLabel.Content = "Добавить зал";
        }

        private void BtnDeleteHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new DeleteHallPage();
            titleLabel.Content = "Удалить зал";
        }

        private void BtnAddSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new AddSubscriptionPage();
            titleLabel.Content = "Добавить абонемент";
        }

        private void BtnDeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new DeleteSubscriptionPage();
            titleLabel.Content = "Удалить абонемент";
        }

        private void BtnBindClientTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new BindClientTrainerPage();
            titleLabel.Content = "Записать клиента к тренеру";
        }

        private void BtnBindClientSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new BindClientSubscriptionPage();
            titleLabel.Content = "Связать клиента и абонемент";
        }

        private void BtnBindSubscriptionHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new BindHallSubscriptionPage();
            titleLabel.Content = "Связать зал и абонемент";
        }

        private void BtnBindTrainerHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new BindTrainerHallPage();
            titleLabel.Content = "Назначить зал тренеру";
        }
    }
}
