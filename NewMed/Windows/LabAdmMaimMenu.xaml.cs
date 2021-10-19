using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using NewMed.Model;

namespace NewMed.Windows
{
    /// <summary>
    /// Логика взаимодействия для LabAdmMaimMenu.xaml
    /// </summary>
    public partial class LabAdmMaimMenu : Window
    {

        DispatcherTimer _dispTimer; // Таймер
        TimeSpan _dispTimerCounter; // Счётчик таймера 

        bool isFirst = true;

        public LabAdmMaimMenu(User user) // Тут в инициализациия принимает атрибут юзера, чтобы потом загрузить его имя в ТекстБлок
        {
            InitializeComponent();
            UserNameTB.Text = user.UserName.ToString(); // Вот сама загрузка имени

            _dispTimerCounter = new TimeSpan(0, 0, 0); // Таймер на работу
            _dispTimer = new DispatcherTimer();
            _dispTimer.Interval = TimeSpan.FromSeconds(1);
            _dispTimer.Tick += new EventHandler(TimerTick);
            _dispTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e) // Запуск таймера с сообщением на 5 минутах и выключением на 10 
        {
            _dispTimerCounter = _dispTimerCounter + new TimeSpan(0, 0, 1);
            TimerTB.Text = _dispTimerCounter.ToString();

            if (_dispTimerCounter >= new TimeSpan(0, 5, 0) && isFirst == true)
            {
                MessageBox.Show("До конца сеанса осталось 5 минут!");
                isFirst = false;
            }

            if (_dispTimerCounter >= new TimeSpan(0, 10, 0))
            {
                LabMainMenu.isLocked = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                _dispTimer.Stop();
                MessageBox.Show("Время сеанса исткело!");
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Кнопка выключения
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Выход из учётки
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // История входа
        {
            AuthHistory authHistory = new AuthHistory();
            authHistory.Show();
        }
    }
}
