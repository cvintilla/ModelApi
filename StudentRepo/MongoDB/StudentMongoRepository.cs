using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class StudentMongoRepository : IStudentMongoRepository
    {
        private readonly MongoConstants _constants;

        public StudentMongoRepository(MongoConstants constants)
        {
            _constants = constants;
        }

        public List<Student> GetStudents()
        {
            var collection = StudentCollection();

            FilterDefinition<Student> filter = FilterDefinition<Student>.Empty;

            var results = collection.Find(filter).ToList();

            return results;
        }

        public Guid UpdateStudentById(Guid id, Student newStudent)
        {
            var collection = StudentCollection();

            var filter = collection.Find(x => x.Id == id).Filter;

            collection.ReplaceOne(filter, newStudent);

            return newStudent.Id;
        }

        public Guid CreateStudent(Student student)
        {
            var collection = StudentCollection();

            collection.InsertOne(student);

            return student.Id;
        }

        public long DeleteStudentById(Guid id)
        {
            var collection = StudentCollection();

            var filter = collection.Find(x => x.Id == id).Filter;

            var deleteResult = collection.DeleteOne(filter);

            return deleteResult.DeletedCount;
        }

        private IMongoCollection<Student> StudentCollection()
        {
            var db = Connection();

            var collection = db.GetCollection<Student>(_constants.studentCollection);

            return collection;
        }

        private IMongoDatabase Connection()
        {
            var client = new MongoClient();

            var database = client.GetDatabase(_constants.databaseName);

            return database;
        }
    }
}
