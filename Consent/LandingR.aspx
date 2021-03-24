<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandingR.aspx.cs" Inherits="LandingR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Welcome</title>

    <link href="css/Thrill.css" rel="stylesheet"/>
     <link href="https://fonts.googleapis.com/css?family=Roboto:300" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
   
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
 
</head>
<body>
    <form id="form1" runat="server">
        <div >

            <div style="text-align:center" >
                <img src="https://infosearchsite.com/MID/Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server"/>
                <br /><br />
            </div>
            <div id="divwelcometxt" class="welcometxt" runat="server" >
               
            </div>
            <br />
            <div id="div2" runat="server" class="container" style="text-align:center">
                <%--you'll need to verify your identity to successfully apply to Uber Canada.--%>
            </div>

            <br />


             <div style="background-image:url(https://infosearchsite.com/MID/Images/bgwrapper.png)">

            <div class="container shadow p-3 mb-5" style="width:80vw;background-color:white">


                <div id="landingdiv" runat="server">
                    <div id="div3" runat="server" class="paragraphlgtxt">
                        You'll need:
                    </div>
                    <div style="text-align: center">
                        <img src="https://infosearchsite.com/MID/Images/licenseanimated.gif" /><br />
                        <br />

                    </div>
                    <div style="padding-left: 3em;" id="divlist" runat="server">


                        <img src="https://infosearchsite.com/MID/Images/bullet_icon_1.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp;To provide your consent<br />
                        <br />
                        <img src="https://infosearchsite.com/MID/Images/bullet_icon_2.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp;Your valid Canadian driver's licence<br />
                        <br />
                        <img src="https://infosearchsite.com/MID/Images/bullet_icon_3.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp;A flat, coloured surface for your driver's licence photo
                        <br />
                        <br />
                        <%--<img src="https://infosearchsite.com/MID/Images/bullet_icon_4.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp;To be prepared to take a selfie<br />--%>
                        <img src="https://infosearchsite.com/MID/Images/bullet_icon_4.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp;Please be prepared to upload images of 2 pieces of Government issued identification that confirm your: name, date of birth and address.  One piece must include a photo.  Acceptable Photo ID includes: Driver’s License, Passport, Permanent Resident Card, Canadian Citizenship Card.  Acceptable non-Photo ID which provide both name and date of birth includes: Immigration Papers, Hunting/Fishing License, Birth Certificate, Hospital Card<br />
                        <br />
                        <%--<img src="https://infosearchsite.com/MID/Images/bullet_icon_5.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp; Be prepared to upload additional pieces of Government issued ID at the end of this process<br />--%>
                        <%--<img src="https://infosearchsite.com/MID/Images/bullet_icon_5.svg" style="height: 22px; margin-left: -32px" />&nbsp;&nbsp; Please be prepared to upload images of 2 pieces of Government issued identification that confirm your: name, date of birth and address.  One piece must include a photo.  Acceptable Photo ID includes: Driver’s License, Passport, Permanent Resident Card, Canadian Citizenship Card.  Acceptable non-Photo ID which provide both name and date of birth includes: Immigration Papers, Hunting/Fishing License, Birth Certificate, Hospital Card<br />--%>
                        <br />
                    </div>
                    <div id="div4" runat="server" class="welcometxt" style="font-size: 16px; font-weight: bold; padding: 12px; text-align: justify">
                       
                    </div>



                </div>

 
            </div>

           

            <div id="buttons" runat="server">
                <div style="text-align:center">
                    <button id="btnContinue" onserverclick="btnContinue_Click" runat="server" type="button" class="btn btn-success" style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px" ></button>
                </div>
                <div style="text-align:center">
                    <br />
                    <button type="button" class="btn btn-danger" style="width:200px;font-family:Roboto;background-color:#E2223A;border-radius:20px""  onclick="javascript:window.close()">
                        <div id="btnLater" runat="server">I'll come back later</div></button>
                </div>
            </div>



            <div >
                <br /><br /><br />
                <div  style="background-color:gray;color:white;font-size:12px;text-align:center">
                    <br />
                    <div id="footer" runat="server"></div>
                    <%--Copyright © 2018 ISB Canada, All Rights Reserved.--%>
                    <br /><br />
                </div>
            </div>

                 </div>

            
        </div>
    </form>
</body>
</html>
