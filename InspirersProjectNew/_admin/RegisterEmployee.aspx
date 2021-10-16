<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="RegisterEmployee.aspx.cs" Inherits="admin_RegisterEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row" style="height: 80px; padding: 20px; background-color: #0e2426;">
        <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-user fa-1x"></span>&nbsp;&nbsp;Add Employee</h1>
    </div>

    <div class="iconns2" style="height: 80px; padding: 5px; margin-top: -20px; background-color: #0e2426;">
        <div class="col-lg-8 col-md-8 col-sm-6 col-xs-4">
            <asp:TextBox ID="empSearch" runat="server" CssClass="pull-left form-control" placeholder="Enter Employee First Name"></asp:TextBox>
        </div>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-4">
            <asp:Button runat="server" Text="Search" ID="btnSearch" CssClass="btn btn-default pull-left form-control" OnClick="btnSearch_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-4">
            <asp:Button runat="server" Text="View All" ID="Button1" CssClass="btn btn-default pull-left form-control" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="Button1_Click" />
        </div>
        <br />
        <br />

    </div>
    <br />

    <div class="row">

        <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <label class="form-label">Attachment</label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:Image ID="empImage" runat="server" Style="width: 140px; height: 160px; background-color: #fff;" />
            </div>
        </div>
        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12">
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Employee Code</label>
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">First Name</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="empFirstName" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Name" ControlToValidate="empFirstName" ForeColor="Red" ValidationExpression="^([a-zA-Z\s]{3,50})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="empFirstName" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Last Name</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="empLastName" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Name" ControlToValidate="empLastName" ForeColor="Red" ValidationExpression="^([a-zA-Z\s]{3,50})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="empLastName" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Gender</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="empGender" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="empGender" runat="server" CssClass="form-control">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Email</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid email." ControlToValidate="empEmail" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="empEmail" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Mobile</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="empMobile" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid mobile." ControlToValidate="empMobile" ForeColor="Red" ValidationExpression="^([+]*[0-9]{10,15})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="empMobile" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Type</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="empType" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="empType" runat="server" CssClass="form-control">
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem>Teacher</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Grade</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid." ControlToValidate="empGrade" ForeColor="Red" ValidationExpression="^([A-E]{1,1})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="empGrade" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Address:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="empAddress" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                <asp:TextBox ID="empAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Designation</label>
                <asp:TextBox ID="empDesignation" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Qualification</label>
                <asp:TextBox runat="server" ID="empQualification" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Joining Date:</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid date" ControlToValidate="empJoiningDate" ForeColor="Red" ValidationExpression="^([1-9]|1[012])[/]([1-9]|[12][0-9]|3[01])[/](19|20)\d\d$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox ID="empJoiningDate" runat="server" CssClass="form-control" ReadOnly="False" placeholder="mm/dd/yyyy"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <label class="form-label">Leaving Date:</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid date" ControlToValidate="empLeavingDate" ForeColor="Red" ValidationExpression="^([1-9]|1[012])[/]([1-9]|[12][0-9]|3[01])[/](19|20)\d\d$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                <asp:TextBox ID="empLeavingDate" runat="server" CssClass="form-control" ReadOnly="False" placeholder="mm/dd/yyyy"></asp:TextBox>
            </div>



        </div>
    </div>
    <br />

    <hr />



    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-fade col-1  pull-left form-control" Text="Submit" ForeColor="White" ID="btnRegister" OnClick="btnRegisterEmployee_Click" ValidateRequestMode="Enabled" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
        <asp:LinkButton runat="server" class="hvr-icon-spin col-5 pull-left form-control" Text="Update" ForeColor="White" ID="btnUpdate" OnClick="btnUpdate_Click" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-pop col-10 pull-left form-control" Text="Active" ForeColor="White" ID="btnActive" OnClick="btnActive_Click" CausesValidation="False" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-push col-14 pull-left form-control" ForeColor="White" Text="Deactive" ID="btnDeactive" OnClick="btnDeactive_Click" CausesValidation="False" />
    </div>
    <hr />
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton ID="btnResetData" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White" OnClick="btnReset_Click" Text="Reset Fields" CausesValidation="False" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-fade col-14 pull-left form-control" ForeColor="White" Text="Pay Salary" ID="btnAssignSalary" OnClick="btnAssignSalary_Click" CausesValidation="False" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-spin col-2 pull-left form-control" ForeColor="White" Text="Reset ID/Pwd" ID="btnResetCredential" OnClick="btnResetCredential_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" class="hvr-icon-rotate col-23 pull-left form-control" ForeColor="White" Text="Upload Picture" ID="btnUploadPicture" OnClick="btnUploadPicture_Click" CausesValidation="False" />
    </div>
    <br />
    <br />
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
    <asp:Label Text="" ID="lblError" runat="server" />

    <hr />
    <br />
    <br />


    <div class="clearfix"></div>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
