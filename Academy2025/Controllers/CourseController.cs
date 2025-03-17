using Academy2025.Data;
using Academy2025.Repositories;
using Academy2025.Dtos;
using Microsoft.AspNetCore.Authentication;
using Academy2025.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetAsync()
        {
            return await _courseService.GetAllAsync();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetAsync(int id)
        {
            var Course = await _courseService.GetByIdAsync(id);

            return Course == null ? NotFound() : Course;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CourseDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CourseDto data)
        {
            var Course = await _courseService.UpdateAsync(id, data);

            return Course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _courseService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
