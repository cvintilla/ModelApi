using Domain;
using MongoDB.Bson;
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

        public List<Student> GetStudents()
        {
            var collection = StudentCollection();

            FilterDefinition<Student> filter = FilterDefinition<Student>.Empty;

            var results = collection.Find(filter).ToList();

            return results;
        }

        public Guid UpdateStudent(Student newStudent)
        {
            var collection = StudentCollection();

            var filter = collection.Find(x => x.Id == newStudent.Id).Filter;

            collection.ReplaceOne(filter, newStudent);

            return newStudent.Id;
        }

        public Guid CreateStudent(Student student)
        {
            var collection = StudentCollection();

            collection.InsertOne(student);

            return student.Id;
        }

        public long DeleteStudent(Student student)
        {
            var collection = StudentCollection();


            // TODO:
            // needs to be tested
            var filter = collection.Find(x => x.Id == student.Id
            || x.Name == student.Name
            || x.Course == student.Course
            || x.GPA == student.GPA)
                .Filter;

            var deleteResult = collection.DeleteOne(filter);

            return deleteResult.DeletedCount;
        }


        public List<Guid> CreateStudents(List<Student> students)
        {
            var collection = StudentCollection();

            collection.InsertMany(students);

            var guids = students.Select(x => x.Id).ToList();

            return guids;
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
