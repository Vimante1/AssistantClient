using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AssistantClient.Core.SignalR
{
    internal class Commands
    {
        public Dictionary<string, Action> MyCommands;

        public Commands()
        {
            MyCommands = new Dictionary<string, Action>();

            MyCommands.Add("Browser", Browser);
            MyCommands.Add("TurnOff", TurnOff);
            MyCommands.Add("Site", OpenSite);
            MyCommands.Add("Discord", Discord);
        }

        public void StartCommand(string message)
        {
            Console.WriteLine(message);
            Action action;
            if (MyCommands.TryGetValue(message, out action!))
            {
                action();
            }
        }

        private void Discord()
        {
            string programName = "Discord";

            // Створити новий об'єкт класу Process
            Process process = new Process();

            // Встановити властивості для запуску програми
            process.StartInfo.FileName = programName;
            process.StartInfo.UseShellExecute = true;

            // Запустити програму
            process.Start();
        }

        private void OpenSite()
        {

        }

        private void TurnOff()
        {
            Process.Start("shutdown", "/s /t 1");
            Environment.Exit(0);
        }

        public void Browser()
        {
            try
            {
                Process.Start(new ProcessStartInfo("http://www.google.com") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }
    }
}
