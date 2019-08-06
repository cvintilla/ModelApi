using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        /// <summary>
        /// The ID of the student
        /// </summary>
        [IgnoreDataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the student
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of courses the
        /// </summary>
        public List<Course> Course { get; set; }

        /// <summary>
        /// the students gpa
        /// </summary>
        public double GPA { get; set; }
    }
}
