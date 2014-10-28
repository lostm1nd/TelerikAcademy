<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome</h1>
        <p>
            <input type="text" placeholder="Search by author and title" runat="server" id="searchField" class="form-control" />
            <asp:Button Text="Search" runat="server" ID="seachBtn" OnClick="SeachButton_Click" CssClass="btn btn-info"/>
        </p>
    </div>

    <asp:ListView runat="server" ID="ListViewCategories"
        ItemType="LibrarySystem.Models.Category" SelectMethod="ListViewCategories_GetData"
        GroupItemCount="3">

        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <GroupSeparatorTemplate>
            <hr />
        </GroupSeparatorTemplate>

        <ItemTemplate>
            <article class="col-md-4">
                <h3><%#: Item.Name %></h3>

                <asp:Repeater runat="server" DataSource='<%# Item.Books %>' ItemType="LibrarySystem.Models.Book">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# string.Format("~/BookDetails?bookId={0}", Item.BookId) %>' runat="server">
                                <%# string.Format("\"{0}\" <i>by {1}</i>", Item.Title, Item.Author) %>
                            </a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

            </article>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
