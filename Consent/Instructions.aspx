<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Instructions.aspx.cs" Inherits="Instructions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructions</title>
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://infosearchsite.com/MID/css/iPhone.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>





</head>
<body >
    <form id="form1" runat="server"   >
        

      


<%--        <div id="divNotice" class="animated fadeInUp" style="display: block;">
            <div class="mt60">
                <h1 style="font-family: Arial;" id="H1" runat="server">Instructions for DL</h1>
                <hr class="longLine hr" />
                <div class="consentDiv" style="font-family: Arial;">
                    <ol>
                        <li id="Li1" runat="server">Hold your phone still and in portrait mode </li>
                        <li id="Li2" runat="server">Make sure to place your ID on a flat contrast background (no white or black background) </li>
                        <li id="Li3" runat="server">Make sure you are in a glare-free environment. Center the ID and make sure all 4 corners are in the camera frame</li>

                    </ol>
                </div>
            </div>
            <div class="mt60">
                <h1 style="font-family: Arial;" id="lbl22" runat="server">Instructions for DL</h1>
                <hr class="longLine hr"/>  
                <div class="consentDiv" style="font-family:Arial;">
                    <ol>
                        <li id="lbl23" runat="server">Hold your phone still and in portrait mode </li>
                        <li id="lbl24" runat="server">Make sure to place your ID on a flat contrast background (no white or black background) </li>
                        <li id="lbl25" runat="server">Make sure you are in a glare-free environment. Center the ID and make sure all 4 corners are in the camera frame</li>

                    </ol>
                </div> 
            </div>
            <hr class="longLine hr"/>
            <div class="mt60">
                <h1 style="font-family: Arial;" id="lbl26" runat="server">Instructions for selfie</h1>
                <hr class="longLine hr" />
                <div class="consentDiv" style="font-family: Arial;">
                    <ol>
                        <li id="lbl27" runat="server">Do not wear any headgear.  </li>
                        <li id="lbl28" runat="server">Make sure you are in a glare-free environment  </li>
                        <li id="lbl29" runat="server">Remove any eyeglasses or sunglasses. </li>
                        <li id="lbl30" runat="server">Make sure you are looking towards the camera and not sideways</li>

                    </ol>
                </div>
            </div>
            <hr class="longLine hr"/>
            <div class="mt60">            
                
                <div class="consentDiv" style="font-family: Arial;" id="lbl31" runat="server">
                    Please keep your browser window open until you receive results – a green light or red light for your identity verification
                </div>
            </div>
            

                <div  style="text-align:center">
                        <button id="btnContinue" style="font-family:Arial;align-content:center;text-align:center;background-color:gray" runat="server" onServerClick="btnContinue_Click" disabled="disabled" >I understand. Let's Proceed</button>
                     <%--<asp:Button ID="btnContinue" runat="server" Text="I understand. Let's Proceed" class="btn btn-success btn-lg btn-block" OnClick="btnContinue_Click" />--%>
