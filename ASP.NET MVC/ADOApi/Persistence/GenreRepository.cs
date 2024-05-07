using ADOApi.Core.Interfaces;
using ADOApi.Core.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADOApi.Persistence
{
    public class GenreRepository : IGenreRepository
    {
        private readonly string connectionString;
        public GenreRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLSPNames.GetAllGenres, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var genre = new Genre { 
                            Id = reader.GetInt32("Id"), 
                            Name = reader.GetString("Name"),
                        };

                        genres.Add(genre);
                    }
                }
            }

            return genres;
        }
    }
}
