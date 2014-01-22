using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace db
{
    partial class Database
    {

        public string GetHouseName(int id)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "SELECT HouseName FROM accounts WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                if (!rdr.HasRows) return "";
                rdr.Read();
                return rdr.GetString("HouseName");
            }
        }

        public int GetHouseId(string name)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "SELECT house FROM accounts WHERE name=@name;";
            cmd.Parameters.AddWithValue("@name", name);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                if (!rdr.HasRows) return 0;
                rdr.Read();
                return rdr.GetInt32("house");
            }
        }
        public void UpgradeHouseLevel(int id, int newLevel)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "UPDATE accounts SET HouseLevel=@level WHERE house=@id";
            cmd.Parameters.AddWithValue("@level", newLevel);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public int GetHouseLevel(int id)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "SELECT HouseLevel FROM accounts WHERE house=@id";
            cmd.Parameters.AddWithValue("@id", id);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
    }
}