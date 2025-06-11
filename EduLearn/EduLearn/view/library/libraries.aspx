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
            flex: 0 1 calc(25% - 32px); /* 4 items per row, responsive */
            background-color: #fff;
            border-radius: 12px;
            padding: 16px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.06);
            text-align: center;
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

            .book-item:hover {
                transform: translateY(-6px);
                box-shadow: 0 8px 24px rgba(0, 0, 0, 0.1);
            }

            .book-item img {
                width: 100%;
                max-height: 220px;
                object-fit: cover;
                border-radius: 8px;
                margin-bottom: 12px;
            }

            .book-item a {
                display: block;
                font-family: 'Jaro', sans-serif;
                font-size: 1.2rem;
                color: black;
                text-decoration: none;
                margin-bottom: 8px;
            }

                .book-item a:hover {
                    color: #333;
                }

            .book-item .remove-btn {
                background-color: #e74c3c;
                color: white;
                border: none;
                padding: 6px 12px;
                border-radius: 4px;
                font-size: 0.9rem;
                cursor: pointer;
                transition: background-color 0.2s ease;
            }

                .book-item .remove-btn:hover {
                    background-color: #c0392b;
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
                <asp:Button ID="Button1" CssClass="remove-btn" runat="server" Text="Remove" CommandName="removeFromList" UseSubmitBehavior="False" OnClientClick="return confirm('Are you sure you want to remove this book?');"/>
            </div>
            <%# (Container.ItemIndex + 1) % 3 == 0 ? "<div class='divider'></div>" : "" %>
        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
