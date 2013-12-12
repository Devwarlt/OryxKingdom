using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace db
{
    partial class Database
    {
        public int GetHouseId(string name)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "SELECT id FROM houses WHERE name=@name;";
            cmd.Parameters.AddWithValue("@name", name);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                if (!rdr.HasRows) return 0;
                rdr.Read();
                return rdr.GetInt32("id");
            }
        }
        public void UpgradeHouseLevel(int id, int newLevel)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "UPDATE houses SET level=@level WHERE id=@id";
            cmd.Parameters.AddWithValue("@level", newLevel);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public int GetHouseLevel(int id)
        {
            MySqlCommand cmd = CreateQuery();
            cmd.CommandText = "SELECT level FROM houses WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
    }
}