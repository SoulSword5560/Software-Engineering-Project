<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="EduLearn.view.Notes.note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
        body {
            font-family: 'Jaro';
        }
        .Note-card {
    display: flex;
    border-bottom: 1px solid #ccc;
    padding: 15px 0;
    align-items: flex-start;
}

.Note-info {
    flex: 1;
}

.Note-info h3 {
    font-size: 20px;
    color: #34495E;
    margin-bottom: 5px;
    font-family: 'Jaro', sans-serif;
}

.Note-info p {
    font-size: 14px;
    color: #555;
    margin: 4px 0;
}
           </style>
    <asp:Repeater ID="rptNotes" runat="server" OnItemCommand="rptNotes_ItemCommand">
    <ItemTemplate>
        <div class="Note-card">
            <div class="Note-info">
                <a href='<%# Eval("Image") %>' target="_blank">
                <p id="NotesName"><%# Eval("Description") %></p>
            </div>
             <asp:HiddenField ID="hfNoteName" runat="server" Value='<%# Eval("Description") %>' />
            <asp:Button ID="Button1" runat="server" Text="Button" CommandName="AddNote" UseSubmitBehavior="false"/>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
