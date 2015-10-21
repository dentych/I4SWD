using BlackBookDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBookDAL.Models;
using System.Data.SQLite;
using System.Globalization;

namespace BlackBookDAL
{
    public class SqliteTransactionRepository : ITransactionRepository
    {
        SQLiteConnection con = null;

        public SqliteTransactionRepository()
        {
            string file = "BlackBook.sqlite";
            string sqlCon = "Data Source=" + file + ";Version=3";

            con = new SQLiteConnection(sqlCon);

            con.Open();
            string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Transactions'";
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

                sql = @"CREATE TABLE `Transactions` (
	                        `ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                        `DebitorID`	INTEGER NOT NULL,
	                        `Amount`	INT NOT NULL,
	                        `Date`	TEXT NOT NULL,
	                        FOREIGN KEY(`DebitorID`) REFERENCES Assholes ( ID )
                        );";

                var cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void InsertTransaction(Transaction transaction)
        {
            try
            {
                string sql = "INSERT INTO Transactions (DebitorID, Amount, Date) VALUES (@did, @amount, @date)";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@did", transaction.DebitorID);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        public void DeleteTransaction(long id)
        {
            try
            {
                string sql = "DELETE FROM Transactions WHERE ID = @id";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        public Transaction GetTransactionById(long id)
        {
            try
            {
                string sql = "SELECT * FROM Transactions WHERE ID = @id";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();

                var transaction = new Transaction
                {
                    ID = (long)reader["ID"],
                    DebitorID = (long)reader["DebitorID"],
                    Amount = (int)reader["Amount"],
                    Date = (string)reader["Date"]
                };

                con.Close();

                return transaction;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }

            return null;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            List<Transaction> transactions = null;

            try
            {
                string sql = "SELECT * FROM Transactions";

                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                Transaction transaction;
                transactions = new List<Transaction>();
                while (reader.Read())
                {
                    transaction = new Transaction
                    {
                        ID = (long)reader["ID"],
                        DebitorID = (long)reader["DebitorID"],
                        Amount = (int)reader["Amount"],
                        Date = (string)reader["Date"]
                    };
                    transactions.Add(transaction);
                }

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n{1}", e.Message, e.StackTrace);
            }

            return transactions;
        }

        public void UpdateTransaction(Transaction transaction)
        {
            try
            {
                string sql = "UPDATE Transactions WHERE ID = @id SET DebitorID = @did, Amount = @amount, Date = @date";

                var cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", transaction.ID);
                cmd.Parameters.AddWithValue("@did", transaction.DebitorID);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@date", transaction.Date);

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
