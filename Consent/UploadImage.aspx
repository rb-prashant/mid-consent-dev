<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImage.aspx.cs" Inherits="UploadImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    
    
     <link href="css/Thrill.css" rel="stylesheet"/>
      <link href="https://fonts.googleapis.com/css?family=Roboto:300" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <div style="text-align: center">
                <img src="https://infosearchsite.com/MID/Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server" />
                <br />
                <br />
            </div>

            <div id="divwelcometxt" class="welcometxt"  >
               <%--Upload your ID!--%>
            </div>
            <br /><br />
            <div style="background-image:url(https://infosearchsite.com/MID/Images/bgwrapper.png)">
            <div class="container" style="margin: 15px;background-color:white">
                
                <div style="font-family: Roboto">
                    <%--Save some time and upload images of 2 pieces of ID.--%>
                    Final step - please upload an image of your Driver’d Abstract.
                    <br />
                    <br />
                    <%--Make sure one of those pieces is a photo ID.<br />--%>
                    <br />

                    <div>
                        <asp:FileUpload runat="server" ID="uplFileUploader" style="width: auto; font-family: Roboto; background-color: #2FC7A0; border-radius: 20px"/>
                        <br /><br />
                    </div>
                    <div>
                        <asp:FileUpload runat="server" ID="uplFileUploader2" style="width: auto; font-family: Roboto; background-color: #2FC7A0; border-radius: 20px" Visible="false" />
                        <br /><br />
                    </div>
                    <div>
                        <%--<asp:Button runat="server" ID="btnUpload" Text="Upload Image 1 "
                            OnClick="btnUpload_Click" AutoPostback="false" />--%>


                        <div style="text-align: center">
                            <button id="btnContinue" onserverclick="btnContinue_Click" runat="server" type="button" class="btn btn-success" style="width: 200px; font-family: Roboto; background-color: #2FC7A0; border-radius: 20px">UPLOAD IMAGE</button>
                            
                        </div>
                        <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                    </div>
                    <br /><br />
                    <%--<button runat="server" id="button2" onserverclick="Button1_Click">Upload Image 2</button>--%>
                    <div>
                        <asp:Label runat="server" ID="lblUpload" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
