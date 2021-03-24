<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidateCredentials.aspx.cs" Inherits="ValidateCredentials" %>
<%@ Register Assembly="WebSignature" Namespace="RealSignature" TagPrefix="ASP" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html>


<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style type="text/css">
        .pac-container {
            background-color: #fff;
            position: absolute !important;
            z-index: 1000;
            border-radius: 2px;
            border-top: 1px solid #d9d9d9;
            font-family: Arial,sans-serif;
            box-shadow: 0 2px 6px rgba(0,0,0,0.3);
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            overflow: hidden
        }

        .pac-logo:after {
            content: "";
            padding: 1px 1px 1px 0;
            height: 16px;
            text-align: right;
            display: block;
            background-image: url(https://maps.gstatic.com/mapfiles/api-3/images/powered-by-google-on-white3.png);
            background-position: right;
            background-repeat: no-repeat;
            background-size: 120px 14px
        }

        .hdpi.pac-logo:after {
            background-image: url(https://maps.gstatic.com/mapfiles/api-3/images/powered-by-google-on-white3_hdpi.png)
        }

        .pac-item {
            cursor: default;
            padding: 0 4px;
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
            line-height: 30px;
            text-align: left;
            border-top: 1px solid #e6e6e6;
            font-size: 11px;
            color: #999
        }

            .pac-item:hover {
                background-color: #fafafa
            }

        .pac-item-selected, .pac-item-selected:hover {
            background-color: #ebf2fe
        }

        .pac-matched {
            font-weight: 700
        }

        .pac-item-query {
            font-size: 13px;
            padding-right: 3px;
            color: #000
        }

        .pac-icon {
            width: 15px;
            height: 20px;
            margin-right: 7px;
            margin-top: 6px;
            display: inline-block;
            vertical-align: top;
            background-image: url(https://maps.gstatic.com/mapfiles/api-3/images/autocomplete-icons.png);
            background-size: 34px
        }

        .hdpi .pac-icon {
            background-image: url(https://maps.gstatic.com/mapfiles/api-3/images/autocomplete-icons_hdpi.png)
        }

        .pac-icon-search {
            background-position: -1px -1px
        }

        .pac-item-selected .pac-icon-search {
            background-position: -18px -1px
        }

        .pac-icon-marker {
            background-position: -1px -161px
        }

        .pac-item-selected .pac-icon-marker {
            background-position: -18px -161px
        }

        .pac-placeholder {
            color: gray
        }

        /*Signature CSS*/
        .kbw-signature {
            width: 400px;
            height: 200px;
        }
        /* Ends here Signature CSS*/
        .clickable {
            cursor: pointer;
        }

        /*.modal{
            width:80%;
            height:85%;
            font-size:small;
            position:;
        }*/
    </style>
<%--    <script type="text/javascript" src="App_Scripts/jquery-1.8.2.js">    
    </script>--%>
    <style>
        html, body, #map-canvas {
            height: 100%;
            margin: 0px;
            padding: 0px
        }

        .modal {
            width: 85%; /* respsonsive width */
            position: absolute;
            left: 10px;
            top: 10px;
        }

        .ui-datepicker {
            z-index: 1600;
            width:100%;
            position:relative;
            top:-290px;
        }

        
    </style>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
<%--    <script src="https://infosearchsite.com/uber/js/jquery.validate.js"></script>
    <script src="https://infosearchsite.com/uber/js/jquery.js"></script>
    <script src="https://infosearchsite.com/uber/js/jquery-1.11.1.js"></script>--%>
    <script src="http://jqueryvalidation.org/files/dist/additional-methods.min.js"></script>




    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&amp;signed_in=true&amp;libraries=places"></script>



    <link type="text/css" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
            <link href="css/Thrill.css" rel="stylesheet"/>
    <title>Insurance Search Bureau (ISB)
    </title>
   <%-- <link href="https://infosearchsite.com/uber/css/field.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="https://infosearchsite.com/uber/css/views.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="https://infosearchsite.com/uber/css/font-awesome.min.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="https://infosearchsite.com/uber/css/default.css" rel="stylesheet" type="text/css" media="screen" src="/templates/splash/css/default.less"/>--%>
    <script src="https://infosearchsite.com/uber/js/jquery.maskedinput.js" type="text/javascript"></script>
  <%--  <link href="https://infosearchsite.com/uber/css/style.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="https://infosearchsite.com/uber/css/open-sans-fontfacekit.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="https://infosearchsite.com/uber/css/date.css" rel="stylesheet" type="text/css" media="screen"/>
    <script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/33/5/common.js"></script>
    <script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/33/5/util.js"></script>
    <script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/33/5/controls.js"></script>
    <script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/33/5/places_impl.js"></script>
    <script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/33/5/stats.js"></script>--%>



    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script>

        
    </script>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet"/>
<script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
</head>


<body class="html front not-logged-in one-sidebar sidebar-second page-node page-node- page-node-35 node-type-page navbar-is-static-top" onload="initialize()" style="background-color:white">
    <%--<header class="navbar navbar-static-top navbar-default" id="navbar" role="banner" style="padding:2vw;background-color:white">--%>
   <div>
<%--        <div class="container" style="align-content:center" >

            <div style="text-align:center; " >
                <div class="col-md-3" style="text-align: center">
                    <img src="https://infosearchsite.com/MID/Images/ISB-Global-Services-Logo-Final.jpg" style="width:20%;height:5%"/>
                </div>
                <div class="col-md-9">
                    <h1 style="font-family: 'Times New Roman';" id="lblheader" runat="server">Criminal Record Verification</h1>
                </div>
            </div>

               
               
        </div>--%>

        <div style="text-align: center">
            <img src="https://infosearchsite.com/MID/Images/Banner 1_updated.jpg" class="bannerimg" id="bannerimg" runat="server"/>
            <br />
            <br />
        </div>
                   <div>
                <img src="https://infosearchsite.com/MID/Images/progress bar - 20.jpg" class="bannerimg"/>
                <br />
                <br />
                       <br />
            </div>
       </div>
        <br />
    <br />

    <div style="background-image:url(https://infosearchsite.com/MID/Images/bgwrapper.png)">
    <div class="container" style="background-color:white">
        <header id="page-header" role="banner"></header>
        <form id="form1" runat="server">


            <script type="text/javascript">
                //<![CDATA[
                var theForm = document.forms['form1'];
                if (!theForm) {
                    theForm = document.form1;
                }
                function __doPostBack(eventTarget, eventArgument) {
                    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                        theForm.__EVENTTARGET.value = eventTarget;
                        theForm.__EVENTARGUMENT.value = eventArgument;
                        theForm.submit();
                    }
                }
//]]>
            </script>
             <div style="background-image:url(https://infosearchsite.com/MID/Images/bgwrapper.png)">
            <div class="container shadow p-3 mb-5" style="width:80vw;text-align:center;background-color:white">
                <div id="totalbody" runat="server">
                    <div >

                        <div>
                            <div class="row">&nbsp;</div>
                            <div>
                                <img src="https://infosearchsite.com/MID/Images/check_icon.svg" style="height:100px" /><br />
                            </div>
                            <div class="welcometxt" id="divStep1" runat="server">
                                Step 1:
                                <br />
                            </div>
                            <div class="paragraphtxt" id="divconsanddec" runat="server">
                                Give your consent and declaration
                            </div>
                            <div class="h3" id="lbl1" runat="server">
                                <%--A. Personal Information--%>
                            </div>
<%--                            <br />
                            <br />--%>

                            <label id="lblFirstName" runat="server"></label>
                            <label id="lblMiddleName" runat="server"></label>
                            <label id="lblSurname" runat="server"></label>
                            <label id="lblUserID" runat="server"></label>

<%--                            <div class="row" id="tester">


                                <div class="form-group col-md-3">
                                    <span id="lbl3" runat="server">Given Name(s)</span><br />
                                    <label id="lblFirstName" runat="server"></label>

  
                                </div>
                                <div class="form-group col-md-3">
                                    <span id="lbl4" runat="server">Middle Name(s)</span><br />
                                    <label id="lblMiddleName" runat="server"></label>
  
                                </div>
                                <div class="form-group col-md-3">
                                    <span id="lbl2" runat="server">Surname (lastname)</span><br />
                                    <label id="lblSurname" runat="server"></label>

                                </div>
                            </div>--%>

                           
                        </div>


<%--                        <div id="div1" runat="server" style="color: red">
                            <h3 style="color: black">B. Informed Consent and Declaration</h3>
                            <br />
                            Click on the link below to read the consent form and declare any previous offenses. Declaring offenses is optional but strongly recommended for confirming background check results.<br />
                            <br />
                        </div>--%>

                        <div > <div id="divreadthe" runat="server" style="text-align:justify;display:inline">Read the</div>
                            <div id="divreadthegoogle" runat="server" style="text-align:justify;color:red;display:inline;"></div>
                            <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Click Here to read the consent form</button>--%>
                            <a class="clickable" data-toggle="modal" data-target="#myModal" style="text-align: center;display:inline"><u><strong><span id="lbl5" runat="server">consent and declaration form</span><span id="lbl5google" runat="server" style="color:#28599D"></span></strong></u></a>
                            <div class="container">
                                <!-- Modal -->
                                <div class="modal fade" id="myModal" role="dialog">
                                    <div class="modal-dialog" style="left: 8px; top: auto; width: 90%">

                                        <!-- Modal content-->
                                        <div class="modal-content" style="font-size: 8px">
                                            <div class="modal-header" style="margin-left:0em">
                                                <button type="button" class="close" data-dismiss="modal" style="margin:0">&times;</button>
                                                <h6 class="modal-title" id="lbl11" runat="server">C. Informed Consent and Declaration</h6>

                                            </div>
                                            <div class="modal-body">




                                                <%--                                            <div class="field-content">
                                                <div class="row">&nbsp;</div>

                                                <div class="53">
                                                    B. Reason for the Criminal Record Verification
                                                </div>

                                                <div class="col-md-12">
                                                    Reason for Request (example Employment - Employer - Job Title): Employment/Contract/Driving
                                                </div>
                                                <br />
                                                <div class="col-md-12">
                                                    Organization Requesting Search : ISB Canada
                                                </div>
                                                <br />
                                                <div class="col-md-6">
                                                    Contact Name: Johanna Clifford
                                                </div>
                                                <div class="col-md-6">
                                                    Contact Phone Number: 905-875-6828
                                                </div>

                                            </div>--%>


                                                <div class="field-content" style="text-align:justify">
                                                    <div class="row">&nbsp;</div>
                                                    <div class="row">
                                                        <%--                                                    <br />--%>
                                                    </div>
                                                    <%--                                                <div class="53">
                                                    C.Informed Consent

                                                </div>--%>
                                                    <div class="row">
                                                        <%--                                                    <br />--%>
                                                    </div>
                                                    <div  id="lbl12" runat="server">
                                                        SEARCH AUTHORIZATION - I HEREBY CONSENT TO THE SEARCH OF the RCMP National Repository of Criminal Records based on the name(s),
                            date of birth and where used, the declared criminal record history provided by myself. 
                            I understand that this verification of the National Repository of Criminal Records is not being confirmed by fingerprint comparison 
                            which is the only true means by which to confirm if a criminal record exists in the National Repository of Criminal Records.
                                                    
                                                    </div>
                                                    <div class="row">
                                                        <%--                                                    <br />--%>
                                                    </div>
                                                    <div  id="lbl13" runat="server">
                                                        POLICE INFORMATION SYSTEM(S)-I HEREBY CONSENT TO THE SEARCH OF police information systems, as part of a Police Information Check, 
                            which will consist of a search of the following systems (check applicable):
                                                    
                                                    </div>
                                                    <div class="row">
                                                        <%--<br />--%>
                                                    </div>
                                                    <div class="row">
                                                        <%--<br />--%>
                                                    </div>
                                                    <br />
                                                    <div >
                                                        <div class="form-check">
                                                            <label class="form-check-label" for="exampleCheck1" id="lbl14" runat="server"><input type="checkbox" id="exampleCheck1" checked="checked" disabled="disabled" />
                                                            CPIC Investigative Data Bank</label>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div >
                                                        <div class="form-check">
                                                            <label class="form-check-label" for="exampleCheck1" id="lbl15" runat="server"><input type="checkbox"  id="exampleCheck2" checked="checked" disabled="disabled" />
                                                            Police Information Portal(PIP)</label>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <%--                                                <div class=" col-md-4">
                                                    <div class="form-check">
                                                        <input type="checkbox" class="form-check-input" id="exampleCheck3" disabled="disabled" />
                                                        <label class="form-check-label" for="exampleCheck1">OTHER:</label>
                                                    </div>
                                                </div>--%>
                                                    <div id="lbl16" runat="server">
                                                        <strong>AUTHORIZATION AND WAIVER </strong>to provide a confirmation of criminal record or any police information.
                                                    <%--<br />--%>
                                                    I certify that the information set out by me in this application is true and correct to the best of my ability.
                                I consent to the release of the results of the criminal record check to <strong>ISB Canada</strong>, located in Toronto, ON, Canada.
                                                    </div>
                                                    <%--                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <strong>UBER</strong>,
                                                        <br />
                                                        Company Name
                                                        <br />
                                                        <br />
                                                    </div>
                                                    <div class="col-md-3">
                                                        located in ___________________,
                                                        <br />
                                                        City and Country 
                                                    </div>
                                                </div>--%>



                                                    <%--<div class="row">--%>
                                                    <div  id="lbl18" runat="server">
                                                        I hereby release and forever discharge all members and employees of the processing Police Service and the Royal Canadian Mounted Police from any and all actions, claims and demands for damages, loss or injury howsoever arising which may hereafter be sustained by myself as a result of the disclosure of information by the Cobourg Police to ISB Canada Milton,ON.
                                                    </div>
                                                    <%--</div>--%>

                                                    <%--                                                <div class="row">
                                                    <div class="col-md-3">Cobourg Police Service to</div>
                                                    <div class="col-md-3">ISB Canada</div>
                                                    <div class="col-md-3">Milton,ON </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-3">Name of Processing Police Service </div>
                                                    <div class="col-md-3">Company Name </div>
                                                    <div class="col-md-3">City and Country </div>
                                                </div>
                                                <br />--%>
                                                </div>


                                                <div id="divoffense" runat="server" visible="false">

                                                    <div id="content" >
                                                        <%--<div class="row">&nbsp;</div>
                                                <div class="row">
                                                    <br />
                                                </div>
                                                <div class=" col-md-6">
                                                    <h5>D.Identification Verification</h5>
                                                </div>
                                                <div class=" col-md-6">
                                                    <input type="checkbox" class="form-check-input" id="exampleCheck4" checked="checked" disabled="disabled" />
                                                    <h5>Electronic Identity Verification</h5>
                                                </div>
                                                <div class="row">
                                                    <br />
                                                </div>

                                                <div class="row">
                                                    <div class=" col-md-6">Witnessing Agent's Name: </div>
                                                    <div class=" col-md-6">Identification Verified:</div>
                                                </div>
                                                <div class="row">
                                                    <br />
                                                </div>
                                                <div class="row">
                                                    <div class=" col-md-6">Witnessing Agent's Signature: </div>
                                                    <div class=" col-md-6">
                                                        Type of Photo ID Viewed<br />
                                                        (Governmet Issued) & Secondary ID
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <br />
                                                </div>

                                                <div class=" col-md-9">
                                                    Name and location of the company where information will be stored in Canada: ISB Canada, Milton, ON
                                                </div>
                                                <br />
                                                <div class="col-md-9" style="font-weight: bold">
                                                    **Information related to this criminal record check is collected, retained and disclosed in accordance with applicable privacy legislation.**
                                                </div>
                                                <div class="col-md-9" style="font-weight: bold; text-align: right">
                                                    CRIMINAL RECORD VERIFICATION<br />
                                                    Informed Consent Form

                                                </div>
                                                <div class="row">
                                                    <br />
                                                </div>
                                                <div class="col-md-9">
                                                    Declaration of Criminal Record
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-9">
                                                    This form is required to be filled out and attached to your Informed Consent Form for a Criminal Record Verification.
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-3">Surname(last name)</div>
                                                <div class="col-md-3">Given name(s) </div>
                                                <div class="col-md-3">Date of Birth</div>
                                                <div class="row">
                                                    
                                                </div>
                                                <div class="col-md-9">
                                                    Information is collected and disclosed in accordance with federal, provincial and municipal laws
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-12">
                                                    A Declaration of Criminal Record does not constitute a Certified Criminal Record by the RCMP and may not contain all criminal record convictions.
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-9">
                                                    Applicants must declare all convictions for offences under Canadian federal law.
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-9">
                                                    Do not declare the following: 
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="col-md-1"></div>
                                                <div class="col-md-9">
                                                    <ul>
                                                        <li>A conviction for which you have received a Record Suspension {formerly pardon) in accordance with the Criminal Records Act;</li>
                                                        <li>A conviction where you were a "young person" under the Youth Criminal Justice Act;</li>
                                                        <li>An Absolute or Conditional Discharge, pursuant to section 730 of the Criminal Code;</li>
                                                        <li>An offence for which you were not convicted;</li>
                                                        <li>Any provincial or municipal offence, and;</li>
                                                        <li>Any charges dealt with out side of Canada.</li>
                                                    </ul>
                                                </div>
                                                <div class="row">
                                                    
                                                </div>
                                                <div class="col-md-9" style="font-weight: bold">
                                                    Note that a Certified Criminal Record can only be issued based on the submission of fingerprints to the RCMP National Repository of Criminal Record.
                                                </div>
                                                <div class="row">
                                                    
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">Offence   </div>
                                                    <div class="col-md-3">Date of Sentence </div>
                                                    <div class="col-md-3">Location</div>
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtOffence1" id="txtOffence1" type="text" class="form-control" />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtDate1" id="txtDate1" type="text"/>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtLocation1" id="txtLocation1" type="text" class="form-control" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtOffence2" id="txtOffence2" type="text" class="form-control" />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtDate2" id="txtDate2" type="text"/>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtLocation2" id="txtLocation2" type="text" class="form-control" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtOffence3" id="txtOffence3" type="text" class="form-control" />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtDate3" id="txtDate3" type="text"  />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <input runat="server" name="txtLocation3" id="txtLocation3" type="text" class="form-control" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">Signature of Applicant</div>
                                                    <div class="col-md-6">Date(YYYY-MM-DD)</div>
                                                </div>
                                                <div class="row">
                                                   
                                                </div>
                                                <div>
                                                    Verified By: 
                                    <br />
                                                    Coburg Police Services<br />
                                                    Name of Police Agency Employee
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-9" style="text-align: right">
                                                        <img src="https://infosearchsite.com/search/images/isbLogoMain.jpg" />
                                                    </div>
                                                </div>
                                                <div>
                                                    <div class="row">
                                                       
                                                    </div>
                                                    <div class="col-md-9" style="font-weight: bold">Consent for the release of personal information</div>
                                                    <div class="row">
                                                        
                                                    </div>
                                                    <div class="col-md-9">I , have applied for employment / contract work with  (The Company).</div>
                                                    <div class="row">
                                                       
                                                    </div>
                                                    <div class="col-md-9">
                                                        I understand that as a condition of my employment/contract work, the company will perform a full background check on me.
                            These checks/searches may include some, or all the following: criminal search, drivers abstract, driver insurance history, credit history, employment verification, 
                            education verification, verification of address for up to 10 years, employment references,Verification of Drivers license status, Terrorism watch list check,
                            Validation of SIN number.
                                                    </div>
                                                    <div class="row">
                                                       
                                                    </div>
                                                    <div class="col-md-9">
                                                        I hereby authorize the holder(s) of information, relating to the items checked off below, to disclose the information requested, 
                            at any time, to the company and/or its authorized agents and ISB Canada.
                                                    </div>
                                                    <div class="row">
                                                        
                                                    </div>
                                                    <div class="col-md-9">
                                                        I understand that the Company will use some or all the disclosed information provided, from any source to 
                            evaluate me and confirm my suitability for employment/contract work.
                                                    </div>
                                                    <div class="row">
                                                       
                                                    </div>
                                                    <div class="col-md-9">
                                                        I hereby release and forever discharge the holder(s) of information relating to
                            the above, including ISB Canada, and the Company, their respective affiliated entities and any former, 
                            current, and future partners, directors, officers, employees, agents, successors and assigns, including those belonging to affiliated entities,
                            from any actions, claims, and demands of any kind whatsoever relating to the collection,
                            disclosure, or use of this information by the holder(s) of information relating to the above items, ISB Canada or the Company.
                            I further declare the information below, on my résumé/application, and provided verbally to the Company,
                            is complete and accurate. I understand a false statement may disqualify me from employment and give cause for my dismissal if employed. 

                                                    </div>
                                                </div>--%>
                                                        <%--                        <div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="exampleChk2" />
                                    <label class="form-check-label" for="exampleCheck1">Fraud Alert - through Equifax Canada</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="exasmpleChk2" />
                                    <label class="form-check-label" for="exampleCheck1">Driver Record/Abstract/CVOR/NSC</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="exsampleChk2" />
                                    <label class="form-check-label" for="exampleCheck1">Address Verification (up to 10 years) - through Equifax Canada</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Driver Insurance History</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">SIN Validation – SIN#</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Consumer Credit Report - through Equifax Canada</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Check Driver License Status - through Check DL</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Terrorism/Global Clearance</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Other:</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Other:</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Other:</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Other:</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Employment References</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Employment Verification</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-8">
                                <ul>
                                    <li>Last Name at time of Employment:</li>
                                    <li>May we contact your current employer listed?</li>
                                    <li>If yes above, Name of current employer?</li>
                                </ul>
                            </div>


                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" />
                                    <label class="form-check-label" for="exampleCheck1">Education/Professional Verifications</label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-8">
                                <ul>
                                    <li>Last Name used during schooling/course(s):</li>
                                </ul>
                            </div>


                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">Applicant First Name : </div>
                            <div class="col-md-6">Last Name :  </div>

                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-12">Date of Birth :</div>







                            <div class="row">
                                <br />
                            </div>
                            <div class="col-md-6">Applicant Signature:_____________    </div>
                            <div class="col-md-6">Date :  </div>

                        </div>--%>



                                                        <br />
                                                        <br />
                                                        <div id="div2" runat="server" style="color: red;text-align:justify">
                                                            <div >
                                                                <strong>Declaration of Criminal Record</strong>
                                                            </div>
                                                            <div class="row">
                                                            </div>
                                                            <div id="declarationdiv" runat="server">
                                                                Please declare any previous offenses on your record below. Your declaration will be used to confirm the results from your background check. If you do not declare your previous offenses, your background check may not be processed successfully.
                                                            </div>
                                                        </div>

                                                        <div class="row">

                                                            <div class="col-md-3">
                                                                <label>Offence</label><br />
                                                                <input runat="server" name="txtOffence1" id="txtOffence1" type="text" class="form-control" />
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Date of Offence</label><br />
                                                                <input runat="server" name="txtDate1" id="txtDate1" type="text" readonly="readonly" />
                                                                <%--<input type="text" id="datepicker" />--%>
                                                                <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
                                                        <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
                                                        <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
                                                        <link rel="stylesheet" href="/resources/demos/style.css" />--%>
                                                                <script>
                                                                    $(function () {
                                                                        $("#datepicker").datepicker();

                                                                    });
                                                                    $(function () {
                                                                        $("#txtDate1").datepicker({ changeYear: true, yearRange: "1900:2030" });

                                                                    });
                                                                    $(function () {
                                                                        $("#txtDate2").datepicker({ changeYear: true, yearRange: "1900:2030" });

                                                                    });
                                                                    $(function () {
                                                                        $("#txtDate3").datepicker({ changeYear: true, yearRange: "1900:2030" });

                                                                    });
                                                                    //var datePickerOptions = {
                                                                    //    dateFormat: 'yy/m/d',
                                                                    //    firstDay: 1,
                                                                    //    changeMonth: true,
                                                                    //    changeYear: true
                                                                    //    // ...
                                                                    //}
                                                                    $(function () {


                                                                    });

                                                                </script>

                                                            </div>


                                                            <div class="col-md-3">
                                                                <label>Location</label><br />
                                                                <input runat="server" name="txtLocation1" id="txtLocation1" type="text" class="form-control" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Offence</label><br />
                                                                <input runat="server" name="txtOffence2" id="txtOffence2" type="text" class="form-control" />
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Date of Offence</label><br />
                                                                <input runat="server" name="txtDate2" id="txtDate2" type="text" readonly="readonly" />

                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Location</label><br />
                                                                <input runat="server" name="txtLocation2" id="txtLocation2" type="text" class="form-control" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                        </div>


                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Offence</label><br />
                                                                <input runat="server" name="txtOffence3" id="txtOffence3" type="text" class="form-control" />
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Date of Offence</label><br />
                                                                <input runat="server" name="txtDate3" id="txtDate3" type="text" readonly="readonly" />


                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Location</label><br />
                                                                <input runat="server" name="txtLocation3" id="txtLocation3" type="text" class="form-control" />
                                                            </div>
                                                        </div>


                                                        <div class="row">
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <%--                                                <div id="content">

                                                </div>--%>

                                                        <input type="hidden" id="hdndate2" runat="server" />
                                                        <input type="hidden" id="hdnoffence2" runat="server" />
                                                        <input type="hidden" id="hdnlocation2" runat="server" />

                                                        <input type="hidden" id="hdndate3" runat="server" />
                                                        <input type="hidden" id="hdnoffence3" runat="server" />
                                                        <input type="hidden" id="hdnlocation3" runat="server" />

                                                        <input type="hidden" id="hdndate4" runat="server" />
                                                        <input type="hidden" id="hdnoffence4" runat="server" />
                                                        <input type="hidden" id="hdnlocation4" runat="server" />

                                                        <input type="hidden" id="hdndate5" runat="server" />
                                                        <input type="hidden" id="hdnoffence5" runat="server" />
                                                        <input type="hidden" id="hdnlocation5" runat="server" />

                                                        <input type="hidden" id="hdndate6" runat="server" />
                                                        <input type="hidden" id="hdnoffence6" runat="server" />
                                                        <input type="hidden" id="hdnlocation6" runat="server" />

                                                        <input type="hidden" id="hdndate7" runat="server" />
                                                        <input type="hidden" id="hdnoffence7" runat="server" />
                                                        <input type="hidden" id="hdnlocation7" runat="server" />

                                                        <input type="hidden" id="hdndate8" runat="server" />
                                                        <input type="hidden" id="hdnoffence8" runat="server" />
                                                        <input type="hidden" id="hdnlocation8" runat="server" />

                                                        <input type="hidden" id="hdndate9" runat="server" />
                                                        <input type="hidden" id="hdnoffence9" runat="server" />
                                                        <input type="hidden" id="hdnlocation9" runat="server" />


                                                        <script>
                                                            var rowNum = 1;
                                                            var offencelabel1 = document.createElement("label");
                                                            offencelabel1.innerText = "Offence"

                                                            var offencelabel2 = document.createElement("label");
                                                            offencelabel2.innerText = "Offence"

                                                            var offencelabel3 = document.createElement("label");
                                                            offencelabel3.innerText = "Offence"

                                                            var offencelabel4 = document.createElement("label");
                                                            offencelabel4.innerText = "Offence"

                                                            var offencelabel5 = document.createElement("label");
                                                            offencelabel5.innerText = "Offence"

                                                            var offencelabel6 = document.createElement("label");
                                                            offencelabel6.innerText = "Offence"

                                                            var offencelabel7 = document.createElement("label");
                                                            offencelabel7.innerText = "Offence"

                                                            var offencelabel8 = document.createElement("label");
                                                            offencelabel8.innerText = "Offence"

                                                            var offencelabel9 = document.createElement("label");
                                                            offencelabel9.innerText = "Offence"

                                                            var datelabel1 = document.createElement("label");
                                                            datelabel1.innerHTML = "Date of Offence"

                                                            var datelabel2 = document.createElement("label");
                                                            datelabel2.innerHTML = "Date of Offence"

                                                            var datelabel3 = document.createElement("label");
                                                            datelabel3.innerHTML = "Date of Offence"


                                                            var datelabel4 = document.createElement("label");
                                                            datelabel4.innerHTML = "Date of Offence"

                                                            var datelabel5 = document.createElement("label");
                                                            datelabel5.innerHTML = "Date of Offence"

                                                            var datelabel6 = document.createElement("label");
                                                            datelabel6.innerHTML = "Date of Offence"

                                                            var datelabel7 = document.createElement("label");
                                                            datelabel7.innerHTML = "Date of Offence"

                                                            var datelabel8 = document.createElement("label");
                                                            datelabel8.innerHTML = "Date of Offence"

                                                            var datelabel9 = document.createElement("label");
                                                            datelabel9.innerHTML = "Date of Offence"


                                                            var breaker = document.createElement("div");
                                                            breaker.innerHTML = '<div class="row"><br/></div>';

                                                            var locationlabel1 = document.createElement("label");
                                                            locationlabel1.innerHTML = "Location"

                                                            var locationlabel2 = document.createElement("label");
                                                            locationlabel2.innerHTML = "Location"

                                                            var locationlabel3 = document.createElement("label");
                                                            locationlabel3.innerHTML = "Location"

                                                            var locationlabel4 = document.createElement("label");
                                                            locationlabel4.innerHTML = "Location"

                                                            var locationlabel5 = document.createElement("label");
                                                            locationlabel5.innerHTML = "Location"

                                                            var locationlabel6 = document.createElement("label");
                                                            locationlabel6.innerHTML = "Location"

                                                            var locationlabel7 = document.createElement("label");
                                                            locationlabel7.innerHTML = "Location"

                                                            var locationlabel8 = document.createElement("label");
                                                            locationlabel8.innerHTML = "Location"

                                                            var locationlabel9 = document.createElement("label");
                                                            locationlabel9.innerHTML = "Location"


                                                            function addRow() {

                                                                rowNum++;
                                                                //var i;
                                                                //for (i = 0; i < 7; i++) {
                                                                //    //eval("var offencelabel" + rowNum + "document.createElement(\"label\");offencelabel" + rowNum + ".innerText = \"Offence\"");
                                                                //    //eval("var datelabel" + rowNum + "document.createElement(\"label\");datelabel"+rowNum+".innerText = \"Date of Offence\"");

                                                                //    var datePickerOptions = {
                                                                //        dateFormat: 'yy/m/d',
                                                                //        firstDay: 1,
                                                                //        changeMonth: true,
                                                                //        changeYear: true,
                                                                //        // ...
                                                                //    }
                                                                //    var offence2 = document.createElement("input");
                                                                //    offence2.id = "txtOffence22" + rowNum;
                                                                //    offence2.type = "text";
                                                                //    offence2.className = "form-control";

                                                                //    var dateFrom = document.createElement("input");
                                                                //    dateFrom.id = "txtDateFrom"+rowNum;
                                                                //    dateFrom.type = "text";
                                                                //    dateFrom.style.width = "70px";
                                                                //    dateFrom.readonly = "readonly";

                                                                //    var location2 = document.createElement("input");
                                                                //    location2.id = "txtLocation22"+rowNum;
                                                                //    location2.type = "text";
                                                                //    location2.className = "form-control";


                                                                //    document.getElementById('content').appendChild(offencelabel1);
                                                                //    document.getElementById('content').appendChild(offence2);

                                                                //    document.getElementById('content').appendChild(datelabel1);
                                                                //    document.getElementById('content').appendChild(breaker);
                                                                //    document.getElementById('content').appendChild(dateFrom);

                                                                //    document.getElementById('content').appendChild(locationlabel1);
                                                                //    document.getElementById('content').appendChild(breaker);
                                                                //    document.getElementById('content').appendChild(location2);


                                                                //    $(dateFrom).datepicker(datePickerOptions);


                                                                //}

                                                                if (rowNum == 2) {

                                                                    var datePickerOptions = {
                                                                        dateFormat: 'yy/m/d',
                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                        
                                                                        // ...
                                                                    }

                                                                    var offence2 = document.createElement("input");
                                                                    offence2.id = "txtOffence22";
                                                                    offence2.type = "text";
                                                                    offence2.className = "form-control";

                                                                    var dateFrom = document.createElement("input");
                                                                    dateFrom.id = "txtDateFrom";
                                                                    dateFrom.type = "text";
                                                                    dateFrom.style.width = "70px";
                                                                    dateFrom.readonly = "readonly";

                                                                    var location2 = document.createElement("input");
                                                                    location2.id = "txtLocation22";
                                                                    location2.type = "text";
                                                                    location2.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel1);
                                                                    document.getElementById('content').appendChild(offence2);

                                                                    document.getElementById('content').appendChild(datelabel1);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel1);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location2);
                                                                    $("#content").append('<br/>');


                                                                    $(dateFrom).datepicker(datePickerOptions);
                                                                }
                                                                if (rowNum == 3) {
                                                                    var datePicker2Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence3 = document.createElement("input");
                                                                    offence3.id = "txtOffence33";
                                                                    offence3.type = "text";
                                                                    offence3.className = "form-control";

                                                                    var dateFrom2 = document.createElement("input");
                                                                    dateFrom2.id = "txtDateFrom2";
                                                                    dateFrom2.type = "text";
                                                                    dateFrom2.style.width = "70px";
                                                                    dateFrom2.readonly = "readonly";

                                                                    var location3 = document.createElement("input");
                                                                    location3.id = "txtLocation33";
                                                                    location3.type = "text";
                                                                    location3.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel2);
                                                                    document.getElementById('content').appendChild(offence3);

                                                                    document.getElementById('content').appendChild(datelabel2);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom2);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel2);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location3);
                                                                    $("#content").append('<br/>');

                                                                    $(dateFrom2).datepicker(datePicker2Options);
                                                                }

                                                                if (rowNum == 4) {
                                                                    var datePicker3Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence4 = document.createElement("input");
                                                                    offence4.id = "txtOffence44";
                                                                    offence4.type = "text";
                                                                    offence4.className = "form-control";

                                                                    var dateFrom3 = document.createElement("input");
                                                                    dateFrom3.id = "txtDateFrom3";
                                                                    dateFrom3.type = "text";
                                                                    dateFrom3.style.width = "70px";
                                                                    dateFrom3.readonly = "readonly";

                                                                    var location4 = document.createElement("input");
                                                                    location4.id = "txtLocation44";
                                                                    location4.type = "text";
                                                                    location4.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel3);
                                                                    document.getElementById('content').appendChild(offence4);

                                                                    document.getElementById('content').appendChild(datelabel3);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom3);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel3);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location4);
                                                                    $("#content").append('<br/>');

                                                                    $(dateFrom3).datepicker(datePicker3Options);
                                                                }
                                                                if (rowNum == 5) {
                                                                    var datePicker4Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence5 = document.createElement("input");
                                                                    offence5.id = "txtOffence55";
                                                                    offence5.type = "text";
                                                                    offence5.className = "form-control";

                                                                    var dateFrom4 = document.createElement("input");
                                                                    dateFrom4.id = "txtDateFrom4";
                                                                    dateFrom4.type = "text";
                                                                    dateFrom4.style.width = "70px";
                                                                    dateFrom4.readonly = "readonly";

                                                                    var location5 = document.createElement("input");
                                                                    location5.id = "txtLocation55";
                                                                    location5.type = "text";
                                                                    location5.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel4);
                                                                    document.getElementById('content').appendChild(offence5);

                                                                    document.getElementById('content').appendChild(datelabel4);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom4);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel4);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location5);
                                                                    $("#content").append('<br/>');

                                                                    $(dateFrom4).datepicker(datePicker4Options);
                                                                }
                                                                if (rowNum == 6) {
                                                                    var datePicker5Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence6 = document.createElement("input");
                                                                    offence6.id = "txtOffence66";
                                                                    offence6.type = "text";
                                                                    offence6.className = "form-control";

                                                                    var dateFrom5 = document.createElement("input");
                                                                    dateFrom5.id = "txtDateFrom5";
                                                                    dateFrom5.type = "text";
                                                                    dateFrom5.style.width = "70px";
                                                                    dateFrom5.readonly = "readonly";

                                                                    var location6 = document.createElement("input");
                                                                    location6.id = "txtLocation66";
                                                                    location6.type = "text";
                                                                    location6.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel5);
                                                                    document.getElementById('content').appendChild(offence6);

                                                                    document.getElementById('content').appendChild(datelabel5);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom5);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel5);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location6);
                                                                    $("#content").append('<br/>');


                                                                    $(dateFrom5).datepicker(datePicker5Options);
                                                                }
                                                                if (rowNum == 7) {
                                                                    var datePicker6Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence7 = document.createElement("input");
                                                                    offence7.id = "txtOffence77";
                                                                    offence7.type = "text";
                                                                    offence7.className = "form-control";

                                                                    var dateFrom6 = document.createElement("input");
                                                                    dateFrom6.id = "txtDateFrom6";
                                                                    dateFrom6.type = "text";
                                                                    dateFrom6.style.width = "70px";
                                                                    dateFrom6.readonly = "readonly";

                                                                    var location7 = document.createElement("input");
                                                                    location7.id = "txtLocation77";
                                                                    location7.type = "text";
                                                                    location7.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel6);
                                                                    document.getElementById('content').appendChild(offence7);

                                                                    document.getElementById('content').appendChild(datelabel6);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom6);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel6);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location7);
                                                                    $("#content").append('<br/>');


                                                                    $(dateFrom6).datepicker(datePicker6Options);
                                                                }
                                                                if (rowNum == 8) {
                                                                    var datePicker7Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence8 = document.createElement("input");
                                                                    offence8.id = "txtOffence88";
                                                                    offence8.type = "text";
                                                                    offence8.className = "form-control";

                                                                    var dateFrom7 = document.createElement("input");
                                                                    dateFrom7.id = "txtDateFrom7";
                                                                    dateFrom7.type = "text";
                                                                    dateFrom7.style.width = "70px";
                                                                    dateFrom7.readonly = "readonly";

                                                                    var location8 = document.createElement("input");
                                                                    location8.id = "txtLocation88";
                                                                    location8.type = "text";
                                                                    location8.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel7);
                                                                    document.getElementById('content').appendChild(offence8);

                                                                    document.getElementById('content').appendChild(datelabel7);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom7);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel7);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location8);
                                                                    $("#content").append('<br/>');


                                                                    $(dateFrom7).datepicker(datePicker7Options);
                                                                }
                                                                if (rowNum == 8) {
                                                                    var datePicker8Options = {

                                                                        firstDay: 1,
                                                                        changeMonth: true,
                                                                        changeYear: true,
                                                                        
                                                                    }

                                                                    var offence9 = document.createElement("input");
                                                                    offence9.id = "txtOffence99";
                                                                    offence9.type = "text";
                                                                    offence9.className = "form-control";

                                                                    var dateFrom8 = document.createElement("input");
                                                                    dateFrom8.id = "txtDateFrom8";
                                                                    dateFrom8.type = "text";
                                                                    dateFrom8.style.width = "70px";
                                                                    dateFrom8.readonly = "readonly";

                                                                    var location9 = document.createElement("input");
                                                                    location9.id = "txtLocation99";
                                                                    location9.type = "text";
                                                                    location9.className = "form-control";


                                                                    document.getElementById('content').appendChild(offencelabel8);
                                                                    document.getElementById('content').appendChild(offence9);

                                                                    document.getElementById('content').appendChild(datelabel8);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(dateFrom8);
                                                                    $("#content").append('<br/>');

                                                                    document.getElementById('content').appendChild(locationlabel8);
                                                                    $("#content").append('<br/>');
                                                                    document.getElementById('content').appendChild(location9);
                                                                    $("#content").append('<br/>');

                                                                    $(dateFrom8).datepicker(datePicker8Options);
                                                                }



                                                            }







                                                        </script>

                                                        <%--                                                <div id="content">

                                                </div>

                                                <div>
                                                    <button id="btnAddOffence" type="button" class="btn btn-light" onclick="addRow()">Add Offence</button>
                                                </div>
                                                <script>
                                                    var rowNum=1;
                                                    function addRow() {
                                                        rowNum++;
                                                        var div = document.createElement('div');

                                                        div.className = 'row';

                                                        div.innerHTML =
                                                            '                                                <div class="row">\
                                                    <div class="col-md-3">\
                                                        <label>Offence</label><br />\
                                                        <input runat="server"  type="text" class="form-control" />\
                                                    </div>\
                                                    <div class="col-md-3">\
                                                        <label>Date of Offence</label><br />\
                                                        <input runat="server" name="" type="text"  readonly="readonly"/></div>\
                                                    <div class="col-md-3">\
                                                        <label>Location</label><br />\
                                                        <input runat="server" name=""  type="text" class="form-control" />\
                                                    </div>\
                                                </div>';

                                                        document.getElementById('content').appendChild(div);
                                                    }
                                                </script>--%>
                                                    </div>

                                                    <div>
                                                        <button id="btnAddOffence" type="button" class="btn btn-light" onclick="addRow()">Add Offence</button>
                                                    </div>

                                                </div>





                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-primary btn-lg btn-block" data-dismiss="modal" id="lbl19" runat="server">I agree </button>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div id="divthengive" style="display:inline;" runat="server">then give your consent below</div>
                        </div>






                        <div class="myclass">



