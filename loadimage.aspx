<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loadimage.aspx.cs" Inherits="SignApp.loadimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>    
    <script src="jQuery/jquery-2.0.3.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="scripts/signature_pad.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="margin-top:20px; text-align:center;">
        <input type="text" id="inpsearch" name="outputdir" class="form-control"
               style="display:inline; width:200px;" runat="server"/>
        <asp:Button ID="btnsub" class="btn btn-info" runat="server" Text="Load the Image" OnClick="btnsub_Click"/>
    </div>
    <div class="container">
        <asp:Image id="inpimg" runat="server"
           AlternateText="Traffic Image"
           ImageUrl="images/image1.jpg"/>

    </div>
    </form>
</body>
</html>
