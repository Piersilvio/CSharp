using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDB.DB
{
    internal class DBConnection
    {
        protected string? _StringConnection { get; set; }
        public SqlConnection _Connection { get; set; }

        public DBConnection(string stringConn) { this._StringConnection = stringConn; }
      
        public async Task<bool> Connection()
        {
            var flag = false;

            this._Connection = new SqlConnection(this._StringConnection);

            try
            {
                //open conn
                await this._Connection.OpenAsync();
                flag = true;
            }
            catch (SqlException ex)
            {
                flag = false; //connessione fallita
            }
            finally
            {
                //close conn
                if (this._Connection.State == System.Data.ConnectionState.Closed) { this._Connection.Close(); }
            }

            return flag;
        }



        public async Task SimpleOperation()
        {
            //aggiornamento
            //var updateQuery = new SqlCommand("UPDATE Products SET ...", this._Connection);
            //int affectedRows = await updateQuery.ExecuteNonQueryAsync();

            // Query
            try
            {
                var query = new SqlCommand("SELECT * FROM Products", this._Connection);
                SqlDataReader reader = await query.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Conteggio
            var countQuery = new SqlCommand("SELECT COUNT(*) FROM Products", this._Connection);
            var v = await countQuery.ExecuteScalarAsync();
            var count = (int)v;
        }
    }

    //internal class DBOperations : DBConnection
    //{
    //    public DBOperations(string stringConn) : base(stringConn) { }

    //    public async Task SimpleOperation()
    //    {
    //        //aggiornamento
    //        var updateQuery = new SqlCommand("UPDATE Products SET ...", this._Connection);
    //        int affectedRows = await updateQuery.ExecuteNonQueryAsync();

    //        // Query
    //        var query = new SqlCommand("SELECT * FROM Products", this._Connection);
    //        SqlDataReader reader = await query.ExecuteReaderAsync();

    //        // Conteggio
    //        var countQuery = new SqlCommand("SELECT COUNT(*) FROM Products", this._Connection);
    //        var v = await countQuery.ExecuteScalarAsync();
    //        var count =  (int)v;
    //    }
    //}
}
