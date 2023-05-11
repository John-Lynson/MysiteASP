using Microsoft.Data.SqlClient;
using Mysite.Core.Interfaces;
using Mysite.Core.Models;
using System.Threading.Tasks;

namespace Mysite.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> AddAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("INSERT INTO Users (Email, PasswordHash) OUTPUT INSERTED.Id VALUES (@Email, @PasswordHash)", connection))
                {
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                    user.Id = (int)await command.ExecuteScalarAsync();
                }
            }

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UPDATE Users SET Email = @Email, PasswordHash = @PasswordHash WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<User> CreateAsync(User user)
        {
            // Je kunt hier dezelfde logica gebruiken als in je AddAsync methode.
            return await AddAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                // Voeg hier eventueel andere velden toe.
                            };
                        }
                    }
                }
            }

            public async Task<User> GetByIdAsync(int id) // Deze methode moet overeenkomen met de definitie in de interface
            {
                User user = null;
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                user = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")), // Gebruik GetInt32 als de Id een integer is in de database
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    // Voeg hier de andere velden toe
                                };
                            }
                        }
                    }
                }
                return user;
            }
            // Implementeer de rest van de methoden op een vergelijkbare manier...

            // Implementeer de andere methoden die zijn gedefinieerd in de IUserRepository interface
        }

        //OrderRepository using ADO.NET
        public class OrderRepository : IOrderRepository
        {
            private readonly string _connectionString;

            public OrderRepository(string connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<Order> GetByIdAsync(int id) // Deze methode moet overeenkomen met de definitie in de interface
            {
                Order order = null;
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM Orders WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                order = new Order
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")), // Gebruik GetInt32 als de Id een integer is in de database
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")), // Gebruik GetInt32 als de UserId een integer is in de database
                                                                                           // Voeg hier de andere velden toe
                                };
                            }
                        }
                    }
                }
                return order;
            }
            // Implementeer de rest van de methoden op een vergelijkbare manier...

            // Implementeer de andere methoden die zijn gedefinieerd in de IOrderRepository interface
        }
        // Ga verder met andere repositories...
    }

}