using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebTEST4.Models
{
    public class AppContext
    {
        public string ConnectionString { get; set; }

        public AppContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            user_id = Convert.ToInt32(reader["user_id"]),
                            user_name = reader["user_name"].ToString(),
                            user_pass = reader["user_pass"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
        public List<Inventory> GetAllInventories(int uid)
        {
            List<Inventory> list = new List<Inventory>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from inventory where user={uid}", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Inventory()
                        {
                            inv_id = Convert.ToInt32(reader["inv_id"]),
                            item = Convert.ToInt32(reader["item"]),
                            count = Convert.ToInt32(reader["inv_count"]),
                            user = Convert.ToInt32(reader["user"])
                        });
                    }
                }
            }
            return list;
        }
        public List<Item_type> GetAllItemTypes()
        {
            List<Item_type> list = new List<Item_type>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from item_type", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Item_type()
                        {
                            item_type_id = Convert.ToInt32(reader["inv_id"]),
                            item_type_name = reader["item_type_name"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
        public List<Item> GetAllItems()
        {
            List<Item> list = new List<Item>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from item", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Item()
                        {
                            item_id = Convert.ToInt32(reader["item_id"]),
                            item_name = reader["item_name"].ToString(),
                            item_desc = reader["item_desc"].ToString(),
                            image = reader["item_image"].ToString(),
                            item_type = Convert.ToInt32(reader["item_type"]),
                        });
                    }
                }
            }
            return list;
        }
        public void AddUser(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into user(user_name, user_pass) values ('{username}', '{password}')", conn);
                cmd.ExecuteReader();
            }
        }
        public void AddInventory(int item, int count, int user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into inventory(item, inv_count, user) values ('{item}', '{count}', '{user}')", conn);
                cmd.ExecuteReader();
            }
        }
        public void Default()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update util set uid=0, isAuthorized=false", conn);
                cmd.ExecuteReader();
            }
        }
        public bool isAuthorized()
        {
            int pass = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from util where id=1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pass = Convert.ToInt32(reader["isAuthorized"]);
                    }
                }
            }
            if (pass == 0)
                return false;
            else
                return true;
        }
        public void Authorize(int user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"update util set uid={user}, isAuthorized=true", conn);
                cmd.ExecuteReader();
            }
        }
        public int UniqueID()
        {
            int uid = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from util where id=1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uid = Convert.ToInt32(reader["uid"]);
                    }
                }
            }
            return uid;

        }
        public List<UniversalModel> GetModelByType(int uid, int type)
        {
            List<UniversalModel> list = new List<UniversalModel>();
            List<Item> items = GetAllItems();
            List<Inventory> inventory = GetAllInventories(uid);

            foreach(Inventory i in inventory)
            {
                foreach(Item j in items)
                {
                    if (i.item == j.item_id)
                    {
                        if(j.item_type == type)
                        {
                            list.Add(new UniversalModel
                            {
                                count = i.count,
                                item_desc = j.item_desc,
                                item_image = j.image,
                                item_name = j.item_name
                            });
                        }
                    }
                }
            }
            return list;
        }
        public void EditInventoryCount(int count, int item, int user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"update inventory set inv_count={count} where item={item} and user={user}", conn);
                cmd.ExecuteReader();
            }
        }
        public void DeleteItem(int item, int uid)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"delete from inventory where item={item} and user={uid}", conn);
                cmd.ExecuteReader();
            }
        }
    }
}
