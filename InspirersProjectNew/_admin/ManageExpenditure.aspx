<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="ManageExpenditure.aspx.cs" Inherits="_admin_ManageExpenditure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
    <div class="row" style="height:80px; padding:20px;  background-color:#0e2426;">
            <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size:25px;"><span class="fa fa-dollar fa-1x"></span>&nbsp;&nbsp;Add Expenditure</h1>
 <hr />
  
      </div>
         <div class="iconns2" style="height:80px; padding:5px; margin-top:-20px; background-color:#0e2426;">
        <div class="col-lg-10 col-md-10 col-sm-9 col-xs-8">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="pull-left form-control" placeholder="Enter Expenditure Reason" ></asp:TextBox>
        </div>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-4">
             <asp:Button runat="server" Text="Search"  ID="btnSearch" CssClass="btn btn-default pull-left form-control" OnClick="btnSearch_Click" UseSubmitBehavior="False" CausesValidation="False" />
        </div>
        <br />
    </div>
    <br />
    <div class="row">
            <div class="iconns2">
               <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12" >
                   <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                       <label class="form-label">Attachment</label>
                   </div>
                   <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                       <asp:Image ID="image" runat="server" style="width:140px; height:160px;" />
                   </div>
            </div>
         <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12">
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Id</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
                 <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                     <label class="form-label" >Amount</label> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid amount" ControlToValidate="txtAmount" ForeColor="Red" ValidationExpression="^([0-9]{1,10})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:TextBox runat="server" id="txtAmount" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                     <label class="form-label" >Reason</label> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtReason" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                     <asp:TextBox runat="server" id="txtReason" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <label class="form-label">Date</label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid" ControlToValidate="txtDate" ForeColor="Red" ValidationExpression="^([1-9]|1[012])[/]([1-9]|[12][0-9]|3[01])[/](19|20)\d\d$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="mm/dd/yyyy"></asp:TextBox>
                </div>
               
               <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                     <label class="form-label" >Note</label> 
                     <asp:TextBox runat="server" id="txtNote" CssClass="form-control"></asp:TextBox>
                </div>
                
            </div>
        </div>
        <div class="col-md-1">
        </div>
    </div>

  <hr />     
   
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
                    <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Submit"  ForeColor="White" ID="btnSubmit" OnClick="btnSubmit_Click" />
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                
                      <asp:LinkButton runat="server" type="submit"  class="hvr-icon-spin col-5 pull-left form-control" Text="Update" ForeColor="White" ID="btnUpdate" OnClick="btnUpdate_Click"  />
                </div>
             
                 <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
                      <asp:LinkButton ID="btnReset" runat="server" class="hvr-icon-spin col-11 pull-left form-control" ForeColor="White"  OnClick="btnReset_Click" Text="Reset Fields" CausesValidation="False" />
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
                   <asp:LinkButton runat="server" class="hvr-icon-rotate col-23 pull-left form-control" ForeColor="White" Text="Upload File" ID="btnUploadPicture" OnClick="btnUploadPicture_Click" CausesValidation="False" />
                 </div>
               
                
    <hr />
    <div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
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

     <div class="clearfix"></div> 
       <hr />
     <div  class="row">
        <div class="col-md-12">
            <div class="iconns2">
                <asp:GridView ID="searchGridView" runat="server" class="table table-condensed" HeaderStyle-BackColor="#1bbc9b" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="#0e2426" OnSelectedIndexChanged="searchGridView_SelectedIndexChanged" CellPadding="1" BorderStyle="Solid" BorderWidth="2px" BorderColor="#0e2426">
                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="2px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" EditText="Select" />
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#0e2426" BorderColor="#0e2426" />
                    <HeaderStyle BackColor="#0e2426" Forecolor="#1bbc9b" BorderColor="#0e2426" BorderStyle="Solid" BorderWidth="2px"></HeaderStyle>
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#0e2426" BorderColor="#0e2426" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#0e2426" BorderColor="#0e2426" Font-Bold="True"/>
                    <SelectedRowStyle BackColor="#1bbc9b" Font-Bold="True" ForeColor="#0e2426" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                </asp:GridView>
                
            </div>
        </div>
    </div>
        <asp:Label ID="lblError" runat="server" ForeColor="red" Visible="true" Font-Size="10pt"></asp:Label>
    <hr />
<%--  </ContentTemplate>
 </asp:UpdatePanel>--%>
</asp:Content>

