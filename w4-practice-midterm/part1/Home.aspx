<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="part1.Home" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Part 1</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" class="form col-lg-6 m-auto p-3" runat="server">

    <div class="card d-block mb-3">
        <div class="card-header">
            <h1 class="h1">Account Info</h1>
        </div>
        <div class="card-body">
            <table>
                <tr>
                    <td>Owner</td>
                    <td><asp:TextBox runat="server" ID="TextboxAccountOwner"></asp:TextBox></td>
                </tr>                
                <tr>
                    <td>ID</td>
                    <td><asp:TextBox runat="server" ID="TextboxAccountId"></asp:TextBox></td>
                </tr>                
                <tr>
                    <td>Total</td>
                    <td><asp:TextBox runat="server" ID="TextboxTotal"></asp:TextBox></td>
                </tr>
            </table>

            <div class="form-group">
                <asp:Button runat="server" ID="ButtonSearch" OnClick="ButtonSearch_OnClick" Text="Get Results" CssClass="btn btn-primary" />
            </div>

        </div>
    </div>
</form>

<script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
