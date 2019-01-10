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
    }
}
