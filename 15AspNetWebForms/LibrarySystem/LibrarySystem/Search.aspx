<%@ Page Title="Search Results for: " Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Page.Title %> <asp:Literal runat="server" ID="QueryText" Mode="Encode" /></h1>

    <asp:Repeater runat="server" ID="RepeaterQuery"
        ItemType="LibrarySystem.Models.Book" SelectMethod="RepeaterQuery_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href='<%# string.Format("~/BookDetails?bookId={0}", Item.BookId) %>' runat="server">
                    <%# string.Format("\"{0}\" <i>by {1}</i>", Item.Title, Item.Author) %>
                </a>
                (Category: <%#: Item.Category.Name %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <p><a href="~/Default" runat="server">Back to books</a></p>
</asp:Content>
