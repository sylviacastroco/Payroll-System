using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Checks user roles from the session object
        if (Session["SecurityLevel"] == "A")
        {

            btnSubmit.Visible = true;

            //Allow the user to add the data
        }
        else
        {

               Response.Redirect("frmLogin.aspx");
           
                 btnSubmit.Visible = false;
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        /*
         * This function will first check server side validations 
         * and then add values to the session object and redirect 
         * to frmPersonalVerified form.
         */
        if (ValidateFields()) //if Validate fields method has returned true
        {
            //Add all text boxes values to the session object.
            Session.Add("txtFirstName", txtFirstName.Text);//Add First Name to Session Object
            Session.Add("txtLastName", txtLastName.Text);  //Add Last Name to Session Object
            Session.Add("txtPayRate", txtPayRate.Text);    //Add Pay Rate to Session Object
            Session.Add("txtStartDate", txtStartDate.Text);//Add Start Date to Session Object    
            Session.Add("txtEndDate", txtEndDate.Text);    //Add End Date to Session Object
            Server.Transfer("frmPersonalVerified.aspx");//Redirect to frmPersonalVerified page
        }

    }

    /*
     *This function will validate all the fields and return true or false 
     * depending on validation result 
     */
    protected bool ValidateFields()
    {
        /*
         * The following statements will reset colors of all text boxes
         * and reset the label lblError so that they do not contain the 
         * states of previous validations 
         */
        txtFirstName.BackColor = System.Drawing.Color.White;
        txtLastName.BackColor = System.Drawing.Color.White;
        txtPayRate.BackColor = System.Drawing.Color.White; 
        txtStartDate.BackColor = System.Drawing.Color.White;
        txtEndDate.BackColor = System.Drawing.Color.White;
        lblError.Text = "";

        bool isValidated = true;

        
        /*
         * The following statements will validate all text boxes
         * if any text box is empty, it will
         * set the error message and store it in lblError label
         * change the back color of the text box
         * set function variable to false
         */

        //Validate First Name
        if(txtFirstName.Text.Trim() =="")
        {
            lblError.Text += "First Name cannot be empty. "; 
            txtFirstName.BackColor = System.Drawing.Color.Yellow;
            isValidated= false;                                 

        }

        //Validate Last Name
        if (txtLastName.Text.Trim() == "")
        {
            lblError.Text += "Last Name cannot be empty. ";
            txtLastName.BackColor = System.Drawing.Color.Yellow;
            isValidated = false;
        }

        //Validate Pay Rate
        if (txtPayRate.Text.Trim() == "")
        {
            lblError.Text += "Pay Rate cannot be empty. ";
            txtPayRate.BackColor = System.Drawing.Color.Yellow;
            isValidated = false;
        }

        //Validate Start Date
        if (txtStartDate.Text.Trim() == "")
        {
            lblError.Text += "Start Date cannot be empty. ";
            txtStartDate.BackColor = System.Drawing.Color.Yellow;
            isValidated = false;
        }

        //Validate End Date
        if (txtEndDate.Text.Trim() == "")
        {
            lblError.Text += "End Date cannot be empty. ";
            txtEndDate.BackColor = System.Drawing.Color.Yellow;
            isValidated = false;
        }


        /*
         * This code will run if all the fields are non Empty
         * This will validate start date and end date and check
         * if start date is less than or equal to end date or not
         */
        if (isValidated)
        {

            string strStartDate = txtStartDate.Text; //store startDate in string
            string strEndDate = txtEndDate.Text;     //store endDate in string

            DateTime startDateTime = DateTime.Parse(strStartDate); //convert start date to DateTime Object
            DateTime endDateTime = DateTime.Parse(strEndDate);     //Convert end date to  DateTime Object

            if (DateTime.Compare(startDateTime, endDateTime) > 0)   //if startDate is greater than End Date
            {
                lblError.Text += "Start Date must be less than the End Date. "; //set error message
                txtStartDate.BackColor = System.Drawing.Color.Yellow;           //change back color of start date text box
                txtEndDate.BackColor = System.Drawing.Color.Yellow;             //change back color of end date text box
                isValidated = false;                                            //set function variable to false

            }
        }
        return isValidated;

    }

    protected void btnViewPersonnel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmViewPersonnel.aspx");
    }
}
