using HelloApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDBContext _context;
        public CourseController(AppDBContext dBContext)
        {
            _context = dBContext;
        }
        // GET: CourseController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("course successful");
        }
        [HttpGet("with-course")]
        public async Task<IActionResult> GetCoursewithStudent()
         {
            var course = await _context.Courses
                .Include(c => c.Students)
                .ToListAsync();
            return Ok(course);
        }
    }
}
