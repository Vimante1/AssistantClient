using System;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using AssistantClient.Core.FileUtils;
using Application = System.Windows.Application;
using AssistantClient.Core.NotifyIconUtils;
using AssistantClient.Core.SignalR;
using System.Drawing;

namespace AssistantClient
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        NotifyIcon _notifyIcon = new NotifyIcon();
        MyFile _file = new MyFile();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Tray tray = new Tray();
            if (!_file.CheckExists()) ShowWindow();
            else start(_file.ReadFile());
          
        }


        public static void start(string Mail)
        {
            Hub hub = new Hub();
            hub.ConnectAsync(Mail);
        }
        public static void ShowWindow()
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
        }

    }
}
