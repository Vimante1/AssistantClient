using AssistantClient.Core.FileUtils;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
namespace AssistantClient.Core.SignalR
{
    internal class Hub
    {
        static HubConnection? HubConnection;
        MyFile _file = new MyFile();
        Commands commands = new Commands();
        public async Task<bool> ConnectAsync(string Mail)
        {
            try
            {
                HubConnection = new HubConnectionBuilder()
                          .WithUrl("http://localhost:5203/hub")
                          .Build();

                HubConnection.On<string>("Send", message => commands.StartCommand(message));
                await HubConnection.StartAsync();
                await HubConnection.InvokeAsync("CreateUser", "vimanter27@gmail.com");
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

    }
}
