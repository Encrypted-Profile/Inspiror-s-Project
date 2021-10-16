<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="RegisterStudent.aspx.cs" Inherits="_admin_ManageClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-smile-o fa-1x"></span>&nbsp;&nbsp;
        Student Information</h1>
    <br />
    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-md-12">
            <div class="iconns2">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Student Code</label>
                    <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Student Name</label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-smile-o fa-1x"></span>&nbsp;&nbsp;
        Course Registration</h1>
    <br />


    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="iconns2">
                        <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <label class="form-label">Select Class</label>
                            <asp:DropDownList ID="cboClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboClass_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Enabled="False" Selected="True">Select Class</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <label class="form-label">Class Timing</label>
                            <asp:TextBox runat="server" ID="txtTiming" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <label class="form-label">Class Subject</label>
                            <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <label class="form-label">Class Teacher</label>
                            <asp:TextBox runat="server" ID="txtTeacher" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <label class="form-label">Class Fee</label>
                            <asp:TextBox runat="server" ID="txtFee" CssClass="form-control">

                            </asp:TextBox>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <hr />
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Add Course" ForeColor="White" ID="LinkButton1" OnClick="LinkButton1_Click" />
    </div>
    <div class="clearfix"></div>
    <hr />
    <div class="row">
        <div class="col-md-12">


            <div class="table-responsive ">
                <asp:DataList ID="orderGrid" runat="server" class="table table-bordered">
                    <HeaderTemplate>
                        <table style="width: 100%;">
                            <thead>
                                <th>Seriel</th>
                                <th>Course Code</th>
                                <th>Course Name</th>
                                <th>Timing</th>
                                <th>Fee</th>
                                <th>Teacher</th>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="element"><%#Eval("Seriel")%></td>
                            <td class="element"><%#Eval("Course Code")%></td>
                            <td class="element"><%#Eval("Course Name")%></td>
                            <td class="element"><%#Eval("Timing")%></td>
                            <td class="element"><%#Eval("Fee")%></td>
                            <td class="element"><%#Eval("Teacher")%></td>
                            <td>
                                <asp:LinkButton runat="server" ID="linkbutton1" class="icon" CustomParameter='<%#Eval("Seriel")%>' OnClick="deleteRow" CausesValidation="false">
                                                        <span class="fa fa-trash "></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblTotalAmount" runat="server" Text="0.00"></asp:Label>
        </div>
    </div>

    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Register Now > " ForeColor="White" ID="LinkButton2" OnClick="btnRegisterClient_Click" />
    </div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton ID="LinkButton3" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White" Text="Reset Data" CausesValidation="False" OnClick="LinkButton3_Click" />
    </div>
    <div class="clearfix"></div>
    <hr />
</asp:Content>

