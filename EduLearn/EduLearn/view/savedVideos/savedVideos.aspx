<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="savedVideos.aspx.cs" Inherits="EduLearn.view.savedVideos.savedVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>Saved Videos</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        body {
            font-family: 'Jaro';
        }
        .video-card {
    display: flex;
    border-bottom: 1px solid #ccc;
    padding: 15px 0;
    align-items: flex-start;
}

.thumbnail {
    width: 200px;
    margin-right: 20px;
    flex-shrink: 0;
}

.thumbnail img {
    width: 100%;
    height: auto;
    border-radius: 5px;
}

.video-info {
    flex: 1;
}

.video-info h3 {
    font-size: 20px;
    color: #34495E;
    margin-bottom: 5px;
    font-family: 'Jaro', sans-serif;
}

.video-info p {
    font-size: 14px;
    color: #555;
    margin: 4px 0;
}

    </style>
    <asp:Repeater ID="rptVideos" runat="server" OnItemCommand="rptVideos_ItemCommand">
        <ItemTemplate>
            <div class="video-card">
                <div class="thumbnail">
                    <iframe 
                    width="200" 
                    height="113" 
                    src='<%# Eval("URL") %>' 
                    frameborder="0" 
                    allowfullscreen>
                </iframe>
                </div>
                <div class="video-info">
                    <h3><%# Eval("Name") %></h3>
                    <p>Category:</p>
                    <p><%# Eval("Category") %></p>
                    <p><strong>Description:</strong></p>
                    <p><%# Eval("Description") %></p>
                </div>
                <asp:HiddenField ID="hfVideoName" runat="server" Value='<%# Eval("Name") %>' />
                <asp:Button ID="Button1" runat="server" Text="Remove" CommandName="removeFromList" UseSubmitBehavior="False" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
