﻿using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazor_metrozon.Models
{
    public static class PostgresConnection
    {
        private static string con_str = "host=localhost;Port=5432;Username=postgres;Password=Athhfhb5558;Database=metrozon-db;";
        static NpgsqlConnection con = new NpgsqlConnection(con_str);
        public static List<Product> ShowProducts()
        {
            var products = new List<Product>();
            con.Open();
            var com = new NpgsqlCommand("SELECT * FROM product", con);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    var product = new Product(
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

        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            con.Open();
            var com = new NpgsqlCommand("SELECT * FROM categories", con);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var category = new Category(
                        reader.GetInt32(0),
                        reader.GetString(1));
                    categories.Add(category);
            }
            con.Close();
            return categories;
        }
        public static async Task BagAdd(int user_id, int product_id, bool alreadyHasPr)
        {
            con.Open();
            NpgsqlCommand cmd;
            if (alreadyHasPr)
            {
                cmd = new NpgsqlCommand(
                    $"UPDATE bag SET amount = amount + 1 WHERE user_id = {user_id} AND in_bag = {product_id}", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd = new NpgsqlCommand(
                    $"INSERT INTO bag (user_id, in_bag, amount) VALUES ({user_id}, {product_id}, 1)", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

        public static async Task BagDelete(int user_id, int product_id)
        {
            con.Open();

            try
            {
                var cmd = new NpgsqlCommand(
                    $"DELETE FROM bag WHERE user_id = {user_id} AND in_bag = {product_id} AND amount = 0", con);
                cmd.ExecuteNonQuery();
            }

            catch
            {
                var cmd = new NpgsqlCommand($"UPDATE bag SET amount = amount - 1 WHERE user_id = {user_id} AND in_bag = {product_id}", con);
                cmd.ExecuteNonQuery();
            }
            
            con.Close();
        }

        public static async Task<List<Bag>> GetBagData(int user_id)
        {
            var bagData = new List<Bag>();
            con.Open();
            var cmd = new NpgsqlCommand($"SELECT * FROM bag WHERE user_id = {user_id}", con);
            var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                var userBag = new Bag(
                reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                bagData.Add(userBag);
            }
            con.Close();
            return bagData;
        }
        public static async Task AddProduct(int seller_id, int category_id, int amount, int price, string title, string description)
        {
            con.Open();
            
                var cmd = new NpgsqlCommand($"INSERT INTO product (" +
                                            $"seller_id, category_id, amount, price, rating, title, description) " +
                                            $"VALUES ({seller_id}, {category_id}, {amount}, {price}, 4.2, '{title}', '{description}')", con);

                cmd.ExecuteNonQuery();
                con.Close();
        }

        public static async Task ChangeProduct(int product_id, int category_id, int amount, int price, string title, string description)
        {
            con.Open();
            
            var cmd = new NpgsqlCommand("UPDATE product SET " +
                                        $"category_id = {category_id}, " +
                                        $"amount = {amount}, " +
                                        $"price = {price}, " +
                                        $"title = '{title}', " +
                                        $"description = '{description}' " + $"WHERE product_id = {product_id}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static async Task DeleteProduct(int product_id)
        {
            con.Open();
            var cmd = new NpgsqlCommand($"DELETE FROM product WHERE product_id = {product_id}", con);

            con.Close();
        }
        static async Task SellProduct(int product_id)
        {

        }

    }

}
