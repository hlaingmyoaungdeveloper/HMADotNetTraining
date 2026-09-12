using Microsoft.AspNetCore.SignalR;

namespace June2026.SignalRMvp.Hubs;

public class MvpHub : Hub
{
    // Shared in-memory counter across all connected users (No database required)
    private static int _clickCount = 0;

    // Send current counter state to newly connected client
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("UpdateClickCount", _clickCount);
        await base.OnConnectedAsync();
    }

    // Feature 2: Increment shared counter & broadcast to all connected clients
    public async Task IncrementCounter()
    {
        int newCount = Interlocked.Increment(ref _clickCount);
        // SignalR Event: Server -> All Clients ("UpdateClickCount")
        await Clients.All.SendAsync("UpdateClickCount", newCount);
    }

    // Feature 3: Send global broadcast notification to all connected clients
    public async Task BroadcastAlert(string message)
    {
        // SignalR Event: Server -> All Clients ("ReceiveAlert")
        await Clients.All.SendAsync("ReceiveAlert", message);
    }
}
