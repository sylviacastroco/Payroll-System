using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmEditPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SecurityLevel"] != "A") //If the logged in user is not Admin
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}