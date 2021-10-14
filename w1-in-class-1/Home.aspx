<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="w1_in_class_1.Home" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 1 - In Class #1</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">

        <!-- HTML collapses whitespace by default, so we disable that for our mock console -->
        <style>
            .whitespace {
                white-space: pre;
            }
        </style>

        <!-- Flex view pane for split screen on larger monitors -->
        <div class="d-md-flex" style="height: 100vh; max-width: 100vw;">

            <!-- Left/Top Pane for XML input (Note, Web.config must be configured for XML input) -->
            <div class="col-md-6 h-100 text-center">
                <h1 class="h1">Input your XML</h1>
                <asp:TextBox runat="server" ID="textBoxXmlInput" TextMode="MultiLine" CssClass="w-100 form-text h-75 border-0 border-bottom"></asp:TextBox>
                <h2 class="h2">...or choose a file!</h2>
                <div class="btn-group">                
                    <asp:FileUpload runat="server" ID="fileUpload"  CssClass="form-control m-auto" />
                    <asp:Button runat="server" CssClass="btn btn-primary m-auto" Text="Upload" OnClick="ButtonUpload_Click"/>
                </div>
            </div>


            <!-- Right/Bottom Pane for Commands and Output -->
            <div class="col-md-6 h-100">

                <div class="h-50 w-100">
                    <h1 class="h1 text-center">XPath Commands</h1>

                    <div class="d-block text-center px-3 align-content-center my-5">
                        <asp:Button runat="server" OnClick="ButtonDisplayDateVersion_Click" Text="Display Version Date & Version Number" CssClass="btn btn-primary w-75 mb-2" />
                        <asp:Button runat="server" OnClick="ButtonInfoOnContact_Click" Text="Get All Contacts" CssClass="btn btn-primary w-75 mb-2" />
                        <asp:Button runat="server" OnClick="ButtonOnlyMaleInfo_Click" Text="Get Male Contacts" CssClass="btn btn-primary w-75 mb-2" />

                        <div class="btn-group w-75 mb-2">
                            <asp:TextBox runat="server" ID="textBoxSpecificLastName" Placeholder="Last Name" CssClass="form-control" />
                            <asp:Button runat="server" OnClick="ButtonSpecificLastName_Click" Text="Search" CssClass="btn btn-primary" />
                        </div>

                        <asp:Button runat="server" OnClick="ButtonClearDisplay_Click" Text="Clear Display" CssClass="btn btn-secondary w-75 mb-2" />
                    </div>
                </div>

                <!-- Mock Console -->
                <div class="bg-black h-50 text-white">
                    <div style="height: 12%">
                        <h1 class="h1 m-0 mb-1 border-bottom">Output</h1>
                    </div>
                    <div class="px-1" style="overflow-y: scroll; height: 88%">
                        <asp:Literal runat="server" ID="outputRegion"></asp:Literal>
                    </div>
                </div>

            </div>
        </div>
    </form>

    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
