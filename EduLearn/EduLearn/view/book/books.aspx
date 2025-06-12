<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="EduLearn.view.book.books" %>

<asp:Content ID="pageTitleContent" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>Books</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/view/book/book.css") %>' />
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .book-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 20px;
            padding: 20px;
            max-width: 1000px;
            margin: 0 auto;
        }

        .book-item {
            flex: 0 1 300px;
            text-align: center;
            padding: 20px;
            border-radius: 16px;
            background-color: white;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }

            .book-item img {
                width: 100%;
                height: 360px;
                object-fit: cover;
                border-radius: 8px;
                display: block;
                margin-bottom: 16px;
            }

            .book-item a {
                text-decoration: none;
                color: black;
                font-family: 'Jaro', sans-serif;
                font-size: 1.3rem;
                font-weight: bold;
                display: block;
                margin: 8px 0;
            }

            .book-item .btn {
                background-color: #e74c3c;
                color: white;
                border: none;
                padding: 8px 20px;
                border-radius: 6px;
                font-size: 1rem;
                cursor: pointer;
                transition: background-color 0.2s ease;
            }

                .book-item .btn:hover {
                    background-color: #c0392b;
                }

            .book-item .book-btn {
                margin-top: 10px;
                background-color: #3498db;
                color: white;
                border: none;
                padding: 8px 16px;
                border-radius: 6px;
                font-size: 0.95rem;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }
                
                .book-item .book-btn:hover{
                     background-color: #2980b9;
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
                <asp:Button ID="Button1" CssClass="book-btn" runat="server" Text="Add" CommandName="AddBook" UseSubmitBehavior="false" />
            </div>
            <%# (Container.ItemIndex + 1) % 3 == 0 ? "<div class='divider'></div>" : "" %>
        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
