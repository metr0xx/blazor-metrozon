using Npgsql;
using System;
using System.Collections.Generic;

namespace blazor_metrozon.Models
{
    public class PostgresConnection
    {
        /*public static async void Connection()
        {
            String connectionString = "Server=localhost;Port=5432;User=postgres;Password=Vbifyz5558;Database=metrozonDB;";
            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();
            await using (var cmd = new NpgsqlCommand("INSERT INTO users (Name, Surname, Money, Phone, Email, Password) VALUES ('Bob', 'Semenov', 15000, '865384358', 'bs@bww.com', '123')", conn))
            {
                cmd.Parameters.AddWithValue("Hello world");
                await cmd.ExecuteNonQueryAsync();
            }
            List<string> res = new List<string>();
            await using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    res.Add(reader.GetString(0));
                }
            }
        }*/
        
    }
}
