<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="EduLearn.view.home.home" %>

<asp:Content ID="pageTitleContent" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>Home</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="home.css" />
    <link href="https://fonts.googleapis.com/css2?family=Jaro&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            font-family: 'Poppins', sans-serif;
        }

        .home-container {
            display: flex;
            justify-content: space-between;
            gap: 20px;
            padding: 20px;
        }

        .left-section {
            width: 70%;
        }

        .right-section {
            width: 100%;
            max-width: 350px;
            background: #f4f4f4;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 6px 18px rgba(0, 0, 0, 0.05);
            font-family: 'Poppins', sans-serif;
        }

            .right-section h2 {
                font-size: 1.4rem;
                font-weight: 700;
                margin-bottom: 20px;
/*                border-bottom: 2px solid #ccc;*/
                padding-bottom: 6px;
                text-align: center;
            }

        .video-section, .book-section {
            background: white;
            padding: 15px;
            margin-bottom: 20px;
            border-radius: 10px;
        }

        .book-grid {
            display: flex;
            gap: 15px;
        }

        .book-card {
            width: 330px;
            text-align: center;
        }

            .book-card img {
                width: 100%;
                height: 350px;
                object-fit: cover;
                border-radius: 8px;
            }

            .book-card a {
                text-decoration: none;
                font-family: 'Poppins', sans-serif;
                color: black;
                font-size: 1.5rem;
                margin-bottom: 0;
                padding-bottom: 0;
            }

        .placeholder-container {
            height: 300px;
            background: #e0e0e0;
            border-radius: 8px;
        }

        .note-card {
            background: #ffffff;
            border-radius: 10px;
            padding: 12px 16px;
            margin-bottom: 14px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.06);
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

            .note-card:hover {
                transform: translateY(-4px);
                box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            }

            .note-card h3 {
                font-size: 1.1rem;
                margin: 0;
                font-family: 'Jaro', sans-serif;
            }

        .note-card a{
            text-decoration: none;
            display: block;
            text-align: center;
            color: black;
        }
    </style>

    <div class="home-container">
        <!-- Left Section (Video + Books) -->
        <div class="left-section">
            <!-- YouTube Video Section -->
            <div class="video-section">
                <h2>Tutorials</h2>
                <iframe width="100%" height="315" frameborder="0" allowfullscreen
                    src="<%= GetYouTubeEmbedUrl() %>"></iframe>
            </div>

            <!-- Book Section -->
            <div class="book-section">
                <h2>Books</h2>
                <div class="book-grid">
                    <asp:Repeater ID="bookRepeater" runat="server">
                        <ItemTemplate>
                            <div class="book-card">
                                <a href='<%# Eval("URL") %>' target="_blank">
                                    <img src='<%# Eval("Image") %>' alt="Book Cover" />
                                    <p><%# Eval("Name") %></p>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>


        <!-- Right Section -->
        <div class="right-section">
            <h2>Notes | Questions & Answers</h2>
            <asp:Repeater ID="notesRepeater" runat="server">
                <ItemTemplate>
                    <div class="note-card">
                        <a href='<%# Eval("Image") %>' target="_blank">
                            <h3><%# Eval("Description") %></h3>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
