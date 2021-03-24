<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MIDEID.aspx.cs" Inherits="MIDEID" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

       <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <link href="css/Thrill.css" rel="stylesheet"/>
        <link href="https://fonts.googleapis.com/css?family=Roboto:300" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
       
        <div style="text-align:justify">
            <div style="text-align: center">
                <img src="Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server" />

            </div>

             <div style="background-image:url(Images/bgwrapper.png)">

                 <div  class="container shadow p-3 mb-5" style="width:80vw;text-align:center;background-color:white">
                     <br /><br />
                     <label style="text-align:justify" id="lblEidlanding" runat="server">
                         Unfortunately we have been unable to validate your identity.<br />
                         <br />

                         To complete the screening process we would like to use our Electronic Identity Validation (eID) tool.  Identity verification using eID is performed through Equifax using their product called eID Verifier. You will be asked 4 questions based on your credit history. You may be asked fake questions (meaning trick questions) as well as real questions.  If the question doesn’t relate to you, you should answer with “none of the above". This is NOT a credit check and does NOT affect your credit score. Equifax simply uses the information from your credit history to verify your identity with questions only you should know the answers to.
                         <br /><br />
                          This tool does not give Uber access to your credit information or any of your responses to the eID questions. The only information that is provided to Uber about your eID verification is whether you were able to prove your identity.
                         <br /><br />
                            Please complete the details below and check the box to give your consent to start the eID process.

                     </label>
                     <br /><br />



                     <asp:Label ID="Label1" runat="server" Text="FirstName" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtFirstName" runat="server"  Width="200px" ReadOnly="true"></asp:TextBox>
                     <br />
                     <br />
                     <asp:Label ID="Label2" runat="server" Text="SecondName" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtSecondName" runat="server"  Width="200px" ReadOnly="true"></asp:TextBox>
                     <br />
                     <br />
                     <asp:Label ID="Label3" runat="server" Text="LastName" Width="200px" ></asp:Label>
                     <br />
                     <asp:TextBox ID="txtLastName" runat="server"  Width="200px" ReadOnly="true"></asp:TextBox>
                     <br />
                     <br />
                     <asp:Label ID="Label4" runat="server" Text="DOB" Width="200px"></asp:Label>
                     <br />
                     <%--put validation--%>
                     <input type="text" id="txtDob" runat="server" name="TextBox4"  style="width:200px;background-color:#BEBEBE" readonly/>

                     <br />
                     <asp:Label ID="Label15" runat="server" Text="Phone Number" Width="200px"></asp:Label>
                     <br />
                     <%--put validation--%>
                     <input type="text" id="txtPhone" runat="server" name="phone" style="width: 200px" />

                     <br />
                     <asp:Label ID="Label16" runat="server" Text="Email" Width="200px" ></asp:Label>
                     <br />
                     <%--put validation--%>
                     <input type="text" id="txtEmail" runat="server" name="email" style="width: 200px" readonly/>

                     <br />
                     <asp:Label ID="Label14" runat="server" Text="Gender" Width="200px" ></asp:Label>
                     <br />
                     <select id="ddgender" runat="server">
                         <option value="1" >Male</option>
                         <option value="2">Female</option>
                     </select>
                     <br />
                     <asp:Label ID="Label5" runat="server" Text="Street" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtCurrentStreet" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label6" runat="server" Text="City" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtCurrentCity" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label7" runat="server" Text="Province" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtCurrentProvince" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label8" runat="server" Text="Postal Code" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtCurrentPostal" runat="server" Width="200px" ></asp:TextBox>
                     <br />
                     <asp:Label ID="Label9" runat="server" Text="How long did you live at this address?" Width="200px"></asp:Label>
                     <br />
                     <select id="ddyears" runat="server">
                         <option value="1">More than 2 years</option>
                         <option value="2">Less than 2 years</option>                         
                     </select>
                     <br />
                     
                     <div id="previous" style="display:none">
                     <asp:Label ID="Label10" runat="server" Text="Street" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtPreviousStreet" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label11" runat="server" Text="City" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtPreviousCity" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label12" runat="server" Text="Province" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtPreviousProvince" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label13" runat="server" Text="Postal Code" Width="200px"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtPreviousPostalCode" runat="server" Width="200px"></asp:TextBox>
                     <br />
                         <br />

                         <br />
                     </div>


                     <input type="checkbox" id="chkAgree" name="chkAgreee" runat="server" style="margin-left: 4px" />

                     <span id="labelcheckbox1" runat="server" class="paragraphtxt" style="font-weight: normal; margin-left: -4px; text-align: justify;">I agree to give my consent for eID</span>

                     <br />
                     <br />
                     <asp:Button ID="Button1" runat="server" Text="Submit" align="center" class="btn btn-success " style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px;text-align:center" OnClick="Button1_Click" OnClientClick="return proceed();"/>
                     <script>
                         var rowNum = 1;
                         function proceed() {
                             //alert("Hi");
                             
                             
                             if ($("#txtFirstName").val().length == 0) {
                                 alert("First name cannot be blank");
                                 return false;
                                 
                             }



                                                       
                             if ($("#txtLastName").val().length == 0) {
                                 alert("Surname cannot be blank");
                             }

                             var dobl = $("#txtDob");
                            
                             if (dobl.val().length == 0) {
                                 alert("Date of Birth cannot be blank");
                             }

                            
                             


                             if ($("#txtCurrentStreet").val().length == 0) {
                                 alert("Current Street cannot be blank");
                             }

                             if ($("#txtCurrentCity").val().length == 0) {
                                 alert("Current City cannot be blank");
                             }

                             if ($("#txtCurrentProvince").val().length == 0) {
                                 alert("Current Province cannot be blank");
                             }
                             if ($("#txtCurrentPostal").val().length == 0) {
                                 alert("Current Postal cannot be blank");
                             }


                             var ddvalue = $('#ddyears').val();

                             if (ddvalue > 1) {

                                 $('#previous').show();

                                 if ($("#txtPreviousStreet").val().length == 0) {
                                     alert("Previous Street cannot be blank");
                                 }

                                 if ($("#txtPreviousCity").val().length == 0) {
                                     alert("Previous City cannot be blank");
                                 }

                                 if ($("#txtPreviousProvince").val().length == 0) {
                                     alert("Previous Province cannot be blank");
                                 }
                                 if ($("#txtPreviousPostal").val().length == 0) {
                                     alert("Previous Postal cannot be blank");
                                 }


                             }
                             else {
                                 $('#previous').hide();
                             }


                             var check = $("#chkAgree").is(':checked');

                             if ($("#chkAgree").is(':checked')) {
                                
                             }
                             else {
                                 
                                 alert("Please agree to the terms and conditions");
                                 return false;
                             }

                         }
                         //previous address



                     </script>
                     <br />
                     <br />

                 </div>

        </div>
    </form>
</body>
</html>
