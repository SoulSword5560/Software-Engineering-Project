<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="EduLearn.view.authentication.register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register new account</title>
    <link rel="stylesheet" type="text/css" href="register.css" />
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="register-box">
                <h2>Register New Account</h2>
                
                <label>Username</label>
                <asp:TextBox ID="usernameTB" runat="server" CssClass="input-field" placeholder="name must be more than 8 character"></asp:TextBox>

                <label>Email</label>
                <asp:TextBox ID="emailTB" runat="server" CssClass="input-field" placeholder="email must be a valid one"></asp:TextBox>

                <label>Password</label>
                <asp:TextBox ID="passwordTB" runat="server" CssClass="input-field" TextMode="Password" placeholder="password must be more than 8 character"></asp:TextBox>

                <label>Date of Birth</label>
                <asp:TextBox ID="dobTB" runat="server" CssClass="input-field" TextMode="Date" placeholder="must be a valid date"></asp:TextBox>

                <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>

                <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="register-btn" OnClick="registerBtn_Click" />
            <asp:HyperLink ID="hlHaveAccount" runat="server" Text="already have an account?" CssClass="haveAccount" NavigateUrl="~/view/authentication/login.aspx" />
            </div>
        </div>
    </form>
</body>
</html>

