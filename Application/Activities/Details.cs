using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get;set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            private readonly ILogger<Details> _logger;
            public Handler(DataContext context, ILogger<Details> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Get activity by id: {request.Id}, canceled: {cancellationToken.IsCancellationRequested}");
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}