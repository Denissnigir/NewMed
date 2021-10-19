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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using NewMed.Model;
using NewMed.Windows;

namespace NewMed
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _dispTimer; // Таймер
        TimeSpan _dispTimerCounter; // Счётчик таймера 

        DateTime curDate = DateTime.Now; // Текущая дата
        
        List<Model.AuthHistory> authHistories = new List<Model.AuthHistory>(); // ???

        List<Model.User> users = new List<Model.User>(); // Лист юзеров

        public static bool isFirst = true; // Первый ли раз что-то там

        public MainWindow()
        {
            InitializeComponent();

            if (CaptchaWin.isCaptcha == true && isFirst == false) // Бесполезная штука, всё равно во время капчи вырубаем окно)
            {
                EnterButton.IsEnabled = false;
            }
            else
            {
                EnterButton.IsEnabled = true;
            }

            PasswordTB.Visibility = Visibility.Hidden; // Костыль с ПБ и ТБ
            PasswordPB.Visibility = Visibility.Visible;

            if (LabMainMenu.isLocked == true) // Таймер, запрет входа на минуту
            {
                _dispTimerCounter = new TimeSpan(0, 1, 0);
                _dispTimer = new DispatcherTimer();
                _dispTimer.Interval = TimeSpan.FromSeconds(1);
                _dispTimer.Tick += new EventHandler(TimerTick);
                _dispTimer.Start();
            }

            authHistories = Context._context.AuthHistory.ToList(); // Инициализация контекста AuthHistory
            users = Context._context.User.ToList(); // Инициализация контекста User

        }

        private void TimerTick(object sender, EventArgs e) // Непосредственно сам таймер
        {
            _dispTimerCounter = _dispTimerCounter - new TimeSpan(0, 0, 1);
            TimerTB.Text = _dispTimerCounter.ToString();


            if (_dispTimerCounter <= new TimeSpan(0, 0, 0))
            {
                _dispTimer.Stop();
                LabMainMenu.isLocked = false;
                MessageBox.Show("Теперь вы можете войти!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Кнопка выключения 
        {
            Application.Current.Shutdown();
        }

        private void ShowPassword_Click(object sender, RoutedEventArgs e) // Замена ТБ и ПБ
        {
            if (ShowPassword.IsChecked == true)
            {
                PasswordPB.Visibility = Visibility.Hidden;
                PasswordTB.Visibility = Visibility.Visible;
                PasswordTB.Text = PasswordPB.Password;
            }
            else
            {
                PasswordPB.Visibility = Visibility.Visible;
                PasswordTB.Visibility = Visibility.Hidden;
                PasswordPB.Password = PasswordTB.Text;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Авторизация
        {
            try
            {
                if (LabMainMenu.isLocked == false)
                {
                    PasswordTB.Text = PasswordPB.Password;

                    var user = users.Where(i => i.UserLogin == LoginTB.Text && i.UserPassword == PasswordTB.Text).FirstOrDefault();

                    var userLogin = users.Where(i => i.UserLogin == LoginTB.Text).FirstOrDefault();





                    if (user != null)
                    {
                        if (user.UserRoleName.ToString() == "1")
                        {
                            Model.AuthHistory authHistory = new Model.AuthHistory();
                            authHistory.UserLogin = user.UserId;
                            authHistory.AuthDate = curDate;
                            authHistory.AuthTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            authHistory.IsSuccessfull = true;
                            user.UserLastenter = curDate;

                            Context._context.AuthHistory.Add(authHistory);
                            Context._context.SaveChanges();

                            LabMainMenu labMainMenu = new LabMainMenu(user as User);
                            labMainMenu.Show();
                            this.Close();
                        }
                        else if (user.UserRoleName.ToString() == "2")
                        {
                            Model.AuthHistory authHistory = new Model.AuthHistory();
                            authHistory.UserLogin = user.UserId;
                            authHistory.AuthDate = curDate;
                            authHistory.AuthTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            authHistory.IsSuccessfull = true;
                            user.UserLastenter = curDate;

                            Context._context.AuthHistory.Add(authHistory);
                            Context._context.SaveChanges();

                            LabIsslMainMenu labIsslMainMenu = new LabIsslMainMenu(user as User);
                            labIsslMainMenu.Show();
                            this.Close();

                        }
                        else if (user.UserRoleName.ToString() == "3")
                        {
                            Model.AuthHistory authHistory = new Model.AuthHistory();
                            authHistory.UserLogin = user.UserId;
                            authHistory.AuthDate = curDate;
                            authHistory.AuthTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            authHistory.IsSuccessfull = true;
                            user.UserLastenter = curDate;

                            Context._context.AuthHistory.Add(authHistory);
                            Context._context.SaveChanges();

                            LabAdmMaimMenu labAdmMaimMenu = new LabAdmMaimMenu(user as User);
                            labAdmMaimMenu.Show();
                            this.Close();
                        }
                        else if (user.UserRoleName.ToString() == "4")
                        {
                            Model.AuthHistory authHistory = new Model.AuthHistory();
                            authHistory.UserLogin = user.UserId;
                            authHistory.AuthDate = curDate;
                            authHistory.AuthTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            authHistory.IsSuccessfull = true;
                            user.UserLastenter = curDate;

                            Context._context.AuthHistory.Add(authHistory);
                            Context._context.SaveChanges();


                            ManagerMainMenu managerMainMenu = new ManagerMainMenu(user as User);
                            managerMainMenu.Show();
                            this.Close();
                        }
                    }
                    else if (isFirst == true)
                    {
                        var userLoginData = users.Where(i => i.UserLogin == LoginTB.Text).FirstOrDefault();

                        if(userLoginData == null)
                        {
                            throw new Exception("Нет такого логина!");
                        }
                        else
                        {
                            MessageBox.Show("Неверно введены данные");


                            Model.AuthHistory authHistory = new Model.AuthHistory();

                            authHistory.UserLogin = userLogin.UserId;
                            authHistory.AuthDate = curDate;
                            authHistory.AuthTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            authHistory.IsSuccessfull = false;

                            Context._context.AuthHistory.Add(authHistory);
                            Context._context.SaveChanges();

                            CaptchaWin captchaWin = new CaptchaWin();
                            captchaWin.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вход ограничен!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
            
        }
    }
}
