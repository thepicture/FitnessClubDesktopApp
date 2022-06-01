using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            childFormLoader.Content = new helloPage();
            statusBarFree.statusbar = statusBar;

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);

                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Подключение к базе данных неуспешно. Проверьте настройки сети.");
                System.Windows.Application.Current.Shutdown();
            }
        }


        private void btnMainPage_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Перейти на главную страницу";
        }

        private void btnMainPage_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnAddClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить клиента в базу данных";
        }

        private void btnAddClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnDeleteClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить клиента из базы данных";
        }

        private void btnDeleteClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnModifyClient_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Модифицировать или просмотреть данные о существующих клиентах";
        }

        private void btnModifyClient_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnAddTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить тренера в базу данных";
        }

        private void btnAddTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnDeleteTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить тренера из базы данных";
        }

        private void btnDeleteTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnAddHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить зал в базу данных";
        }

        private void btnAddHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnDeleteHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить зал из базы данных";
        }

        private void btnDeleteHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnAddSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Добавить абонемент в базу данных";
        }

        private void btnAddSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnDeleteSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Удалить абонемент из базы данных";
        }

        private void btnDeleteSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnBindClientTrainer_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Записать клиента к тренеру";
        }

        private void btnBindClientTrainer_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnBindClientSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить клиенту абонемент";
        }

        private void btnBindClientSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnBindSubscriptionHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить зал абонементу";
        }

        private void btnBindSubscriptionHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnBindHallSubscription_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить абонементу зал";
        }

        private void btnBindHallSubscription_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnBindTrainerHall_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Content = "Назначить зал тренеру";
        }

        private void btnBindTrainerHall_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBar.Content = "";
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new helloPage();
            titleLabel.Content = "Главная";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new addClientPage();
            titleLabel.Content = "Добавить клиента";
        }

        private void checkboxSelect_Unchecked(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new helloPage();
            titleLabel.Content = "Главная";
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new deleteClientPage();
            titleLabel.Content = "Удалить клиента";
        }

        private void btnModifyClient_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new modifyClientPage();
            titleLabel.Content = "Изменить данные о клиенте";
        }

        private void btnAddTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new addTrainerPage();
            titleLabel.Content = "Добавить тренера";
        }

        private void btnDeleteTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new deleteTrainerPage();
            titleLabel.Content = "Удалить тренера";
        }

        private void btnAddHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new addHallPage();
            titleLabel.Content = "Добавить зал";
        }

        private void btnDeleteHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new deleteHallPage();
            titleLabel.Content = "Удалить зал";
        }

        private void btnAddSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new addSubscriptionPage();
            titleLabel.Content = "Добавить абонемент";
        }

        private void btnDeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new deleteSubscriptionPage();
            titleLabel.Content = "Удалить абонемент";
        }

        private void btnBindClientTrainer_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new bindClientTrainerPage();
            titleLabel.Content = "Записать клиента к тренеру";
        }

        private void btnBindClientSubscription_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new bindClientSubscriptionPage();
            titleLabel.Content = "Связать клиента и абонемент";
        }

        private void btnBindSubscriptionHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new bindHallSubscriptionPage();
            titleLabel.Content = "Связать зал и абонемент";
        }

        private void btnBindTrainerHall_Click(object sender, RoutedEventArgs e)
        {
            childFormLoader.Content = new bindTrainerHallPage();
            titleLabel.Content = "Назначить зал тренеру";
        }
    }
}