<%--                            <div>
                                <div class="row">
                                    <div class="col-md-6" id="lbl6" runat="server">Date : </div>
                                    <label id="lblDate" runat="server"></label>
                                    <div class="col-md-6" id="lbl7" runat="server">Applicant Signature:    </div>


                                </div>
                            </div>--%>

                            <div >
                                <asp:WebSignature  ID="WebSignature1" Width="250" height="100"   runat="server"  bShowSignHereSticker="False" bShowPenTools="False"  WelcomeMessage="Please sign above using full signature.">
                                </asp:WebSignature>
                            </div>
                        </div>




                        </section>
                    </div>
                    <br />

                    <div class="row">
                        <div  style="align-content: center;padding:20px;width: 100%;">

<%--                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="customCheck1">
                                <label class="custom-control-label" for="customCheck1">Check this custom checkbox</label>
                            </div>--%>

                            <div style="display:inline;text-align:center" >

                                <%--<label class="paragraphtxt" style="font-weight:normal;margin-left:-4px;text-align:justify;padding:12px" for="exampleCheck1" id="lbl8" runat="server">--%>
                                    <input type="checkbox" id="chkAgree" name="chkAgree" runat="server" style="margin-left:4px" />
                                    <%--<label id="labelcheckbox1" runat="server" class="paragraphtxt" style="font-weight:normal;margin-left:-4px;text-align:justify;padding:12px">I agree that I have read the consent form</label>--%>
                                    <span id="labelcheckbox1" runat="server" class="paragraphtxt" style="font-weight:normal;margin-left:-4px;text-align:center;">I agree that I have read the consent form</span>
                                <%--</label>--%>

                            </div>
                            <br />
                            <div id="divMVRCheck" runat="server" style="display:inline-block;text-align:center">
                                <%--<label style="display: inline-block;font-weight:normal;margin-left:-4px;text-align:justify;padding:12px" class="paragraphtxt"  for="exampleCheck1" id="lbl9" runat="server">--%>
                                    <input type="checkbox" id="chkConsent" name="chkConsent" runat="server" style="display: inline-block;margin-left:4px" />
                                <span id="labelchkbox2" runat="server" class="paragraphtxt" style="font-weight:normal;margin-left:-4px;text-align:justify;padding:12px">By checking this box you are providing your electronic consent to ISB Canada to affix the signature collected here to the Provincial Driver Abstract consent form.</span>
                                <%--</label>--%>
                                <label style="display: inline-block;font-weight:normal" class="paragraphtxt"  for="exampleCheck1" id="lbl9a" runat="server"></label>


                            </div>
                             <br /><br />
                            <div style="text-align:center">
                            <%--class="btn btn-success form-submit"--%>
                            <asp:Button ID="Button1" runat="server" Text="Click Here to Proceed" class="btn btn-success " style="width:200px;font-family:Roboto;background-color:#2FC7A0;border-radius:20px;text-align:center" OnClick="Button1_Click" OnClientClick="proceed();" />

                                </div>
                            <%--hello--%>
                            <script>
                                var rowNum = 1;
                                function proceed() {
                                    //alert('Hi');
                                    if ($('#WebSignature1').length > 0 && ($('#WebSignature1').attr('isvalid') == true || $('#WebSignature1').attr('isvalid') == "true")) {
                                        $('#Button1').val('Please wait...').css({ pointerEvents: 'none', opacity: '0.5' });
                                    }
                                    var dateval1 = $('#txtDateFrom').val();
                                    var offenceval1 = $('#txtOffence22').val();
                                    var locationval1 = $('#txtLocation22').val();

                                    var dateval2 = $('#txtDateFrom2').val();
                                    var offenceval2 = $('#txtOffence33').val();
                                    var locationval2 = $('#txtLocation33').val();

                                    var dateval3 = $('#txtDateFrom3').val();
                                    var offenceval3 = $('#txtOffence44').val();
                                    var locationval3 = $('#txtLocation44').val();

                                    var dateval4 = $('#txtDateFrom4').val();
                                    var offenceval4 = $('#txtOffence55').val();
                                    var locationval4 = $('#txtLocation55').val();

                                    var dateval5 = $('#txtDateFrom5').val();
                                    var offenceval5 = $('#txtOffence66').val();
                                    var locationval5 = $('#txtLocation66').val();

                                    var dateval6 = $('#txtDateFrom6').val();
                                    var offenceval6 = $('#txtOffence77').val();
                                    var locationval6 = $('#txtLocation77').val();

                                    var dateval7 = $('#txtDateFrom7').val();
                                    var offenceval7 = $('#txtOffence88').val();
                                    var locationval7 = $('#txtLocation88').val();

                                    var dateval8 = $('#txtDateFrom8').val();
                                    var offenceval8 = $('#txtOffence99').val();
                                    var locationval8 = $('#txtLocation99').val();




                                    //alert(val1);
                                    //$('#foo').val(val1);
                                    //alert($('#foo').val());
                                    $('#hdndate2').val(dateval1);
                                    $('#hdnoffence2').val(offenceval1);
                                    $('#hdnlocation2').val(locationval1);

                                    $('#hdndate3').val(dateval2);
                                    $('#hdnoffence3').val(offenceval2);
                                    $('#hdnlocation3').val(locationval2);

                                    $('#hdndate4').val(dateval3);
                                    $('#hdnoffence4').val(offenceval3);
                                    $('#hdnlocation4').val(locationval3);

                                    $('#hdndate5').val(dateval4);
                                    $('#hdnoffence5').val(offenceval4);
                                    $('#hdnlocation5').val(locationval4);

                                    $('#hdndate6').val(dateval5);
                                    $('#hdnoffence6').val(offenceval5);
                                    $('#hdnlocation6').val(locationval5);

                                    $('#hdndate7').val(dateval6);
                                    $('#hdnoffence7').val(offenceval6);
                                    $('#hdnlocation7').val(locationval6);

                                    $('#hdndate8').val(dateval7);
                                    $('#hdnoffence8').val(offenceval7);
                                    $('#hdnlocation8').val(locationval7);

                                    $('#hdndate9').val(dateval8);
                                    $('#hdnoffence9').val(offenceval8);
                                    $('#hdnlocation9').val(locationval8);



                                    //var Agree = document.getElementById("chkAgree");
                                    //var Checked = document.getElementById("chkAgree");


                                    //if (!(Agree.checked == true && Checked == true))
                                    //{
                                    //    alert("Please check the box(es) to confirm that you have read the terms and conditions");
                                    //}


                                }
                            </script>
                            <br />

                            <%--<button type="button" class="btn btn-primary btn-lg btn-block">Block level button</button>--%>
                            <%--<input type="submit" name="btnSubmit" value="Click Here to Proceed" id="btnSubmit" class="btn btn-success form-submit" runat="server" OnClick="SubmitForm" />--%>
                            <div id="technicaldifficulties" runat="server" style="text-align: center">
                                If you are experiencing technical difficulties please call us at 1-800-295-5732
                            </div>
                        </div>


                    </div>
                    <%--<div class="row" >
                        <img src="https://infosearchsite.com/MID/Images/rotatedevice.gif" />
                    </div>--%>
