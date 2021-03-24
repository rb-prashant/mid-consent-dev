using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
//using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thanks1 : System.Web.UI.Page
{
    string aidsegmentname = "";
    string payload = "";
    string email = "athangaraj@isbc.ca";
    string firstname = "";
    int companyid;
    string companyname;
    string guid;
    string lan = "";
    DateTime transdt;
    protected void Page_Load(object sender, EventArgs e)
    {


        //idtext.InnerText = "Final step - please upload an image of your Driver’s Abstract.";
        //uplFileUploader2.Visible = false;
        //SendEmail("athangaraj@isbc.ca", "2", "2");
        //SendEmail("athangaraj@isbc.ca", "TEST", "TEST");
        //SendEmailWithAttachment("athangaraj@isbc.ca", "UBER Video Identity Verification Instruction with attachment", "");
        //pass.Visible = false;
        //fail.Visible = false;
        //lblThanks.Text = "";

        try
        {
            Session["province"] = "";
            Session["thanks"] = "yes";
            guid = Request.QueryString["uid"];

            // Session["pdl"] = "";
            // guid = "97EF52D1-2599-4F22-9C1F-4147DFB0CEAB";
            // Session["lang"] = "FR";
            // uploadids2.Visible = false;
            // SendEmail("athangaraj@isbc.ca", guid, Request.QueryString.ToString());
            if (!IsPostBack)
            {
                //   guid = "800DF2C7-F364-4CE4-AF72-90506AD3F566";


                // check if it is a test order
                try
                {
                    //SendEmail("athangaraj@isbc.ca", "1", "1");

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                    {

                        DataSet dataSet = new DataSet();
                        using (SqlCommand cmd = new SqlCommand("select * from AIDOrders where AIDGUID = @guid", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@guid", guid);
                            conn.Open();
                            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

                            sqlData.Fill(dataSet);

                            conn.Close();

                            aidsegmentname = dataSet.Tables[0].Rows[0]["AIDSegmentName"].ToString();
                            payload = dataSet.Tables[0].Rows[0]["payload"].ToString();
                            companyid = Convert.ToInt32(dataSet.Tables[0].Rows[0]["companyid"].ToString());
                            transdt = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["transdt"].ToString());


                            string newstring = payload.Replace(';', '&');
                            string newstring2 = newstring.Replace(':', '=');
                            conn.Close();
                            var query = HttpUtility.ParseQueryString(newstring2);
                            email = query.Get("email");
                            Session["firstname"] = query.Get("firstname");
                            Session["lastname"] = query.Get("lastname");
                            if (query.Get("province") != null)
                            {
                                lan = query.Get("province");
                                Session["province"] = "QC";
                                if (lan == "QC")
                                {
                                    lan = "FR";
                                }
                            }
                            if (query.Get("language") != null)
                            {
                                lan = query.Get("language");
                                Session["lang"] = lan;
                            }
                            if (query.Get("package") != null)
                            {
                                Session["package"] = query.Get("package");
                            }
                            if (query.Get("pdl") != null)
                            {
                                Session["pdl"] = query.Get("pdl");
                            }

                            if (Session["lang"] != null)
                            {
                                lan = Session["lang"].ToString();
                            }
                            //if (companyid != 3409)
                            //{
                            //    uploadids.Visible = false;
                            //    Button1.Visible = false;
                            //}


                            if (Session["pdl"].ToString() == "RQ")
                            {



                                using (SqlCommand cmd1 = new SqlCommand("update AIDORders set DriverType = 1 where AIDGUID = @guid", conn))
                                {
                                    cmd1.CommandType = CommandType.Text;
                                    cmd1.Parameters.AddWithValue("@guid", guid);
                                    conn.Open();
                                    cmd1.ExecuteNonQuery();
                                    conn.Close();
                                }

                            }



                            // For test
                            //if (query.Get("driveruuid") != null)
                            //{
                            //    string driveruuid = query.Get("driveruuid");
                            //    if (driveruuid.Contains("eid_test"))
                            //    {
                            //        Response.Redirect("http://infosearchsite.com/MID_Test/validatecredentials.aspx?guid=" + guid);
                            //    }
                            //}



                        }
                    }
                }
                catch
                {

                }





                //guid = "DB7FEF1A-6F69-4E29-A9FF-F63D78F3CE39";
                //guid = "GoogleTest";
                //SendEmailWithAttachment("athangaraj@isbc.ca", "TEST", "TEST");
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                {
                    DataSet dataSet = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("select * from AIDOrders where AIDGUID = @guid", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@guid", guid);
                        conn.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

                        sqlData.Fill(dataSet);

                        conn.Close();

                        aidsegmentname = dataSet.Tables[0].Rows[0]["AIDSegmentName"].ToString();
                        payload = dataSet.Tables[0].Rows[0]["payload"].ToString();
                        companyid = Convert.ToInt32(dataSet.Tables[0].Rows[0]["companyid"].ToString());
                        transdt = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["transdt"].ToString());


                        string newstring = payload.Replace(';', '&');
                        string newstring2 = newstring.Replace(':', '=');
                        conn.Close();
                        var query = HttpUtility.ParseQueryString(newstring2);
                        email = query.Get("email");
                        Session["firstname"] = query.Get("firstname");
                        Session["lastname"] = query.Get("lastname");
                        if (query.Get("province") != null)
                        {
                            lan = query.Get("province");

                            if (lan == "QC")
                            {
                                lan = "FR";
                            }
                        }
                        if (Session["lang"] != null)
                        {
                            lan = Session["lang"].ToString();
                        }
                        //if (query.Get("language") != null)
                        //{
                        //    lan = query.Get("language");
                        //}
                        uploadids2.Visible = false;
                        btnUpload.Visible = false;

                        //UploadID
                        if (Session["province"] != null && Session["package"] != null)
                        {
                            // Session["lang"] = "EN";
                            //lan = "EN";

                            // if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                            {
                                uploadids2.Visible = true;
                                btnUpload.Visible = true;
                                idtext.InnerText = "";


                            }

                            if (Session["pdl"] != null)
                            {
                                if (Session["pdl"].ToString() == "RQ")
                                {
                                    uplFileUploader2.Visible = false;
                                    btnUpload.Visible = false;
                                    // idtext.InnerText = "Save some time and upload one id";
                                    //idtext.InnerText = "Please upload one piece of photo identification";
                                }
                            }

                        }


                    }
                }




                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                {
                    //using (SqlCommand cmd = new SqlCommand(" select AIDSegmentName from AIDOrders where AIDGUID = @guid", conn))
                    //{
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.Parameters.AddWithValue("@guid", guid);

                    //    conn.Open();
                    //    aidsegmentname = Convert.ToString(cmd.ExecuteScalar());
                    //    conn.Close();
                    //}

                    //using (SqlCommand cmd = new SqlCommand("select payload from AIDOrders where AIDGUID = @guid", conn))
                    //{
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.Parameters.AddWithValue("@guid", guid);

                    //    conn.Open();
                    //    payload = Convert.ToString(cmd.ExecuteScalar());
                    //    string newstring = payload.Replace(';', '&');
                    //    string newstring2 = newstring.Replace(':', '=');
                    //    conn.Close();
                    //    var query = HttpUtility.ParseQueryString(newstring2);
                    //    email = query.Get("email");
                    //    Session["firstname"] = query.Get("firstname");
                    //    Session["lastname"] = query.Get("lastname");
                    //    if(query.Get("province") !=null)
                    //    {
                    //        lan = query.Get("province");
                    //    }     

                    //}
                    //using (SqlCommand cmd = new SqlCommand("select companyid from AIDOrders where AIDGUID = @guid", conn))
                    //{
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.Parameters.AddWithValue("@guid", guid);

                    //    conn.Open();
                    //    companyid = Convert.ToInt32(cmd.ExecuteScalar());
                    //    conn.Close();
                    //}
                    using (SqlCommand cmd = new SqlCommand("select name from Company where CompanyID = @companyid", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@companyid", companyid);

                        conn.Open();
                        companyname = Convert.ToString(cmd.ExecuteScalar());
                        conn.Close();
                    }



                }

                if (companyid == 3800)
                {
                    Response.Redirect("https://www.infosearchsite.com/OrderProduct/thanks.aspx?uid=" + guid);
                }
                //if (!String.IsNullOrEmpty(aidsegmentname))
                //{
                //    SendEmail("athangaraj@isbc.ca", "AID Segment Name", "AID SegmentName :" + aidsegmentname);
                //}
                //aidsegmentname = "PASS";
                if (aidsegmentname.ToUpper().Contains("PASS") || aidsegmentname.ToUpper().Contains("GOOD"))
                {
                    Session["pass"] = "true";
                    pass.Visible = true;
                    fail.Visible = false;

                    pass.Visible = false;

                    //if (lan == "QC")
                    //{
                    //    lblThanks.Text = "Nous vous remercions " + Session["firstname"] + "  d’avoir complété le processus de validation de l’identité.<br/> " +
                    //        "Nous avons reçu votre information et effectuerons la vérification de vos antécédents " +
                    //        "Si vous avez des questions, nous vous invitons à contacter le ou la responsable de la conformité et de la confidentialité à privacy@isbc.ca";
                    //}
                    //else
                    //{
                    //    lblThanks.Text = "	Thank you " + Session["firstname"] + " for completing the Identity Validation process.<br/> " +
                    //        "We have received your information, and your background screening will be completed. " +
                    //        "If you have any questions please contact our Privacy Officer at privacy@isbc.ca. ";
                    //}

                    if (lan == "FR")
                    {
                        DataSet ds1 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 8 and langugateid=2 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds1);

                            }
                        }
                        // passimage.Src = ds1.Tables[0].Rows[0][9].ToString();
                        lblThanks.Text = ds1.Tables[0].Rows[0][1].ToString() + Session["firstname"] + ds1.Tables[0].Rows[0][2].ToString();
                        //divFooter.InnerHtml = ds1.Tables[0].Rows[0][10].ToString();
                        bannerimg.Src = "Images/banner_fr.png";
                        progressimg.Src = "Images/progressbar-100_fr.png";

                    }
                    else
                    {

                        DataSet ds1 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 8 and langugateid=1 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds1);

                            }
                        }
                        //passimage.Src = ds1.Tables[0].Rows[0][9].ToString();
                        lblThanks.Text = ds1.Tables[0].Rows[0][1].ToString() + Session["firstname"] + ds1.Tables[0].Rows[0][2].ToString();
                        divFooter.InnerHtml = ds1.Tables[0].Rows[0][10].ToString();
                    }
                    if (!IsPostBack)
                    {
                        if (!String.IsNullOrEmpty(payload))
                        {
                            if (companyid == 3653)
                            {
                                int notificationcount;
                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                                {
                                    using (SqlCommand cmd = new SqlCommand("select count(*) from MVIDEmailSent where typeid = 2 and packagegui = @packagegui", conn))
                                    {
                                        cmd.CommandType = CommandType.Text;

                                        cmd.Parameters.AddWithValue("@packagegui", guid);
                                        conn.Open();
                                        notificationcount = Convert.ToInt32(cmd.ExecuteScalar());
                                        conn.Close();

                                    }
                                }

                                if (notificationcount < 1)
                                {
                                    string emailbody;
                                    emailbody = " An MID was completed for an Uber Ride Share candidate with the following payload <br/>" + payload +
                                          "<br/><br/> Start Time = " + transdt + "       Completed Time = " + DateTime.Now.ToString() + "       Time Taken = " + ((DateTime.Now - transdt).TotalMinutes).ToString() + " minutes";
                                    SendEmail("vid@isbc.ca", "UBER RIDE SHARE NOTIFICATION", emailbody);
                                }
                            }
                            if (companyid == 3391)
                            {
                                string emailbody;
                                string subject;
                                DataSet ds2 = new DataSet();
                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                                {
                                    using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where id =25  order by companyid desc", conn))
                                    {
                                        cmd.CommandType = CommandType.Text;
                                        conn.Open();
                                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                        da1.Fill(ds2);

                                    }
                                }
                                if (!IsPostBack)
                                {
                                    if (!String.IsNullOrEmpty(payload))
                                    {
                                        int count = 0;
                                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                                        {
                                            using (SqlCommand cmd = new SqlCommand("select count(*) from MVIDEmailSent where emailto = @emailto and packagegui = @packagegui and typeid=2", conn))
                                            {
                                                cmd.CommandType = CommandType.Text;
                                                cmd.Parameters.AddWithValue("@emailto", email);
                                                cmd.Parameters.AddWithValue("@packagegui", guid);
                                                conn.Open();
                                                count = Convert.ToInt32(cmd.ExecuteScalar());
                                                conn.Close();

                                            }
                                        }
                                        if (count < 1)
                                        {
                                            emailbody = ds2.Tables[0].Rows[0][6].ToString() + ds2.Tables[0].Rows[0][1].ToString() + Session["firstname"] + ds2.Tables[0].Rows[0][2].ToString() + ds2.Tables[0].Rows[0][3].ToString() + ds2.Tables[0].Rows[0][4].ToString() + ds2.Tables[0].Rows[0][5].ToString() + ds2.Tables[0].Rows[0][7].ToString();
                                            subject = ds2.Tables[0].Rows[0]["Subject"].ToString();
                                            SendEmail(email, subject, emailbody);
                                        }
                                    }
                                }
                            }



                            //UploadID
                            if (Session["province"] != null && Session["package"] != null)
                            {
                                // Session["lang"] = "EN";
                                //lan = "EN";

                                //  if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                                {
                                    uploadids2.Visible = true;
                                    btnUpload.Visible = true;
                                    idtext.InnerText = "";
                                    lblThanks.Text = "Thank you for completing the Mobile Identity Validation process.<br/>" +
                                // "Unfortunately, we cannot prove your identity based on this method and the information you provided.<br/>" +
                                // " To complete your application, you will need to prove your identity through Video Identity Validation(VID).This process is conducted by the Insurance Search Bureau of Canada(ISB) and should take approximately 5 - 7 minutes." +
                                "In order for us to complete your criminal check you need to upload 2 pieces of ID.One must be a Government issued photo ID. (e.g. Driver’s License, Canadian Citizenship Card, Passport, Permanent Resident Card)<br/>" +
                                " Please upload two CLEAR photos of your 2 pieces of ID.<br/> ";
                                    // "After you’ve uploaded your ID please contact ISB via email at vid@isbc.ca to schedule a time for a video call.<br/>" +
                                    //"    <ol><li> A time, which is convenient for you, that ISB can call you via video chat(ensure you include AM / PM) </li ><li> Your cell phone number, email address or username for the app to be used </li>" +
                                    // "<li> Which of the following video apps you would like to use; Facetime(for iPhone / iPad), Google Hangouts, IMO, Skype, Google Duo." +
                                    // " (Make sure you have the app downloaded on your phone / device.You can visit Google Play store to download if you don’t have one currently installed.)</li></ol><br/>" +
                                    // "If you encounter any problems, please don’t hesitate to contact us for assistance at 800 - 295 - 5732.<br/>";
                                    // "At this time Greenlight Hubs are unavailable to support you – due to COVID - 19.<br/> We appreciate your cooperation in completing the VID process.<br/>";
                                    //pass.Visible = true;

                                }

                                if (Session["pdl"] != null)
                                {
                                    if (Session["pdl"].ToString() == "RQ")
                                    {
                                        btnUpload.Visible = false;
                                        uplFileUploader2.Visible = false;
                                        uplFileUploader.Visible = false;
                                        // lblThanks.Text = "Thank you for completing the Mobile Identity Validation Process. <br/>We have received your information and your background check will be completed. If you have any questions please contact our privacy offcer at privacy@isbc.ca";
                                        lblThanks.Text = "Thank you for completing the Mobile Identity Validation Process. <br/>We have received your information and your background check will be completed. If you have any questions please contact our privacy offcer at privacy@isbc.ca";
                                        //  pass.Visible = true;
                                    }
                                }

                            }
                        }
                    }



                }
                else
                {
                    Session["pass"] = "false";

                    Session["eidcomp"] = Request.QueryString["eidcomp"];
                    //midEid workflow

                    if (Session["eidcomp"] == null)
                    {
                        if (companyid == 3409 || companyid == 1)
                        {
                            Server.Transfer("MIDEID.aspx?guid=" + guid + "&lan=" + lan);
                        }
                    }




                    pass.Visible = false;
                    fail.Visible = true;

                    fail.Visible = false;

                    string emailbody = "";
                    string subject = "Video Identity Verification Instructions";
                    //lblThanks.Text = "	Thank you for completing the Identity Validation process. . Unfortunately, we are unable to validate your identity with the information provided. " +
                    //    "Further verification is required through Video Identity Validation." +
                    //    " Please email  or call  to schedule a time to validate your identity within the next 24 hours. ";
                    if (lan == "FR")
                    {

                        bannerimg.Src = "Images/banner_fr.png";
                        progressimg.Src = "Images/progressbar-100_fr.png";
                        lblThanks.Text = "Merci d’avoir tenté de valider votre identité par l’entremise du processus de Validation de l’identité mobile.<br/><br/>" +
                            "Malheureusement, nous n’avons pas été en mesure de valider votre identité à l’aide de cette méthode.<br/><br/> " +
                            " Pour terminer votre demande, vous devrez prouver votre identité par l’entremise de la <strong>Validation de l’identité par vidéo (VID).</strong> " +
                            "Ce processus est effectué par ISB (Insurance Search Bureau of Canada) et prend environ de cinq à sept minutes. Pour compléter la vérification de votre casier judiciaire, nous exigeons deux pièces d’identité. Nous avons déjà votre permis de conduire, il nous en manque donc seulement une. <br/><br/> " +
                            "Une fois que vous avez lu et suivi les instructions suivantes, veuillez contacter ISB par courriel à  <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> pour déterminer l’horaire de la vidéoconférence. <br/><br/>Veuillez inclure dans ce courriel :<br/>" +
                            //"send the pictures/photocopies of your identification requested below, and advise what time would work best for you to conduct a video call.<br/><br/>" +
                            "<ol><li>le moment qui vous convient pour qu’ISB puisse vous appeler par vidéoconférence </li>" +
                            "<li>Veuillez indiquer l’application que vous préférez</li></ol>" +
                            "<strong><u> Instructions </u></strong><br/><br/>" +
                            //" 1. Please take a picture or photocopy of your two pieces of identification (Click <a href=\"https://infosearchsite.com/search/open/Acceptable_ID.pdf\" target=\"_blank\" > here</a> for list of acceptable IDs) <br/ >2. Depending on your device (Android or Apple), open the appropriate file  for further instructions." +
                            //"<br/> Click <a href=\"https://infosearchsite.com/search/open/UBER_Android_Users_instructions.pdf\" target=\"_blank\">here</a> for Android" +
                            //"<br/> Click <a href=\"https://infosearchsite.com/search/open/UBER_Apple_IPhone_instructions.pdf\" target=\"_blank\">here</a> for Apple" +
                            "<ol><li>Prenez la photographie d’une autre pièce d’identité (non pas votre permis, puisque nous avons déjà cette information). Cette pièce d’identité doit contenir au moins votre nom.</li>" +
                            "<li>Choisissez l’application vidéo que vous préférez utiliser : Facetime (pour le iPhone et iPad), Google Hangouts, IMO, Skype ou Google Duo. Assurez-vous que l’application est installée sur votre téléphone ou appareil. Si vous n’en avez pas, visitez le magasin Google Play pour en télécharger une.</li>" +
                            "<li>Faites parvenir un courriel à ISB à  <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> pour l’informer de ce qui suit :" +
                            "<ol><li>Votre numéro de téléphone cellulaire, votre adresse de courriel ou votre nom d’utilisateur pour l’application que vous désirez utiliser</li>" +
                            "<li>Un moment qui vous convient pour qu’ISB puisse vous contacter (veuillez indiquer le matin ou l’après-midi) </li></ol></li></ol>" +


                            "<br/><br/>Si vous avez des difficultés et désirez obtenir de l’aide, veuillez composer le  <a href=\"tel:8002955732\">800-295-5732</a><br /><br />" +
                            //"We appreciate your cooperation in completing this process." +
                            //"<br/><br/>Thank You!";
                            "<br/>Nous vous remercions de votre coopération à compléter ce ";
                        emailbody = "<strong>Bonjour " + Session["firstname"] + "</strong>,<br/><br/>" +
                       " Merci d’avoir tenté de validé votre identité par le processus de <strong>Validation d’identité par application mobile</strong> .<br/><br/>" +
                       "Malheureusement, nous ne sommes pas en mesure de validé votre identité de cette façon.<br/><br/> " +
                       " Afin de compléter votre application, vous devrez valider votre identité par la  <strong>Validation d’identité vidéo.</strong> " +
                       ".  Ce processus est fait par The Insurance Search Bureau of Canada (ISB) et devrait prendre approximativement 5 à 7 minutes.<br/><br/> " +
                       //"Please contact ISB via email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a>  in order to schedule a time for a video conference.<br/><br/>" +
                       "Lorsque vous aurez pris connaissance et suivit les instructions ci basse, s’il vous plait contacter ISB via courriel au <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> afin de céduler un rendez-vous pour une appel conférence vidéo. De plus, veuillez joindre à ce courriel les photos/photocopies des  pièces d’identités  requises et  nous avisez du moment qui vous serait opportun pour recevoir l’appel vidéo.<br/><br/>" +
                       "<strong><u> Instructions </u></strong><br/><br/>" +
                       " <ol><li>1.	Veuillez prendre une photo ou une photocopie de deux pièces d’identité.</li ><li>	2.	Envoyer un courriel à ISB nous avisant quel application d’appel vidéo vous désirez utiliser ainsi que du moment qui vous  convient le mieux.</ li ></ ol >" +
                       "<br/><br/>S’il y a quoique ce soit de problématique, s’il-vous-plait n’hésitez pas à nous contacter pour assistance au <a href=\"tel:+18002955732\">800-295-5732</a><br /><br />Nous apprécions votre coopération afin de compléter ce processus." +
                       "<br/><br/>Merci!";

                        DataSet ds1 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 7 and langugateid=2 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds1);

                            }
                        }
                        //passimage.Src = ds1.Tables[0].Rows[0][9].ToString();
                        lblThanks.Text = ds1.Tables[0].Rows[0][1].ToString() + ds1.Tables[0].Rows[0][2].ToString() + ds1.Tables[0].Rows[0][3].ToString() + ds1.Tables[0].Rows[0][4].ToString() + ds1.Tables[0].Rows[0][5].ToString();
                        divFooter.InnerHtml = ds1.Tables[0].Rows[0][10].ToString();
                        DataSet ds2 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 5 and langugateid=2 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds2);

                            }
                        }
                        emailbody = ds2.Tables[0].Rows[0][6].ToString() + ds2.Tables[0].Rows[0][1].ToString() + Session["firstname"] + ds2.Tables[0].Rows[0][2].ToString() + ds2.Tables[0].Rows[0][3].ToString() + ds2.Tables[0].Rows[0][4].ToString() + ds2.Tables[0].Rows[0][5].ToString() + ds2.Tables[0].Rows[0][7].ToString();
                        subject = ds2.Tables[0].Rows[0]["Subject"].ToString();

                    }
                    else
                    {
                        lblThanks.Text = "Thank you for attempting to validate your identity through the <strong>Mobile Identity Validation</strong> process.<br/><br/>" +
                            "Unfortunately, we have been unable to validate your identity by this method.<br/><br/> " +
                            " To complete your application, you will need to prove your identity through <strong>Video Identity Validation (VID).</strong> " +
                            "This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5-7 minutes. In order for us to complete your criminal check we require 2 pieces of ID. We already have your drivers licence, so we just need one more. <br/><br/> " +
                            //"Please contact ISB via email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a>  in order to schedule a time for a video conference.<br/><br/>" +
                            "Once you have read and followed the instructions below, please contact ISB via email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> to schedule a time for a video conference. <br/><br/>In this email please include:<br/>" +
                            //"send the pictures/photocopies of your identification requested below, and advise what time would work best for you to conduct a video call.<br/><br/>" +
                            "<ol><li>a time, which is convenient for you, that ISB can call you via video chat</li>" +
                            "<li>which video chat application you prefer </li></ol>" +
                            "<strong><u> Instructions </u></strong><br/><br/>" +
                            //" 1. Please take a picture or photocopy of your two pieces of identification (Click <a href=\"https://infosearchsite.com/search/open/Acceptable_ID.pdf\" target=\"_blank\" > here</a> for list of acceptable IDs) <br/ >2. Depending on your device (Android or Apple), open the appropriate file  for further instructions." +
                            //"<br/> Click <a href=\"https://infosearchsite.com/search/open/UBER_Android_Users_instructions.pdf\" target=\"_blank\">here</a> for Android" +
                            //"<br/> Click <a href=\"https://infosearchsite.com/search/open/UBER_Apple_IPhone_instructions.pdf\" target=\"_blank\">here</a> for Apple" +
                            "<ol><li>Take a picture of another piece of ID (not your driving license, we already have that), this ID must have a minimum of your name on it.</li>" +
                            "<li>Choose which video app you would like to use; facetime (for iphone/ipad), google hangouts, IMO, skype, google duo. Make sure you have the app downloaded on your phone/device. You can visit google play store to download if you don’t have one currently.</li>" +
                            "<li>Send ISB an email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> and advise of the following:" +
                            "<ol><li>Your cell phone number, email address or username for the app to be used</li>" +
                            "<li>A convenient time for ISB to call you (ensure you include AM/PM)</li></ol></li></ol>" +


                            "<br/><br/>If you encounter any problems, please don&rsquo;t hesitate to contact us for assistance at <a href=\"tel:8002955732\">800-295-5732</a><br /><br />" +

                            "<br/>We appreciate your cooperation in completing the VID process";
                        emailbody = "<strong>Hello " + Session["firstname"] + " " + Session["lastname"] + "</strong>,<br/><br/>" +

                        " Thank you for attempting to validate your identity through the <strong>Mobile Identity Validation</strong> process.<br/><br/>" +
                        "Unfortunately, we have been unable to validate your identity by this method.<br/><br/> " +
                        " To complete your application, you will need to prove your identity through <strong>Video Identity Validation.</strong> " +
                        "This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5-7 minutes.<br/><br/> " +
                        //"Please contact ISB via email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a>  in order to schedule a time for a video conference.<br/><br/>" +
                        "Once you have read and followed the instructions below, please contact ISB via email at <a href=\"mailto: vid@isbc.ca\">vid@isbc.ca</a> to schedule a time for a video conference. In this email please send the pictures/photocopies of your identification requested below, and advise what time would work best for you to conduct a video call.<br/><br/>" +
                        "<strong><u> Instructions </u></strong><br/><br/>" +
                        " <ol><li>Please take a picture or photocopy of your two pieces of identification</li ><li>	Send an email to ISB advising of which video chat application you will use and what time works best for you.</ li ></ ol >" +
                        "<br/><br/>If you encounter any problems, please don&rsquo;t hesitate to contact us for assistance at <a href=\"tel:+18002955732\">800-295-5732</a><br /><br />We appreciate your cooperation in completing this process." +
                        "<br/><br/>Thank You!" +
                        "<br/><br/>Video apps available for use by ISB:<br/><br/>IOS – Facetime, Skype, IMO<br/><br/>Android – Google Hangouts, Duo, IMO, Skype";
                        DataSet ds1 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {
                            //companyid = 3653;
                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 7 and langugateid=1 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {

                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds1);
                                conn.Close();

                            }
                        }
                        //passimage.Src = ds1.Tables[0].Rows[0][9].ToString();
                        lblThanks.Text = ds1.Tables[0].Rows[0][1].ToString() + ds1.Tables[0].Rows[0][2].ToString() + ds1.Tables[0].Rows[0][3].ToString() + ds1.Tables[0].Rows[0][4].ToString() + ds1.Tables[0].Rows[0][5].ToString() + ds1.Tables[0].Rows[0][6].ToString() + ds1.Tables[0].Rows[0][7].ToString() + ds1.Tables[0].Rows[0][8].ToString();
                        divFooter.InnerHtml = ds1.Tables[0].Rows[0][10].ToString();
                        DataSet ds2 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 5 and langugateid=1 and companyid in (0," + companyid + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds2);
                                conn.Close();

                            }
                        }
                        emailbody = ds2.Tables[0].Rows[0][6].ToString() + ds2.Tables[0].Rows[0][1].ToString() + Session["firstname"] + ds2.Tables[0].Rows[0][2].ToString() + ds2.Tables[0].Rows[0][3].ToString() + ds2.Tables[0].Rows[0][4].ToString() + ds2.Tables[0].Rows[0][5].ToString() + ds2.Tables[0].Rows[0][7].ToString();
                        subject = ds2.Tables[0].Rows[0]["Subject"].ToString();

                    }
                    // if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                    {
                        btnUpload.Visible = true;

                        if (lan == "FR")
                        {
                            Session["lang"] = "FR";
                            lblThanks.Text = "Merci d’avoir tenté de valider votre identité par l’entremise du processus de Validation de l’identité mobile.<br/>Malheureusement, nous n’avons pas été en mesure de valider votre identité à l’aide de cette méthode et les informations que vous avez fournies.<br/>Pour terminer votre demande, vous devrez prouver votre identité par l’entremise de la Validation de l’identité par vidéo (VID). Ce processus est effectué par Insurance Search Bureau of Canada (ISB) et prend environ de cinq à sept minutes. Pour ce faire, nous avons besoin que vous téléchargiez des images de deux pièces d’identité. Une pièce doit être une pièce d’identité avec photo émise par le gouvernement. S’il vous plaît télécharger deux photos CLAIRES de vos 2 pièces d'identité.<br/>Veuillez contacter ISB par courriel à vid@isbc.ca pour se préparer et déterminer l’horaire de la vidéoconférence.<br/>Si vous avez des difficultés et désirez obtenir de l’aide, veuillez contacter ISB par courriel à vid@isbc.ca.<br/>Pour le moment, en raison de COVID-19, les hubs Greenlight ne sont pas disponibles pour vous soutenir<br/>Nous vous remercions de votre coopération à compléter ce processus.";
                            lblThanks.Text = "Merci d’avoir tenté de terminer le processus de Validation de l’Identité Mobile. Malheureusement,  nous ne pouvons pas prouver votre identité sur la base de cette méthode et des informations que vous avez fournies. Pour procéder avec votre vérification des antécédents, veuillez télécharger 2 pièces d’identité émises par le gouvernement. (Ex: permis de conduire, carte de citoyenneté canadienne, passeport, carte de résident permanent).S’il - vous - plait, téléchargez une photo CLAIRE de votre pièce d’identité supplémentaire. Si la photo n’est pas claire, cela retardera votre processus de vérification des antécédents.";

                            if (Session["pdl"] != null)
                            {
                                if (Session["pdl"].ToString() == "RQ")
                                {
                                    lblThanks.Text = "Merci d’avoir tenté de valider votre identité par l’entremise du processus de Validation de l’identité mobile.<br/>Malheureusement, nous n’avons pas été en mesure de valider votre identité à l’aide de cette méthode et les informations que vous avez fournies.<br/>Pour terminer votre demande, vous devrez prouver votre identité par l’entremise de la Validation de l’identité par vidéo (VID). Ce processus est effectué par Insurance Search Bureau of Canada (ISB) et prend environ de cinq à sept minutes. Pour ce faire, nous avons besoin que vous téléchargiez une image de pièce d’identité. Ce pièce doit être une pièce d’identité avec photo émise par le gouvernement (Permis de conduire, Carte de citoyenneté Canadienne, Passeport, Carte de Résident Permanent). S’il vous plaît télécharger une photo CLAIRES de votre pièce d'identité.<br/>Veuillez contacter ISB par courriel à vid@isbc.ca pour se préparer et déterminer l’horaire de la vidéoconférence.<br/>Si vous avez des difficultés et désirez obtenir de l’aide, veuillez contacter ISB par courriel à vid@isbc.ca.<br/>Pour le moment, en raison de COVID-19, les hubs Greenlight ne sont pas disponibles pour vous soutenir.<br/>Nous vous remercions de votre coopération à compléter ce processus.";


                                    lblThanks.Text = "Merci d’avoir tenté de terminer le processus de Validation de l’Identité Mobile. Malheureusement,  nous ne pouvons pas prouver votre identité sur la base de cette méthode et des informations que vous avez fournies. Pour procéder avec votre vérification des antécédents, veuillez télécharger 1 pièce d’identité émises par le gouvernement. (Ex: permis de conduire, carte de citoyenneté canadienne, passeport, carte de résident permanent).S’il - vous - plait, téléchargez une photo CLAIRE de votre pièce d’identité supplémentaire. Si la photo n’est pas claire, cela retardera votre processus de vérification des antécédents.";
                                }
                            }

                        }
                        else
                        {
                            Session["lang"] = "EN";
                            lblThanks.Text = "Thank you for trying to complete the Mobile Identity Validation process.<br/>Unfortunately, we cannot prove your identity based on this method and the information you provided." +
                                "<br/>To complete your application, you will need to prove your identity through Video Identity Validation(VID). This process is conducted by the Insurance Search Bureau of Canada(ISB) and should take approximately 5 - 7 minutes.In order for ISB to complete your criminal check you need to upload 2 pieces of ID.One must be a Government issued photo ID(e.g.Driver’s License, Canadian Citizenship Card, Passport, Permanent Resident Card) Please upload two CLEAR photos of your 2 pieces of ID below." +
                                "<br/>ISB have sent you an email with instructions to schedule and prepare for the VID. <br/>If you encounter any problems, please don’t hesitate to contact ISB for assistance at 800 - 295 – 5732." +
                                "<br/>At this time Greenlight Hubs are unavailable to support you – due to COVID - 19.We appreciate your cooperation in completing the VID process.";

                            lblThanks.Text = "Thank you for trying to complete the Mobile Identity Validation process. Unfortunately, we cannot prove your identity based on this method and the information you provided. To proceed with your background check, please upload 2 pieces of government issued ID   (e.g.Driver’s License, Canadian Citizenship Card, Passport, Permanent Resident Card).Please upload two CLEAR photos of your 2 pieces of ID. If the photo is not clear, this will delay your background check process.";

                            if (Session["pdl"] != null)
                            {
                                if (Session["pdl"].ToString() == "RQ")
                                {
                                    lblThanks.Text = "Thank you for trying to complete the Mobile Identity Validation process.<br/>Unfortunately, we cannot prove your identity based on this method and the information you provided.<br/>To complete your application, you will need to prove your identity through Video Identity Validation(VID). This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5 - 7 minutes.  In order for ISB to complete your criminal check you need to upload 1 additional piece of ID which muust be a Government issued photo ID (e.g. Driver’s License, Canadian Citizenship Card, Passport, Permanent Resident Card) Please upload one CLEAR photo of your piece of ID below.<br/>ISB have sent you an email with instructions to schedule and prepare for the VID.<br/>If you encounter any problems, please don’t hesitate to contact ISB for assistance at 800 - 295 – 5732.<br/>At this time Greenlight Hubs are unavailable to support you – due to COVID - 19. We appreciate your cooperation in completing the VID process.";

                                    lblThanks.Text = "Thank you for trying to complete the Mobile Identity Validation process. Unfortunately, we cannot prove your identity based on this method and the information you provided. To proceed with your background check, please upload 1 piece of government issued ID   (e.g.Driver’s License, Canadian Citizenship Card, Passport, Permanent Resident Card).Please upload a CLEAR photo of your 1 piece of ID. If the photo is not clear, this will delay your background check process.";

                                }
                            }
                        }


                    }

                    if (!IsPostBack)
                    {
                        if (!String.IsNullOrEmpty(payload))
                        {
                            int count = 0;
                            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("select count(*) from MVIDEmailSent where emailto = @emailto and packagegui = @packagegui and typeid=2", conn))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@emailto", email);
                                    cmd.Parameters.AddWithValue("@packagegui", guid);
                                    conn.Open();
                                    count = Convert.ToInt32(cmd.ExecuteScalar());
                                    conn.Close();

                                }
                            }

                            //if (companyid != 3653)
                            {
                                //if (count < 1 && aidsegmentname.Contains("Fail")) 
                                //{
                                //    SendEmail(email, subject, emailbody);
                                //}

                                //if(aidsegmentname.Contains("Fail"))
                                //{
                                //    SendEmailWithAttachment("vid@isbc.ca", "Video Identity Verification Instruction with attachment for " + Session["firstname"] + " - " + companyname, emailbody);
                                //}
                                if (count < 1)
                                {
                                    SendEmail(email, subject, emailbody);
                                }
                                SendEmailWithAttachment("vid@isbc.ca", "Video Identity Verification Instruction with attachment for " + Session["firstname"] + " - " + companyname, emailbody);

                            }
                            if (companyid == 3653)
                            {
                                int notificationcount;
                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
                                {
                                    using (SqlCommand cmd = new SqlCommand("select count(*) from MVIDEmailSent where typeid = 2 and packagegui = @packagegui", conn))
                                    {
                                        cmd.CommandType = CommandType.Text;

                                        cmd.Parameters.AddWithValue("@packagegui", guid);
                                        conn.Open();
                                        notificationcount = Convert.ToInt32(cmd.ExecuteScalar());
                                        conn.Close();

                                    }
                                }

                                if (notificationcount < 1)
                                {
                                    emailbody = " An MID was completed for an Uber Ride Share candidate with the following payload <br/>" + payload +
                                        "<br/><br/> Start Time = " + transdt + "       Completed Time = " + DateTime.Now.ToString() + "       Time Taken = " + ((DateTime.Now - transdt).TotalMinutes).ToString() + " minutes";
                                    SendEmail("vid@isbc.ca", "UBER RIDE SHARE NOTIFICATION", emailbody);
                                }
                            }

                        }
                    }



                    //SendEmail("athangaraj@isbc.ca", "UBER Video Identity Verification Instructions", emailbody); -test

                }
            }
            //uploadids.InnerText = "you will need to upload two pieces of id. Please have it ready. You can do it by clicking this button below.";
        }
        catch (Exception ex)
        {

            SendEmail("athangaraj@isbc.ca", "Error in Thanks Page", ex.Message);
        }


    }


    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        SendEmail("athangaraj@isbc.ca", "Uploadbutton", "Uploadbutton");
        //Server.Transfer("ValidateCredentials.aspx?Uploadimgid=" + guid);

        if (Session["lang"] == "FR")
        {
            lblUpload.Text = "Merci! Les images ont été téléchargées avec succès";
        }
        else
        {
            lblUpload.Text = "Thank You! The images have been uploaded successfully";
        }


        //if (uplFileUploader.HasFile && uplFileUploader2.HasFile)
        //{
        //    try
        //    {
        //        string strTestFilePath = uplFileUploader.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
        //        string strTestFileName = Path.GetFileName(strTestFilePath); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
        //        Int32 intFileSize = uplFileUploader.PostedFile.ContentLength;
        //        string strContentType = uplFileUploader.PostedFile.ContentType;

        //        // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
        //        Stream strmStream = uplFileUploader.PostedFile.InputStream;
        //        Int32 intFileLength = (Int32)strmStream.Length;
        //        byte[] bytUpfile = new byte[intFileLength + 1];
        //        strmStream.Read(bytUpfile, 0, intFileLength);
        //        strmStream.Close();

        //        string strTestFilePath2 = uplFileUploader2.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
        //        string strTestFileName2 = Path.GetFileName(strTestFilePath2); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
        //        Int32 intFileSize2 = uplFileUploader2.PostedFile.ContentLength;
        //        string strContentType2 = uplFileUploader2.PostedFile.ContentType;

        //        // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
        //        Stream strmStream2 = uplFileUploader2.PostedFile.InputStream;
        //        Int32 intFileLength22 = (Int32)strmStream2.Length;
        //        byte[] bytUpfile2 = new byte[intFileLength + 1];
        //        strmStream2.Read(bytUpfile2, 0, intFileLength);
        //        strmStream2.Close();

        //        saveFileToDb(bytUpfile, bytUpfile2, guid); // or use uplFileUploader.SaveAs(Server.MapPath(".") + "filename") to save to the server's filesystem.
        //                                                   //lblUploadResult.Text = "Upload Success. File was uploaded and saved to the database.";
        //        uplFileUploader.Visible = false;
        //        uplFileUploader2.Visible = false;
        //        Button1.Visible = false;
        //        lblUpload.Text = "Thank You! The images have been uploaded successfully";
        //    }
        //    catch (Exception err)
        //    {
        //        SendEmail("athangaraj@isbc.ca", "Upload", err.ToString());
        //        //lblUploadResult.Text = "The file was not updloaded because the following error happened: " + err.ToString();
        //        lblUpload.Text = "Error in Uploading the file because ";
        //    }
        //}
        //else
        //{
        //    lblUpload.Text = "Please upload two pieces of ID to proceed";
        //    // lblUploadResult.Text = "No File Uploaded because none was selected.";
        //}

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // SendEmail("athangaraj@isbc.ca", "Uploadbutton", "Uploadbutton");
        //Server.Transfer("ValidateCredentials.aspx?Uploadimgid=" + guid);
        // lblUpload.Text = "Thank You! The images have been uploaded successfully";
        lblThanks.Text = "";
        idtext.InnerText = "";

        if (Session["pdl"].ToString() == "RQ")
        {

            if (uplFileUploader.HasFile || uplFileUploader2.HasFile)
            {
                try
                {
                    string strTestFilePath = uplFileUploader.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
                    string strTestFileName = Path.GetFileName(strTestFilePath); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
                    Int32 intFileSize = uplFileUploader.PostedFile.ContentLength;
                    string strContentType = uplFileUploader.PostedFile.ContentType;

                    // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
                    Stream strmStream = uplFileUploader.PostedFile.InputStream;
                    Int32 intFileLength = (Int32)strmStream.Length;
                    byte[] bytUpfile = new byte[intFileLength + 1];
                    strmStream.Read(bytUpfile, 0, intFileLength);
                    strmStream.Close();


                    byte[] bytUpfile2;

                    try
                    {

                        string strTestFilePath2 = uplFileUploader2.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
                        string strTestFileName2 = Path.GetFileName(strTestFilePath2); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
                        Int32 intFileSize2 = uplFileUploader2.PostedFile.ContentLength;
                        string strContentType2 = uplFileUploader2.PostedFile.ContentType;

                        // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
                        Stream strmStream2 = uplFileUploader2.PostedFile.InputStream;
                        Int32 intFileLength22 = (Int32)strmStream2.Length;
                        bytUpfile2 = new byte[intFileLength + 1];
                        strmStream2.Read(bytUpfile2, 0, intFileLength);
                        strmStream2.Close();
                    }
                    catch
                    {
                        bytUpfile2 = new byte[0];

                    }

                    saveFileToDb(bytUpfile, bytUpfile2, guid); // or use uplFileUploader.SaveAs(Server.MapPath(".") + "filename") to save to the server's filesystem.
                                                               //lblUploadResult.Text = "Upload Success. File was uploaded and saved to the database.";
                    uplFileUploader.Visible = false;
                    uplFileUploader2.Visible = false;
                    btnUpload.Visible = false;

                    fail.Visible = false;



                    if (Session["lang"].ToString() == "FR")
                    {
                        if (Session["pass"].ToString() == "true")
                        {
                            lblUpload.Text = "Merci! Les images ont été téléchargées avec succès. Nous allons maintenant commencer le processus de sélection des antécédents";
                            pass.Visible = true;
                        }
                        else
                        {
                            pass.Visible = true;
                            //lblUpload.Text = "Merci ! Les images ont été téléchargées avec succès. Pour compléter votre demande, vous devrez prouver votre identité par le biais de la Validation d’Identité Vidéo (VID). Ce processus est mené par Insurance Search Bureau of Canada (ISB) et devrait prendre environ 5 à 7 minutes. Vous devez prendre rendez-vous pour une appel vidéo pour terminer votre vérification des antécédents.<br/><br/>  <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Veuillez cliquer ici pour céduler votre appel vidéo.</button></a><br/><br/>Si vous rencontrez des problèmes, n’hésitez pas à contacter ISB pour obtenir de l’aide à ubersupport@isbglobalservices.com.Pour le moment, Greenlight Hubs ne sont pas disponibles pour vous aider – en raison du Covid-19.<br/><br/>Nous apprécions votre coopération pour mener à bien le processus VID.";
                            lblUpload.Text = "Merci ! Les images ont été téléchargées avec succès. Pour compléter votre demande, vous devez prendre rendez-vous pour une appel vidéo. Ce processus est mené par Insurance Search Bureau of Canada (ISB) et devrait prendre environ 5 à 7 minutes.<br/><br/>  <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Veuillez cliquer ici pour céduler votre appel vidéo.</button></a><br/><br/>Si vous rencontrez des problèmes, n’hésitez pas à contacter ISB pour obtenir de l’aide à ubersupport@isbglobalservices.com. <br/><br/> Pour le moment, Greenlight Hubs ne sont pas disponibles pour vous aider – en raison du Covid-19.<br/><br/>Nous apprécions votre coopération pour mener à bien le processus VID.";
                        }

                    }
                    else
                    {

                        if (Session["pass"].ToString() == "true")
                        {
                            pass.Visible = true;
                            lblUpload.Text = "Thank You! The images have been uploaded successfully. We will now begin the background screening process";
                        }
                        else
                        {
                            pass.Visible = true;
                            // lblUpload.Text = "Thank You! The images have been uploaded successfully. To complete your application, you will need to prove your identity through Video Identity Validation(VID). This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5 - 7 minutes. You need to set up a video call appointment to complete your background screening. <br/><br/> <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Please click here to schedule your video call.</button></a> <br/><br/>If you encounter any problems, please don’t hesitate to contact ISB for assistance at ubersupport@isbglobalservices.com. At this time Greenlight Hubs are unavailable to support you – due to COVID - 19.<br/><br/> We appreciate your cooperation in completing the VID process.";
                            lblUpload.Text = "Thank You! The images have been uploaded successfully. To complete your application, you need to set up a video call appointment. This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5 - 7 minutes. <br/><br/> <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Please click here to schedule your video call.</button></a> <br/><br/>If you encounter any problems, please don’t hesitate to contact ISB for assistance at ubersupport@isbglobalservices.com. At this time Greenlight Hubs are unavailable to support you – due to COVID - 19.<br/><br/> We appreciate your cooperation in completing the VID process.";
                        }
                    }
                }
                catch (Exception err)
                {
                    SendEmail("athangaraj@isbc.ca", "Upload", err.ToString());
                    //lblUploadResult.Text = "The file was not updloaded because the following error happened: " + err.ToString();
                    lblUpload.Text = "Error in Uploading the file because ";
                }
            }
            else
            {
                lblUpload.Text = "Please upload two pieces of ID to proceed";
                // lblUploadResult.Text = "No File Uploaded because none was selected.";
            }
        }
        else
        {
            if (uplFileUploader.HasFile && uplFileUploader2.HasFile)
            {
                try
                {
                    string strTestFilePath = uplFileUploader.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
                    string strTestFileName = Path.GetFileName(strTestFilePath); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
                    Int32 intFileSize = uplFileUploader.PostedFile.ContentLength;
                    string strContentType = uplFileUploader.PostedFile.ContentType;

                    // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
                    Stream strmStream = uplFileUploader.PostedFile.InputStream;
                    Int32 intFileLength = (Int32)strmStream.Length;
                    byte[] bytUpfile = new byte[intFileLength + 1];
                    strmStream.Read(bytUpfile, 0, intFileLength);
                    strmStream.Close();






                    string strTestFilePath2 = uplFileUploader2.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
                    string strTestFileName2 = Path.GetFileName(strTestFilePath2); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
                    Int32 intFileSize2 = uplFileUploader2.PostedFile.ContentLength;
                    string strContentType2 = uplFileUploader2.PostedFile.ContentType;

                    // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
                    Stream strmStream2 = uplFileUploader2.PostedFile.InputStream;
                    Int32 intFileLength22 = (Int32)strmStream2.Length;
                    byte[] bytUpfile2 = new byte[intFileLength + 1];
                    strmStream2.Read(bytUpfile2, 0, intFileLength);
                    strmStream2.Close();


                    saveFileToDb(bytUpfile, bytUpfile2, guid); // or use uplFileUploader.SaveAs(Server.MapPath(".") + "filename") to save to the server's filesystem.
                                                               //lblUploadResult.Text = "Upload Success. File was uploaded and saved to the database.";
                    uplFileUploader.Visible = false;
                    uplFileUploader2.Visible = false;
                    btnUpload.Visible = false;


                    fail.Visible = false;
                    pass.Visible = false;
                    if (Session["lang"].ToString() == "FR")
                    {
                        if (Session["pass"].ToString() == "true")
                        {
                            pass.Visible = true;
                            lblUpload.Text = "Merci! Les images ont été téléchargées avec succès. Nous allons maintenant commencer le processus de sélection des antécédents";
                        }
                        else
                        {
                            pass.Visible = true;
                            //lblUpload.Text = "Merci ! Les images ont été téléchargées avec succès. Pour compléter votre demande, vous devrez prouver votre identité par le biais de la Validation d’Identité Vidéo (VID). Ce processus est mené par Insurance Search Bureau of Canada (ISB) et devrait prendre environ 5 à 7 minutes. Vous devez prendre rendez-vous pour une appel vidéo pour terminer votre vérification des antécédents.<br/><br/>  <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Veuillez cliquer ici pour céduler votre appel vidéo.</button></a><br/><br/>Si vous rencontrez des problèmes, n’hésitez pas à contacter ISB pour obtenir de l’aide à ubersupport@isbglobalservices.com. <br/><br/> Pour le moment, Greenlight Hubs ne sont pas disponibles pour vous aider – en raison du Covid-19.<br/><br/>Nous apprécions votre coopération pour mener à bien le processus VID.";
                            lblUpload.Text = "Merci ! Les images ont été téléchargées avec succès. Pour compléter votre demande, vous devez prendre rendez-vous pour une appel vidéo. Ce processus est mené par Insurance Search Bureau of Canada (ISB) et devrait prendre environ 5 à 7 minutes.<br/><br/>  <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Veuillez cliquer ici pour céduler votre appel vidéo.</button></a><br/><br/>Si vous rencontrez des problèmes, n’hésitez pas à contacter ISB pour obtenir de l’aide à ubersupport@isbglobalservices.com. <br/><br/> Pour le moment, Greenlight Hubs ne sont pas disponibles pour vous aider – en raison du Covid-19.<br/><br/>Nous apprécions votre coopération pour mener à bien le processus VID.";
                        }

                    }
                    else
                    {
                        if (Session["pass"].ToString() == "true")
                        {
                            pass.Visible = true;
                            lblUpload.Text = "Thank You! The images have been uploaded successfully. We will now begin the background screening process";
                        }
                        else
                        {
                            pass.Visible = true;
                            lblUpload.Text = "Thank You! The images have been uploaded successfully. To complete your application, you will need to set up a video call appointment. This process is conducted by the Insurance Search Bureau of Canada (ISB) and should take approximately 5 - 7 minutes. <br/><br/>  <a href=\"https://outlook.office365.com/owa/calendar/ISBGLOBAL@afimacmerged.onmicrosoft.com/bookings/\"> <button type=\"button\">Please click here to schedule your video call.</button></a> <br/><br/>If you encounter any problems, please don’t hesitate to contact ISB for assistance at  ubersupport@isbglobalservices.com. <br/><br/> At this time Greenlight Hubs are unavailable to support you – due to COVID - 19. We appreciate your cooperation in completing the VID process.";
                        }
                    }
                }
                catch (Exception err)
                {
                    SendEmail("athangaraj@isbc.ca", "Upload", err.ToString());
                    //lblUploadResult.Text = "The file was not updloaded because the following error happened: " + err.ToString();
                    lblUpload.Text = "Error in Uploading the file because ";
                }
            }
            else
            {
                lblUpload.Text = "Please upload two pieces of ID to proceed";
                // lblUploadResult.Text = "No File Uploaded because none was selected.";
            }
        }

    }

    protected void saveFileToDb(byte[] bytUpfile, byte[] bytUpfile2, string guid)
    {
        string testDbConnection = ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString;
        // string testDbConnection = "Data Source=VMCorpDev1;Initial Catalog=PropertyManagement;Persist Security Info=True;User ID=ais_devel;Password=devel";
        // string strInsertStmt = string.Format("INSERT INTO [PropMgtFileAttachments] ([AttachedFileName],[CreatedBy],[CreatedDt],[AttachedFile]) VALUES ('{0}','John Doe',GETDATE(),@TestFile)", strTestFileName);
        string strInsertStmt = string.Format("insert into AIDUploadImage values (@GUID,@TestFile,@TestFile2,0, getdate())");

        using (SqlConnection conn = new SqlConnection(testDbConnection))
        {
            SqlCommand cmdCommand = conn.CreateCommand();
            cmdCommand.CommandText = strInsertStmt;
            cmdCommand.CommandType = System.Data.CommandType.Text;
            cmdCommand.Parameters.AddWithValue("@TestFile", bytUpfile);
            cmdCommand.Parameters.AddWithValue("@TestFile2", bytUpfile2);
            cmdCommand.Parameters.AddWithValue("@GUID", guid);
            cmdCommand.Connection.Open();
            cmdCommand.ExecuteNonQuery();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // SendEmail("athangaraj@isbc.ca", "BUTTON", "BUTTON");
        //lblThanks.Text = "Thank you for completing the MID process and providing your information. We will get in touch with you shortly. ";
        //pass.Visible = true;
        //fail.Visible = false;
        //AdditionalFields.Visible = false;

    }

    #region Email
    public string SendEmail(string EmailTo, string subject, string emailbody)
    {
        string headerimage;
        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT HeaderImage FROM CandidateEmail WHERE(CompanyID = @companyid)", conn))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@companyid", companyid);

        //        conn.Open();
        //        headerimage = Convert.ToString(cmd.ExecuteReader());
        //        conn.Close();


        //    }
        //}
        headerimage = ConfigurationManager.AppSettings["EmailHeader_" + companyid];
        if (String.IsNullOrEmpty(headerimage))
        {
            headerimage = "https://infosearchsite.com/search/images/isbLogoMain.jpg";
        }





        //string emailstring = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><meta content='text/html; charset=iso-8859-1' http-equiv=Content-Type><style type=text/css><!--body{background-color: #dddddd;font-family: Arial, Helvetica, sans-serif;font-size: 12px;}td{font-family: Arial, Helvetica, sans-serif;font-size: 12px;}td a{color: #0060ff;}td a:hover{color: #d30000;}img{border:none;}.titleX{font-size:20px; font-weight:bold; color:#036AAB;}.titleX2{font-size:16px; font-weight:bold;}--></style></head><body><br/>";
        //emailstring += "<table cellspacing='0' cellpadding='0' border='0' width='700' align='center' style='border:1px solid #aaaaaa; background-color:#ffffff;'>";
        //emailstring += "<tr><td style='padding-left:40px; padding-right:40px; padding-bottom:50px; padding-top:40px; '>";
        //emailstring += "<table cellspacing='0' cellpadding='0' border='0' width='100%'><tr><td style='text-align:center;background-color:white' height='80' align='center'>";
        //// emailstring += "<img src='" & ds.Tables(0).Rows(0)(9) & "' height='80'  /></td></tr>";
        ////if (companyid == 3409)
        ////{
        ////    emailstring += "<img src='http://uber-static.s3.amazonaws.com/emails/email_top.png' height='80'  /></td></tr>";
        ////}
        ////else
        ////{
        ////    emailstring += "< img src = 'https://infosearchsite.com/search/images/isbLogoMain.jpg' height='80'/></td></tr>";
        ////}
        ////else
        ////{
        ////    emailstring += "< img src = " + headerimage + "height='80'/></td></tr>";
        ////}
        //emailstring += "<img src='" + headerimage + "' height='80'/></td></tr>";



        //emailstring += "<tr><td style='text-align:right; background-color:#dddddd;border-top:4px solid #ffffff;' height='12'>";

        //emailstring += "</td></tr>";
        //            emailstring += "<tr><!-- LEFT --><td valign='top' style='text-align:justify; color:#333333;'><table>";

        //emailstring += "<tr><td>"+emailbody+"</td></tr>";
        //emailstring += "<tr><td>&nbsp;</td></tr>";

        //emailstring += "<tr><td style=\"font - size: 9.0pt; font - family: 'Arial',sans - serif;text-align:center \"><br/><br/><img src='https://infosearchsite.com/MID/Images/ISB-Global-Services-Logo-Final.jpg' height='80' width ='100' /><br /> ISB Canada<br />8160 Parkhill Drive, Milton, Ontario, L9T 5V7, Canada | <a href=\"tel: +18664160006\">1.866.416.0006</a> |  <a href=\"mailto: info @isbc.ca\">info@isbc.ca</a> | <br/>Copyright &copy; 2017 | All Rights Reserved.</td></tr>";
        //emailstring += "<tr><td style=\"font - size: 9.0pt; font - family: 'Arial',sans - serif;text-align:center \"></td></tr>";
        //emailstring += "<br/><br/>";
        //emailstring += "<tr><td style=\"font - size: 1.5pt; font - family: 'Verdana',sans - serif; color: #999999;\">This transmission contains information which may be confidential and which may also be privileged. It is intended for the named addressee only. Unless you are the named addressee, or authorized to receive it on behalf of the addressee you may not copy or use it, or disclose it to anyone else. If you have received this transmission in error please contact the sender. Thank you for your cooperation. You may opt-out from receiving CEM&rsquo;s from AFIMAC by unsubscribing&nbsp;<a href=\"http://www.afimacglobal.com/subscription/subscriptions/unsubscribe\">here</a>\"</td></tr>";


        string emailstring = emailbody;


        SmtpClient S = new SmtpClient();
        MailAddress to = new MailAddress(EmailTo);
        //MailAddress to = new MailAddress("athangaraj@isbc.ca");
        //string to = EmailTo;
        //string from = "EIDApplication@isbc.ca";
        MailAddress from = new MailAddress("ISB Canada<EIDApplication@isbc.ca>");
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);

        string[] bcc = ConfigurationManager.AppSettings["AuditEmail"].Split(',');

        foreach (string bccitem in bcc)
        {
            message.Bcc.Add(bccitem);
        }




        //message.To.Add("hsidhu@isbc.ca");
        message.IsBodyHtml = true;
        message.Body = emailstring;
        //message.Attachments.Add(new Attachment(@"C:\sites\infosearchsite.com\WS_Uploads\MID_Fail\Acceptable_ID.pdf"));
        //message.Attachments.Add(new Attachment(@"C:\sites\infosearchsite.com\WS_Uploads\MID_Fail\UBER_Android_Users_instructions.pdf"));
        //message.Attachments.Add(new Attachment(@"C:\sites\infosearchsite.com\WS_Uploads\MID_Fail\UBER_Apple_IPhone_instructions.pdf"));

        //message.AlternateViews.Add(getEmbeddedImage("/sites/infosearchsite.com/images/thanksfail.png"));

        //S.Host = "localhost";
        //S.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
        S.Host = "centos6.afimacglobal.com";
        S.Port = 25;
        S.UseDefaultCredentials = false;
        S.Credentials = new NetworkCredential("Donotreply@isbc.ca", "AFI1isb2");
        S.DeliveryMethod = SmtpDeliveryMethod.Network;
        message.Subject = subject;
        S.Send(message);

        if (!subject.Contains("AID Segment Name"))
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("WS_CheckMIDEmailTemp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter GUIID_1 = new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = 2
                };
                cmd.Parameters.Add(GUIID_1);
                SqlParameter OrderBY_1 = new SqlParameter
                {
                    ParameterName = "@OrderBy",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = companyid
                };
                cmd.Parameters.Add(OrderBY_1);
                SqlParameter GUID_1 = new SqlParameter
                {
                    ParameterName = "@GUID",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = guid
                };
                cmd.Parameters.Add(GUID_1);
                SqlParameter RunScriptIT = new SqlParameter
                {
                    ParameterName = "@RunScriptIT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = 1
                };
                cmd.Parameters.Add(RunScriptIT);
                SqlParameter EmailBody = new SqlParameter
                {
                    ParameterName = "@EmailBody",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = emailbody
                };
                cmd.Parameters.Add(EmailBody);
                SqlParameter EmailSubject = new SqlParameter
                {
                    ParameterName = "@EmailSubject",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = subject
                };
                cmd.Parameters.Add(EmailSubject);
                SqlParameter EmailFrom = new SqlParameter
                {
                    ParameterName = "@EmailFrom",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = "ISB Canada < EIDApplication@isbc.ca >"
                };
                cmd.Parameters.Add(EmailFrom);
                SqlParameter EmailTo_1 = new SqlParameter
                {
                    ParameterName = "@EmailTo",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = EmailTo
                };
                cmd.Parameters.Add(EmailTo_1);
                SqlParameter TypeID = new SqlParameter
                {
                    ParameterName = "@TypeID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = 2
                };
                cmd.Parameters.Add(TypeID);
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();

            }
        }
        return "Email Sent";
    }

    public string SendEmailWithAttachment(string EmailTo, string subject, string emailbody)
    {
        //SendEmail("athangaraj@isbc.ca", "Entered here", "");
        string headerimage;
        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT HeaderImage FROM CandidateEmail WHERE(CompanyID = @companyid)", conn))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@companyid", companyid);

        //        conn.Open();
        //        headerimage = Convert.ToString(cmd.ExecuteReader());
        //        conn.Close();


        //    }
        //}
        headerimage = ConfigurationManager.AppSettings["EmailHeader_" + companyid];
        if (String.IsNullOrEmpty(headerimage))
        {
            headerimage = "https://infosearchsite.com/search/images/isbLogoMain.jpg";
        }





        //string emailstring = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><meta content='text/html; charset=iso-8859-1' http-equiv=Content-Type><style type=text/css><!--body{background-color: #dddddd;font-family: Arial, Helvetica, sans-serif;font-size: 12px;}td{font-family: Arial, Helvetica, sans-serif;font-size: 12px;}td a{color: #0060ff;}td a:hover{color: #d30000;}img{border:none;}.titleX{font-size:20px; font-weight:bold; color:#036AAB;}.titleX2{font-size:16px; font-weight:bold;}--></style></head><body><br/>";
        //emailstring += "<table cellspacing='0' cellpadding='0' border='0' width='700' align='center' style='border:1px solid #aaaaaa; background-color:#ffffff;'>";
        //emailstring += "<tr><td style='padding-left:40px; padding-right:40px; padding-bottom:50px; padding-top:40px; '>";
        //emailstring += "<table cellspacing='0' cellpadding='0' border='0' width='100%'><tr><td style='text-align:center;background-color:white' height='80' align='center'>";
        //// emailstring += "<img src='" & ds.Tables(0).Rows(0)(9) & "' height='80'  /></td></tr>";
        ////if (companyid == 3409)
        ////{
        ////    emailstring += "<img src='http://uber-static.s3.amazonaws.com/emails/email_top.png' height='80'  /></td></tr>";
        ////}
        ////else
        ////{
        ////    emailstring += "< img src = 'https://infosearchsite.com/search/images/isbLogoMain.jpg' height='80'/></td></tr>";
        ////}
        ////else
        ////{
        ////    emailstring += "< img src = " + headerimage + "height='80'/></td></tr>";
        ////}
        //emailstring += "<img src='" + headerimage + "' height='80'/></td></tr>";

        ////emailstring += "<img src='https://infosearchsite.com/search/images/isbLogoMain.jpg' height='80'  /></td></tr>";

        //emailstring += "<tr><td style='text-align:right; background-color:#dddddd;border-top:4px solid #ffffff;' height='12'>";

        //emailstring += "</td></tr>";
        //emailstring += "<tr><!-- LEFT --><td valign='top' style='text-align:justify; color:#333333;'><table>";

        //emailstring += "<tr><td>" + emailbody + "</td></tr>";
        //emailstring += "<tr><td>&nbsp;</td></tr>";

        //emailstring += "<tr><td style=\"font - size: 9.0pt; font - family: 'Arial',sans - serif;text-align:center \"><br/><br/><img src='https://infosearchsite.com/MID/Images/ISB-Global-Services-Logo-Final.jpg' height='80' width ='100' /><br /> ISB Canada<br />8160 Parkhill Drive, Milton, Ontario, L9T 5V7, Canada | <a href=\"tel: +18664160006\">1.866.416.0006</a> |  <a href=\"mailto: info @isbc.ca\">info@isbc.ca</a> | <br/>Copyright &copy; 2017 | All Rights Reserved.</td></tr>";
        //emailstring += "<tr><td style=\"font - size: 9.0pt; font - family: 'Arial',sans - serif;text-align:center \"></td></tr>";
        //emailstring += "<br/><br/>";
        //emailstring += "<tr><td style=\"font - size: 1.5pt; font - family: 'Verdana',sans - serif; color: #999999;\">This transmission contains information which may be confidential and which may also be privileged. It is intended for the named addressee only. Unless you are the named addressee, or authorized to receive it on behalf of the addressee you may not copy or use it, or disclose it to anyone else. If you have received this transmission in error please contact the sender. Thank you for your cooperation. You may opt-out from receiving CEM&rsquo;s from AFIMAC by unsubscribing&nbsp;<a href=\"http://www.afimacglobal.com/subscription/subscriptions/unsubscribe\">here</a>\"</td></tr>";

        string emailstring = emailbody;



        SmtpClient S = new SmtpClient();
        MailAddress to = new MailAddress(EmailTo);
        //string to = EmailTo;
        //string from = "EIDApplication@isbc.ca";
        MailAddress from = new MailAddress("ISB Canada<EIDApplication@isbc.ca>");
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);

        string[] bcc = ConfigurationManager.AppSettings["AuditEmail"].Split(',');

        foreach (string bccitem in bcc)
        {
            message.Bcc.Add(bccitem);
        }

        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
        //{
        //    SqlCommand cmd = new SqlCommand("WS_CheckMIDEmailTemp", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter GUIID_1 = new SqlParameter
        //    {
        //        ParameterName = "@ID",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Size = 100,
        //        Value = 2
        //    };
        //    cmd.Parameters.Add(GUIID_1);
        //    SqlParameter OrderBY_1 = new SqlParameter
        //    {
        //        ParameterName = "@OrderBy",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Size = 100,
        //        Value = companyid
        //    };
        //    cmd.Parameters.Add(OrderBY_1);
        //    SqlParameter GUID_1 = new SqlParameter
        //    {
        //        ParameterName = "@GUID",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Size = 100,
        //        Value = guid
        //    };
        //    cmd.Parameters.Add(GUID_1);
        //    SqlParameter RunScriptIT = new SqlParameter
        //    {
        //        ParameterName = "@RunScriptIT",
        //        SqlDbType = System.Data.SqlDbType.Int,
        //        Value = 1
        //    };
        //    cmd.Parameters.Add(RunScriptIT);
        //    SqlParameter EmailBody = new SqlParameter
        //    {
        //        ParameterName = "@EmailBody",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Value = emailbody
        //    };
        //    cmd.Parameters.Add(EmailBody);
        //    SqlParameter EmailSubject = new SqlParameter
        //    {
        //        ParameterName = "@EmailSubject",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Value = "Video Identity Verification Instructions"
        //    };
        //    cmd.Parameters.Add(EmailSubject);
        //    SqlParameter EmailFrom = new SqlParameter
        //    {
        //        ParameterName = "@EmailFrom",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Value = "ISB Canada < EIDApplication@isbc.ca >"
        //    };
        //    cmd.Parameters.Add(EmailFrom);
        //    SqlParameter EmailTo_1 = new SqlParameter
        //    {
        //        ParameterName = "@EmailTo",
        //        SqlDbType = System.Data.SqlDbType.NVarChar,
        //        Value = EmailTo
        //    };
        //    cmd.Parameters.Add(EmailTo_1);
        //    SqlParameter TypeID = new SqlParameter
        //    {
        //        ParameterName = "@TypeID",
        //        SqlDbType = System.Data.SqlDbType.Int,
        //        Value = 2
        //    };
        //    cmd.Parameters.Add(TypeID);
        //    conn.Open();
        //    cmd.ExecuteScalar();
        //    conn.Close();

        //}

        //message.To.Add("hsidhu@isbc.ca");
        message.IsBodyHtml = true;
        message.Body = emailstring;
        string frontimage = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select FileName from AIDOrders as a inner join WSPackage as b on b.PackageGUID = a.AIDGUID inner join WSPackageDetails as c on c.WSPackageID = b.WSPackageID inner join WSUploadFileDetails as d on d.WSPackageDetailID = c.WSPackageDetailID where d.FileName like '%front%' and a.AIDGUID =  @guid", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@guid", guid);

                conn.Open();
                frontimage = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();



            }
        }
        //SendEmail("athangaraj@isbc.ca", "SQL EXECUTED", "");
        try
        {
            if (!String.IsNullOrEmpty(frontimage))
            {
                message.Attachments.Add(new Attachment(frontimage));
                // SendEmail("athangaraj@isbc.ca", "IMAGE ADDED", frontimage);
            }
        }
        catch
        {

        }
        //message.Attachments.Add(new Attachment(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "HTMLFiles\\" + "HTML_" + guid + ".html"));
        message.Attachments.Add(new Attachment(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin\\" + "PDF_" + guid + ".pdf"));
        //SendEmail("athangaraj@isbc.ca", "HTML ADDED", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "HTMLFiles\\" + "HTML_" + guid + ".html");



        //message.Attachments.Add(new Attachment(@"C:\sites\infosearchsite.com\WS_Uploads\MID_Fail\UBER_Android_Users_instructions.pdf"));
        //message.Attachments.Add(new Attachment(@"C:\sites\infosearchsite.com\WS_Uploads\MID_Fail\UBER_Apple_IPhone_instructions.pdf"));

        //message.AlternateViews.Add(getEmbeddedImage("/sites/infosearchsite.com/images/thanksfail.png"));

        //S.Host = "localhost";
        //S.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
        S.Host = "centos6.afimacglobal.com";
        S.Port = 25;
        S.UseDefaultCredentials = false;
        S.Credentials = new NetworkCredential("Donotreply@isbc.ca", "AFI1isb2");
        S.DeliveryMethod = SmtpDeliveryMethod.Network;
        message.Subject = subject;
        S.Send(message);
        return "Email Sent";
    }



    #endregion


}