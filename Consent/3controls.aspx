<%@ Page Language="C#" AutoEventWireup="true" CodeFile="3controls.aspx.cs" Inherits="_3controls" %>
<%@ Register Assembly="WebSignature" Namespace="RealSignature" TagPrefix="ASP" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:WebSignature ID="WebSignature1"  Width="600" Height="100" runat="server">
            </asp:WebSignature>

            <asp:Image ID="Image1" runat="server"
                ImageUrl="~/images/blank.gif" />

            <%--<asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />--%>

            <asp:WebSignature ID="WebSignature2"  Width="600" Height="100" runat="server">
            </asp:WebSignature>

            <asp:Image ID="Image2" runat="server"
                ImageUrl="~/images/blank.gif" />

            <asp:WebSignature ID="WebSignature3"  Width="600" Height="100" runat="server">
            </asp:WebSignature>

            <asp:Image ID="Image3" runat="server"
                ImageUrl="~/images/blank.gif" />

            
        </div>
    </form>
</body>
</html>
