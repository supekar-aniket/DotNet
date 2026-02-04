using _34_web_API_CURD_with_Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _34_web_API_CURD_with_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly WebApiwithCrudDatabaseContext dbContext;

        public StudentAPIController(WebApiwithCrudDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetStudent ()
        {
            var studData = await dbContext.Students.ToListAsync();

            return Ok(studData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetStudentById(int id)
        {
            var studData = await dbContext.Students.FindAsync(id);

            if (studData == null)
            {
                return NotFound();
            }

            return Ok(studData);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(student).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var studData = await dbContext.Students.FindAsync(id);

            if(studData == null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(studData);
            await dbContext.SaveChangesAsync();

            return Ok(studData);
        }
    }
}
