<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="LibrarySystem.Registered.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <asp:GridView ID="GridViewCategories" runat="server"
        CssClass="table table-bordered gridView"
        AutoGenerateColumns="false"
        ItemType="LibrarySystem.Models.Category"
        SelectMethod="GridViewCategories_GetData"
        DataKeyNames="CategoryId"
        UpdateMethod="GridViewCategories_UpdateItem"
        DeleteMethod="GridViewCategories_DeleteItem"
        AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CommandField ShowEditButton="true" ShowHeader="true" HeaderText="Edit" />
            <asp:CommandField ShowDeleteButton="true" ShowHeader="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:LinkButton ID="CreateCategoryBtn" Text="Create New Category"
        CssClass="btn btn-info" OnClick="CreateCategoryBtn_Click" runat="server" />
    <br />

    <asp:Panel runat="server" ID="CreateCategoryPanel" Visible="false">
        <asp:FormView runat="server" ID="CreateCategoryFormView"
            DefaultMode="Insert"
            ItemType="LibrarySystem.Models.Category"
            InsertMethod="CreateCategoryFormView_InsertItem">
            <InsertItemTemplate>
                <asp:Panel runat="server" CssClass="panel panel-default">
                    <asp:Panel runat="server" CssClass="panel-heading">Create Category</asp:Panel>
                    <asp:Panel runat="server" CssClass="panel-body">
                        <asp:TextBox runat="server" ID="TextBoxCategoryName" Text="<%# BindItem.Name %>" EnableViewState="false" />
                        <asp:Button Text="Create" runat="server" CommandName="Insert" CssClass="btn btn-success" />
                        <asp:Button Text="Cancel" runat="server" ID="CalcelCategoryCreate" CssClass="btn btn-danger" OnClick="CalcelCategoryCreate_Click" />
                    </asp:Panel>
                </asp:Panel>
            </InsertItemTemplate>
        </asp:FormView>
    </asp:Panel>

</asp:Content>
