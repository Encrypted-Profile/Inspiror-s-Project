<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeReport.aspx.cs" Inherits="_admin_EmployeeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><link href="../css/bootstrap.css" rel="stylesheet" /><link href="../css/font-awesome.css" rel="stylesheet" /><link href="../css/basic.css" rel="stylesheet" /><link href="../css/custom.css" rel="stylesheet" /><link href="../css/Invoice.css" rel="stylesheet" />');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-12" style="height:108px; padding:20px;  background-color:#0e2426;">
            <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size:25px;"><span class="fa fa-print"></span>&nbsp;&nbsp;Search & Print Employee</h1>
        </div>
    </div>

    <div class="iconns2">
          <div class="col-lg-2 col-md-2 col-sm-3">
        </div>
        <div class="col-lg-8 col-md-8 col-sm-6 col-xs-12">
                      <asp:DropDownList ID="cboEmployee" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboEmployee_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
        </div>
        <div class="col-lg-2 col-md-2 col-sm-3">
        </div>

    </div>
    <br />
    <br />

    <hr />

    <asp:Panel id="pnlContents" runat = "server" >
        <br />

        <div class="iconns2">
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align: center; font-weight: bolder;">
                    <h2 style="font-weight:bold;">Inspirer's Project Management System</h2>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                </div>
            </div>
        </div>
        <br />
        <div  class="row text-center contact-info">
         <div class="col-lg-12 col-md-12 col-sm-12">
             <hr />
             <span>
                   <strong>Email : </strong>  inspirer@project.com 
             </span>
             <span>
                 <strong>Call : </strong>  0413062162 
             </span>
             
             <hr />
         </div>
     </div>
        
    <div class="iconns2">
        <br />
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center; font-weight:bolder;">
                <asp:Image ID="empImg" runat="server" style="width:150px;"/>
                 <asp:Label ID="lblPicture" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="text-align: center; font-weight: bolder;">
                    <asp:Label ID="lblEmployeeId" runat="server" Text=""></asp:Label>
                </div>
            </div>
        <br />
          
     
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    FirstName:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    LastName:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                </div>
             </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Email:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Phone No:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Gender:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Qualification:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblQualification" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Address:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Designation:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Joining Date:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblJoiningDate" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Leaving Date:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblLeavingDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Status:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Type:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
                </div>
            </div>
           <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                    Salary Type:
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblSalaryType" runat="server" Text=""></asp:Label>
                </div>
               <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left; font-weight: bolder;">
                   <asp:Label ID="lblSalaryLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblHourSalary" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    <hr />
        </asp:Panel>
    <div class="row">
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                <asp:Button ID="Button5" runat="server" CssClass="btn btn-success pull-left form-control" Text="Print"  OnClientClick = "return PrintPanel();"/>
           </div>
            <asp:Label ID="lblError" Visible="false" runat="server" Text=""></asp:Label>

    </div>
       <div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                </h4>
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
    <hr />
</asp:Content>

