using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
	public class List
	{
		public class Query : IRequest<List<Activity>> { }

		public class Handler(DataContext context, ILogger<List> logger) : IRequestHandler<Query, List<Activity>>
		{
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await context.Activities.ToListAsync();
			}
		}
	}
}