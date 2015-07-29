<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="highscore.aspx.cs" Inherits="ToDoList.highscore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grdScores" runat="server" AutoGenerateColumns="false" DataKeyNames="username"
         CssClass="table table-striped table-hover"
         AllowPaging="true" PageSize="3"
         AllowSorting="true" OnSorting="grdScores_Sorting" OnRowDataBound="grdScores_RowDataBound">

        <Columns>
            <asp:BoundField DataField="username" HeaderText="User" SortExpression="User" />
            <asp:BoundField DataField="points" HeaderText="Points" SortExpression="Points"/>
        </Columns>

    </asp:GridView>

</asp:Content>
