using MediatR;
using Persistence;

namespace Application.Activities
{
	public class Delete
	{
		public class Command : IRequest
		{
			public Guid Id {get;set;}
		}

		partial class Handler(DataContext context) : IRequestHandler<Command>
		{
            public async Task Handle(Command request, CancellationToken cancellationToken)
			{
				var activity = await context.Activities.FindAsync(request.Id);
				context.Remove(activity);
				await context.SaveChangesAsync();
			}
		}
	}
}