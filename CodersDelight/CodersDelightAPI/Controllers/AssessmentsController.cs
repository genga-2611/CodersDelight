using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AssessmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AssessmentsController(ApplicationDbContext context)
    {
        _context = context;
    }
    

    [HttpPost]
    public async Task<ActionResult<Assessment>> CreateAssessment(Assessment assessment)
    {
        _context.Assessments.Add(assessment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAssessment), new { id = assessment.Id }, assessment);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Assessment>> GetAssessment(int id)
    {
        var assessment = await _context.Assessments.Include(a => a.Questions).FirstOrDefaultAsync(a => a.Id == id);
        if (assessment == null) return NotFound();
        return assessment;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assessment>>> GetAssessments()
    {
        return await _context.Assessments.Include(a => a.Questions).ToListAsync();
    }
}