using Microsoft.AspNetCore.SignalR;
using Traversal.Models;

namespace SignalRApi.Hubs
{
    public class VisitorHubs(VisitorService _visitorService):Hub
    {
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", "bbb");
        }
    }
}