using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] != "A") //If the logged in user is not Admin
        {
            Response.Redirect("frmLogin.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Checks if the new user is successfully saved
        if (clsDataLayer.SaveUser(Server.MapPath("App_Data\\PayrollSystem_DB.mdb"), txtUserName.Text, txtPassword.Text, cboRole.Text))
        {
            //Bing datagrid again to show the newly added user
            GridView1.DataBind();
            lblNewUserStatus.Text = "The user was successfully added!";

        }
        else
            lblNewUserStatus.Text = "The user could not be added";
        
    }
}