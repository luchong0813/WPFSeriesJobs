using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _4_WPFDataTemplete
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 5; i++)
            {
                students.Add(
                    new Student {
                        Id = i, 
                        Photo = "46243214.jpg",
                        Name = $"傲慢与偏见{i}", 
                        Sex = $"{(i % 2 != 0 ? "男" : "女")}", 
                        IsGraduate = $"{(i % 2 == 0 ? "在读" : "毕业")}" });
            }
            datagrid1.ItemsSource = students;


            List<User> users = new List<User>();
            for (int i = 0; i <= 3; i++)
            {
                users.Add(new User { Photo = "46243214.jpg", UserName = $"傲慢与偏见{i}", CreatTime = DateTime.Now });
            }
            itemControl1.ItemsSource = users;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public string IsGraduate { get; set; }
    }


    public class User
    {
        public string Photo { get; set; }

        public string UserName { get; set; }

        public DateTime CreatTime { get; set; }
    }
}
