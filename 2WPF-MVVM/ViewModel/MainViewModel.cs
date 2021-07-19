using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _2WPF_MVVM.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public string[] backcolor;
        public MainViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem{ Icon="\ue720",Name="用户"},
                new MenuItem{ Icon="\ue613",Name="财务"},
                new MenuItem{ Icon="\ue62b",Name="积分"},
                new MenuItem{ Icon="\ue636",Name="市场"},
                new MenuItem{ Icon="\ue69a",Name="客服"}
            };

            backcolor = new string[] {
                "#219AFD",
                "#60B721",
                "#FFA000",
                "#30B8C4",
                "#E87A6C"
           };
            LoadEarnigs();

            //省事..把个人资料和推荐用户放一起了
            UserList = new ObservableCollection<User>()
            {
                new User{ Nick="傲慢与偏见",Name="她比亚索还要浪",Phonen="13812345678",UserName="luchong",Url="https://www.cnblogs.com/chonglu/",Photo="./Images/logo.png"},
                new User{ Nick="张三",Photo="./Images/logo.png"},
                new User{ Nick="李四",Photo="./Images/logo.png"}
            };

            MenuItemCmd = new RelayCommand<string>(ShowMenuCmd);
        }

        private async void LoadEarnigs()
        {
            await Task.Run(() =>
            {
                Earnings = new ObservableCollection<Earning>();
                while (true)
                {
                    Random random = new Random();

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Earnings.Clear();
                        for (int i = 0; i < 5; i++)
                        {
                            Earnings.Add(new Earning
                            {
                                Integral = Convert.ToInt32(random.Next(10000, 99999)),
                                Yield = Convert.ToDouble(random.Next(0, 1)),
                                BackColor = backcolor[i]
                            });
                        }

                    });
                    Thread.Sleep(3000);
                }
            });
        }

        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public ObservableCollection<Earning> Earnings { get; set; }
        public ObservableCollection<User> UserList { get; set; }

        public RelayCommand<string> MenuItemCmd { get; set; }

        public void ShowMenuCmd(string btnName)
        {
            switch (btnName)
            {
                case "用户":
                    //Action
                    break;
                case "财务":
                    break;
                case "积分":
                    break;
                case "市场":
                    break;
                case "客服":
                    break;
                default:
                    break;
            }
            Messenger.Default.Send(btnName, "ExecuteMenuItem");
        }
    }

    public class MenuItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }
    }

    public class Earning
    {
        public int Integral { get; set; }
        public double Yield { get; set; }

        public string BackColor { get; set; }
    }

    public class User
    {
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Phonen { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
    }

}