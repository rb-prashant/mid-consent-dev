<%@ Page Language="C#" AutoEventWireup="true" CodeFile="validatecredentialsver2.aspx.cs" Inherits="validatecredentialsver2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
    
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/Thrill.css" rel="stylesheet"/>
        <link href="https://fonts.googleapis.com/css?family=Roboto:300" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >

            <div style="text-align:center" >
                <img src="Images/Banner 1_updated.jpg" class="bannerimg" />
                <br /><br />
            </div>
            <div class="welcometxt" >
                Hi Alex,
            </div>
            <br />
            <div class="container" style="text-align:center">
                you'll need to verify your identity to successfully apply to Uber Canada.
            </div>

            <br />

            <div class="container shadow p-3 mb-5" style="width:80vw">
                <div class="paragraphlgtxt">
                    You'll need:
                </div>
                <div style="text-align:center">
                    <img src="Images/licenseanimated.gif" /><br /><br />
                    
                </div>
                <div style="padding-left:3em">
<%--                    <ul >
                        <li ><img src="Images/bullet_icon_1.svg" style="height:22px" />To provide your consent<br/><br /></li>
                        
                        <li style="list-style-image: url('../Images/bullet_icon_2.svg')">Your valid Canadian driver's licence <br /><br /></li>
                                                    
                        <li style="list-style-image: url('../Images/bullet_icon_3.svg')">A flat, coloured surface for your driver's licence photo <br /><br /></li>
                        
                        <li style="list-style-image: url('../Images/bullet_icon_4.svg')">To be prepared to take a selfie<br /></li>

                    </ul>--%>
                    <img src="Images/bullet_icon_1.svg" style="height:22px;margin-left:-22px" />To provide your consent<br/><br />
                    <img src="Images/bullet_icon_2.svg" style="height:22px;margin-left:-22px" />Your valid Canadian driver's licence<br/><br />
                    <img src="Images/bullet_icon_3.svg" style="height:22px;margin-left:-22px" />A flat, coloured surface for your driver's licence photo <br/><br />
                    <img src="Images/bullet_icon_4.svg" style="height:22px;margin-left:-22px" />To be prepared to take a selfie<br/><br />
                </div>
                <div class="welcometxt" style="font-size:16px;font-weight:bold">
                    If you exit before receiving a red or a green light result at the end of this process, your background check will not be completed
                </div>

                
            </div>
            <div>
                <div style="text-align:center">
                    <button type="button" class="btn btn-success" style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px" >Let's Start</button>
                </div>
                <div style="text-align:center">
                    <br />
                    <button type="button" class="btn btn-danger" style="width:200px;font-family:Roboto;background-color:#E2223A;border-radius:20px"">I'll come back later</button>
                </div>
            </div>
            <div id="footer">
                <br /><br /><br />
                <div style="background-color:gray;color:white;font-size:12px;text-align:center">
                    <br />
                    Copyright © 2018 ISB Canada, All Rights Reserved.
                    <br /><br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
