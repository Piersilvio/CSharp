using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SQLServerDB.DB;
using System.Data;

namespace SQLServerDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ConnectionString = "Server=20222312-AIT;Database=Northwind;Trusted_Connection=True;User ID=PROD/pspicoli; Password=ElToroLautaro10##;TrustServerCertificate=True";

            DBConnection db = new DBConnection(ConnectionString);

            var flag = db.Connection().Result;
            
            if(flag) {
                Console.WriteLine("Connesione aperta");
            }
            else
            {
                Console.WriteLine("Connesione non aperta");
            }
        }
    }
}