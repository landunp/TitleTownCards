using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadTransactionData : IGetAllTransactions, IGetTransaction
    {
        public List<Transaction> GetAllTransactions()
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Transaction> allTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                allTransactions.Add(new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), transactionCost = rdr.GetDouble(2), managerID = rdr.GetInt32(3), managerName = rdr.GetString(4), employeeID = rdr.GetInt32(5), employeeName = rdr.GetString(6), memberID = rdr.GetInt32(7)});
            }
            return allTransactions;
        }
        public Transaction GetTransaction(int transactionID)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";
            MySqlCommand cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@TransactionID", transactionID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), transactionCost = rdr.GetDouble(2), managerID = rdr.GetInt32(3), managerName = rdr.GetString(4), employeeID = rdr.GetInt32(5), employeeName = rdr.GetString(6), memberID = rdr.GetInt32(7)};
        }
    } 
}