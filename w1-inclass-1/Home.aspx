<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="w1_inclass_1.Home" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>XML INPUT</h1>
                <asp:TextBox runat="server" ID="textBoxXmlInput" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div>
                <h1>XPATH FUNCTIONS</h1>
                <ol>
                    <li><asp:Button runat="server" Name="ButtonDisplayDateVersion" OnClick="ButtonDisplayDateVersion_Click" Text="Display the version date and version number"/></li>
                    <li><asp:Button runat="server" Name="ButtonInfoOnContact" OnClick="ButtonInfoOnContact_Click" Text="Return all of the information about each contact (including the sex)"/></li>
                    <li><asp:Button runat="server" Name="ButtonOnlyMaleInfo" OnClick="ButtonOnlyMaleInfo_Click" Text="Return all of the information for only the males in the contact list"/></li>
                    <li>
                        <asp:TextBox runat="server" Name="TextBoxSpecificLastName" />
                        <asp:Button runat="server" Name="ButtonSpecificLastName" OnClick="ButtonSpecificLastName_Click" Text="Return all of the information for a specific last name that you enter "/>
                    </li>
                    <li>
                        <asp:Button runat="server" OnClick="ButtonClearDisplay_Click" Text="Clear Display"/>
                    </li>
                </ol>
            </div>

            <div>
                <h1>OUTPUT</h1>
                <asp:TextBox runat="server" ID="textBoxOutput" ReadOnly="true" TextMode="MultiLine" />
            </div>


        </div>
    </form>
</body>
</html>
