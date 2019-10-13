using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonalVerified : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //So here we are initializing text property of the textbox "txtVerifiedInfo" after fetching the
        //values from the session object

        txtVerifiedInfo.Text = Session["txtFirstName"].ToString() +
        "\n" + Session["txtLastName"].ToString() +
        "\n" + Session["txtPayRate"].ToString() +
        "\n" + Session["txtStartDate"].ToString() +
        "\n" + Session["txtEndDate"].ToString();

        // Check if the record is successfully saved in the tblPersonnel Table and prints the appropriate message in the text box txtVerifiedInfo
        if (clsDataLayer.SavePersonnel(Server.MapPath("App_Data\\PayrollSystem_DB.mdb"),
        Session["txtFirstName"].ToString(),
        Session["txtLastName"].ToString(),
        Session["txtPayRate"].ToString(),
        Session["txtStartDate"].ToString(),
        Session["txtEndDate"].ToString()))
        {
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was successfully saved!";

        }
        else
        {
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was NOT saved.";
        }
    }
}
