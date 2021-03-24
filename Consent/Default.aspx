<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html >
    
<head id="Head1">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Electronic Identification Verification - ISB Canada
    </title>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!--
        html {
        }

        body {
            margin: 0px;
            font-family: arial,sans-serif;
            font-size: 12px;
            color: #333333;
            background-color: #eeeeee;
            background-image: url('images/bk_dots.gif');
        }

        .displayTable {
            border-top: 1px solid #bbbbbb;
            border-left: 1px solid #bbbbbb;
        }

            .displayTable td {
                border-right: 1px solid #bbbbbb;
                border-bottom: 1px solid #bbbbbb;
            }

        .TableBorder {
            border: 1px solid #bbbbbb;
        }

        .loginBox {
            background-color: #ffffff;
            border: 1px solid #cccccc;
            margin-left: auto;
            margin-right: auto;
            margin-top: 5px;
            width: auto;
        }

            .loginBox input[type=text] {
                box-sizing: border-box;
                border: 0px solid #555;
                outline: none;
            }

            .loginBox input[type=button] {
                padding: 12px 20px;
                margin: 8px 0;
                box-sizing: border-box;
                border: 2px solid #555;
                outline: none;
            }

        .loginBox2 input[type=text] {
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #555;
            outline: none;
        }

        .submitButton {
            padding: 4px;
            font-size: 20px;
            border: 1px solid #cccccc;
        }

        .shadow {
            box-shadow: 0 0px 3px #dddddd;
            -webkit-box-shadow: 0 0px 3px #dddddd;
            -moz-box-shadow: 0 0px 3px #dddddd;
        }

        .shadow2 {
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #555;
            outline: none;
        }

        .leftColumn {
            background-color: #ffffff;
            border-right: 1px solid #cccccc;
        }

        .title {
            font-size: 21px;
            color: #016699;
        }

        .rating td {
            text-align: center;
            width: 30px;
        }

        .radioButton {
            border: 0px solid #555;
            border-color: #fff;
            border-style: none;
            border: none;
        }
        /* DivTable.com */
        .divTable {
            display: table;
            width: 100%;
        }

        .divTableRow {
            display: table-row;
            
        }

        .divTableHeading {
            background-color: #EEE;
            display: table-header-group;
        }

        .divTableCell, .divTableHead {
            border: 1px solid #999999;
            display: table-cell;
            padding: 3px 10px;
            width:50%;
        }

        .divTableHeading {
            background-color: #EEE;
            display: table-header-group;
            font-weight: bold;
        }

        .divTableFoot {
            background-color: #EEE;
            display: table-footer-group;
            font-weight: bold;
        }

        .divTableBody {
            display: table-row-group;
        }
        /*.margin-three {
            margin-right: 25px;
        }*/

        /*.three {
            width: 200px;
            float: left;
        }*/

        /*input[type="text"], select {
            border: solid 1px #ccc;
            border-radius: 4px;
            height: 25px;
            width: 100%;
            line-height: 20px;
            font-size: 14px;
            -webkit-appearance: none;
            -moz-transition: all .3s linear;            
            -o-transition: all .3s linear;
            -webkit-transition: all .3s linear;
            transition: all .3s linear;
            padding-left: 10px;
        }*/
        -->
    </style>

</head>
<%--<head runat="server">
    <title></title>
</head>--%>
    <body>
        <form id="form1" runat="server">


<%--<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js">
     //window.onload = function(){  alert('test'); }  
<%--//<![CDATA[
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
}--%>
<%--    debugger
    $(document).ready(function () {     
 alert('Test');  
});--%>
<%--//]]>--%>
<%--</script>--%>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
        <script>
            //window.onload = function () {
            //    if (!(/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent))) {
            //        alert("Not Mobile Browser");
            //        //window.location.replace("http://stackoverflow.com");
            //        window.location.href = 'http://stackoverflow.com';
            //    }
            //}            
        </script>



    <div>
            <div id="verifierThanks" class="loginBox shadow" style="text-align: center">	    

			    
                <div style="text-align:center"><h2><u>::CRIMINAL RECORD VERIFICATION::</u></h2><h3><br />Informed Consent Form</h3></div>
                <br>
                
                <div >
                    <div >
                        <div >
                            <div >
                                <div>
                                    <div >
                                        <div >
                                            <div style="text-align:center"><strong>A. Personal Information<br /></strong><br /></div>
                                        </div>

