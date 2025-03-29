<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EduLearn.view.authentication.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="login.css" rel="stylesheet" />
     <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-box">
                <h2>Login</h2>
                <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="emailTB" runat="server" placeholder="Email" CssClass="input-field" />
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="passwordTB" runat="server" TextMode="Password" placeholder="Password" CssClass="input-field" />
                
                 <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>

                <div class="forgot-password">
                    <asp:HyperLink ID="hlResetPassword" runat="server" Text="Reset Password" CssClass="forgot-link" />
                </div>
                
                <div class="create-account">
                    <asp:HyperLink ID="hlCreateAccount" runat="server" Text="No Account? Create New Account" CssClass="create-link" NavigateUrl="~/view/authentication/register.aspx" />
                </div>
                
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
