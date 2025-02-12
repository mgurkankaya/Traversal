using Microsoft.AspNetCore.SignalR;
using SignalRApiForSql.Models;

namespace SignalRApiForSql.Hubs
{
    public class VisitorHub(VisitorService _visitorService) : Hub
    {
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", "bbb");
        }
    }
}
