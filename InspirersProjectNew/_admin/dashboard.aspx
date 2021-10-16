<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="admin_dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col_3">
        <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-gears fa-1x"></span>&nbsp;&nbsp;
        Dashboard
        </h1>
        <p><span class="fa fa-gear fa-1x"></span>&nbsp;&nbsp;Dashboard displays data analysis using charts, labels, graphs as well as figures.</p>
        <hr />
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 widget">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-tasks icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label Text="$452" ID="lblTotalProjects" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Total Projects</span>
                </div>
            </div>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 widget">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-archive user1 icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label Text="$452" ID="lblCompleted" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Completed Projects</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12  widget">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-money user2 icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label Text="$452" ID="lblStarted" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Started Projects</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 widget ">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-dashboard dollar1 icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label Text="$452" ID="lblPending" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Pending Projects</span>
                </div>
            </div>

        </div>
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 widget">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-users dollar2 icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label ID="lblUnassignedEmp" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Unassigned Employees</span>
                </div>
            </div>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 widget">
            <div class="r3_counter_box">
                <i class="pull-left fa fa-building-o dollar2 icon-rounded"></i>
                <div class="stats">
                    <strong>
                        <asp:Label ID="lblUnassignedPro" runat="server" Style="color: black; font-size: 22px;" /></strong>
                    <br />
                    <span>Unassigned Projects</span>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="row-one widgettable">
    </div>

    <div class="row-one widgettable">
    </div>

</asp:Content>


