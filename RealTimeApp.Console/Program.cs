using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:7166/notifications")
               .Build();

connection.On<string>("ReceiveNotification", (message) =>
{
    Console.WriteLine($"Notification received: {message}");
});

try
{
    await connection.StartAsync();
    Console.WriteLine("Connection started.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error starting connection: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

await connection.StopAsync();