﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form runat="server">
        <div class="container">
            <div class="card">
                <div class="card-body">
                    <div class="md-form md-outline">
                        <asp:Label ID="LbPost" AssociatedControlID="tbtitle" runat="server" Text="Post Title"></asp:Label>
                        <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="md-form md-outline">
                        <asp:Label ID="LbDesc" AssociatedControlID="tbcontent" runat="server" Text="Post Description"></asp:Label>
                        <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="custom-file">
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
                                <asp:Label ID="LbFile" AssociatedControlID="fileUpload" runat="server" Text="Upload a file" CssClass="custom-file-label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6 text-right">
                            <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <% if (allPosts().Count > 0)
                {
            %>
            <div class="card mt-3">
                <asp:Repeater runat="server" ID="postinfo" DataSourceID="postdata" OnItemCommand="postinfo_ItemCommand">
                    <ItemTemplate>
                        <div class="card-body" id="post<%#Eval("Id") %>">
                            <div class="row">
                                <div class="col-lg-6">
                                    <h4 class="card-title" runat="server" id="posttitle"><%#Eval("title") %></h4>
                                    <asp:TextBox runat="server" ID="tbUptitle" CssClass="form-control" Visible="false" Text='<%#Eval("title") %>'></asp:TextBox>
                                </div>
                                <div class="col-lg-6 text-right">
                                    <asp:Button runat="server" CommandName="editpost" ID="btnEdit" Text="Edit" CssClass="btn btn-sm btn-info" />
                                </div>
                            </div>

                            <div class="media mt-4 px-1">
                                <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                                    alt="Generic placeholder image">
                                <div class="media-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <h5 class="font-weight-bold mt-0">
                                                <a href="#">Danny Newman</a>
                                            </h5>
                                        </div>
                                        <div class="col-lg-6">
                                            <i class="fas fa-clock mr-1"></i><span>Created on: <%#Eval("datecreated") %>
                                            </span>
                                        </div>
                                    </div>
                                    <div runat="server" id="postcontent">
                                        <%#Eval("content") %>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbUpcontent" TextMode="MultiLine" Rows="6" CssClass="form-control" Visible="false" Text='<%#Eval("content") %>'></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                            <div class="card-header border-0 font-weight-bold">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:Button runat="server" CommandName="cancel" ID="btncancel" Text="Cancel" CssClass="btn btn-sm btn-danger" Visible="false" />
                                    </div>
                                    <div class="text-right col-lg-6">
                                        <asp:Button runat="server" CommandName="save" CommandArgument='<%#Eval("Id") %>' ID="btnSave" Text="Save Changes" CssClass="btn btn-sm btn-success" Visible="false" />
                                        <asp:Button runat="server" CommandName="viewpost" CommandArgument='<%#Eval("Id") %>' ID="btnView" Text="View >>" CssClass="btn btn-sm btn-success" />
                                    </div>
                                </div>
                            </div>
                            <hr />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="postdata"
                    ConnectionString="<%$ connectionStrings: ConnStr%>"
                    SelectCommand="SELECT * FROM POST ORDER BY datecreated DESC"
                    runat="server"></asp:SqlDataSource>
            </div>
            <%} %><% else
                      { %>
            <div class="text-center mt-3">
                <h4 class="font-weight-bold">No Posts</h4>
            </div>
            <% } %>
        </div>
    </form>
</asp:Content>
