<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="w2_group_activity_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 2 - Group Activity #1</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="form col-lg-6 m-auto p-3" runat="server">
        <div class="card d-block mb-3">
            <div class="card-header">
                <h1 class="h1">Calculator</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="">
                        <asp:TextBox runat="server" Placeholder="5" ID="TextBoxCalculatorInput1" CssClass="form-control" />
                    </label>
                </div>
                <div class="form-group">
                    <label for="">
                        <asp:TextBox runat="server" Placeholder="3" ID="TextBoxCalculatorInput2" CssClass="form-control" />
                    </label>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="ButtonAdd" OnClick="ButtonAdd_Click" Text="Add" CssClass="btn btn-primary" />
                    <asp:Button runat="server" ID="ButtonSubtract" OnClick="ButtonSubtract_Click" Text="Subtract" CssClass="btn btn-primary" />
                </div>
                <div class="form-group">
                    <p class="text-success">
                        <asp:Literal runat="server" ID="CalculatorResult" />
                    </p>
                </div>
            </div>
        </div>

        <div class="card d-block mb-3">
            <div class="card-header">
                <h1 class="h1">Phone Verify</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="">
                        <asp:TextBox runat="server" ID="TextBoxPhone" Placeholder="4011232222" CssClass="form-control" />
                    </label>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="ButtonGetRegion" OnClick="ButtonGetRegion_Click" Text="Get Region" CssClass="btn btn-primary" />
                </div>
                <div class="form-group">
                       <p class="text-success">
                        <asp:Literal runat="server" ID="OutputRegion" />
                    </p>
                </div>
            </div>
        </div>

        <div class="card d-block ">
            <div class="card-header">
                <h1 class="h1">Address Lookup</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="">
                        <asp:TextBox runat="server" Placeholder="Providence" ID="TextBoxCity" CssClass="form-control" />
                    </label>
                </div>
                 <div class="form-group">
                    <label for="">
                        <asp:TextBox runat="server" Placeholder="RI" ID="TextBoxState" CssClass="form-control" />
                    </label>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="ButtonFindZipCodes" OnClick="ButtonFindZipCodes_Click" Text="Get Zipcodes!" CssClass="btn btn-primary" />
                </div>
                <div class="form-group">
                    <p class="text-success">
                        <asp:Literal runat="server" ID="OutputZipCode" />
                    </p>
                </div>
            </div>
        </div>

    </form>
</body>
</html>