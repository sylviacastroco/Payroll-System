using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSalaryCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BTNCalculateSalary_Click(object sender, EventArgs e)
    {
        string strAnnualHours = txtAnnualHours.Text; //Getting the value of Annual Hours from the textbox into a string
        double AnnualHours = Convert.ToDouble(strAnnualHours); //Converting the string value strAnnualHours to double and saving it in a double variable


        string strRate = txtRate.Text;//Getting the value of Rate from the textbox into a string
        double Rate = Convert.ToDouble(strRate); //Converting the string value strRate to double and saving it in a double variable

        double AnnualSalary = AnnualHours * Rate; //Getting annual salary that is Annual Hour multiply by rate

        lblSalary.Text = "$" + AnnualSalary.ToString(); //Displaying Annual salary into a label
        
    }
}
