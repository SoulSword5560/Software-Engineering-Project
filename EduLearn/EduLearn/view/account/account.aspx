<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="EduLearn.view.account.account" %>
<asp:Content ID="pageTitleContent" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>Account</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="account.css" />
<link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="account-box">
        <div class="info-box">
            <asp:Label ID="name" runat="server" Text="Label" CssClass="info"></asp:Label>
            <asp:Label ID="email" runat="server" Text="Label" CssClass="info"></asp:Label>
            <asp:Label ID="dob" runat="server" Text="Label" CssClass="info"></asp:Label>
        </div>
        <div class="button-box">
            <asp:Button ID="resetPass" runat="server" Text="Change Password" CssClass="button" OnClick="resetPass_Click" />
            <asp:Button ID="resetEmail" runat="server" Text="Change Email"  CssClass="button"/>
        </div>
    </div>
</asp:Content>
