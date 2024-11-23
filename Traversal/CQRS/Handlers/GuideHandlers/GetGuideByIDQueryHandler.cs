using DataAccessLayer.Concrete;
using MediatR;
using Traversal.CQRS.Queries.GuideQueries;
using Traversal.CQRS.Results.GuideResults;

namespace Traversal.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler(Context _context ) : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync( request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideId = value.GuideId,
                Description = value.Description,
                Name = value.Name
            };
        }
    }
}