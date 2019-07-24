using Domain;
using System;

namespace Services
{
    public interface IStudentService
    {
        Guid StoreStudent(Student student);
    }
}
