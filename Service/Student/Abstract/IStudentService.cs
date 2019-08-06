using Domain;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Guid UpdateStudentById(Guid id, Student newStudent);
        Guid CreateStudent(Student student);
        long DeleteStudentById(Guid studentId);
    }
}