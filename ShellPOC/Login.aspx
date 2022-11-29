<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShellPOC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="text-align:center">
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
                <asp:TextBox type="text" name="name" ID="name" placeholder="Enter Name" runat="server"/>
                <br />
                <br />
                <asp:TextBox type="text" name="Password" ID="pass" placeholder="Enter Password" runat="server"/>
            </div>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click1"/>
        </form>
    </div>
</body>
</html>
