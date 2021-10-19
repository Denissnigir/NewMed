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

namespace NewMed.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthHistory.xaml
    /// </summary>
    public partial class AuthHistory : Window
    {
        List<User> userLoginList = new List<User>(); // Юзеры
        List<NewMed.Model.AuthHistory> authHistories = new List<Model.AuthHistory>(); // История авторизации
        List<string> sortDateList = new List<string>() 
        {
            "Сортировка по дате",
            "Сортировать в порядке возрастания",
            "Соритровать в порядке убывания"
        }; // Лист для сортировки

        public AuthHistory()
        {
            InitializeComponent();

           
            
            userLoginList = Context._context.User.ToList();
            userLoginList.Insert(0, new User { UserLogin = "Фильтрация" });

            SortCB.ItemsSource = sortDateList;
            SortCB.SelectedIndex = 0;

            FilterCB.ItemsSource = userLoginList;
            FilterCB.SelectedIndex = 0;
            Filter();
        }
       
        public void Filter() // Фильтрация и сортировка
        {
            authHistories = Context._context.AuthHistory.ToList();

            switch (SortCB.SelectedIndex)
            {
                case 0:
                    authHistories = Context._context.AuthHistory.ToList();
                    break;
                case 1:
                    authHistories = authHistories.OrderBy(i => i.AuthDate).ToList();
                    break;
                case 2:
                    authHistories = authHistories.OrderByDescending(i => i.AuthDate).ToList();
                    break;
            }
            
            if (FilterCB.SelectedIndex != 0)
            {
                authHistories = authHistories.Where(i => i.UserLogin == FilterCB.SelectedIndex).ToList();
            }
            Users.ItemsSource = authHistories;
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
