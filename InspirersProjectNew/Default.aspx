<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Academy Of Excellence
    </title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="css/bootstrap.css">
    <link href="css/font-awesome.css" rel="stylesheet" />


    <!-- jQuery 2.2.3 -->
    <script src="js/jquery-1.11.1.min.js"></script>
    <!-- Bootstrap 3.3.6 -->
    <script src="js/bootstrap.js"></script>
    <!-- Slimscroll -->
    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
    <style>
        body {
            background-image: url("loginpic/29.jpg");
            background-size: 100%;
            background-position: center;
        }

        h4 {
            color: black;
        }

        h1 {
            color: black;
            font-family: Gabriola !important;
            font-size: 77px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

        <div class="container">
            <div class="row text-center " style="padding-top: 100px;">
                <div class="col-md-12">
                </div>
            </div>
            <div class="row ">
                <div class="col-md-5 col-md-offset-5 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                    <div class="panel-body">
                        <br />
                        <br />
                        <h1>Academy of Excellence</h1>
                        <br />
                        <h4>Enter Details to Login</h4>
                        <br />
                        <div class="form-group input-group">
                            <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                            <asp:TextBox ID="txtUserLogin" runat="server" class="form-control" placeholder="Your Username "></asp:TextBox>
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            <asp:TextBox ID="txtUserLoginPassword" runat="server" class="form-control" placeholder="Place Your Password " TextMode="Password"></asp:TextBox>
                        </div>

                        <asp:Button ID="Button1" runat="server" Text="Login Now" Style="color: black;" class="btn btn-dark" OnClick="loginNow" />
                        <asp:Label ID="lblError" runat="server" Style="color: red;"></asp:Label>
                    </div>
                </div>
                <div class="row text-right " style="padding-top: 100px;">
                    <div class="col-md-12">
                    </div>
                </div>
            </div>
        </div>
        <!-- /.login-box-body -->

        <!-- Modal Popup -->
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
        <!-- Modal Popup -->


        <!-- /.login-box -->
    </form>
    <!-- jQuery 2.2.3 -->

</body>
</html>
