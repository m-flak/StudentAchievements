<%@ Page Title="Inquire" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Inquire.aspx.cs" Inherits="StudentAchievements.Inquire" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<section>
        <h3><%: Title %></h3>
        <p>Select a category to find average grades by: </p>
	</section>
    <section style="display: flex;">
        <asp:RadioButtonList ID="QuerySelector" runat="server" RepeatDirection="Horizontal" Width="737px">
            <asp:ListItem>Internet</asp:ListItem>
            <asp:ListItem>Past Failures</asp:ListItem>
            <asp:ListItem>Study Time</asp:ListItem>
            <asp:ListItem>Absences</asp:ListItem>
        </asp:RadioButtonList>
        <asp:LinkButton ID="InquireButton" runat="server" OnClick="InquireButton_Click" CssClass="btn btn-default">Inquire!</asp:LinkButton>
    </section>
    <section>
        <asp:PlaceHolder ID="ResultsPlaceHolder" runat="server" OnLoad="ResultsPlaceHolder_Load">
            <p><i>If nothing appears, click 'Inquire!' again.</i></p>
            <% if (CategoriesAverages.Count > 0) %>
            <% { %>
                <h4 class="header-average-grades">Average Grades:</h4>
                <% foreach (KeyValuePair<string, int> kvp in CategoriesAverages) %>
                <% { %>
                    <div style="display: flex;">
                        <strong><%: kvp.Key %>:&nbsp;</strong>
                        <p><%: kvp.Value %></p>
                    </div>
                <% } %>
            <% } %>
        </asp:PlaceHolder>
    </section>
</asp:Content>
