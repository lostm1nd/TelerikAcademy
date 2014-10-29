<%@ Page Title="Create new aricle" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CreateArticle.aspx.cs" Inherits="NewsSystemWeb.Registered.CreateArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="row">
        <h1><%: Page.Title %></h1>
    </header>

    <asp:FormView runat="server" ID="FormViewArticle"
        DefaultMode="Insert"
        ItemType="NewsSystemWeb.Models.Article"
        DataKeyNames="ArticleId"
        InsertMethod="FormViewArticle_InsertItem"
        Width="100%">
        <InsertItemTemplate>
            <asp:Panel runat="server" CssClass="panel panel-default">
                <asp:Panel runat="server" CssClass="panel-heading"></asp:Panel>
                <asp:Panel runat="server" CssClass="panel-body">

                    <div class="form-group">
                        <label class="control-label">Title:</label>
                        <asp:TextBox runat="server" ID="tbTitleEdit" Text='<%# BindItem.Title %>' CssClass="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Title is required" ControlToValidate="tbTitleEdit" runat="server"
                            ForeColor="Red" Font-Bold="true" />
                    </div>                        
                        
                    <div class="form-group">
                        <label class="control-label">Category:</label>
                        <asp:DropDownList runat="server" ID="DdlCategories" CssClass="form-control"
                            ItemType="NewsSystemWeb.Models.Category"
                            SelectMethod="DdlCategories_GetData"
                            DataTextField="Name"
                            DataValueField="CategoryId"
                            SelectedValue='<%# BindItem.CategoryId %>'>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label class="control-label">Content:</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" Height="100"
                            ID="tbDescriptionEdit" Text='<%# BindItem.Content %>' CssClass="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Content is required" ControlToValidate="tbDescriptionEdit" runat="server"
                            ForeColor="Red" Font-Bold="true" />
                    </div>

                    <div class="form-group">
                        <asp:Button Text="Create" runat="server" CommandName="Insert" CssClass="btn btn-success" />
                        <asp:HyperLink Text="Cancel" runat="server" NavigateUrl="~/Registered/Articles.aspx" CssClass="btn btn-danger" />
                    </div>

                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