<%--                    <div class="row">
                        <div class="col-mg-12" style="font-weight: bold" id="lblfooter" runat="server">
                            If you have any questions regarding this consent form, please call 905-875-6828/1-800-609-6552 and ask for the EBS team.
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-10" style="text-align: center">
                            <asp:Label id="lblErrors" runat="server" />
                        </div>

                    </div>
                </div>
                <br />
                <div id="othermessage" runat="server" style="width:80vw;text-align:center;background-color:white" >

                </div>


            </div>
                 </div>
            
            <div>
               <asp:Label id="lblAlreadyUsed" runat="server" style="color:red" />
            </div>
            <div >
                <br />
                <br />
                <br />
                <div style="background-color: gray; color: white; font-size: 12px; text-align: center">
                    <br />
            <div id="footer" runat="server">Copyright © 2018 ISB Canada, All Rights Reserved.-</div>
                    
                    <br />
                    <br />
                </div>
            </div>
        </form>
    </div>
<%--    <div class="footer-head-container">
        <footer class="container">
            <div class="region region-footer-head">
                <section class="block block-block clearfix" id="block-block-31">
                    <div>
                        8160 Parkhill Drive, Milton, Ontario, L8T 5V7, Canada T: 1.866.416.0006, F: 
905.875.4993
                    </div>
                </section>
            </div>
        </footer>
    </div>
    <div class="footer-container">
        <footer class="footer container">
            <div class="region region-footer-head">
                <div class="region region-footer">
                    <section class="block block-block clearfix" id="block-block-3">
                        <div>
                            <a href="mailto:info@isbc.ca">info@isbc.ca</a><br>
                            © Copyright 2014 ISB 
Canada | All Rights Reserved | Accessible Customer 
Service
                        </div>
                    </section>
                </div>
            </div>
        </footer>
    </div>--%>

        </div>


    <div class="pac-container pac-logo" style="display: none; width: 846px; position: absolute; left: 248px; top: 482px;"></div>
</body>



</html>


