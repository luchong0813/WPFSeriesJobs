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
                new MenuItem{ Icon="\ue720",Name="�û�"},
                new MenuItem{ Icon="\ue613",Name="����"},
                new MenuItem{ Icon="\ue62b",Name="����"},
                new MenuItem{ Icon="\ue636",Name="�г�"},
                new MenuItem{ Icon="\ue69a",Name="�ͷ�"}
            };

            backcolor = new string[] {
                "#219AFD",
                "#60B721",
                "#FFA000",
                "#30B8C4",
                "#E87A6C"
           };
            LoadEarnigs();

            //ʡ��..�Ѹ������Ϻ��Ƽ��û���һ����
            UserList = new ObservableCollection<User>()
            {
                new User{ Nick="������ƫ��",Name="����������Ҫ��",Phonen="13812345678",UserName="luchong",Url="https://www.cnblogs.com/chonglu/",Photo="./Images/logo.png"},
                new User{ Nick="����",Photo="./Images/logo.png"},
                new User{ Nick="����",Photo="./Images/logo.png"}
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
                case "�û�":
                    //Action
                    break;
                case "����":
                    break;
                case "����":
                    break;
                case "�г�":
                    break;
                case "�ͷ�":
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