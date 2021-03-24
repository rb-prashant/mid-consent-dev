<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Thanks1.aspx.cs" Inherits="Thanks1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <link href="css/Thrill.css" rel="stylesheet"/>
        <link href="https://fonts.googleapis.com/css?family=Roboto:300" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="border:solid 1px solid;border-color:blue">
        <div style="text-align:justify">
<%--            <div class="col-md-3" style="text-align: center">
                <img src="https://infosearchsite.com/search/images/isbLogoMain.jpg" />
            </div>--%>
            <div style="text-align: center">
                <img src="Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server" />
                <br />
                <br />
            </div>
            <div>
                <img src="Images/progress bar - 100.jpg" class="bannerimg" id="progressimg" runat="server"/>
                <br />
            </div>

            <br />
            <br />
            <br />

            <div style="background-image:url(Images/bgwrapper.png)">
            <div  class="container shadow p-3 mb-5" style="width:80vw;text-align:center;background-color:white">

<%--            <div style="text-align:center">
                <img id="RSAimage" src="Images/rsaimg.png" style="height:60px" />
            </div>
                                                <div id="AdditionalFields" style="text-align:center" runat="server" >
                    We require some additional details to process your request. Please input the below fields
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="VIN "></asp:Label><br /> <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Years Insured "></asp:Label> <br /><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Email Address: "></asp:Label> <br /><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Phone Number: "></asp:Label> <br /><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Tickets: "></asp:Label> <br /><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="Accidents and Claims: "></asp:Label> <br /><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </div>
                                    <br /><br /><br /><br />
                                    <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Submit" Visible="true"  class="btn btn-success " style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px;text-align:center" />
                </div>--%>

            <div  id="pass" style="text-align:center" runat="server">
                <div style="text-align: center" >
                    <%--<img id="passimage" src="https://infosearchsite.com/MID/images/thankspass.png" style="width: 20%;height:5%" runat="server"/>--%>

                    <img id="passimage" src="Images/accepted_icon.svg" runat="server" style="height:60px;text-align:center"/>
                </div>
            </div>
            <div style="text-align:center" id="fail" runat="server">
                <div style="text-align: center">
                    <%--<img src="https://infosearchsite.com/MID/images/thanksfail.png" style="width: 20%;height:5%" runat="server"/>--%>
                    <img id="failimage" src="~/Images/declined_icon.svg" runat="server" style="width:300px;height:50px"/>

                </div>
            </div>


                            <div class="paragraphtxt" style="text-align: justify">
                <br />
                <asp:Label ID="lblThanks" runat="server" Style="text-align:center">            </asp:Label>
                <br /><br /><br /><br />




                                                <div id="uploadids2" class="container" style="margin: 15px" runat="server">
                    <div style="font-family: Roboto">
                        <div id="idtext" runat="server">
                            Save some time and upload images of 2 pieces of ID.
                        <br />
                            <br />
                            Make sure one of those pieces is a photo ID.<br />
                        </div>

                        <br />

                        <div>
                            <asp:FileUpload runat="server" ID="uplFileUploader" />
                            <br />
                        </div>
                        <div>
                            <asp:FileUpload runat="server" ID="uplFileUploader2" />



                            <br />
                        </div>


                        <div>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload Images" OnClick="btnUpload_Click"   Visible="false"  class="btn btn-success " style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px;text-align:center" />
                        </div>

                                                <br /><br />

                        <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" Visible="false"  class="btn btn-success " style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px;text-align:center"  />--%>

                      

                        <div>
                            <asp:Label runat="server" ID="lblUpload" Text=""></asp:Label>
                        </div>
                    </div>


            </div>



            </div>


<%--                        <div id="uploadids" runat="server">
                Before you exit please upload images of 2 pieces of ID. This will save you some time when setting up the VID session.  Click the button below to upload the ID images.
            </div>--%>





        

                
<%--            <div class="col-md-9" style="text-align: center;font-family:Arial" id="divFooter" runat="server">
                <br/><br/><img src='https://infosearchsite.com/MID/Images/ISB-Global-Services-Logo-Final.jpg' height='80' width ='100' /><br /> ISB Canada<br />8160 Parkhill Drive, Milton, Ontario, L9T 5V7, Canada | <a href="tel: +18664160006">1.866.416.0006</a> |  <a href="mailto: info @isbc.ca">info@isbc.ca</a> | <br/>Copyright &copy; 2017 | All Rights Reserved.
            </div>--%>
        <div id="divFooter" runat="server">
            <br />
            <br />
            <br />
            <div style="background-color: gray; color: white; font-size: 12px; text-align: center">
                <br />
                Copyright © 2018 ISB Canada, All Rights Reserved.
                    <br />
                <br />
            </div>
        </div>

                </div>
        <div>
        </div>
            </div>
    </form>
</body>
</html>
<%--                <div >
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        
                        <ContentTemplate>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                </div>--%>
