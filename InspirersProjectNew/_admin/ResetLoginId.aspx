<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="ResetLoginId.aspx.cs" Inherits="_admin_ResetLoginId" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="row">
        <div class="col-md-12" style="height:100px; padding:20px;  background-color:#0e2426;">
            <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size:25px;"><span class="fa fa-key fa-1x"></span>&nbsp;&nbsp;Change Login Id</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <div class="iconns2">
                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                     <label class="form-label">New Login ID</label><br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId" ErrorMessage="Fill the fields!" CssClass="validater" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter atleast four characters!" ControlToValidate="txtLoginId" ForeColor="Red" ValidationExpression="^([a-zA-Z1-9\-_@]{4,15})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                     <asp:TextBox ID="txtLoginId" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                <br />
                <br />
                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                     <asp:Button ID="Button1" runat="server" Text="Change" class="btn btn-primary" OnClick="Button1_Click" />
                 </div>
                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                     <asp:Label ID="lblError" runat="server" ForeColor="#FF0066" Visible="False" Font-Size="10pt"></asp:Label>
                 </div>
            
              
            </div>
        </div>
        <div class="col-md-2">
        </div>
    </div>
            
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
</asp:Content>

