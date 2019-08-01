using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Services;

namespace ModelApi.Controllers
{
    /// <summary>
    /// Sample API go to api/swagger
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    { 
        private readonly IMongoRepository _mongoRepository;

        private readonly ILogger<StudentController> _logger;

        public StudentController(IMongoRepository mongoRepository, ILogger<StudentController> logger)
        {
            _mongoRepository = mongoRepository;
            _logger = logger;
        }

        [HttpGet]
        public List<Student> Get()
        {
            var result = _mongoRepository.GetStudents();

            if (!result.Any())
            {
                _logger.LogInformation("No Data in the database.");
            }

            return result;
        }

        [HttpPut]
        public ActionResult<Guid> Put([FromBody] Student student)
        {
            var response = _mongoRepository.UpdateStudent(student);

            if (response == Guid.Empty)
            {
                _logger.LogInformation("No student updated.");
            }

            return response;
        }

        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Student student)
        {
            var studentID = _mongoRepository.CreateStudent(student);

            return studentID;
        }

        [HttpDelete]
        public long Delete([FromBody] Student student)
        {
            var result = _mongoRepository.DeleteStudent(student);

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine();
        }

        [HttpPost("{id}")]
        public void Post(int id, [FromBody] string value)
        {
            Console.WriteLine();
        }

        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] string value)
        {
            Console.WriteLine();
        }
    }
}