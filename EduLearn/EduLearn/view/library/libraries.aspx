<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="libraries.aspx.cs" Inherits="EduLearn.view.library.libraries" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/view/library/library.css") %>' />

</asp:Content>
<asp:Content ID="PageTitleContent" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>Library</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
.book-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;
    gap: 20px;
    padding: 20px;
    max-width: 1000px;
    margin: 0 auto;
}
.book-item {
    flex: 0 1 calc(33.33% - 20px);
    text-align: center;
    padding: 30px 0 0 0;
}
.book-item a {
    text-decoration:none;
    font-family: 'Jaro';
    color: black;
    font-size: 1.5rem;
    margin-bottom: 0;
    padding-bottom: 0;
}
.book-item a p {
    padding: 10px 0 0 0;
}
.book-item img {
    width: 100%;
    max-height: 250px;
    object-fit: contain;
    border-radius: 5px;
    box-shadow: 0 4px 6px rgba(0,0,0,0.1);
}
.divider {
    width: 100%;
    height: 2px;
    background-color: black;
    margin: 0px 0;
    padding :0;
}

</style>
     <asp:Repeater ID="rptBooks" runat="server" OnItemCommand="rptBooks_ItemCommand">
     <HeaderTemplate>
         <div class="book-container">
     </HeaderTemplate>

     <ItemTemplate>
         <div class="book-item">
             <a href='<%# Eval("URL") %>' target="_blank">
                 <img src='<%# Eval("Image") %>' alt='<%# Eval("Name") %>' />
                 <p id="bookNameText"><%# Eval("Name") %></p>
             </a>
             <asp:HiddenField ID="hfBookName" runat="server" Value='<%# Eval("Name") %>' />
             <asp:Button ID="Button1" runat="server" Text="Remove" CommandName="removeFromList" UseSubmitBehavior="False" />
         </div>
          <%# (Container.ItemIndex + 1) % 3 == 0 ? "<div class='divider'></div>" : "" %>
     </ItemTemplate>

     <FooterTemplate>
         </div>
     </FooterTemplate>
 </asp:Repeater>

   
</asp:Content>
