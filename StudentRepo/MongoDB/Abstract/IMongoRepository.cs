using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IMongoRepository
    {
        Guid CreateStudent(Student student);
        List<Guid> CreateStudents(List<Student> students);
        Guid UpdateStudent(Student newStudent);
        Guid DeleteStudent(Guid studentId);
        List<Student> GetStudents();
    }
}
