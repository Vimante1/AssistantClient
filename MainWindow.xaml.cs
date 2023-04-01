using AssistantClient.Core.FileUtils;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AssistantClient
{
    public partial class MainWindow : Window
    {
        public static MainWindow? _Window;
        MyFile MyFile = new MyFile();
        public MainWindow()
        {

            InitializeComponent();

            _Window = this;
            this.Left = 400;
            this.Top= 150;
            TBox.Focus();
               
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(TBox.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ErrorBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MyFile.CreateFile(TBox.Text);
                App.start(TBox.Text);
                this.Close();
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TurnButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MovingWindow(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
            _Window?.DragMove();
            }
        }
      
        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") )
            {
                e.Handled = true; // забороняє ввід символів
            }
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.google.com") { UseShellExecute = true });
        }

       
    }
}
