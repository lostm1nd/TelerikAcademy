<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystemWeb.ViewArticle" %>

<%@ Register Src="~/Controls/Likes.ascx" TagPrefix="uc1" TagName="Likes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Page.Title %></h1>

    <asp:FormView runat="server" ID="FormViewDetails"
        ItemType="NewsSystemWeb.Models.Article"
        SelectMethod="FormViewDetails_GetItem">
        <ItemTemplate>
            <div class="panel panel-default">
                <div class="panel-heading" style="overflow: auto">
                    <h2 style="display:inline-block">
                        <%#: Item.Title %>
                        <small> Category: <%#: Item.Category.Name %></small>
                    </h2>
                    <div class="pull-right">
                        <uc1:Likes runat="server" ID="Likes" TotalLikes='<%# Item.Likes.Count %>' OnUpvote="Likes_Upvote" OnDownvote="Likes_Downvote" />
                    </div>
                </div>
                <div class="panel-body" style="clear:both">
                    <p>
                        <%# Item.Content %>
                    </p>
                </div>
                <div class="panel-footer">
                    <span>Author: <%#: Item.Author.UserName %></span>
                    <span class="pull-right"><%# Item.DateCreated.ToLocalTime() %></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:HyperLink Text="Back To Homepage" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-default" />
</asp:Content>
