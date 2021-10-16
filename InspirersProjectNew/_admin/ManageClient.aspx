<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="ManageClient.aspx.cs" Inherits="_admin_ManageClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-smile-o fa-1x"></span>&nbsp;&nbsp;Register New Student</h1>
    <br />
    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-md-12">
            <div class="iconns2">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Student Code</label>
                    <asp:TextBox runat="server" ID="txtCode" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Student Name</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid name" ControlToValidate="txtName" ForeColor="Red" ValidationExpression="^([a-zA-Z\s]{3,50})$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Father Name</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtFather" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Name" ControlToValidate="txtFather" ForeColor="Red" ValidationExpression="^([a-zA-Z\s]{3,50})$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="txtFather" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Gender</label>
                    <asp:DropDownList ID="cboGender" runat="server" CssClass="form-control">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Mobile</label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid number" ControlToValidate="txtMobile" ForeColor="Red" ValidationExpression="^([+]*[0-9]{10,15})$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Email</label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid email" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Emergency number</label>
                    <asp:TextBox runat="server" ID="txtEmergency" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <hr />
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton ID="LinkButton1" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White" OnClick="btnReset_Click" Text="Generate Code" CausesValidation="False" />
    </div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Register > " ForeColor="White" ID="LinkButton2" OnClick="btnRegisterClient_Click" />
    </div>

    <div class="clearfix"></div>
    <hr />
</asp:Content>

