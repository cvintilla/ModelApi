using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Student Object
    /// </summary>
    public class Student : BsonDocument
    {
        /// <summary>
        /// The ID of the student
        /// </summary>
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
