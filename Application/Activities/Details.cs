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

        public class Handler(DataContext context, ILogger<Details> logger) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                logger.LogInformation($"Get activity by id: {request.Id}, canceled: {cancellationToken.IsCancellationRequested}");
                return await context.Activities.FindAsync(request.Id);
            }
        }
    }
}