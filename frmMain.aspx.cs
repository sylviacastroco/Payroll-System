using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This statement will Save the current user activity to tblUserActivity table
        clsDataLayer.SaveUserActivity(Server.MapPath("App_Data\\PayrollSystem_DB.mdb"), "frmPersonnel");

        if (Session["SecurityLevel"] != "A") //If the logged in user is not Admin
        {
            //disable the following images and links
            linkbtnNewEmployee.Visible = false;
            imgbtnNewEmployee.Visible = false;
            linkbtnViewUserActivity.Visible = false;
            imgbtnViewUserActivity.Visible = false;
            linkbtnEditEmployees.Visible = false;
            imgbtnEditEmployees.Visible = false;
            linkbtnManageUsers.Visible = false;
            imgbtnManageUsers.Visible = false;


        }


    }
}
