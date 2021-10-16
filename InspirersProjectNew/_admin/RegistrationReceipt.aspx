<%@ Page Title="" Language="C#" MasterPageFile="~/_admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="RegistrationReceipt.aspx.cs" Inherits="_admin_ManageClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/print.css" rel="stylesheet" />
    <%--------------------------------/--%>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=800,width=800');
            printWindow.document.write('<html><head><link href="../css/print.css" rel="stylesheet" />');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 100);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-head-line col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-size: 25px;"><span class="fa fa-print fa-1x"></span>&nbsp;&nbsp;
        Registration Receipt</h1>
    <br />
    <div id="printSection">
        <asp:Panel ID="pnlContents" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <center> <asp:Image ID="Image1" runat="server" src="../logoSmallBW.png" /></center>
                    <h1 class="col-lg-12 col-md-12 col-sm-12 col-xs-12 heading">Academy Of Excellence</h1>
                </div>
                <div class="col-md-12 header">
                    <p class="title">Learning Today For Better Tomorrow</p>
                    <p class="title">Faiz M. Road Near Azeem Club, Quetta.</p>
                    <p class="title">Office Phone: 081-2875515</p>
                    <p class="title-light">Student Admission Receipt</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 header">
                    <p class="title">Receipt No</p>
                    <p class="barCode">0022154578</p>
                </div>
                <div class="col-md-12">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Name: "></asp:Label></td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Father Name: "></asp:Label></td>
                            <td>
                                <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Date:"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPaymentDate" runat="server" Text="-"></asp:Label></td>
                        </tr>
                    </table>
                    <p class="title-light">Class Detail</p>

                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed printTable"></asp:GridView>

                    <asp:Label ID="lblTotalAmount" runat="server" Text="0.00"></asp:Label>
                    <br />
                    <p class="title-light">Received By</p>
                    <div id="stamp"></div>
                    <div class="clearfix"></div>
                    <p class="title">Software By: Softnat Technologies</p>
                    <div class="clearfix"></div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="clearfix"></div>
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12" style="text-align: left; font-weight: bolder;">
        <asp:LinkButton runat="server" type="submit" class="hvr-icon-fade col-1 pull-left form-control" Text="Print" ForeColor="White" ID="LinkButton2" OnClientClick="return PrintPanel();" />
    </div>
    <div class="clearfix"></div>
</asp:Content>

