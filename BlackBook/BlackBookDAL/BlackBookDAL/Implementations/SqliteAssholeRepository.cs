using BlackBookDAL.Interfaces;
using BlackBookDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BlackBookDAL
{
    public class SqliteAssholeRepository : IAssholeRepository
    {
        SQLiteConnection con;

        public SqliteAssholeRepository()
        {
            string file = "BlackBook.sqlite";
            string sqlCon = "Data Source=" + file + ";Version=3";

            con = new SQLiteConnection(sqlCon);

            con.Open();
            string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Assholes'";
            var cmd = new SQLiteCommand(sql, con);
            if (cmd.ExecuteScalar() == null)
            {
                Init();
            }
            con.Close();
        }

        private void Init()
        {
            try
            {
                string sql;

                sql = @"CREATE TABLE `Assholes` (
	                        `ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                        `Name`	VARCHAR(50),
	                        `Debit`	INT
                        );";

                var cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void InsertAsshole(Asshole asshole)
        {
            try
            {
                con.Open();

                string sql = "INSERT INTO Assholes (Name, Debit) VALUES (@param1, @param2)";

                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@param1", asshole.Name);
                cmd.Parameters.AddWithValue("@param2", asshole.Debit);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        public void DeleteAsshole(long id)
        {
            try
            {
                string sql = "DELETE FROM Assholes WHERE ID = @param1";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@param1", id);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        public Asshole GetAssholeById(long id)
        {
            try
            {
                string sql = "SELECT * FROM Assholes WHERE ID = @param1";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@param1", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                var asshole = new Asshole
                {
                    ID = (long)reader["ID"],
                    Name = (string)reader["Name"],
                    Debit = (int)reader["Debit"]
                };

                con.Close();

                return asshole;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }

            return null;
        }

        public IEnumerable<Asshole> GetAssholes()
        {
            List<Asshole> assholes = null;

            try
            {
                string sql = "SELECT * FROM Assholes";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                Asshole asshole;
                assholes = new List<Asshole>();
                while (reader.Read())
                {
                    asshole = new Asshole
                    {
                        ID = (long)reader["ID"],
                        Name = (string)reader["Name"],
                        Debit = (int)reader["Debit"]
                    };
                    assholes.Add(asshole);
                }

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }

            return assholes;
        }
        
        public void UpdateAsshole(Asshole asshole)
        {
            try
            {
                string sql = "UPDATE Assholes WHERE ID = @id SET Name = @name, Debit = @debit";

                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", asshole.ID);
                cmd.Parameters.AddWithValue("@name", asshole.Name);
                cmd.Parameters.AddWithValue("@debit", asshole.Debit);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }
    }
}
