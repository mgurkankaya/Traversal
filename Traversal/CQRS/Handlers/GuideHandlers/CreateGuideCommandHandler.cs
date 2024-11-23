using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using Traversal.CQRS.Commands.GuideCommands;

namespace Traversal.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler(Context _context) : IRequestHandler<CreateGuideCommand>
    {
        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                TwitterUrl = "",
                InstagramUrl = "",
                Status = true

            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
