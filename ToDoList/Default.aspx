<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoList._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to your personal To Do List, with a twist!</h1>
        <p class="lead">Check out how other people are doing! .</p>
        <p><a href="/HighScores" class="btn btn-primary btn-lg">High Scores &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                Dont Have An Account?
            </p>
            <p>
                Register a free account with us and get started by building your own to do list and tracking your progress!
            </p>
            <p>
                <a class="btn btn-default" href="/Account/Register">Register &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sign In</h2>
            <p>
                Already have an account?.
            </p>
            <p>
                Sign in and check on what you need to do, or add some new tasks!
            </p>
            <p>
                <a class="btn btn-default" href="/Account/Login">Login &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Already Logged In?</h2>
            <p>
                Already Logged in and good to go?
            </p>
            <p>
                Then go look at your To Do List, what are you sitting around here for?
            </p>
            <p>
                <a class="btn btn-default" href="/ToDo">To Do &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
