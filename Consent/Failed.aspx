<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Failed.aspx.cs" Inherits="Failed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>An error was encountered</title>
    <link href="./bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align:center" >
                <img style="width:100%;" src="https://infosearchsite.com/MID/Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server"/>
                <br /><br />
            </div>
            <div style="text-align:center;">
               <div runat="server" id="ErrorMsgResponse" style="font-size: 21px;">An error was encountered. Please contact administrator or start over again!</div>
            </div>
        </div>
    </form>
</body>
</html>
