<%@ Page Title="Graphs" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Graphs.aspx.cs" Inherits="StudentAchievements.Graphs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<section>
		<h3><%: Title %></h3>
		<p>Select a correlation to graph against student final grades:
			<asp:DropDownList ID="CorrelationList" runat="server" Width="174px" Height="16px">
                <asp:ListItem Value="travel_time">Travel Time</asp:ListItem>
                <asp:ListItem Value="study_time">Study Time</asp:ListItem>
                <asp:ListItem Value="failures">Failures</asp:ListItem>
                <asp:ListItem Value="family_relations">Family Relations</asp:ListItem>
                <asp:ListItem Value="free_time">Free Time</asp:ListItem>
                <asp:ListItem Value="go_out">Goes Out</asp:ListItem>
                <asp:ListItem Value="daily_alcohol">Daily Alcohol</asp:ListItem>
                <asp:ListItem Value="weekly_alcohol">Weekly Alcohol</asp:ListItem>
                <asp:ListItem Value="health">Health</asp:ListItem>
                <asp:ListItem Value="absences">Absences</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;
            <asp:LinkButton ID="GraphButton" runat="server" CssClass="btn btn-default" OnClick="GraphButton_Click">Graph!</asp:LinkButton>
        </p>
	</section>
    <section>
        <% if (SelectedCorrelation != null) %>
        <% { %>
           <p><i>If nothing appears, click 'Graph!' again.</i></p>
           <div style="display: flex;">
               <p style="flex-shrink: 1;"><strong>Final Grade</strong></p>
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
               <p style="flex-shrink: 1; align-self: flex-end;"><strong><%: SelectedCorrelationProper %></strong></p>
           </div>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostgresConnection %>" ProviderName="<%$ ConnectionStrings:PostgresConnection.ProviderName %>" SelectCommand="SELECT &quot;travel_time&quot;, &quot;study_time&quot;, &quot;failures&quot;, &quot;family_relations&quot;, &quot;free_time&quot;, &quot;go_out&quot;, &quot;daily_alcohol&quot;, &quot;weekly_alcohol&quot;, &quot;health&quot;, &quot;absences&quot;, &quot;grade_final&quot; FROM &quot;student_achievements&quot;"></asp:SqlDataSource>
        <% } %>
        <% else %>
        <% { %>
                <p><strong>Please select a correlation.</strong></p>
        <% } %>
    </section>
</asp:Content>