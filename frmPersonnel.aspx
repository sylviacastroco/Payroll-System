<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPersonnel.aspx.cs" Inherits="frmPersonnel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personnel Form</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1" >
            <br />
            <br />
            
        <asp:Panel ID="Panel1" runat="server" Height="250px" HorizontalAlign="Left" 
            Width="902px" style="margin-top: 0px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ACITLogo.jpg" />
            <br />
            <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: " Width="75px"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtFirstName" ErrorMessage="First Name cannot be empty"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name: " Width="75px"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtLastName" ErrorMessage="Last Name cannot be empty"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPayRate" runat="server" Text="Pay Rate: " Width="75px"></asp:Label>
            <asp:TextBox ID="txtPayRate" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblStartDate" runat="server" Text="Start Date: " Width="75px"></asp:Label>
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtStartDate" ErrorMessage="Enter date in mm/dd/yyyy format" 
                ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[ \/.-](0?[1-9]|1[012])[ \/.-](19|20)\d\d$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblEndDate" runat="server" Text="End Date: " Width="75px"></asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtEndDate" ErrorMessage="Enter date in mm/dd/yyyy format" 
                ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[ \/.-](0?[1-9]|1[012])[ \/.-](19|20)\d\d$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" PostBackUrl="~/frmMain.aspx" Text="Cancel" />
            <asp:Button ID="btnViewPersonnel" runat="server" 
                onclick="btnViewPersonnel_Click" Text="View Personnel" />
        </asp:Panel>
       
    </div>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
