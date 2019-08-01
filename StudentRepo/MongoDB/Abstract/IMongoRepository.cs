using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IMongoRepository
    {
        List<Student> GetStudents();
        Guid UpdateStudent(Student newStudent);
        Guid CreateStudent(Student student);
        long DeleteStudent(Student studentId);

        List<Guid> CreateStudents(List<Student> students);
    }
}
