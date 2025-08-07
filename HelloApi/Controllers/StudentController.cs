using HelloApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDBContext _context;
        public StudentController(AppDBContext dBContext)
        {
            _context = dBContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Student api working");
        }

        [HttpGet("with-student")]
        public async Task<IActionResult> GetStudentwithCourse()
        {
            var student = await _context.Students
                .Include(s => s.Course)
                .ToListAsync();

            return Ok(student);
        }

    }
}
