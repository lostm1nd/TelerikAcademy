<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="BookDetailsContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewDetails"
        ItemType="LibrarySystem.Models.Book"
        SelectMethod="FormViewDetails_GetItem">
        <HeaderTemplate>
            <h1><%: Page.Title %></h1>            
        </HeaderTemplate>
        <ItemTemplate>
            <p class="jumbotron"><%#: Item.Title %></p>
            <p><i>by <%#: Item.Author %></i></p>
            <p>ISBN <%#: Item.ISBN %></p>
            <p>Web site: <a href='<%#: Item.WebSite %>'><%#: Item.WebSite %></a></p>
            <p>
                <%#: Item.Description %>
            </p>
        </ItemTemplate>
        <FooterTemplate>
            <p><a href="~/Default" runat="server">Back to books</a></p>
        </FooterTemplate>
    </asp:FormView>
</asp:Content>
