using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolMVC.Models
{
    public class Connection
    {
        SqlDataReader Datareader;
        //global declaration of the variable 
        SqlConnection connection;
        String connection_String = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=SchoolEntity;Integrated Security=True";
        SqlCommand command;



        //this method is used to insert the query in the database table that is used to store the record of the query
        public void sendfeedback(String qry)
        {
            // passing the connection string to the conection class
            connection = new SqlConnection(connection_String);
            //open the connection 
            connection.Open();
            //passing the connection with the command relation 
            command = new SqlCommand(qry, connection);
            ////calling the method to execute the query 
            command.ExecuteNonQuery();
            //closing the connection 
            connection.Close();
        }


        public DataTable SrchLogin(String qry)
        {
            DataTable tbl = new DataTable();


            connection = new SqlConnection(connection_String);

            connection.Open();
            command = new SqlCommand(qry, connection);

            Datareader = command.ExecuteReader();

            tbl.Load(Datareader);

            connection.Close();

            return tbl;
        }



    }
}