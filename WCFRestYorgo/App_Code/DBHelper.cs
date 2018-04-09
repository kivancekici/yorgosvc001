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
    private string port = "3306";
    private string database="roadisyon";
    private string uid="root";
    private string password="roaroa";
    public DBHelper()
    {
        initDBHelper();
    }

    public static DBHelper getDBHelper()
    {
        return new DBHelper();
    }

    private void initDBHelper()
    {
        server = "localhost:3306";
        database = "yorgopos";
        uid = "root";
        password = "password";
        //new MySqlConnection("server=localhost; Port =3306; userid=root; password=roaroa; database=roadisyon; pooling=false");
        string connectionString;
        connectionString = "server=" + server + ";"+"Port="+port +";"+ "database=" +
        database + ";" + "userid=" + uid + ";" + "password=" + password + "; pooling=false;";

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

    public bool insertUpdate(MySqlCommand cmd)
    {
        try
        {
            openConnection();
            cmd.Connection = mysqlConn;
            cmd.ExecuteNonQuery();
            return true;
        }catch(Exception ex)
        {
            return false;
        }
        finally
        {
            closeConnection();
        }
    }


    public DataTable select(MySqlCommand cmd)
    {
        try
        {
            openConnection();
            cmd.Connection = mysqlConn;
            MySqlDataAdapter mda = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            mda.Fill(ds);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            closeConnection();
        }
    }




}