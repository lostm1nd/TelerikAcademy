<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="NewsSystemWeb.Registered.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="row">
        <h1><%: Page.Title %></h1>
    </header>

    <section class="row">
        <div class="col-md-6">
            <asp:GridView ID="GridViewCategories" runat="server"
                AutoGenerateColumns="false"
                CssClass="table table-bordered gridView"
                ItemType="NewsSystemWeb.Models.Category"
                SelectMethod="GridViewCategories_GetData"
                DataKeyNames="CategoryId"
                UpdateMethod="GridViewCategories_UpdateItem"
                DeleteMethod="GridViewCategories_DeleteItem"
                AllowSorting="true"
                AllowPaging="true"
                PageSize="5">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Edit" runat="server" CommandName="Edit" CssClass="btn btn-info" />
                            <asp:Button Text="Delete" runat="server" CommandName="Delete" CssClass="btn btn-danger" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:Button Text="Update" runat="server" CommandName="Update" CssClass="btn btn-info" />
                            <asp:Button Text="Cancel" runat="server" CommandName="Cancel" CssClass="btn btn-danger" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <p>
                <asp:LinkButton runat="server" ID="CreateCategoryBtn" Text="Create New Category" CssClass="btn btn-info" OnClick="CreateCategoryBtn_Click" />
            </p>

            <asp:Panel runat="server" ID="CreateCategoryPanel" Visible="false">
                <asp:FormView runat="server" ID="CreateCategoryFormView"
                    DefaultMode="Insert"
                    ItemType="NewsSystemWeb.Models.Category"
                    InsertMethod="CreateCategoryFormView_InsertItem">
                    <InsertItemTemplate>
                        <asp:Panel runat="server" CssClass="panel panel-default">
                            <asp:Panel runat="server" CssClass="panel-heading">Create Category</asp:Panel>
                            <asp:Panel runat="server" CssClass="panel-body">
                                <p>
                                    <asp:TextBox runat="server" ID="TextBoxCategoryName" Text="<%# BindItem.Name %>" EnableViewState="false" />
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Category name is required" ControlToValidate="TextBoxCategoryName"
                                        ForeColor="Red" Font-Bold="true" />
                                </p>
                                <p>
                                    <asp:Button Text="Create" runat="server" CommandName="Insert" CssClass="btn btn-success" />
                                    <asp:Button Text="Cancel" runat="server" ID="CancelCategoryCreate" CssClass="btn btn-danger"
                                        OnClick="CancelCategoryCreate_Click" CausesValidation="false" />
                                </p>
                            </asp:Panel>
                        </asp:Panel>
                    </InsertItemTemplate>
                </asp:FormView>
            </asp:Panel>

            <p>
                <asp:HyperLink Text="Back To Homepage" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-default" />
            </p>
        </div>
    </section>
</asp:Content>
