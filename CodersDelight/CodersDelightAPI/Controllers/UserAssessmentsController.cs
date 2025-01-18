using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserAssessmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserAssessmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<UserAssessment>> SubmitAssessment(UserAssessment userAssessment)
    {
        _context.UserAssessments.Add(userAssessment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserAssessment), new { id = userAssessment.Id }, userAssessment);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserAssessment>> GetUserAssessment(int id)
    {
        var userAssessment = await _context.UserAssessments
            .Include(ua => ua.Assessment)
            .Include(ua => ua.User)
            .FirstOrDefaultAsync(ua => ua.Id == id);

        if (userAssessment == null)
            return NotFound();

        return userAssessment;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<UserAssessment>>> GetUserAssessments(int userId)
    {
        return await _context.UserAssessments
            .Include(ua => ua.Assessment)
            .Where(ua => ua.UserId == userId)
            .ToListAsync();
    }

    [HttpGet("assessment/{assessmentId}")]
    public async Task<ActionResult<IEnumerable<UserAssessment>>> GetAssessmentResults(int assessmentId)
    {
        return await _context.UserAssessments
            .Include(ua => ua.User)
            .Where(ua => ua.AssessmentId == assessmentId)
            .ToListAsync();
    }
}