using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;
public class ActivitiesController : BaseApiController
{
    DataContext _context;
    public ActivitiesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet] // api/activities
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await _context.Activities.ToListAsync();
    }

    [HttpGet("{id}")] // api/activities/"155b52b3-6436-427d-b181-438f31458542"
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return await _context.Activities.FindAsync(id);
    }
}
