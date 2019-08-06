using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentMongoRepository _studentMongo;
        public StudentService(IStudentMongoRepository studentMongo)
        {
            _studentMongo = studentMongo;
        }

        public Guid CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();

            var studentId = _studentMongo.CreateStudent(student);

            return studentId;
        }

        public long DeleteStudentById(Guid studentId)
        {
            var deleted = _studentMongo.DeleteStudentById(studentId);

            return deleted;
        }

        public List<Student> GetStudents()
        {
            var students = _studentMongo.GetStudents();

            return students;
        }

        public Guid UpdateStudentById(Guid id, Student newStudent)
        {
            newStudent.Id = id;

            var studentId = _studentMongo.UpdateStudentById(id, newStudent);

            return studentId;
        }
    }
}
