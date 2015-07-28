<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="ToDoList.ToDo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Tasks</h2>

    <a href="editList.aspx">Add Task</a>

    

    <asp:GridView ID="grdTasks" runat="server" AutoGenerateColumns="false" DataKeyNames="taskID"
         CssClass="table table-striped table-hover" OnRowDeleting="grdTasks_RowDeleting"
         AllowPaging="true" PageSize="3" OnPageIndexChanging="grdTasks_PageIndexChanging" OnRowCommand="grdTasks_RowCommand"
         AllowSorting="true" OnSorting="grdTasks_Sorting" OnRowDataBound="grdTasks_RowDataBound">

        <Columns>
            <asp:BoundField DataField="Task" HeaderText="Task" SortExpression="Task" />
            <asp:BoundField DataField="dueDate" HeaderText="Due" SortExpression="Due"/>
            <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
            <asp:HyperLinkField Text="Edit" NavigateUrl="editList.aspx" DataNavigateUrlFields="taskID"
                 DataNavigateUrlFormatString="editList.aspx?taskID={0}" HeaderText="Edit" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            <asp:ButtonField ButtonType="Button" CommandName="Complete" Text="Complete" HeaderText="Complete" />
        </Columns>

    </asp:GridView>
</asp:Content>
