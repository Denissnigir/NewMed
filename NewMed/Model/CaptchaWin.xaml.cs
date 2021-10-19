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
using NewMed.Model;

namespace NewMed.Model
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWin.xaml
    /// </summary>
    public partial class CaptchaWin : Window
    {
        public static bool isCaptcha = false;

        public CaptchaWin()
        {
            InitializeComponent();
            MainWindow.isFirst = false;
            isCaptcha = true;

            label1.Content = Rnd;
            label2.Content = Rnd;
            label3.Content = Rnd;
            label4.Content = Rnd;
        }

        static Random random = new Random();

        public string Rnd
        {
            get
            {
                return random.Next(0, 10).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string res = Convert.ToString(label1.Content);
            res += Convert.ToString(label2.Content);
            res += Convert.ToString(label3.Content);
            res += Convert.ToString(label4.Content);

            if (CaptchaTB.Text == res)
            {
                isCaptcha = false;
                MainWindow.isFirst = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно!");
            }
        }
    }
}
