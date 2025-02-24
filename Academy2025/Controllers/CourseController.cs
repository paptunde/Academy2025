using Academy2025.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CourseController : ControllerBase
    {
        public static List<Course>? Courses = new List<Course>();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return Courses;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            foreach (var user in Courses) {
                if (user.Id == id){
                    return Ok(user);
                }
            }
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			Courses.Add(data);
            return NoContent();
        }

		// PUT api/<CourseController>/5
		[HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
			foreach (var user in Courses)
			{
				if (user.Id == id)
				{
					user.Name = data.Name;
                    user.desctiption = data.desctiption;

                    return NoContent();
				}
			}
            return NotFound();
		}

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
			foreach (var user in Courses)
			{
				if (user.Id == id)
				{
					Courses.Remove(user);
                    return NoContent();
				}
			}
			return NotFound();
		}
    }
}
