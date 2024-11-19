using DataAccessLayer.Concrete;
using Traversal.CQRS.Queries.DestinationQueries;
using Traversal.CQRS.Results.DestinationResults;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler(Context _context)
    {
        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationId,
                City = values.City,
                Daynight = values.DayNight,
                Price = values.Price
            };
        }
    }
}