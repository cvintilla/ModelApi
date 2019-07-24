using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// The course object
    /// </summary>
    public class Course
    {
        /// <summary>
        /// The course code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of the course.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The grade in the course
        /// </summary>
        public float Grade { get; set; }
    }
}
