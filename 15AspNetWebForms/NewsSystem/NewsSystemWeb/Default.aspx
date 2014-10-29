<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsSystemWeb._Default" %>

<%@ Import Namespace="NewsSystemWeb.Extensions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <header class="row">
        <h1>News</h1>
    </header>

    <section>
        <header class="row">
            <h2>Most popular articles</h2>
        </header>

        <asp:Repeater runat="server" ID="RepeaterMostPopular"
            ItemType="NewsSystemWeb.Models.Article"
            SelectMethod="RepeaterMostPopular_GetData">
            <ItemTemplate>
                <div class="row">
                    <h3>
                        <a href='<%# string.Format("~/ViewArticle?id={0}", Item.ArticleId) %>' runat="server"><%#: Item.Title %></a>
                        <small runat="server"><%#: Item.Category.Name %></small>
                    </h3>
                    <p>
                        <%#: Item.Content.TrimTo300() %>
                        <small>
                            <a href='<%# string.Format("~/ViewArticle?id={0}", Item.ArticleId) %>' runat="server">  read more</a>
                        </small>
                    </p>
                    <p>Likes: <%# Item.Likes.Count %></p>
                    <div>
                        <i><%#: Item.Author.UserName %></i>
                        <i>created on: <%# Item.DateCreated.ToLocalTime() %></i>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </section>

    <section>
        <header class="row">
            <h2>All categories</h2>
        </header>

        <asp:ListView runat="server" ID="ListViewCategories"
            ItemType="NewsSystemWeb.Models.Category"
            SelectMethod="ListViewCategories_GetData"
            GroupItemCount="2">

            <GroupTemplate>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>
            </GroupTemplate>

            <ItemTemplate>
                <article class="col-md-6">
                    <h3><%#: Item.Name %></h3>

                    <asp:ListView runat="server"
                        DataSource='<%# Item.Articles.OrderBy(a => a.DateCreated).Take(2) %>'
                        ItemType="NewsSystemWeb.Models.Article">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <a href='<%# string.Format("~/ViewArticle?id={0}", Item.ArticleId) %>' runat="server">
                                    <strong><%#: Item.Title %> </strong>
                                    <i><%# Item.Author.UserName %></i>
                                </a>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <li>No articles.</li>
                        </EmptyDataTemplate>
                    </asp:ListView>

                </article>
            </ItemTemplate>
        </asp:ListView>
    </section>

</asp:Content>
