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
    /// Model Student Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    { 
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="studentService">The Student Service</param>
        /// <param name="logger"></param>
        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all the students in the db
        /// </summary>
        /// <returns>Returns a list of Students</returns>
        [HttpGet]
        public List<Student> Get()
        {
            var result = _studentService.GetStudents();

            return result;
        }

        /// <summary>
        /// Updates the Student by the Student ID.
        /// </summary>
        /// <param name="id">The ID of the student to be updated</param>
        /// <param name="student">The new student properties that will replace the old</param>
        /// <returns>Returns the ID of the student that will be updated</returns>
        [HttpPut("{id}")]
        public Guid Put(Guid id, Student student)
        {
            var response = _studentService.UpdateStudentById(id, student);

            return response;
        }

        /// <summary>
        /// Creates a new student
        /// </summary>
        /// <param name="student">The new student to be added to the db</param>
        /// <returns>Returns the ID of the student that has been created</returns>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Student student)
        {
            var studentID = _studentService.CreateStudent(student);

            return studentID;
        }

        /// <summary>
        /// Deletes a student by the ID of the student
        /// </summary>
        /// <param name="id">The ID of the student to be deleted</param>
        /// <returns>Returns 1 if the student has been deleted</returns>
        [HttpDelete("{id}")]
        public long Delete(Guid id)
        {
            var result = _studentService.DeleteStudentById(id);

            return result;
        }
    }
}