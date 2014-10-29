<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Likes.ascx.cs" Inherits="NewsSystemWeb.Controls.Likes" %>

<div style="text-align:center;display:inline-block">
    <%--<button type="button" class="btn btn-default" runat="server" id="upvoteBtn" onclick="upvoteBtnClick">
      <span class="glyphicon glyphicon-chevron-up"></span>
    </button>--%>
    <asp:Button Text="Up" CssClass="btn btn-default" runat="server" OnClick="upvoteBtnClick" />
    <br />
    <asp:Label ID="LikesCount" runat="server" Font-Size="Large"></asp:Label>
    <br />
    <asp:Button runat="server" Text="Down" OnClick="downvoteBtnClick" CssClass="btn btn-default" />
    <%--<button type="button" class="btn btn-default" runat="server" id="downvoteBtn" onclick="downvoteBtnClick">
      <span class="glyphicon glyphicon-chevron-down"></span>
    </button>--%>
</div>