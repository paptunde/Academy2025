using Academy2025.Data;
using Academy2025.Respositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository _repository;

        public CourseController()
        {
            _repository = new CourseRepository();
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var Course = _repository.GetById(id);

            return Course == null ? NotFound() : Course;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(data);

            return NoContent();
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            var Course = _repository.Update(id, data);

            return Course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repository.Delete(id);

            return result ? NoContent() : NotFound();
        }


        /*
        /// <summary>
        /// 
        /// </summary>
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
		}*/
    }
}
