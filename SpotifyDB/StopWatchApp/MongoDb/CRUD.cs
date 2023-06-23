using System;
using System.Collections.Generic;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDb.Tables;

namespace Monogo
{
    public class CRUD
    {
        private IMongoDatabase database;
        private Stopwatch stopwatch = new Stopwatch();

        public CRUD(string db)
        {
            var client = new MongoClient();
            database = client.GetDatabase(db);

            /*database.CreateCollection("Users");
            database.CreateCollection("Artists");
            database.CreateCollection("Songs");*/
        }

        private void InsertData<D>(string table, D data)
        {
            var collection = database.GetCollection<D>(table);
            collection.InsertOne(data);
        }

        private List<D> ReadData<D>(string table)
        {
            var collection = database.GetCollection<D>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        private void UpdateData<D>(string table, Guid userId, D updatedData)
        {
            var collection = database.GetCollection<D>(table);
            var filter = Builders<D>.Filter.Eq("UserId", userId);
            collection.ReplaceOne(filter, updatedData);
        }

        private void DeleteData<D>(string table, Guid userId)
        {
            var collection = database.GetCollection<D>(table);
            var filter = Builders<D>.Filter.Eq("UserId", userId);
            collection.DeleteOne(filter);
        }

        //method to insert
        public void TimeItTakesToInsert(int numberOfRows)
        {
            stopwatch.Start();
            for (int i = 1; i <= numberOfRows; i++)
            {
                var user = new Users
                {
                    UserId = Guid.NewGuid(),
                    Username = "User" + i,
                    Email = "user" + i + "@gmail.com",
                    Password = "password" + i,
                    RegisteredDate = DateTime.Now
                };
                InsertData("Users", user);
            }
            stopwatch.Stop();
            Console.WriteLine("Insertion completed in: {0}", stopwatch.Elapsed);
        }

        //method to read data using number of rows
        public void TimeItTakesToRead(int numberOfRows)
        {
            stopwatch.Start();
            var dataToRead = ReadData<Users>("Users");
            for (int i = 0; i < numberOfRows; i++)
            {
                var user = dataToRead[i];
                Console.WriteLine("User: {0}, Email: {1}", user.Username, user.Email);
            }
            stopwatch.Stop();
            Console.WriteLine("Read completed in: {0}", stopwatch.Elapsed);
        }

        //method to update
        public void TimeItTakesToUpdate(int numberOfRows)
        {
            stopwatch.Start();
            var dataToRead = ReadData<Users>("Users");
            for (int i = 0; i < numberOfRows; i++)
            {
                var user = dataToRead[i];
                var updatedUser = new Users
                {
                    UserId = user.UserId,
                    Username = user.Username + "_updated",
                    Email = user.Email,
                    Password = user.Password,
                    RegisteredDate = user.RegisteredDate
                };
                UpdateData("Users", user.UserId, updatedUser);
            }
            stopwatch.Stop();
            Console.WriteLine("Update completed in: {0}", stopwatch.Elapsed);
        }

        public void TimeItTakesToDelete(int numberOfRows)
        {
            stopwatch.Start();
            var dataToRead = ReadData<Users>("Users");
            for (int i = 0; i < numberOfRows; i++)
            {
                var user = dataToRead[i];
                DeleteData<Users>("Users", user.UserId);
            }
            stopwatch.Stop();
            Console.WriteLine("Deletion completed in: {0}", stopwatch.Elapsed);
        }
    }
}
