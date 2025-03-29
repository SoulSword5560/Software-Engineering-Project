<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPass.aspx.cs" Inherits="EduLearn.view.authentication.resetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset</title>
    <link href="resetPass.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="reset-container">
            <div class="reset-box">
                <h2>Reset Password</h2>
                <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="emailTB" runat="server" placeholder="Email" CssClass="input-field" />
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="passwordTB" runat="server" TextMode="Password" placeholder="Password" CssClass="input-field" />
                <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="conTB" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="input-field" />

                <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>


                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="reset-button" OnClick="btnReset_Click" />
            </div>
        </div>
    </form>
</body>
</html>
