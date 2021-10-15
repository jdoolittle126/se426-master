<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockService.aspx.cs" Inherits="HTTPGetExample.StockService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Button ID="btnGetStock" runat="server" OnClick="btnGetStock_Click" Text="Get Stock" />
                        <asp:Button ID="btnEasyWay" runat="server" OnClick="btnEasyWay_Click" Text="The Easy Way" />
                        <asp:Button ID="btnClearTextBox" runat="server" OnClick="btnClearTextBox_Click" Text="Clear Text Box" />
                        <asp:TextBox ID="txtResults" runat="server" Height="293px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
