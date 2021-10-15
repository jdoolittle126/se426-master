<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="w2_in_class_2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 2 - In-Class #2</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="form col-lg-6 m-auto p-3" runat="server">

        <div class="card d-block mb-3">
            <div class="card-header">
                <h1 class="h1">Point of Interest Finder</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                        <asp:TextBox runat="server" Placeholder="What can I help you find?" ID="TextBoxPoi" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <asp:Button runat="server" ID="ButtonSearch" OnClick="ButtonSearch_Click" Text="Search!" CssClass="btn btn-primary" />
                </div>

               <div class="form-group">
                   <asp:Literal runat="server" ID="TotalResultsOutput" />
                </div>

                <div class="form-group">
                   <asp:Literal runat="server" ID="PoiOutput" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
