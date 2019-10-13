using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        // Create the object to dsUser Dataset
        dsUser dsUserLogin;
        // secutrity Level variable that holds the role of the suer
        string SecurityLevel;
        // Verify user login and password from the datbase
        dsUserLogin = clsDataLayer.VerifyUser(Server.MapPath("App_Data\\PayrollSystem_DB.mdb"),
        Login1.UserName, Login1.Password);
        // if user does not exist
        if (dsUserLogin.tblUserLogin.Count < 1)
        {

            e.Authenticated = false;
            // Send the Email to the user
           if (clsBusinessLayer.SendEmail("youremail@yourdomain.com",
                "receiver@receiverdomain.com", "", "", "Login Incorrect",
                "The login failed for UserName: " + Login1.UserName +
                " Password: " + Login1.Password))
           {
 
                Login1.FailureText = Login1.FailureText +
                " Your incorrect login information was sent to receiver@receiverdomain.com";

            }

            return;
        }
        // set the security level of the user
        SecurityLevel = dsUserLogin.tblUserLogin[0].SecurityLevel.ToString();
        // switch for the security level values
        switch (SecurityLevel)
        {
            case "A":
                // if he has all the priviledges then set the session variable value to A
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "A";
                break;
            case "U":
                // if the user has limited priviledges then set the session variable to U
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "U";
                break;
            default:
                e.Authenticated = false;
                break;
        }


    }
}