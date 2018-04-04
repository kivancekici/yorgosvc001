using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper
{
    private MySqlConnection mysqlConn;
    private string server="localhost";
    private string database;
    private string uid;
    private string password;
    public DBHelper()
    {
        initDBHelper();
    }

    private void initDBHelper()
    {
        server = "localhost:3306";
        database = "yorgopos";
        uid = "root";
        password = "password";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        mysqlConn = new MySqlConnection(connectionString);

        openConnection();
    }

    private bool openConnection()
    {
        try
        {
            mysqlConn.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            return false;
        }
    }

    private bool closeConnection()
    {
        try
        {
            mysqlConn.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            return false;
        }
    }


    public static DBHelper getDBHelper()
    {
        return new DBHelper();
    }


    public bool insertUpdate(MySqlCommand cmd)
    {
        try
        {
            cmd.Connection = mysqlConn;
            cmd.ExecuteNonQuery();
            return true;
        }catch(Exception ex)
        {
            return false;
        }
    }


    public DataSet select(MySqlCommand cmd)
    {
        try
        {
            cmd.Connection = mysqlConn;
            MySqlDataAdapter mda = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            mda.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}