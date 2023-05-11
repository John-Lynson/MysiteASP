using Microsoft.Data.SqlClient;
using Mysite.Core.Interfaces;

namespace Mysite.DataAccess.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly string _connectionString;

        public ShoppingCartRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(string id)
        {
            ShoppingCart shoppingCart = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM ShoppingCarts WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            shoppingCart = new ShoppingCart
                            {
                                Id = (string)reader["Id"],
                                UserId = (string)reader["UserId"],
                                // Add other fields
                            };
                        }
                    }
                }
            }
            return shoppingCart;
        }
        // Continue implementing the rest of the methods similarly...
    }

    // InventoryRepository using ADO.NET
    public class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Inventory> GetInventoryByProductIdAsync(int productId)
        {
            Inventory inventory = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Inventories WHERE ProductId = @ProductId", connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            inventory = new Inventory
                            {
                                ProductId = (int)reader["ProductId"],
                                Stock = (int)reader["Stock"],
                                // Add other fields
                            };
                        }
                    }
                }
            }
            return inventory;
        }
        // Continue implementing the rest of the methods similarly...
    }
