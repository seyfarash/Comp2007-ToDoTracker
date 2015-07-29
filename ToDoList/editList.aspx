<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editList.aspx.cs" Inherits="ToDoList.editList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Task Details</h1>
    <h5>All fields are required</h5>

    <fieldset>
        <label for="txtTask" class="col-sm-2">Task:</label>
        <asp:TextBox ID="txtTask" runat="server" required MaxLength="100" />
    </fieldset>
    <fieldset>
        <label for="txtPriority" class="col-sm-2">Priority:</label>
        <asp:DropDownList ID="ddlPriority" runat="server">
            <asp:ListItem Text="LOW" Value="1"></asp:ListItem>
            <asp:ListItem Text="MEDIUM" Value="2"></asp:ListItem>
            <asp:ListItem Text="HIGH" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </fieldset>
    <fieldset>
        <label for="txtDueDate" class="col-sm-2">Due Date:</label>
        <asp:TextBox ID="txtDueDate" runat="server" required TextMode="DateTimeLocal" />
        <asp:CustomValidator ID="dueDateValidate" runat="server" ErrorMessage="Date Must Be later than today" ControlToValidate="txtDueDate" CssClass="aler aler-danger" OnServerValidate="dueDateValidate_ServerValidate" Display="Dynamic" EnableClientScript="true"></asp:CustomValidator>
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>
