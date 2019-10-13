using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
// Including namespaces to connect to OLEDB provider
using System.Data.OleDb;
using System.Net;



/// <summary>
/// This class will get the user activity and store it in the database table tblUserActivity
/// </summary>
public class clsDataLayer
{
    // This function gets the user activity from the tblUserActivity
    public static dsUserActivity GetUserActivity(string Database)
    {
        // creating OLEDB Dataset, OLEDB connection and Data adapter objects
        dsUserActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        //create a new connection and provide conenction string to the connection object
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
        "Data Source=" + Database);
        // create a new data adapter and provide query to the data adapter
        sqlDA = new OleDbDataAdapter("select * from tblUserActivity", sqlConn);
        // allocate new data set
        DS = new dsUserActivity();
        // fill the dataset with the results generated from the query
        sqlDA.Fill(DS.tblUserActivity);
        // return the data set
        return DS;
    }

    public static dsPersonnel GetPersonnel(string Database, string strSearch)
    {
        // creating OLEDB Dataset, OLEDB connection and Data adapter objects
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        //create a new connection and provide conenction string to the connection object
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
        "Data Source=" + Database);

        //A where clause for the sql query initially set to empty string
        string whereClause = "";
        //Checks if strSearch paramter has some value then set the where clause
        if (strSearch.Trim().Length > 0)
            whereClause = whereClause + " where LastName = '" + strSearch + "'";

        // create a new data adapter and provide query to the data adapter with the where clause
        sqlDA = new OleDbDataAdapter("select * from tblPersonnel "+whereClause, sqlConn);
        // allocate new data set
        DS = new dsPersonnel();
        // fill the dataset with the results generated from the query
        sqlDA.Fill(DS.tblPersonnel);
        // return the data set
        return DS;
    }
    // This function saves the user activity
    public static void SaveUserActivity(string Database, string FormAccessed)
    {
        // create a new connection and provide connection string to the connection object
        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
        "Data Source=" + Database);
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        string strSQL;
        strSQL = "Insert into tblUserActivity (UserIP, FormAccessed) values ('" +
    GetIP4Address() + "', '" + FormAccessed + "')";
        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }
    // This function gets the IP Address
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;
        foreach (IPAddress IPA in
        Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }
        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        return IP4Address;
    }


    public clsDataLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // This function saves the personnel data
    public static bool SavePersonnel(string Database, string FirstName, string LastName,
    string PayRate, string StartDate, string EndDate)
    {

        bool recordSaved;

        // Create a new Oledb Transaction object
        OleDbTransaction myTransaction = null;


        try
        {
            // Create a New Connection Object to the Access Database
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;

            // set the transaction object and start the transaction
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;

            
            // Create the sql query and set the values from the parameters of first and last names only
            strSQL = "Insert into tblPersonnel " +
            "(FirstName, LastName) values ('" +
            FirstName + "', '" + LastName + "')";
            // set the command text of the command object
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // Execute the insert statement
            command.ExecuteNonQuery();
            // now update the newly created record with payrate,startdate and enddate values
            strSQL = "Update tblPersonnel " +
            "Set PayRate=" + PayRate + ", " +
            "StartDate='" + StartDate + "', " +
            "EndDate='" + EndDate + "' " +
            "Where ID=(Select Max(ID) From tblPersonnel)";
            // update the command text property for the command object
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // now execute the update command
            command.ExecuteNonQuery();


            // Commit the transaction when both insert and update queries have been successfully executed
            myTransaction.Commit();

            // Close the Database connection
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            //Rollback the transaction if some failure occurs
            myTransaction.Rollback();

            recordSaved = false;


        }

        return recordSaved;
    }

    // This function verifies a user in the tblUser table
    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        // Create a dataset object of dsUser dataset
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // Create a connection to the database
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
        "Data Source=" + Database);
        // open dataadapter and set the query
        sqlDA = new OleDbDataAdapter("Select SecurityLevel from tblUserLogin " +
        "where UserName like '" + UserName + "' " +
        "and UserPassword like '" + UserPassword + "'", sqlConn);
        // allocate memory to the dataset object
        DS = new dsUser();
        // fill the dataset using the dataadapter
        sqlDA.Fill(DS.tblUserLogin);
        // return the filled dataset with the data
        return DS;
    }

    // This function saves the personnel data
    public static bool SaveUser(string Database, string UserName, string Password,
    string role)
    {

        bool recordSaved;



        try
        {
            // Create a New Connection Object to the Access Database
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;

        


            // Create the sql query and set the values from the parameters of first and last names only
            strSQL = "Insert into tblUserLogin " +
            "(UserName, UserPassword, SecurityLevel) values ('" +
            UserName + "', '" + Password + "', '" + role + "')";
            // set the command text of the command object
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // Execute the insert statement
            command.ExecuteNonQuery();
           
            // Close the Database connection
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            
            recordSaved = false;


        }

        return recordSaved;
    }


}
