<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentAchievements._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Student Achievements</h1>
        <p class="lead">Query the dataset of student achievements.</p>
        <br />
        <br />
        <div style="display: flex;">
            <p style="flex-grow: 1;"><a runat="server" href="~/Inquire" class="btn btn-primary btn-lg">Query the dataset... &raquo;</a></p>
            <p style="flex-grow: 1;"><a runat="server" href="~/Graphs" class="btn btn-primary btn-lg">Obtain graphs of the dataset... &raquo;</a></p>
        </div>
    </div>

</asp:Content>