<%--                                        <div class="three margin-three">
                                            <span id="Label4">FIRST NAME:</span>
                                            <input name="TxtBox1" type="text" id="TxtBox1">
                                            <span id="RequiredFieldValidator1" style="color: Red; font-size: Small; font-weight: bold; visibility: hidden;">*</span>
                                        </div>--%>



                                        <div class="divTable">
                                            <div class="divTableBody">
                                                <div class="divTableRow">
                                                    <div class="divTableCell" style="text-align:right">Surname(last name)</div>
                                                    <div class="divTableCell"  style="text-align:left"><input id="TetBox1" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox1" type="text" value="" /></div>
                                                </div>
                                                <div class="divTableRow">
                                                    <div class="divTableCell"  style="text-align:right">Given Name(s)</div>
                                                    <div class="divTableCell" style="text-align:left"><input id="TetBox3" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox3" type="text" value="" /></div>
                                                </div>
                                                <div class="divTableRow">
                                                    <div class="divTableCell" style="text-align:right">Middle    Name(s)</div>
                                                    <div class="divTableCell" style="text-align:left"> <input id="TetBox17" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox17" type="text" /></div>
                                                </div>
                                                <div class="divTableRow">
                                                    <div class="divTableCell" style="text-align:right">Surname(last name) at birth</div>
                                                    <div class="divTableCell" style="text-align:left"><input id="TetBox18" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox18" type="text" /></div>
                                                </div>
                                                <div class="divTableRow">
                                                    <div class="divTableCell" style="text-align:right">Former  names(s)</div>
                                                    <div class="divTableCell" style="text-align:left"><input id="TetBox19" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox19" type="text" /></div>
                                                </div>
                                            </div>
                                        </div>










                                        <div>
                                                <div >
                                            <div >Surname(last name)</div>
                                                    <input id="TextBox1" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox1" type="text" value="" /></div>
                                            <br />
                                            <div class="rTableCell">Given Name(s)<input id="TextBox3" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox3" type="text" value="" /></div>
                                            <br />
                                            <div class="rTableCell">Middle    Name(s)
                                                <input id="TextBox17" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox17" type="text" /></div>
                                            <br />

                                        </div>
                                        <br />
                                        <div>
                                            <div>Surname(last name) at birth <input id="TextBox18" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox18" type="text" /></div>
                                            <br />
                                            <div>Former  names(s)<input id="TextBox19" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox19" type="text" /></div>
                                            <br />
                                            <div>Place of birth(City,Province/State,Country)<input id="TextBox20" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox20" type="text" /></div>
                                            <br />
                                        </div>



                                        <div>
                                            <div>
                                                Sex
                                                <select id="DropDownList1" name="DropDownList1">
                                                    <option value="Male">Male</option>
                                                    <option value="Female">Female</option>
                                                </select>
                                            </div>
                                            <div>Date of Birth<input type="date" name="bday"></div>
                                        </div>

                                        <div>
                                            <div>Phone  number(s)<input id="TextBox11" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox11" type="text" value="" /></div><br />
                                            <div>Email Address<input id="TextBox12" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox12" type="text" value="" /></div><br />
                                        </div>

                                        <div>
                                            <div >Current  Home Address</div>
                                        </div>
                                        <div >
                                            <div>Number<input id="TextBox13" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox13" type="text" /></div>
                                            <div>Street<input id="TextBox14" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox14" type="text" value="" /></div>
                                            <div>Apartment<input id="TextBox15" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox15" type="text" /></div>
                                            <div>City<input id="TextBox16" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox16" type="text" value="" /></div>
                                        </div>
                                        <br />
                                        <div>
                                            <div>Province/Territory/State
                                                    <select id="DropDownList2" name="DropDownList2">
                                                        <option value="AB">AB</option>
                                                        <option value="BC">BC</option>
                                                        <option value="MB">MB</option>
                                                        <option value="NB">NB</option>
                                                        <option value="NL">NL</option>
                                                        <option value="NT">NT</option>
                                                        <option value="NS">NS</option>
                                                        <option value="NU">NU</option>
                                                        <option value="ON">ON</option>
                                                        <option value="PE">PE</option>
                                                        <option value="QC">QC</option>
                                                        <option value="SK">SK</option>
                                                        <option value="YT">YT</option>
                                                        <option value="AL">AL</option>
                                                        <option value="AK">AK</option>
                                                        <option value="AZ">AZ</option>
                                                        <option value="AR">AR</option>
                                                        <option value="CA">CA</option>
                                                        <option value="CO">CO</option>
                                                        <option value="CT">CT</option>
                                                        <option value="DE">DE</option>
                                                        <option value="DC">DC</option>
                                                        <option value="FL">FL</option>
                                                        <option value="GA">GA</option>
                                                        <option value="HI">HI</option>
                                                        <option value="ID">ID</option>
                                                        <option value="IL">IL</option>
                                                        <option value="IN">IN</option>
                                                        <option value="IA">IA</option>
                                                        <option value="KS">KS</option>
                                                        <option value="KY">KY</option>
                                                        <option value="LA">LA</option>
                                                        <option value="ME">ME</option>
                                                        <option value="MD">MD</option>
                                                        <option value="MA">MA</option>
                                                        <option value="MI">MI</option>
                                                        <option value="MN">MN</option>
                                                        <option value="MS">MS</option>
                                                        <option value="MO">MO</option>
                                                        <option value="MT">MT</option>
                                                        <option value="NE">NE</option>
                                                        <option value="NV">NV</option>
                                                        <option value="NH">NH</option>
                                                        <option value="NJ">NJ</option>
                                                        <option value="NM">NM</option>
                                                        <option value="NY">NY</option>
                                                        <option value="NC">NC</option>
                                                        <option value="ND">ND</option>
                                                        <option value="OH">OH</option>
                                                        <option value="OK">OK</option>
                                                        <option value="OR">OR</option>
                                                        <option value="PA">PA</option>
                                                        <option value="RI">RI</option>
                                                        <option value="SC">SC</option>
                                                        <option value="SD">SD</option>
                                                        <option value="TN">TN</option>
                                                        <option value="TX">TX</option>
                                                        <option value="UT">UT</option>

                                                    </select>

                                            </div>
                                            <div>Postal/Zip<input id="TextBx30" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox30" type="text" value="" /></div>
                                        </div>
                                        <br />
                                        <div>

                                            <div><strong>Previous Address(es) Within the Last 5 years (attach additional page if necessary) </strong></div>
                                        </div>
                                        <div >
                                            <div>Number<input id="TextBox31" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox31" type="text" /></div>
                                            <div>Street<input id="TextBox32" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox32" type="text" /></div>
                                            <div>Apartment<input id="TextBox33" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox33" type="text" /></div>
                                            <div>City<input id="TextBox34" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox34" type="text" /></div>
                                        </div>
                                        <div>
                                            <div>
                                                Province/Territory/State
                                                    <select id="DropDownList2" name="DropDownList2">
                                                        <option value="AB">AB</option>
                                                        <option value="BC">BC</option>
                                                        <option value="MB">MB</option>
                                                        <option value="NB">NB</option>
                                                        <option value="NL">NL</option>
                                                        <option value="NT">NT</option>
                                                        <option value="NS">NS</option>
                                                        <option value="NU">NU</option>
                                                        <option value="ON">ON</option>
                                                        <option value="PE">PE</option>
                                                        <option value="QC">QC</option>
                                                        <option value="SK">SK</option>
                                                        <option value="YT">YT</option>
                                                        <option value="AL">AL</option>
                                                        <option value="AK">AK</option>
                                                        <option value="AZ">AZ</option>
                                                        <option value="AR">AR</option>
                                                        <option value="CA">CA</option>
                                                        <option value="CO">CO</option>
                                                        <option value="CT">CT</option>
                                                        <option value="DE">DE</option>
                                                        <option value="DC">DC</option>
                                                        <option value="FL">FL</option>
                                                        <option value="GA">GA</option>
                                                        <option value="HI">HI</option>
                                                        <option value="ID">ID</option>
                                                        <option value="IL">IL</option>
                                                        <option value="IN">IN</option>
                                                        <option value="IA">IA</option>
                                                        <option value="KS">KS</option>
                                                        <option value="KY">KY</option>
                                                        <option value="LA">LA</option>
                                                        <option value="ME">ME</option>
                                                        <option value="MD">MD</option>
                                                        <option value="MA">MA</option>
                                                        <option value="MI">MI</option>
                                                        <option value="MN">MN</option>
                                                        <option value="MS">MS</option>
                                                        <option value="MO">MO</option>
                                                        <option value="MT">MT</option>
                                                        <option value="NE">NE</option>
                                                        <option value="NV">NV</option>
                                                        <option value="NH">NH</option>
                                                        <option value="NJ">NJ</option>
                                                        <option value="NM">NM</option>
                                                        <option value="NY">NY</option>
                                                        <option value="NC">NC</option>
                                                        <option value="ND">ND</option>
                                                        <option value="OH">OH</option>
                                                        <option value="OK">OK</option>
                                                        <option value="OR">OR</option>
                                                        <option value="PA">PA</option>
                                                        <option value="RI">RI</option>
                                                        <option value="SC">SC</option>
                                                        <option value="SD">SD</option>
                                                        <option value="TN">TN</option>
                                                        <option value="TX">TX</option>
                                                        <option value="UT">UT</option>

                                                    </select>

                                            </div>
                                            <div >Postal/Zip<input id="TexBox3" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox30" type="text" value="" /></div>
                                        </div>
                                        <br />
                                        <div >
                                            <div><strong>B.Reason for the Criminal Record Verification</strong></div>
                                        </div>
                                        <div>
                                            <div >Reason for Request (example Employment - Employer - Job Title):</div>
                                        </div>
                                        <div >
                                            <div>Organization Requesting Search : </div>
                                        </div>
                                        <div>
                                            <div >Contact Name:</div>
                                            <div >Contact Phone</div>
                                        </div>
                                        <br />
                                        <div>
                                            <div ><strong>C.Informed Consent</strong></div>
                                        </div>
                                        <div >
                                            <div >SEARCH AUTHORIZATION - I HEREBY CONSENT TO THE SEARCH OF the RCMP National Repository of Criminal Records based on the name(s), date of birth and where used,the declared criminal record history provided by myself. I understand that this verification of the National Repository of Criminal Records is not being confirmed by fingerprint comparison which is the only true means by which to confirm if a criminal record exists in the National Repository of Criminal Records.</div>
                                        </div>
                                        <br />
                                        <div >
                                            <div >POLICE INFORMATION SYSTEM(S)-1 HEREBY CONSENT TO THE SEARCH OF police information systems, as part of a Police Information Check, which will consist of a search of the following systems (check applicable):</div>
                                        </div>
                                        <br />
                                        <div >
                                            <div>
                                                <input checked="checked" disabled="disabled" type="checkbox" />CPIC</div>
                                            <div>
                                                <input checked="checked" disabled="disabled" type="checkbox" />Police</div>
                                        </div>
                                        <div>
                                            <div><input checked="checked" disabled="disabled" type="checkbox" />OTHER:</div>
                                            
                                        </div>
                                        <br />
                                        <div >
                                            <div >to ISB Canada/Label,</div>
                                            <div >located in Label,</div>
                                        </div>
                                        <br />
                                        <div >
                                            <div >Company Name</div>
                                            <div >City and Country</div>
                                        </div>
                                        <div>
                                            <div>I hereby release and forever discharge all members and employees of the processing Police Service and the Royal Canadian Mounted Police from any and all actions, claims and demands for damages, loss or injury howsoever arising which may hereafter be sustained by myself as a result of the disclosure of information by the</div>
                                        </div>

                                        <div >
                                            <div ><strong>D.Identification  Verification &emsp;<input checked="checked" disabled="disabled" type="checkbox" />Electronic Identity Verification</strong></div>                                    
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div >
                            <div></div>
                            <div>
                                <div >
                                    <div >
                                        <div >
                                            <div><strong>CRIMINAL
                                                <br />
                                                Informed </strong></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Declaration</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">This form</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Surname(last name)</div>
                                            <div class="rTableCell">Given name(s)</div>
                                            <div class="rTableCell">Date of Birth&lt;isb_sex&lt; span=""&gt;</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Information is collected</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">A Declaration of Criminal .</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Applicants.</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Do not declare g:</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <ul>
                                                    <li>A conviction ;</li>
                                                    <li>A conviction ;</li>
                                                    <li>An Absolute;</li>
                                                    <li>An offence ;</li>
                                                    <li>An;</li>
                                                    <li>Any .</li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell"><strong>Note that ad.</strong></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Offence</div>
                                            <div class="rTableCell">Date of Sentence</div>
                                            <div class="rTableCell">Location</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="TextBox2" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox2" type="text" /></div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell">
                                                <input id="TextBox4" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox4" type="text" /></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="TextBox5" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox5" type="text" /></div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell">
                                                <input id="TextBox6" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox6" type="text" /></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="TextBox7" style="background-color: whitesmoke; border: 1px solid #E0E0E0;" name="TextBox7" type="text" /></div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell">
                                                <input id="TextBox8" style="border: 1px solid #E0E0E0;" name="TextBox8" type="text" /></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell"></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <hr />
                                            </div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell">
                                                <hr />
                                            </div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Signature of Applicant</div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell">Date(YYYY-MM-DD)2018-6-27</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Verified By:</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell"><u>Cobourg Poliec Services</u></div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell"></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Name of Police Agency Employee</div>
                                            <div class="rTableCell"></div>
                                            <div class="rTableCell"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="rTableRow">
                            <div class="rTableCell"></div>
                            <div class="rTableCell">
                                <div class="rTable">
                                    <div class="rTableBody">
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <img src="https://infosearchsite.com/search/images/isbLogoMain.jpg" alt="" /></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell"><strong>Consent for the release of personal information</strong></div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">I Label, have applied for employment / contract work with Label  (The Company).</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">I understand that as</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">I hereby authorize</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">I understand that</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">I hereby release and forever</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox2" name="CheckBox2" type="checkbox" />Fraud Alert - <em>through Equifax Canada</em></div>
                                            <div class="rTableCell">
                                                <input id="CheckBox1" name="CheckBox1" type="checkbox" />Driver Record/Abstract/CVOR/NSC</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox3" name="CheckBox3" type="checkbox" />Address Verification (up to 10 years) - <em>through Equifax Canada</em></div>
                                            <div class="rTableCell">
                                                <input id="CheckBox4" name="CheckBox4" type="checkbox" />Driver Insurance History</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox5" name="CheckBox5" type="checkbox" />SIN Validation – SIN#</div>
                                            <div class="rTableCell">
                                                <input id="CheckBox6" name="CheckBox6" type="checkbox" />Consumer Credit Report - through Equifax Canada</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox7" name="CheckBox7" type="checkbox" />Check Driver License Status - <em>through Check DL</em></div>
                                            <div class="rTableCell">
                                                <input id="CheckBox8" name="CheckBox8" type="checkbox" />Terrorism/Global Clearance</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox9" name="CheckBox9" type="checkbox" />Other:</div>
                                            <div class="rTableCell">
                                                <input id="CheckBox10" name="CheckBox10" type="checkbox" />Other:</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox11" name="CheckBox11" type="checkbox" />Other:</div>
                                            <div class="rTableCell">
                                                <input id="CheckBox12" name="CheckBox12" type="checkbox" />Other:</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox13" name="CheckBox13" type="checkbox" />Employment References</div>
                                            <div class="rTableCell">
                                                <input id="CheckBox14" name="CheckBox14" type="checkbox" />Employment Verification</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <ul>
                                                    <li>Last:</li>
                                                    <li>May we contact your current employer listed?</li>
                                                    <li>If yes above, Name of current employer?</li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <input id="CheckBox15" name="CheckBox15" type="checkbox" />Education/Professional Verifications</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">
                                                <ul>
                                                    <li>Last Name used during schooling/course(s):</li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Applicant First Name : JEN</div>
                                            <div class="rTableCell">Last Name : BATH</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Date of Birth : 1950-04-05</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell">Applicant Signature:_____________</div>
                                            <div class="rTableCell">Date : 11:58:19 AM</div>
                                        </div>
                                        <div class="rTableRow">
                                            <div class="rTableCell"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="rTableRow">
                            <div class="rTableCell"></div>
                            <div class="rTableCell"></div>
                        </div>
                    </div>
                </div>   
                

                    <div class="loginBox shadow">
                    <div ><input id="eIDChkbox" type="checkbox" name="eIDChkbox"></div><span id="lblagree" style="font-weight:bold;">By checking this box, you are giving your digital signature and certify that you agree and consent to the terms and release of information listed on this consent form.You also understand that your credit file will be reviewed for the purpose of verifying your identity</span>
                    <div style="text-align:center"><span id="lbleither">---OR---</span></div>
                    <div ><input id="chkbox8" type="checkbox" name="chkbox8"></div><span id="lbldonotagree" style="font-weight:bold;">I do not agree or consent to the above.</span>
                   </div>
                
                <div>                
                <strong>
                    <span id="Label18">If you have any questions regarding this consent form, please call 905-875-6828/1-800-609-6552 and ask for the EBS team.</span></strong>
                </div>
                
                
                             
                
                <br><br>
                <span id="eidmessage" style="color:Red;font-family:Arial;font-size:Larger;font-weight:bold;">Vous n’aurez qu’une seule occasion de remplir ce questionnaire.  Dès que vous aurez commencé, vous ne pourrez fermer la fenêtre. <br>Assurez-vous d’avoir en main tous les renseignements requis avant de cliquer sur Exécuter.</span>
                 <br><br>
                 <div style="text-align:center">
                     <asp:Button ID="Button1" runat="server" Text="Button" type="submit" OnClick="Button1_Click" />
                 <%--<input type="submit" name="eIDsubmit" value="Click Here To Proceed" onclick="ConfirmAction();" id="eIDsubmit" style="background-color:buttonface;border-color:Black;border-width:2px;border-style:solid;font-weight:bold;"><br><br>--%>
                 </div>
                 
                     <span id="Label19" style="font-size:12px">eIDverifier™ is a Trademark of Equifax</span>
                                                
			</div>
			
			
			
			
    </div>
     

        </form>


</body>

</html>
