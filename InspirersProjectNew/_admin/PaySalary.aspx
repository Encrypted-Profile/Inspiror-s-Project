<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="PaySalary.aspx.cs" Inherits="_admin_PaySalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12" style="height: 108px; padding: 20px; background-color: #0e2426;">
            <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-print"></span>
                Pay Employee Salary
            </h1>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-md-12">
            <div class="iconns2">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Employee Code</label>
                    <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Employee Name</label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtName" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Enter Year</label>
                    <asp:TextBox runat="server" ID="txtYear" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Select Month</label>
                    <asp:DropDownList ID="cboMonth" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="cboMonth_SelectedIndexChanged">
                        <asp:ListItem>January</asp:ListItem>
                        <asp:ListItem>February</asp:ListItem>
                        <asp:ListItem>March</asp:ListItem>
                        <asp:ListItem>April</asp:ListItem>
                        <asp:ListItem>May</asp:ListItem>
                        <asp:ListItem>June</asp:ListItem>
                        <asp:ListItem>July</asp:ListItem>
                        <asp:ListItem>August</asp:ListItem>
                        <asp:ListItem>September</asp:ListItem>
                        <asp:ListItem>October</asp:ListItem>
                        <asp:ListItem>November</asp:ListItem>
                        <asp:ListItem>December</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="salaryGrid" runat="server" CssClass="table table-condensed printTable"></asp:GridView>
        </div>
    </div>
</asp:Content>

