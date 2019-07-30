using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
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

        public StudentController(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        // GET api/values
        [HttpGet]
        public List<Student> Get()
        {
            var result = _mongoRepository.GetStudents();

            return result;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Student student)
        {
            var studentID = _mongoRepository.CreateStudent(student);

            return studentID;
        }

        [HttpPut]
        public ActionResult<Guid> Put([FromBody] Student student)
        {
            var response = _mongoRepository.UpdateStudent(student);

            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine();
        }

        // DELETE api/values/5
        [HttpDelete]
        public Guid Delete([FromBody] Guid student)
        {

            var result = _mongoRepository.DeleteStudent(student);

            return result;
        }
    }
}