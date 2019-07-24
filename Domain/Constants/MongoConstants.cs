using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// The mongo constants
    /// </summary>
    public class MongoConstants
    {
        /// <summary>
        /// Connection string for mongo
        /// </summary>
        public string connectionString = "mongodb://localhost:27017";

        /// <summary>
        /// The school database for mongo
        /// </summary>
        public string databaseName = "schoolDB";
        
        /// <summary>
        /// the student collection for mongo
        /// </summary>
        public string studentCollection = "studentCollection";
    }
}
