<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMain.aspx.cs" Inherits="frmMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ACITLogo.jpg" />
        <font color="black" size="2">
       
        <br />
        <br />
        <br />
         </font>
          <asp:LinkButton ID="linkbtnCalculator"  runat="server" 
            PostBackUrl="~/frmSalaryCalculator.aspx"> Salary Calculator</asp:LinkButton> 
          <asp:ImageButton ID="imgbtnCalculator" ImageUrl="~/images/calculator.png" 
            runat="server" PostBackUrl="~/frmSalaryCalculator.aspx" />
        <br />
        
    
        <asp:LinkButton ID="linkbtnNewEmployee" runat="server" 
            PostBackUrl="~/frmPersonnel.aspx">Add New Employee</asp:LinkButton>
            <asp:ImageButton ID="imgbtnNewEmployee" 
            ImageUrl="~/images/AddEmployee.png" PostBackUrl="~/frmPersonnel.aspx" 
            runat="server" />
        <br />

        <asp:LinkButton ID="linkbtnViewUserActivity" runat="server" 
            PostBackUrl="~/frmUserActivity.aspx">View User Activity</asp:LinkButton>
        <asp:ImageButton ID="imgbtnViewUserActivity" runat="server" 
            ImageUrl="~/images/ViewUserActivity.png" PostBackUrl="~/frmUserActivity.aspx" />
        <br />

        <asp:LinkButton ID="linkbtnViewPersonnel" runat="server" 
            PostBackUrl="~/frmViewPersonnel.aspx">View Personnel</asp:LinkButton>
        <asp:ImageButton ID="imgbtnViewPersonnel" runat="server"
            ImageUrl="~/images/ViewPersonnel.png" PostBackUrl="~/frmViewPersonnel.aspx" />
        <br />

        <asp:LinkButton ID="linkbtnSearch" runat="server" 
            PostBackUrl="~/frmSearchPersonnel.aspx">Search Personnel</asp:LinkButton>
        <asp:ImageButton ID="imgbtnSearch" runat="server" 
            ImageUrl="~/images/search.png" PostBackUrl="~/frmSearchPersonnel.aspx" />
        <br />

        <asp:LinkButton ID="linkbtnEditEmployees" runat="server" 
            PostBackUrl="~/frmEditPersonnel.aspx">Edit Personnel</asp:LinkButton>
        <asp:ImageButton ID="imgbtnEditEmployees" runat="server" 
            ImageUrl="~/images/editPersonnel.png" PostBackUrl="~/frmEditPersonnel.aspx" />
        <br />

        <asp:LinkButton ID="linkbtnManageUsers" runat="server" 
            PostBackUrl="~/frmManageUsers.aspx">Manage Users</asp:LinkButton>
        <asp:ImageButton ID="imgbtnManageUsers" runat="server" 
            ImageUrl="~/images/managerUsers.png" PostBackUrl="~/frmManageUsers.aspx" />
    </div>
    </form>
</body>
</html>
