<%@ Page Title="" Language="C#" MasterPageFile="~/view/template/navbar.Master" AutoEventWireup="true" CodeBehind="QNA.aspx.cs" Inherits="EduLearn.view.QNA.QNA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    <h1>QNA</h1>
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
    gap: 15px;
}

.book-thumbnail img {
    width: 100px;
    height: 140px;
    object-fit: cover;
    border-radius: 8px;
}

.Note-info {
    flex: 1;
}

.Note-info h3 {
    font-size: 20px;
    color: #2C3E50;
    margin-bottom: 8px;
    font-family: 'Jaro', sans-serif;
}

.Note-info p {
    font-size: 14px;
    color: #333;
    margin: 6px 0;
}

    </style>
    <asp:Repeater ID="rptQna" runat="server">
    <ItemTemplate>
        <div class="Note-card">
            <!-- Book Image -->
            <div class="book-thumbnail">
                <img src='<%# Eval("Image") %>' alt="Book Cover" />
            </div>

            <!-- QnA Content -->
            <div class="Note-info">
                <h3>Q&A Resource</h3>
                <p><strong>Question:</strong> <a href='<%# Eval("QuestionURL") %>' target="_blank">View Question</a></p>
                <p><strong>Answer:</strong> <a href='<%# Eval("AnswerURL") %>' target="_blank">View Answer</a></p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

</asp:Content>
