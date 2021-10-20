<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="w2_lab_2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 2 - In-Class #2</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" class="form m-auto p-3" runat="server">
    <div class="row">
            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-header">
                        <h1 class="h1">Traffic Report</h1>
                    </div>
                    <div class="card-body">
                        <p class="text-muted">Find traffic updates in the New England Tech Area!</p>

                        <div class="form-group">
                            <asp:Button runat="server" ID="ButtonTrafficSearch" OnClick="ButtonTrafficSearch_Click" Text="Get Report!" CssClass="btn btn-primary"/>
                        </div>

                        <div class="form-group">
                            <asp:Literal runat="server" ID="TotalResultsOutput"/>
                        </div>

                        <div class="form-group">
                            <asp:Literal runat="server" ID="TrafficOutput"/>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-header">
                        <h1 class="h1">Zip Code Finder</h1>
                    </div>
                    <div class="card-body">
                        <p class="text-muted">Find what's in and around your zip code!</p>
                        
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="TextBoxZipCode" Placeholder="02828" CssClass="form-control"/>
                        </div>

                        <div class="form-group">
                            <asp:Button runat="server" ID="ButtonInZipCodeSearch" OnClick="ButtonInZipCodeSearch_OnClick" Text="Find Cities Within Zip Code!" CssClass="btn btn-primary"/>
                            <asp:Button runat="server" ID="ButtonNearZipCodeSearch" OnClick="ButtonNearZipCodeSearch_OnClick" Text="Find Cities Near Zip Code!" CssClass="btn btn-secondary"/>
                        </div>

                        <div class="form-group">
                            <asp:Literal runat="server" ID="TotalZipOutput"/>
                        </div>

                        <div class="form-group">
                            <asp:Literal runat="server" ID="ZipResultsOutput"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</form>
</body>
</html>