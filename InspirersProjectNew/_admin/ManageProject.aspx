<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="ManageProject.aspx.cs" Inherits="_admin_ManageProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" style="height: 80px; padding: 20px; background-color: #0e2426;">
        <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;">
            <span class="fa fa-archive fa-1x"></span>&nbsp;&nbsp;Manage Classes</h1>
    </div>
    <div class="iconns2" style="height: 80px; padding: 5px; margin-top: -20px; background-color: #0e2426;">
        <div class="col-lg-10 col-md-10 col-sm-9 col-xs-8">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="pull-left form-control" placeholder="Enter Class Name Or Code"></asp:TextBox>
        </div>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-4">
            <asp:Button runat="server" Text="Search" ID="btnSearch" CssClass="btn btn-default pull-left form-control" OnClick="btnSearch_Click" UseSubmitBehavior="False" CausesValidation="False" />
        </div>
        <br />
    </div>
    <div class="row">
        <br />
        <div class="iconns2">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Class Code</label>
                    <asp:TextBox runat="server" ID="txtClassCode" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Class Teacher:</label>
                    <asp:DropDownList ID="cboTeachers" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Subject:</label>
                    <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Class Name:</label>
                    <asp:TextBox runat="server" ID="txtClassName" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Class Fee</label>
                    <asp:TextBox runat="server" ID="txtFee" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Timing</label>
                    <asp:TextBox runat="server" ID="txtClassTiming" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Teacher Percentage</label>
                    <asp:TextBox runat="server" ID="txtTeacherPercentage" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <hr />

    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Submit" ForeColor="White" ID="LinkButton2" OnClick="btnAddProject_Click" />
    </div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-spin col-5 pull-left form-control" Text="Update" ForeColor="White" ID="LinkButton3" OnClick="btnUpdate_Click" />
    </div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton ID="LinkButton1" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White" OnClick="btnReset_Click" Text="Reset Fields" CausesValidation="False" />
    </div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton ID="LinkButton4" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White" Text="View All Classes" CausesValidation="False" OnClick="LinkButton4_Click" />
    </div>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="iconns2">
                <asp:GridView ID="searchGridView" runat="server" class="table table-condensed" HeaderStyle-BackColor="#1bbc9b" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="#0e2426" OnSelectedIndexChanged="searchGridView_SelectedIndexChanged" CellPadding="1" BorderStyle="Solid" BorderWidth="2px" BorderColor="#0e2426">
                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="2px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" EditText="Select" />
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#0e2426" BorderColor="#0e2426" />
                    <HeaderStyle BackColor="#0e2426" ForeColor="#1bbc9b" BorderColor="#0e2426" BorderStyle="Solid" BorderWidth="2px"></HeaderStyle>
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#0e2426" BorderColor="#0e2426" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#0e2426" BorderColor="#0e2426" Font-Bold="True" />
                    <SelectedRowStyle BackColor="#1bbc9b" Font-Bold="True" ForeColor="#0e2426" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                </asp:GridView>

            </div>
        </div>
    </div>
    <asp:Label ID="lblError" runat="server" ForeColor="#FF0066" Visible="true" Font-Size="10pt"></asp:Label>
    <hr />
</asp:Content>

