using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TööBaasigaDemo
{
    internal class Program
    {
        static string connectionString =
            "Data Source=valiitsql.database.windows.net;" +
            "Initial Catalog=Northwind;" +
            "User ID=student;" +
            "Password=Pa$$w0rd;";
        static void Main(string[] args)
        {
            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            string query = 
                "select productID, productName, unitPrice from products";
            //SqlCommand command = new SqlCommand(query, conn);
            //SqlDataReader R = command.ExecuteReader();
            //while(R.Read())
            //{
            //    Console.WriteLine($"toode {R["productName"]} maksab {R["unitPrice"]}");
            //}

            using(var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand(query, conn)) 
                { 
                    var R = cmd.ExecuteReader();
                    while(R.Read())
                    {
                        Console.WriteLine($"toode {R["productName"]} maksab {R["unitPrice"]}");
                    }
                }
            }

        }
    }
}
