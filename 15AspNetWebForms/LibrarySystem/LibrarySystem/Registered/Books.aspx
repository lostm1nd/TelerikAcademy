<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibrarySystem.Registered.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <asp:GridView runat="server" ID="GridViewBooks"
        ItemType="LibrarySystem.Models.Book"
        DataKeyNames="BookId"
        SelectMethod="GridViewBooks_GetData"
        AutoGenerateColumns="false"
        AllowSorting="true"
        AllowPaging="true"
        PageSize="5"
        CssClass="table table-bordered gridView">
        <Columns>
            <asp:BoundField SortExpression="Title" DataField="Title" HeaderText="Title" />
            <asp:BoundField SortExpression="Author" DataField="Author" HeaderText="Author" />
            <asp:BoundField SortExpression="ISBN" DataField="ISBN" HeaderText="ISBN" />
            <asp:BoundField SortExpression="WebSite" DataField="WebSite" HeaderText="Website" />
            <asp:BoundField DataField="Category.Name" HeaderText="Category" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server"
                        PostBackUrl='<%# string.Format("~/Registered/EditBookDetails?bookId={0}", Item.BookId) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <asp:LinkButton ID="CreateBookBtn" Text="Create New Book"
        CssClass="btn btn-info" runat="server" OnClick="CreateBookBtn_Click" />
    <br />

    <asp:Panel runat="server" ID="BookActionsPanel" Visible="false">
        <asp:FormView runat="server" ID="FormViewBook"
            DefaultMode="Insert"
            ItemType="LibrarySystem.Models.Book"
            DataKeyNames="BookId"
            InsertMethod="FormViewBook_InsertItem"
            ViewStateMode="Disabled">
            <InsertItemTemplate>
                <asp:Panel runat="server" CssClass="panel panel-default">
                    <asp:Panel runat="server" CssClass="panel-heading">Create Book</asp:Panel>
                    <asp:Panel runat="server" CssClass="panel-body">

                        <div class="form-group">
                            <label class="control-label">Title:</label>
                            <asp:TextBox runat="server" ID="tbTitleEdit" Text='<%# BindItem.Title %>' CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label class="control-label">Author(s):</label>
                            <asp:TextBox runat="server" ID="tbAuthorEdit" Text='<%# BindItem.Author %>' CssClass="form-control" />
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label">ISBN:</label>
                            <asp:TextBox runat="server" ID="tbISBNEdit" Text='<%# BindItem.ISBN %>' CssClass="form-control" />
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label">Web site:</label>
                            <asp:TextBox runat="server" ID="tbWebEdit" Text='<%# BindItem.WebSite %>' CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label class="control-label">Description:</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Height="120"
                                ID="tbDescriptionEdit" Text='<%# BindItem.Description %>' CssClass="form-control" />
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label">Category:</label>
                            <asp:DropDownList runat="server" ID="DDLCategories" CssClass="form-control"
                                ItemType="LibrarySystem.Models.Category"
                                SelectMethod="DDLCategories_GetData"
                                DataTextField="Name"
                                DataValueField="CategoryId"
                                SelectedValue='<%# BindItem.CategoryId %>'>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Button Text="Create" runat="server" CommandName="Insert" CssClass="btn btn-success" />
                            <asp:Button Text="Cancel" runat="server" ID="CalcelCategoryCreate" CssClass="btn btn-danger" OnClick="CalcelCategoryCreate_Click" />
                        </div>

                    </asp:Panel>
                </asp:Panel>
            </InsertItemTemplate>
        </asp:FormView>
    </asp:Panel>

</asp:Content>
