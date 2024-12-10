using Microsoft.AspNetCore.SignalR;

namespace RealTimeApp.Api;

public class ServerTimeNotifier : BackgroundService
{
    private readonly IHubContext<NotificationsHub, INotificationClient> _hubContext;
    public ServerTimeNotifier(IHubContext<NotificationsHub, INotificationClient> hubContext)
    {
        _hubContext = hubContext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _hubContext.Clients.All.ReceiveNotification($"Server time: {DateTimeOffset.Now}");
            await Task.Delay(5000, stoppingToken);
        }
    }
}
