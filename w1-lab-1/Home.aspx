<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="w1_lab_1.Home" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 1 - Lab #1</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" class="m-3" runat="server">
        
        <div class="row my-5">        
            <h4 class="h4 text-center"> Create Invoice from File</h4>
            <div class="btn-group m-auto" style="max-width: 600px;">                
                <asp:FileUpload runat="server" ID="FileUpload"  CssClass="form-control m-auto" />
                <asp:Button runat="server" CssClass="btn btn-primary m-auto" Text="Upload" OnClick="ButtonUpload_Click"/>
            </div>
            <p class="text-danger text-center"><asp:Literal runat="server" ID="UploadResult" /></p>
        </div>


        <!-- Header -->
        <div class="text-center border-bottom">
            <h1 class="h1">Jon's Sports Emporium</h1>
            <p class="fst-italic">For all of your sports needs!</p>
        </div>
        
        <!-- Billing & Shipping -->
        <div class="d-flex my-2">

            <div class="col-4">
                <p class="fw-bold">Shipping</p>
                <div>
                    <asp:Literal runat="server" ID="Shipping"></asp:Literal>
                </div>
            </div>
            <div class="col-3"></div>
            <div class="col-4">
                <p class="fw-bold">Billing</p>
                <p>
                    <asp:Literal runat="server" ID="Billing"></asp:Literal>
                </p>
            </div>

        </div>
        
        <!-- Line Items -->
        <table class="table table-striped">
            <thead>
            <tr>
                <td>Part Number</td>
                <td>Description</td>
                <td>Options</td>
                <td>Unit Price</td>
                <td>Quantity</td>
                <td>Total Cost</td>
            </tr>
            </thead>
            <tbody>
                <asp:Literal runat="server" ID="TableBody"></asp:Literal>
            </tbody>
        </table>

    </form>

    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
