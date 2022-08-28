using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {

        private List<student> students = new List<student>()
            {

                new student()
                {
                    id = 1,
                    name = "walaa",

                    age = 23,
                    city = "Jenin"
                },
                new student()
                {
                    id = 1,
                    name = "walaa22",

                    age = 25,
                    city = "Ramallah"
                }



            };
        [HttpGet]
        [Route("getStudents")]
        public async Task<ActionResult<student>> GetSudents()
        {

            return Ok(students);
        }

        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult<student>> GetSudent(int id)
        {
            var student = students.Find(x => x.id == id);
            if (student == null)
                return
                    BadRequest("No students found");
            return Ok(student);
        }

        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<student>> AddSudent(student request)
        {
            students.Add(request);
            return Ok(students);
        }

        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<student>> updateSudent(student request)
        {
            var student = students.Find(x => x.id == request.id);
            if (student == null)
                return BadRequest("No students found");
            student.name = request.name;
            student.age = request.age;
            student.city = request.city;
            return Ok(students);
        }

        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult<student>> DeleteSudent(int id)
        {
            var student = students.Find(x => x.id == id);
            if (student == null)
                return
                    BadRequest("No students found");

            students.Remove(student);
            return Ok(student);

        }
    }
}
