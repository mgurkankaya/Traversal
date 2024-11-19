using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Traversal.CQRS.Commands.DestinationCommands;
using Traversal.ViewComponents.Default;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true,
                ImageUrl = "#",
                ImageUrl2 = "#",
                Description = "#",
                CoverImage = "#",
                Details1 = "#",
                Details2 = "#"


            });
            _context.SaveChanges();
        }
    }
}