using Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoConstants _constants;

        public MongoRepository(MongoConstants constants)
        {
            _constants = constants;
        }

        public Guid CreateStudent(Student student)
        {
            var collection = StudentCollection();

            collection.InsertOne(student);

            return student.Id;
        }

        public List<Guid> CreateStudents(List<Student> students)
        {
            var collection = StudentCollection();

            collection.InsertMany(students);

            var guids = students.Select(x => x.Id).ToList();

            return guids;
        }

        public Guid UpdateStudent(Student newStudent)
        {
            var collection = StudentCollection();

            var filter = collection.Find(x => x.Id == newStudent.Id).FirstOrDefault();

            var result = collection.UpdateOne(filter, newStudent);

            return result.UpsertedId.AsGuid;
        }
        
        public Guid DeleteStudent(Student student)
        {
            var collection = StudentCollection();

            var filter = collection.Find(x => x.Id == student.Id).FirstOrDefault();

            collection.DeleteOne(filter);

            return student.Id;
        }

        public List<Student> GetStudents()
        {
            var collection = StudentCollection();

            FilterDefinition<Student> filter = FilterDefinition<Student>.Empty;

            var results = collection.Find(filter).ToList();

            return results;
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
