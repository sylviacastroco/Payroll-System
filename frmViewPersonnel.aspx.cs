using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmViewPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Declare the DataSet
            dsPersonnel myDataSet = new dsPersonnel();

            string strSearch="";
            //Gets Search Name from the request object from the previous form's text box
            if (Request["txtSearchName"] != null) //Checks if the request string is null
                strSearch = Request["txtSearchName"].ToString();
            
            // Fill the dataset with what is returned from the function
            myDataSet = clsDataLayer.GetPersonnel(Server.MapPath("App_Data\\PayrollSystem_DB.mdb"), strSearch);
            // Set the DataGrid to the DataSource based on the table
            grdViewPersonnel.DataSource = myDataSet.Tables["tblPersonnel"];

            // Bind the DataGrid
            grdViewPersonnel.DataBind();
        }

    }
}