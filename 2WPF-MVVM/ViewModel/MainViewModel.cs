using _2WPF_MVVM.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _2WPF_MVVM.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public string[] backcolor = new string[] { "#219AFD", "#60B721", "#FFA000", "#30B8C4", "#E87A6C" };
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

            LoadEarnigs();

            //ʡ��..�Ѹ������Ϻ��Ƽ��û���һ����
            UserList = new ObservableCollection<User>()
            {
                new User{ Nick="������ƫ��",Name="����������Ҫ��",Phone="13812345678",UserName="luchong",Url="https://www.cnblogs.com/chonglu/",Photo="./Images/logo.png",LastOnlineTime=DateTime.Now},
                new User{ Nick="����",Photo="./Images/logo.png",LastOnlineTime=DateTime.Now},
                new User{ Nick="����",Photo="./Images/logo.png",LastOnlineTime=DateTime.Now}
            };

            ConsumeRecordList = new ObservableCollection<ConsumeRecord>()
            {
                new ConsumeRecord{ ConsumeCredits=145,ConsumeItem="�󱣽�",ConsumeTime=DateTime.Now},
                new ConsumeRecord{ ConsumeCredits=123,ConsumeItem="ϴ��",ConsumeTime=DateTime.Now},
                new ConsumeRecord{ ConsumeCredits=376,ConsumeItem="�󱣽�",ConsumeTime=DateTime.Now},
                new ConsumeRecord{ ConsumeCredits=999,ConsumeItem="ϴ��",ConsumeTime=DateTime.Now}
            };

            MenuItemCmd = new RelayCommand<string>(ShowMenuCmd);
            PromotionUrlCmd = new RelayCommand<string>(OpenBrowser);
        }


        #region Property
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public ObservableCollection<Earning> Earnings { get; set; }
        public ObservableCollection<User> UserList { get; set; }
        public ObservableCollection<ConsumeRecord> ConsumeRecordList { get; set; }
        #endregion

        #region Command
        public RelayCommand<string> MenuItemCmd { get; set; }
        public RelayCommand<string> PromotionUrlCmd { get; set; }
        #endregion

        #region Method
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
                                Yield = $"+{random.Next(1, 100) * 0.01}%",
                                BackColor = backcolor[i]

                            });
                        }
                    });
                    Thread.Sleep(3000);
                }
            });
        }

        public void ShowMenuCmd(string btnName)
        {
            switch (btnName)
            {
                case "�û�":
                    //Todo Action...
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

        private void OpenBrowser(string url)
        {
            if (string.IsNullOrEmpty(url)) return;
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        #endregion
    }


}