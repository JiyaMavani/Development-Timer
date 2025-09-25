using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main()
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7152/timerhub")
            .Build();

        connection.On<string>("TimerUpdate", time =>
        {
            Console.WriteLine($"[Client] TimerUpdate: {time}");
        });

        connection.On("TimerEnded", () =>
        {
            Console.WriteLine("[Client] TimerEnded");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to hub!");

        await connection.InvokeAsync("StartTimer", 5, 0.01); // 5 = developerId, 0.01 = hours (~36s)

        Console.ReadLine();
    }
}
