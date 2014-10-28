<%@ Page Title="Edit Book Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditBookDetails.aspx.cs" Inherits="LibrarySystem.Registered.EditBookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Page.Title %></h1>

    <asp:FormView runat="server" ID="FormViewBook"
            DefaultMode="Edit"
            ItemType="LibrarySystem.Models.Book"
            SelectMethod="FormViewBook_GetItem"
            DataKeyNames="BookId"
            UpdateMethod="FormViewBook_UpdateItem">
            <EditItemTemplate>
                <asp:Panel runat="server" CssClass="panel panel-default">
                    <asp:Panel runat="server" CssClass="panel-heading">Edit Book</asp:Panel>
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
                            <asp:Button Text="Update" runat="server" CommandName="Update" CssClass="btn btn-success" />
                            <asp:Button Text="Cancel" runat="server" ID="CalcelCategoryCreate" CssClass="btn btn-danger" OnClick="CalcelCategoryCreate_Click" />
                        </div>

                    </asp:Panel>
                </asp:Panel>
            </EditItemTemplate>
        </asp:FormView>

</asp:Content>
