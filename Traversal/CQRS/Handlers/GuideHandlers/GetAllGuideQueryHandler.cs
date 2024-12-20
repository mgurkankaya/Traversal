﻿using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Traversal.CQRS.Queries.GuideQueries;
using Traversal.CQRS.Results.DestinationResults;
using Traversal.CQRS.Results.GuideResults;

namespace Traversal.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x=>new GetAllGuideQueryResult
            {
                GuideId = x.GuideId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).AsNoTracking().ToListAsync();
        }
    }
}
