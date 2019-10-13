<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSalaryCalculator.aspx.cs"
    Inherits="frmSalaryCalculator" %>

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
        <br />
        <br />
        <asp:Label ID="lbAnnualHours" runat="server" Text="Annual Hours:"></asp:Label>
        <asp:TextBox ID="txtAnnualHours" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbRate" runat="server" Text="Rate:" width="86px"></asp:Label>
        <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BTNCalculateSalary" runat="server" OnClick="BTNCalculateSalary_Click"
            Text="Calculate Salary" />
        <br />
        <br />
        <asp:Label ID="lblSalary" runat="server" Text="$"></asp:Label>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
