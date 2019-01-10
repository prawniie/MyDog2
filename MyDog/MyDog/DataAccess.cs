using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace MyDog
{
    public class DataAccess
    {
        private string conString = "Server=(localdb)\\mssqllocaldb; Database=MyDog";

        internal List<Breed> GetAllBreeds()
        {
            var sql = "SELECT Id, Name FROM Breed";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var listOfBreeds = new List<Breed>();

                while (reader.Read())
                {
                    var breed = new Breed();
                    breed.Id = reader.GetSqlInt32(0).Value;
                    breed.Name = reader.GetSqlString(1).Value;
                    listOfBreeds.Add(breed);
                }

                return listOfBreeds;
            }
        }

        internal List<Dog> GetAllDogs()
        {
            var sql = "SELECT Dog.Name, Breed.Name FROM Dog JOIN Breed ON Dog.BreedId = Breed.Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var listOfDogs = new List<Dog>();

                while(reader.Read())
                {
                    var dog = new Dog();
                    dog.Name = reader.GetSqlString(0).Value;
                    dog.Breed = reader.GetSqlString(1).Value;
                    listOfDogs.Add(dog);
                }

                return listOfDogs;
            }
        }

        internal List<Ring> GetAllRings()
        {
            var sql = "SELECT Id, Number FROM Ring";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var listOfRings = new List<Ring>();

                while(reader.Read())
                {
                    var ring = new Ring();
                    ring.Id = reader.GetSqlInt32(0).Value;
                    ring.Number = reader.GetSqlInt32(1).Value;
                    listOfRings.Add(ring);
                }

                return listOfRings;
            }
        }

        internal List<Exhibitor> GetAllExhibitors()
        {
            var sql = "SELECT Id, FirstName, LastName, PhoneNumber, Mailadress FROM Exhibitor";
            //SELECT Exhibitor.Id, Exhibitor.FirstName, Exhibitor.LastName, Exhibitor.PhoneNumber, Exhibitor.Mailadress, Dog.Name, Dog.Id, Breed.Name " +
            //    "FROM Exhibitor JOIN ExhibitorDog ON Exhibitor.Id = ExhibitorDog.ExhibitorId " +
            //    "JOIN Dog ON ExhibitorDog.DogId = Dog.Id" +
            //    "JOIN Breed ON Breed.Id = Dog.BreedId
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                var listOfExhibitors = new List<Exhibitor>();

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var exhibitor = new Exhibitor();

                    exhibitor.Id = reader.GetSqlInt32(0).Value;
                    exhibitor.FirstName = reader.GetSqlString(1).Value;
                    exhibitor.LastName = reader.GetSqlString(2).Value;
                    exhibitor.PhoneNumber = reader.GetSqlInt32(3).Value;
                    exhibitor.EmailAdress = reader.GetSqlString(4).Value;

                    listOfExhibitors.Add(exhibitor);

                }

                return listOfExhibitors;
            }
        }
    }
}
