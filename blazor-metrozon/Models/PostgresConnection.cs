using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using blazor_metrozon.Data;

namespace blazor_metrozon.Models
{
    public class PostgresConnection
    {
        User user = new User(1, "Mikle", "Frolov", 1200, "88005553535", "abobz@aboba.com", "12345");

        public static List<Product> ShowProducts()
        {
            List<Product> products = new List<Product>();
            StreamReader rd = new StreamReader("./Data/data.txt");
            string con_str = rd.ReadLine();
            NpgsqlConnection con = new NpgsqlConnection(con_str);
            con.Open();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM product", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Product product = new Product(          
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4),
                    reader.GetDouble(5),
                    reader.GetString(6),
                    reader.GetString(7));
                    products.Add(product);
                }
                catch { }
            }
            con.Close();
            return products;
        }
        void AddProduct(string[] values)
        {

        }
        void DeleteProduct(int product_id)
        {

        }
        void SellProduct(int product_id)
        {

        }


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
