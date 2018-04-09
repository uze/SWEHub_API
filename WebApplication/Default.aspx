<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>TryIt Pages - Required Services</p>
    </div>

    <div class="row">
        Crime API Service (R<span>eturns certain crime data for a given location</span>):<br />
        Method: string Crime(string state)<br />
        Please enter your state (abbriviated form. e.g AZ instead of Arizona) <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        Service response:<br />
        <asp:Label ID="Label1" runat="server" Text="-"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Submit" />
        <br />
        <br />
        Sunlight Index API Service (R<span>eturns the annual average sunshine index of a given position</span>):<br />
        Method: string Weather(string zipcode)<br />
        Please enter a location <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        Service response:<br />
        <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
        <br />
    </div>

</asp:Content>
