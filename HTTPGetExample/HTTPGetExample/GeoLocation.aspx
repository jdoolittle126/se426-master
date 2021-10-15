<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoLocation.aspx.cs" Inherits="HTTPGetExample.GeoLocation" validateRequest=false  %>

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
                    <td  align="right" width="50%">
                        <asp:Label ID="Label1" runat="server" Text="IP Address"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIPAddress" runat="server">100.0.57.101</asp:TextBox>
                    </td>
                </tr>
             
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnXPath" runat="server" OnClick="btnXPath_Click" Text="Get Info By XPath" />
                        <asp:Button ID="btnGetInformation" runat="server" OnClick="btnGetInformation_Click" Text="Get Information" />                 
                    </td>
                   </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="txtResults" runat="server" Height="258px" TextMode="MultiLine" Width="366px"></asp:TextBox>
                    </td>
               
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
