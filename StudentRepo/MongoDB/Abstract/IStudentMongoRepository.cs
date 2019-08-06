using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IStudentMongoRepository
    {
        List<Student> GetStudents();
        Guid UpdateStudentById(Guid id, Student newStudent);
        Guid CreateStudent(Student student);
        long DeleteStudentById(Guid studentId);
    }
}
