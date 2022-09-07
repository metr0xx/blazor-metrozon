using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace blazor_metrozon.Models
{
    public class PostgresConnection
    {
        User user = new User(1, "Mikle", "Frolov", 1200, "88005553535", "abobz@aboba.com", "12345");
        static StreamReader rd = new StreamReader("C:/data/string.txt");
        static string con_str = rd.ReadLine();
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
        public List<int> SyncBag(int product_id, bool NewElem)
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
        void AddProduct(string[] values)
            {
            }

            void DeleteProduct(int product_id)
            {

            }
            void SellProduct(int product_id)
            {

            }

        }

    }
