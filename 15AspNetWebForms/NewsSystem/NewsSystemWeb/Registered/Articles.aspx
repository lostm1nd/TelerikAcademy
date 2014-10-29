<%@ Page Title="Edit Articles" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="NewsSystemWeb.Registered.Articles" %>

<%@ Import Namespace="NewsSystemWeb.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="row">
        <h1><%: Page.Title %></h1>
    </header>

    <asp:ListView runat="server" ID="ListViewArticles"
        ItemType="NewsSystemWeb.Models.Article"
        DataKeyNames="ArticleId"
        SelectMethod="ListViewArticles_GetData"
        UpdateMethod="ListViewArticles_UpdateItem"
        OnSorting="ListViewArticles_Sorting">

        <LayoutTemplate>
            <div class="row">
                <asp:Button Text="Sort By Title" runat="server" CommandName="Sort" CommandArgument="Title" CssClass="btn btn-default" />
                <asp:Button Text="Sort By Date" runat="server" CommandName="Sort" CommandArgument="DateCreated" CssClass="btn btn-default" />
                <asp:Button Text="Sort By Category" CommandName="Sort" CommandArgument="Category.Name" runat="server" CssClass="btn btn-default" />
                <asp:Button Text="Sort By Likes" CommandName="Sort" CommandArgument="Likes.Count" runat="server" CssClass="btn btn-default" />
		    </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            <asp:DataPager runat="server" PagedControlID="ListViewArticles" PageSize="5">
                <Fields>
                    <asp:NextPreviousPagerField ShowNextPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
            <asp:HyperLink Text="Create new article" runat="server" NavigateUrl="~/Registered/CreateArticle" CssClass="btn btn-info pull-right" />
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
			    <h3>
                    <%#: Item.Title %>
                    <asp:Button Text="Edit" CommandName="Edit" runat="server" CssClass="btn btn-info" />
                    <asp:Button Text="Delete" CommandName="Delete" runat="server" CssClass="btn btn-danger" />
			    </h3>
			    <p>Category: <%#: Item.Category.Name %></p>
			    <p><%#: Item.Content.TrimTo300() %></p>
			    <p>Likes count: <%# Item.Likes.Count %></p>
			    <div>
				    <i>by <%#: Item.Author.UserName %></i>
				    <i>created on: <%#: Item.DateCreated.ToLocalTime() %></i>
			    </div>
		    </div>
        </ItemTemplate>

        <EditItemTemplate>
            <div class="row" style="background-color: #eee; padding: 4px">
			    <p>
                    <asp:TextBox runat="server" ID="TextBoxEditName" Text='<%# BindItem.Title %>' CssClass="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Title is required"
                        ControlToValidate="TextBoxEditName" runat="server"
                        ForeColor="Red" Font-Bold="true" />
			    </p>
			    <p>
                    <asp:DropDownList runat="server" ID="DdlEditCategory" CssClass="form-control"
                        ItemType="NewsSystemWeb.Models.Category"
                        SelectMethod="DdlEditCategory_GetData"
                        DataTextField="Name"
                        DataValueField="CategoryId"
                        SelectedValue='<%# BindItem.CategoryId %>'>
                    </asp:DropDownList>
			    </p>
			    <p>
                    <asp:TextBox runat="server" ID="TextBoxEditContent" CssClass="form-control"
                        TextMode="MultiLine" Height="100" Text='<%# BindItem.Content %>' />
                    <asp:RequiredFieldValidator ErrorMessage="Content is Required"
                        ControlToValidate="TextBoxEditContent" runat="server"
                        ForeColor="Red" Font-Bold="true" />
			    </p>
			    <p>
				    <i>by <%#: Item.Author.UserName %></i>
				    <i>created on: <%#: Item.DateCreated.ToLocalTime() %></i>
                    <asp:Button Text="Cancel" CommandName="Cancel" runat="server" CausesValidation="false" CssClass="btn btn-danger pull-right" />
                    <asp:Button Text="Update" CommandName="Update" runat="server" CssClass="btn btn-info pull-right" />
			    </p>
		    </div>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
