﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace blazor_metrozon.Models
{
    public class PostgresConnection
    {
        User user = new User(1, "Mikle", "Dorofey", 1000000, "849712", "aboba@edu.mirea.ru", "1234");
        /*static StreamReader rd = new StreamReader("C:/data/string.txt");*/

        private static string con_str = "host=localhost;Port=5432;Username=postgres;Password=Athhfhb5558;Database=metrozon-db;";
        static NpgsqlConnection con = new NpgsqlConnection(con_str);
        public static List<Product> ShowProducts()
        {
            List<Product> products = new List<Product>();
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

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            con.Open();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM categories", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category(
                        reader.GetInt32(0),
                        reader.GetString(1));
                    categories.Add(category);
            }
            con.Close();
            return categories;
        }
        public async Task<List<int>> SyncBag(int product_id, bool NewElem)
        {
            con.Open();
            NpgsqlCommand SearchProductsByUserId = new NpgsqlCommand($"SELECT * FRPOM users WHERE user_id={user.User_id}", con);
            NpgsqlDataReader reader = SearchProductsByUserId.ExecuteReader();
            string UserBagData = "";
            List<int> BagData = new List<int>();
            try
            {
                UserBagData = reader.GetString(7);

                for (int i = 0; i < UserBagData.Length; i += 2) BagData.Add(Convert.ToInt32(UserBagData[i]));
                UserBagData = "";
            }
            catch { }

            finally
            {
                if (NewElem) BagData.Add(product_id);
                else BagData.Remove(product_id);
                for (int i = 0; i < BagData.Count; i++) UserBagData += $"{BagData[i]};";
                NpgsqlCommand UpdateBag = new NpgsqlCommand($"UPDATE users SET products-in-bag = {UserBagData} WHERE user_id={user.User_id}", con);
            }
            return BagData;
        }
        public static async Task AddProduct(int seller_id, int category_id, int amount, int price, string title, string description)
        {
            con.Open();
            
                NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO product (seller_id, category_id, amount, price, rating, title, description) VALUES ({seller_id}, {category_id}, {amount}, {price}, 4.2, '{title}', '{description}')", con);

                cmd.ExecuteNonQuery();
            
            
            con.Close();
        }

        void DeleteProduct(int product_id)
        {

        }
        void SellProduct(int product_id)
        {

        }

    }

}
