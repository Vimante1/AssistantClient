using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace AssistantClient.Core.NotifyIconUtils
{
    internal class Tray
    {
        Forms.NotifyIcon notifyIcon = new Forms.NotifyIcon();

        public Tray()
        {
            var Uri = new Uri("pack://application:,,,/img/Icon.ico");
            Stream stream = Application.GetResourceStream(Uri).Stream;
            stream.Seek(0, SeekOrigin.Begin);
            notifyIcon.Icon = new System.Drawing.Icon(stream);
            notifyIcon.Text = "Assistant";
            notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Reconnect", null ,OnStatusClicked);
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null , OnExitClicked);

            notifyIcon.Visible = true;
        }

        private void OnExitClicked(object? sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnStatusClicked(object sender, EventArgs e)
        {
            App.ShowWindow();
        }
    }
}
