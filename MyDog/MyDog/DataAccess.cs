using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

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
            var sql = "SELECT Dog.Name, Dog.Id, Breed.Name FROM Dog JOIN Breed ON Dog.BreedId = Breed.Id";

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
                    dog.Id = reader.GetSqlInt32(1).Value;
                    dog.Breed = reader.GetSqlString(2).Value;
                    listOfDogs.Add(dog);
                }

                return listOfDogs;
            }
        }

        internal void RemoveRing(int ringId)
        {
            var sql = "DELETE FROM Ring WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", ringId));
                command.ExecuteNonQuery();
            }
        }

        internal void RemoveRingFromRingExhibitor(int ringId)
        {
            var sql = "DELETE FROM RingExhibitor WHERE RingId = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", ringId));
                command.ExecuteNonQuery();
            }
        }

        internal void RemoveRingFromRingBreed(int ringId)
        {
            var sql = "DELETE FROM RingBreed WHERE RingId = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", ringId));
                command.ExecuteNonQuery();
            }

        }

        internal bool CheckIfRingIdExists(int ringId)
        {
            List<Ring> listOfRings = GetAllRings();

            if (listOfRings.Select(r => r.Id).Contains(ringId))
                return true;
            else
                return false;
        }

        internal void RemoveDog(int dogId)
        {
            var sql = "DELETE FROM Dog WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", dogId));
                command.ExecuteNonQuery();
            }
        }

        internal void RemoveDogFromExhibitorDog(int dogId)
        {
            var sql = "DELETE FROM ExhibitorDog WHERE DogId =@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", dogId));
                command.ExecuteNonQuery();
            }
        }

        internal bool CheckIfDogIdExists(int dogId)
        {
            List<Dog> listOfDogs = GetAllDogs();

            if (listOfDogs.Select(d => d.Id).Contains(dogId))
                return true;
            else
                return false;
        }

        internal void CreateDogs(Exhibitor exhibitor)
        {

            foreach (var dog in exhibitor.Dogs)
            {
                //Get breedId from the name of the breed (required to create an instance of dog in the DB)
                int breedId = GetBreedIdFromBreedName(dog);//Kan ej få den att skapa en ny ras om den inte redan finns

                if (breedId == 0)
                {
                    CreateBreed(dog);
                    breedId = GetBreedIdFromBreedName(dog);
                }

                var sql = "INSERT INTO DOG(Name, BreedId) VALUES(@Name,@BreedId)";


                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("Name", dog.Name));
                    command.Parameters.Add(new SqlParameter("BreedId", breedId));

                    command.ExecuteNonQuery();
                }

                AddToExhibitorDogTable(dog, exhibitor);
            }
        }

        private void AddToExhibitorDogTable(Dog dog, Exhibitor exhibitor)
        {
            int dogId = GetDogId(dog);
            int exhibitorId = GetExhibitorId(exhibitor);

            var sql = "INSERT INTO ExhibitorDog VALUES(@DogId, @ExhibitorId)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("DogId", dogId));
                command.Parameters.Add(new SqlParameter("ExhibitorId", exhibitorId));

                command.ExecuteNonQuery();
            }

        }

        private int GetExhibitorId(Exhibitor exhibitor)
        {
            var sql = @"SELECT Id FROM Exhibitor
                        WHERE Mailadress = @Mailadress";

            int exhibitorId = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Mailadress", exhibitor.EmailAdress));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    exhibitorId = reader.GetInt32(0);
                    return exhibitorId;
                }

                return exhibitorId;
            }
        }

        private int GetDogId(Dog dog)
        {
            var sql = @"SELECT Id FROM Dog
                        WHERE Name = @Name";

            int dogId = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Name", dog.Name));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dogId = reader.GetInt32(0);
                    return dogId;
                }

                return dogId;
            }
        }

        internal void RemoveExhibitorFromRingExhibitor(int exhibitorId)
        {
            var sql = "DELETE FROM RingExhibitor WHERE ExhibitorId = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", exhibitorId));
                command.ExecuteNonQuery();
            }
        }

        internal void RemoveExhibitorFromExhibitorDog(int exhibitorId)
        {
            var sql = "DELETE FROM ExhibitorDog WHERE ExhibitorId = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", exhibitorId));
                command.ExecuteNonQuery();
            }
        }

        internal void RemoveExhibitor(int exhibitorId)
        {
            var sql = "DELETE FROM Exhibitor WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Id", exhibitorId));

                command.ExecuteNonQuery();
            }
        }

        internal bool CheckIfExhibitorIdExists(int exhibitorId)
        {
            List<Exhibitor> listOfExhibitors = GetAllExhibitors();

            if (listOfExhibitors.Select(e => e.Id).Contains(exhibitorId))
                return true;
            else
                return false;
        }

        internal bool CheckIfBreedIdExists(int breedId)
        {
            List<Breed> listOfBreeds = GetAllBreeds();

            if (listOfBreeds.Select(b => b.Id).Contains(breedId))
                return true;
            else
                return false;

        }

        internal void RemoveBreed(int breedId)
        {
            var sql = "DELETE FROM Breed WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Id", breedId));

                command.ExecuteNonQuery();
            }
        }

        internal bool CheckIfRingExists(Ring ring)
        {
            List<Ring> listOfRings = GetAllRings();

            if (listOfRings.Select(r => r.Number).Contains(ring.Number))
                return true;
            else
                return false;
        }

        internal void CreateRing(Ring ring)
        {
            var sql = "INSERT INTO Ring VALUES(@Number)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Number", ring.Number));

                command.ExecuteNonQuery();
            }

        }

        internal void CreateBreed(Breed breed)
        {
            var sql = "INSERT INTO Breed VALUES(@Name)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Name", breed.Name));

                command.ExecuteNonQuery();
            }
        }

        internal void CreateExhibitor(Exhibitor exhibitor)
        {
            var sql = "INSERT INTO Exhibitor(FirstName, LastName, PhoneNumber, Mailadress) " +
                        "VALUES (@FirstName, @LastName, @PhoneNumber, @EmailAdress)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("FirstName", exhibitor.FirstName));
                command.Parameters.Add(new SqlParameter("LastName", exhibitor.LastName));
                command.Parameters.Add(new SqlParameter("PhoneNumber", exhibitor.PhoneNumber));
                command.Parameters.Add(new SqlParameter("EmailAdress", exhibitor.EmailAdress));

                command.ExecuteNonQuery();
            }
        }

        internal void CreateBreed(Dog dog)
        {
            var sql = "INSERT INTO Breed VALUES(@Name)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Name", dog.Breed));

                command.ExecuteNonQuery();
            }
        }

        internal void CreateDog(Dog dog)
        {

            //Get breedId from the name of the breed (required to create an instance of dog in the DB)
            int breedId = GetBreedIdFromBreedName(dog);//Kan ej få den att skapa en ny ras om den inte redan finns

            if (breedId == 0)
            {
                CreateBreed(dog);
                breedId = GetBreedIdFromBreedName(dog);
            }

            var sql = "INSERT INTO DOG(Name, BreedId) VALUES(@Name,@BreedId)";


                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("Name", dog.Name));
                    command.Parameters.Add(new SqlParameter("BreedId", breedId));

                    command.ExecuteNonQuery();
                }
        }

        private int GetBreedIdFromBreedName(Dog dog)
        {
            var sql = "SELECT Breed.Id, Breed.Name FROM Breed FULL JOIN Dog ON Breed.Id = Dog.BreedId WHERE Breed.Name = @Name";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Name", dog.Breed));

                SqlDataReader reader = command.ExecuteReader();

                int breedId = 0;

                while (reader.Read())
                {
                    breedId = reader.GetSqlInt32(0).Value;
                }

                return breedId;
            }


        }

        internal bool CheckIfBreedExists(Breed breed)
        {
            List<Breed> listOfBreeds = GetAllBreeds();

            if (listOfBreeds.Select(b => b.Name).Contains(breed.Name))
                return true;
            else
                return false;
        }

        internal bool CheckIfBreedExists(Dog dog)
        {
            List<Breed> listOfBreeds = GetAllBreeds();

            if (listOfBreeds.Select(b => b.Name).Contains(dog.Breed))
                return true;
            else
                return false;
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
                    exhibitor.PhoneNumber = reader.GetSqlString(3).Value;
                    exhibitor.EmailAdress = reader.GetSqlString(4).Value;

                    listOfExhibitors.Add(exhibitor);

                }

                return listOfExhibitors;
            }
        }
    }
}
