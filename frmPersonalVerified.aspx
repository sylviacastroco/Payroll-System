<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPersonalVerified.aspx.cs" Inherits="frmPersonalVerified" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 606px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ACITLogo.jpg" />
        <br />
        <br />
      
        <asp:Label ID="lblInformationSubmit" runat="server" Text="Information to submit"></asp:Label>
        <asp:TextBox ID="txtVerifiedInfo" TextMode="MultiLine" Height="80px" Width="400px" runat="server"></asp:TextBox>
    
    </div>
    <p>
            <asp:Button ID="btnViewPersonnel" runat="server" 
                 Text="View Personnel" 
            PostBackUrl="~/frmViewPersonnel.aspx" style="text-align: center" />
        </p>
    </form>
</body>
</html>