<%--                </div>
        </div>--%>


        <div id="divNotice" class="animated fadeInUp" style="display: block;">
            <div class="mt60" id="lblhead" runat="server">
                <h1 style="font-family: Arial;" id="H1" runat="server">Instructions to verify your identity</h1>
                <hr class="longLine hr" />
                <div class="consentDiv" style="font-family: Arial;">
                    In the following pages, you will be asked to take pictures of both sides of your ID card as well as a selfie of your face.
                </div>
            </div>
            <div class="mt60">
                <h1 style="font-family: Arial;" id="lbl22" runat="server">For ID picture</h1>
                <hr class="longLine hr" />
                <div class="consentDiv" style="font-family: Arial;">
                    <%--<ol>--%>
                        <label id="lbl23" runat="server">1. Choose a glare-free environment (no bright light) </label><br />
                        <label id="lbl24" runat="server">2. Place your ID on a flat contrast background (no white or black background) </label><br />
                        <label id="lbl25" runat="server">3. Hold your phone still and in portrait mode</label><br />
                        <label id="lbl32" runat="server">4. Center the ID and make sure all 4 corners are in the camera frame</label>
                    <%--</ol>--%>
                </div>
            </div>
            <hr class="longLine hr" />
            <div class="mt60">
                <h1 style="font-family: Arial;" id="lbl26" runat="server">For the selfie picture</h1>
                <hr class="longLine hr" />
                <div class="consentDiv" style="font-family: Arial;">
                    <%--<ol>--%>
                        <label id="lbl27" runat="server">1. Choose a glare-free environment (no bright light)  </label><br />
                        <label id="lbl28" runat="server">2. Show your full face (no hats, eyeglasses, sunglasses or scarves)  </label><br />
                        <label id="lbl29" runat="server">3. Look towards the camera (not sideways) </label><br />
                        <label id="lbl30" runat="server"></label>

                    <%--</ol>--%>
                </div>
            </div>
            <hr class="longLine hr" />
            <div class="mt60">

                <div class="consentDiv" style="font-family: Arial;" id="lbl31" runat="server">
                    You will need to keep your browser open until you receive your identity verification results: <br />
                    <ul>
                        <li>A green light means your ID was successfully verified.</li>
                        <li>A red light means more information is needed - please follow the steps as provided via email after seeing the red light. </li>
                    </ul>
                    Please watch this 2 minute instructional video before clicking to proceed below:
                </div>
            </div>
                     <div id ="divVideo" class="animated fadeInUp"  style="display: block;padding:5px 5px 5px 5px;" >
            <video id="myVideo" style="width:100% ;height:auto;text-align:center" controls="controls">
                <%--<source src="https://infosearchsite.com/MID_Test/Images/ISBUber.mp4" type="video/mp4"/>--%>
                <source src="https://infosearchsite.com/MID/Images/ISBUber.mp4" type="video/mp4"/>
            </video>
        </div>
        <p id ="redirect" style="visibility:hidden" runat="server">You can proceed by clicking "I understand let's proceed" in <span id="count"></span> seconds...</p>
        <div class="progress active" style="visibility:hidden" id="progress">
            <div id="pgbar" class="progress-bar  progress-bar-striped progress-bar-animated" role="progressbar" style="width: 0%"></div>
        </div>

            <div style="text-align: center">
                <button id="btnContinue" data-language="EN" style="font-family: Arial; align-content: center; text-align: center; background-color: gray" runat="server" onserverclick="btnContinue_Click" disabled="disabled">I understand. Let's Proceed</button>
                <%--<asp:Button ID="btnContinue" runat="server" Text="I understand. Let's Proceed" class="btn btn-success btn-lg btn-block" OnClick="btnContinue_Click" />--%>
            </div>
        </div>



    </form>
    <script type="text/javascript">
        //window.onbeforeunload = function () {
        //    debugger
        //    return 'Are you sure you want to leave?';
        //};

        $("#btnContinue").click(function () {
            var state = $(this).data('language');
            
            if (state == "EN") {
                alert("Warning: please do not click the back button nor close the browser until you complete the entire process. If you click the back button or close your browser,  you will be locked out of the process for 30 minutes");
            }
            else {
                alert("Attention: s'il vous plaît veillez à ne pas cliquez sur le bouton Retour ou fermez le navigateur jusqu'à ce que vous ayez terminé tout le processus. Si vous cliquez sur le bouton Retour ou fermez votre navigateur, vous serez exclu du processus pendant 30 minutes.");
            }
        });
        //window.onload = function () {

        //    (function () {
        //        var counter = 100;

        //        setInterval(function () {
        //            counter--;
        //            if (counter >= 0) {
        //                span = document.getElementById("count");
        //                span.innerHTML = counter;
        //                //document.getElementById("pgbar").setAttribute("width", counter + "%");
        //                document.getElementById('pgbar').style.width = counter + '%';
        //            }
        //            // Display 'counter' wherever you want to display it.
        //            if (counter === 0) {
        //                //    alert('this is where it happens');
        //                clearInterval(counter);
        //            }

        //        }, 1000);

        //    })();

        //}

        var vid = document.getElementById("myVideo");
        var playcount=0;
        vid.onplay = function () {
            playcount++;
            var counter = 0;
            var anothercounter = 75;
            var perc;
            document.getElementById('progress').style.visibility = 'visible';
            document.getElementById('redirect').style.visibility = 'visible';

            if (playcount < 2) {
                setInterval(function () {
                    counter++;
                    anothercounter--;
                    if (counter <= 75) {
                        span = document.getElementById("count");
                        span.innerHTML = anothercounter;
                        //document.getElementById("pgbar").setAttribute("width", counter + "%");
                        perc = (counter / 75) * 100
                        document.getElementById('pgbar').style.width = perc + '%';

                    }
                    // Display 'counter' wherever you want to display it.
                    if (counter === 75) {
                        //    alert('this is where it happens');
                        document.getElementById('btnContinue').disabled = false;
                        document.getElementById('btnContinue').style.backgroundColor = 'green';
                        clearInterval(counter);
                    }

                }, 1000);
            }
        };

    </script>
</body>


</html>
