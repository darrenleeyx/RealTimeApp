using Microsoft.AspNetCore.SignalR;

namespace RealTimeApp.Api;

public class NotificationsHub : Hub<INotificationClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.ReceiveNotification("Welcome to the notifications hub!");

        await base.OnConnectedAsync();
    }

    public async Task SendNotification(string message)
    {
        await Clients.All.ReceiveNotification(message);
    }
}

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}
