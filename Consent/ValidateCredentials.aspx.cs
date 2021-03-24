using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using System.Text;
using System.Globalization;
using System.Configuration;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Security;
using System.Collections;
using Codaxy.WkHtmlToPdf;
using System.Security.Cryptography;
using System.Collections.Specialized;

public partial class ValidateCredentials : System.Web.UI.Page 
 
{
    #region Declaration
    string driveruuid;
    string firstname;
    string middlename;
    string lastname;
    string dateofbirth;
    string pdl;
    string email;
    string package ;
    string dategenerated ;
    int companyid =1;
    string GUID = "";
    string segmentname = "";
    DateTime TransactionTime ;
    string lan = "FR";
    string duplicateguid;
    string duplicatesegmentname;
    string duplicatetransid;
    int ordercount ;



    string date2;
    string offence2;
    string location2;

    string date3;
    string offence3;
    string location3;

    string date4;
    string offence4;
    string location4;

    string date5;
    string offence5;
    string location5;

    string date6;
    string offence6;
    string location6;


    string date7;
    string offence7;
    string location7;


    string date8;
    string offence8;
    string location8;

    string date9;
    string offence9;
    string location9;
    string ISB_DOMAIN_NAME;
    static string DATABASE_CONNECTION;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        lblFirstName.Visible = false;
        lblMiddleName.Visible = false;
        lblSurname.Visible = false;
        lblUserID.Visible = false;

        string querystring = "";
        string input = "";
        string landing = "";
        string querystrCapture = "";
        string querystrCaptureHash = "";
        string querystrCaptureDecrypted = "";

        Configuration configuration = new Configuration();
        DATABASE_CONNECTION = configuration.GetConnectionString();
        ISB_DOMAIN_NAME = configuration.GetISBDomainName();

        try
        {
            #region "capture payload"
            querystrCapture = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);
            if (Request.QueryString["querystring"] != null)
            {
                querystrCapture = Request.QueryString["querystring"];
            }
            try
            {
                byte[] fernetkey = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
                querystrCaptureDecrypted = Decrypt.DecryptFernet(fernetkey, querystrCapture);
            } 
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    querystrCaptureDecrypted = Decryptt(HttpUtility.UrlDecode(querystrCapture), "dxW0k2P8");
                }
                catch(Exception ex2)
                {
                    Console.WriteLine("Error: " + ex2.Message);
                }
            }
            if (querystrCaptureDecrypted != "" && querystrCaptureDecrypted != null)
            {
                try
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] inputBytes = Encoding.ASCII.GetBytes(querystrCapture);
                        byte[] hashBytes = md5.ComputeHash(inputBytes);

                        // Convert the byte array to hexadecimal string
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < hashBytes.Length; i++)
                        {
                            sb.Append(hashBytes[i].ToString("X2"));
                        }
                        querystrCaptureHash = sb.ToString();
                    }
                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[MIDRAWPayload] ([QueryString],[QueryStringDecrypted],[MD5Hash],[IPAddress],[CreatedOn]) VALUES (@QueryString, @QueryStringDecrypted, @MD5Hash, @IPAddress, getdate())", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@QueryString", querystrCapture);
                            cmd.Parameters.AddWithValue("@QueryStringDecrypted", querystrCaptureDecrypted);
                            cmd.Parameters.AddWithValue("@MD5Hash", querystrCaptureHash);
                            cmd.Parameters.AddWithValue("@IPAddress", GetIPAddress());
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                catch(Exception exSql1)
                {

                }
            }
            #endregion

            #region "Redirect"

            // This block to upload an image
            if (Request.QueryString["uploadimgid"] != null)
            {
                Server.Transfer("uploadimage.aspx?uploadimgid=" + Request.QueryString["uploadimgid"]);
            }

            //Redirects to Thanks Page if uid parameter is present
            if (Request.QueryString["uid"] != null)
            {                
                Thread.Sleep(10000);
                
                string uid = Request.QueryString["UID"];                
                //Response.Redirect("https://www.infosearchsite.com/MID_Test/thanks.aspx?uid=" + uid);
                Server.Transfer("thanks.aspx?uid=" + uid+"&uploadimgid="+uid);
               // SendEmail("athangaraj@isbc.ca", "3", "3");
            }

            //Redirects to Thanks Page if GUID parameter is present
            if (Request.QueryString["guid"] != null)
            {                
                Thread.Sleep(10000);
                string uid = Request.QueryString["GUID"];                
                //Response.Redirect("https://www.infosearchsite.com/MID_Test/thanks.aspx?uid=" + uid);
                Server.Transfer("thanks.aspx?uid=" + uid);

               // SendEmail("athangaraj@isbc.ca", "4", "4");
            }
            

            //Redirects to AID Page if Instructionid parameter is present
            if(Request.QueryString["Instructionid"] != null)
            {
               

                string AIDGUID = Request.QueryString["InstructionID"];
               // SendEmail("athangaraj@isbc.ca", "bp4", AIDGUID);
                string compid = Request.QueryString["companyid"];
                if (compid == null)
                {
                    compid = "0";
                }
                string lang = Request.QueryString["lang"];
                if(lang == "FR")
                {
                    Session["lang"] = "FR";
                }
                else
                {
                    Session["lang"] = "EN";
                }
                                 

                DataSet ds1 = new DataSet();
                using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0,"+compid+") order by companyid desc", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                        da1.Fill(ds1);

                    }
                }

                //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID+"&docType="+ds1.Tables[0].Rows[0]["DocType"].ToString()+"&accountCode="+ds1.Tables[0].Rows[0]["AccountCode"].ToString()+"&lang="+lang, false); old
                //Response.Redirect("https://auth.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false); uber

                //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID="+AIDGUID+"&accountCode=12346&docType=00&lang="+Session["lang"]);


                //Stable version
                Response.Redirect(ISB_DOMAIN_NAME + "/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);

                //Test version
               // Response.Redirect("https://authtest.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);


                if (Session["pdl"].ToString().Contains("driver"))
                {
                    
                    //Response.Redirect("https://authtest.isbc.ca/v4/default.html?GUID=" + AIDGUID + "&docType=0&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);
                }
                else
                {
                    //AID 4.0
                    //Response.Redirect("https://authtest.isbc.ca/v4/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);

                    // https://authtest.isbc.ca/default.html?GUID=[GUID]&docType=1&accountCode=1234&lang=EN

                    // Response.Redirect("https://authtest.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);

                    // Response.Redirect("https://auth.isbc.ca/v312/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);


                }



                return;
            }

            //Redirects to Landing Page
            if(Request.QueryString["landing"] !=null)
            {
               
                string querystr = Request.QueryString["querystring"];
                string firstname = Request.QueryString["firstname"];
                if (firstname == null)
                {
                    firstname = Session["firstname"].ToString();
                }
                if (Request.QueryString["landing"] == "yes")
                {
                    //Server.Transfer("instructions.aspx?landingpage=yes&querystring=" + querystr); uberrideshare
                }
            }
            if(Request.QueryString["Uploadimgid"] !=null)
            {
                string imgaidgud = Request.QueryString["Uploadimgid"];
                Server.Transfer("UploadImage.aspx?uploadimgid=" + imgaidgud);
            }

            #endregion


            if (!IsPostBack)
            {
                #region Check if Mobile Browser or Not
                if (false)
                {
                    // go to mobile pages
                    Response.Redirect("https://authenticate.isbc.ca/webui/default.html");
                }
                else
                {
                    ordercount = 0;
                    #region " Link Decryption"
                    byte[] key = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
                    querystring = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);
                    string url1 = Request.Url.AbsoluteUri.Split('?')[0];
                    

                    if(Request.QueryString["querystring"]!=null)
                    {
                        string q = Request.QueryString["querystring"];
                        input = Decrypt.DecryptFernet(key, Request.QueryString["querystring"]);
                    }
                    else
                    {
                        input = Decrypt.DecryptFernet(key, querystring);
                    }
                    #endregion
                    //string url = url1 + "?" + input;

                    #region "Assign Companyid"
                    var query = HttpUtility.ParseQueryString(input);
                    var driverid = query.Get("driveruuid");
                    
                    if (driverid == null)
                    {
                        companyid = Convert.ToInt32(query.Get("companyid"));
                        Session["companyid"] = Convert.ToInt32(query.Get("companyid"));
                    }
                    else
                    {
                        
                        if(query.Get("companyid") != null)
                        { 
                            companyid = Convert.ToInt32(query.Get("companyid"));
                            Session["companyid"] = Convert.ToInt32(query.Get("companyid"));
                        }
                        else
                        {
                            if (query.Get("pdl") != null || query.Get("package") != null)
                            {
                                if(query.Get("pdl") == "bike" || query.Get("package") == "bike")
                                {
                                    companyid = 3480;
                                    Session["companyid"] = 3480;
                                }
                                else
                                {
                                    companyid = 3409;
                                    Session["companyid"] = 3409;
                                }
                            }
                            else
                            {
                                companyid = 3409;
                                Session["companyid"] = 3409;
                            }
                        }
                    }


                    if (query.Get("package") != null)
                    {
                        if (query.Get("package") == "bike")
                        {
                            companyid = 3480;
                            Session["companyid"] = 3480;
                        }
                        else if (query.Get("package") == "RS")
                        {
                            companyid = 3653;
                            Session["companyid"] = 3653;
                        }
                        else
                        {
                            if (companyid != 3391 && Session["companyid"] == null)
                            {

                                companyid = 3409;
                                Session["companyid"] = 3409;
                            }
                        }
                            
                    }
                    else
                    {
                        companyid = 3409;
                        Session["companyid"] = 3409;
                    }


                    if (Session["companyid"] != null)
                    {

                            bool MVRCheck = MVRCheckboxCheck(Convert.ToInt32(Session["companyid"]));
                            if (MVRCheck == false)
                            {
                                divMVRCheck.Visible = false;
                                chkConsent.Checked = true;
                            }
                        try
                        {
                            if (Convert.ToInt32(Session["companyid"]) == 3391 || Convert.ToInt32(Session["companyid"]) == 3439 || Convert.ToInt32(Session["companyid"]) == 3767 || Convert.ToInt32(Session["companyid"]) == 3769)
                            {
                                divoffense.Visible = true;
                            }

                        }
                        catch
                        {

                        }
                                                 
                    }
                    else
                    {
                        divMVRCheck.Visible = false;
                        chkConsent.Checked = true;
                    }
                    #endregion

                    driveruuid = query.Get("driveruuid");
                    firstname = query.Get("firstname");
                    middlename = query.Get("middlename");
                    lastname = query.Get("lastname");
                    dateofbirth = query.Get("date_of_birth");
                    pdl = query.Get("pdl");
                    email = query.Get("email");
                    package = query.Get("package");
                    dategenerated = query.Get("dategenerated");

                    //lblFirstName.InnerText = query.Get("firstname");
                    //lblSurname.InnerText = query.Get("lastname");

                    Session["driveruuid"] = query.Get("driveruuid");
                    Session["firstname"] = query.Get("firstname");
                    Session["middlename"] = query.Get("middlename");
                    Session["lastname"] = query.Get("lastname");
                    Session["dateofbirth"] = query.Get("date_of_birth");
                    Session["pdl"] = query.Get("pdl");
                    Session["email"] = query.Get("email");
                    Session["package"] = query.Get("package");
                    Session["dategenerated"] = query.Get("dategenerated");
                    Session["province"] = query.Get("prov");
                    Session["productid"] = query.Get("productid");
                    Session["langquery"] = query.Get("lang");
                    Session["lang"] = query.Get("lang");



                    string Package;
                    String sDate = DateTime.Now.ToString();
                    DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                    String dy = datevalue.Day.ToString();
                    String mn = datevalue.Month.ToString();
                    String yy = datevalue.Year.ToString();

                    Package = "<ProductData>";
                    Package += "<isb_FN>" + Session["firstname"] + "</isb_FN>";
                    Package += "<isb_LN>" + Session["lastname"] + "</isb_LN>";
                    Package += "<isb_Ref>" + "1993" + "</isb_Ref>";
                    Package += "<isb_DOL>" + yy + "-" + mn + "-" + dy + "</isb_DOL>";
                    Package += "<isb_Prov>" + "ON" + "</isb_Prov>";
                    Package += "<isb_UserID>" + ConfigurationManager.AppSettings["UserID_" + Session["companyid"]] + "</isb_UserID>";
                    Package += "</ProductData>";


                    Session["packagepayload"] = Package;


                    if(Session["province"]!= null)
                    {
                        if(Session["province"].ToString() == "QC")
                        {
                            Session["lang"] = "FR";
                        }
                        else
                        {
                            Session["lang"] = "EN";
                        }


                    }
                    if(Session["langquery"]!= null)
                    {
                        if(Session["langquery"].ToString() == "FR")
                        {
                            Session["lang"] = "FR";
                        }
                        else if(Session["langquery"].ToString()=="EN")
                        {
                            Session["lang"] = "EN";
                        }
                    }


                    if ((DateTime.Now - Convert.ToDateTime(dategenerated)).TotalDays > 7  && Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS" && Session["pdl"].ToString() == "RQ")
                    {
                        totalbody.Visible = false;
                        lblErrors.Text = "This link is older than 7 days. Please request a new link";

                        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[UberExpiredLinks]    ([payload],[driveruuid],[statusid],[transdt])    VALUES (@payload,@driveruuid,0,getdate())", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@payload", GetPayload());
                                cmd.Parameters.AddWithValue("@driveruuid", Session["driveruuid"].ToString());



                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                //string browser = Request.Browser.Type.ToString();
                            }
                        }

                    }

                    //if (Session["province"] != null)
                    //{
                    #region "French wording"
                    if (Session["lang"].ToString() == "FR")
                        {

                            lblSurname.InnerText = "Nom de famille";
                            lblFirstName.InnerText = "Prénom";
                            lblMiddleName.InnerText = "Second prénom";                           
                            lbl5.InnerText = "formulaire de consentement et de déclaration ";
                            labelcheckbox1.InnerText = "Je reconnais avoir lu le formulaire de consentement";
                            labelchkbox2.InnerText = "En cochant cette case, vous fournissez à  ISB Canada votre consentement électronique pour apposer votre signature saisie ici sur le formulaire de consentement du dossier de conducteur provincial.";
                            
                            Button1.Text = "Cliquez ici pour continuer";
                           
                            lbl11.InnerText = "C. Consentement informé";
                            lbl12.InnerText = "AUTORISATION DE RECHERCHE – PAR LA PRÉSENTE, JE CONSENS À LA VÉRIFICATION du Répertoire national des casiers judiciaires selon les noms, la date de naissance, " +
                                "le lieu d’utilisation et le casier judiciaire que j’ai déclaré. Je reconnais que cette vérification du Répertoire national des casiers judiciaires n’est pas confirmée par la " +
                                "comparaison d’empreintes digitales, laquelle est la véritable façon de confirmer si un casier judiciaire existe dans le Répertoire national des casiers judiciaires.";
                            lbl13.InnerText = "SYSTÈMES D’INFORMATION DE LA POLICE – PAR LA PRÉSENTE, JE CONSENS À LA VÉRIFICATION des systèmes d’information de la police, qui fait partie d’une vérification du" +
                                " Centre d’information de la police et qui consiste à vérifier les systèmes suivants : (cocher dans le cas échéant) :";
                            lbl14.InnerText = "Banque de données d’enquêtes du CIPC";
                            lbl15.InnerText = "Portail d’informations policières (PIP)";
                            lbl16.InnerHtml = "<strong>AUTORISATION ET RENONCIATION</strong>  de fournir une confirmation du casier judiciaire ou tout renseignement de la police." +
                                "Je certifie que les renseignements que j’ai fournis dans la présente demande sont vrais et exacts à ma connaissance. J’accepte la divulgation des résultats de la vérification du casier judiciaire à " +
                                "<strong>ISB Canada</strong>, située à Toronto, Ontario Canada";
                            lbl18.InnerText = "Par les présentes, je dégage et pour toujours tous les membres et tous les employés des services policiers effectuant la recherche de tout procès, toutes " +
                                "réclamations ou demandes de dommages, de perte ou de préjudice que je pourrais subir par la suite ou en raison de la divulgation des renseignements par les services policiers de Cobourg à ISB Canada, Milton, Ontario.";
                            lbl19.InnerText = "Je consens";
                           
                            div2.InnerText = "";

                            divStep1.InnerText = "Étape 1";
                            divconsanddec.InnerText = "Donner votre consentement et votre déclaration";
                            divreadthe.InnerText = "Lire le ";
                            divthengive.InnerText = "et apposer votre signature ci-dessous";
                            footer.InnerText = "Droit d’auteur © 2018 ISB Canada, Tous droits réservés";
                            technicaldifficulties.InnerText = "Si vous rencontrez des difficultés techniques, appelez-nous au 1-800-295-5732";

                            bannerimg.Src = "Images/banner_fr.png";


                            //lbl8.InnerHtml = "<input type=\"checkbox\" id=\"chkAgree\" name=\"chkAgree\" runat=\"server\" style=\"margin - left:4px\" /> Je reconnais avoir lu le formulaire de consentement";

                            //lbl9.InnerHtml = "<input type=\"checkbox\" id=\"chkConsent\" name=\"chkConsent\" runat=\"server\" style=\"display: inline - block; margin - left:-12px\" />En cochant cette case, vous fournissez à  ISB Canada votre consentement électronique pour apposer votre signature saisie ici sur le formulaire de consentement du dossier de conducteur provincial.";
                            
                        }
                    #endregion

                    if (Session["province"] != null && Session["package"] != null)
                    {
                        if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                        {
                            // lblSurname.InnerText = "Nom de famille";
                            //lblFirstName.InnerText = "Prénom";
                            //lblMiddleName.InnerText = "Second prénom";
                            //lbl5.InnerText = "formulaire de consentement et de déclaration ";
                            //labelcheckbox1.InnerText = "Je reconnais avoir lu le formulaire de consentement";
                            //labelchkbox2.InnerText = "En cochant cette case, vous fournissez à  ISB Canada votre consentement électronique pour apposer votre signature saisie ici sur le formulaire de consentement du dossier de conducteur provincial.";

                            //Button1.Text = "Cliquez ici pour continuer";
                            if (Session["lang"].ToString() == "FR")
                            {
                                lbl11.InnerText = "CONSENTEMENT DE LA PERSONNE QUI FAIT L’OBJET D’UNE VÉRIFICATION POLICIÈRE";
                                lbl12.InnerText = "Je, soussigné(e), en tant que :Partenaire - chauffeur(UBER)" +
                                    "autorise le Service de police de la Ville de Blainville à vérifier tous les renseignements qui peuvent révéler un empêchement à mon " +
                                    "sujet, c’est - à - dire tout renseignement concernant une déclaration de culpabilité ou une mise en accusation pour une infraction criminelle " +
                                    "ou un acte criminel : " +
                                    "• commis grâce à l’exploitation d’un service de transport par taxi ou à l’occasion de l’exploitation d’un service de transport rémunéré de " +
                                    "personnes; " +
                                    "• ayant un lien avec les aptitudes requises et la conduite nécessaire pour exercer le métier de chauffeur de taxi ou avec les aptitudes " +
                                    "requises et la conduite nécessaire pour effectuer des services de transport rémunéré de personnes; ou " +
                                    "• concernant le trafic de stupéfiants, leur importation ou leur exportation et la culture de pavot et de chanvre indien et visés selon le cas " +
                                    "aux articles 5, 6 et 7 de la Loi réglementant certaines drogues et autres substances. " +
                                    "Pour ce faire, je consens à ce que le Service de police de la Ville de Blainville fasse ces vérifications dans tous les dossiers et banques " +
                                    "de données qui lui sont accessibles, ces vérifications couvrant la période des cinq(5) dernières années jusqu’à ce jour. " +
                                    "Si j’ai coché l’une des 4 cases de la présente section, je consens également à ce que soit communiqué au Bureau du taxi et du " +
                                    "remorquage / UBER / SAAQ le certificat de recherche négative me concernant, le cas échéant. " +
                                    "Enfin, je comprends que seule une recherche effectuée à l’aide de mes empreintes digitales permet d’établir mon identité avec " +
                                    "exactitude. " +
                                    "J’autorise également le Service de police de la Ville de Blainville à vérifier ou à utiliser les renseignements recueillis à mon sujet et à les " +
                                    "communiquer, au besoin, à toute personne, organisme public ou privé ou tout corps de police canadien dont l’assistance peut être " +
                                    "nécessaire pour les valider ou les compléter. " +
                                    "Au même titre, j’autorise toute personne, tout organisme public ou privé ou tout autre corps de police canadien à communiquer au " +
                                    "Service de police de la Ville de Blainville tout renseignement personnel me concernant qu’ils jugeront utile de transmettre pour " +
                                    "compléter la vérification demandée. " +
                                    "Finalement, j’autorise le Service de police de la Ville de Blainville à envoyer à mon adresse courriel privée, ci-haut mentionnée, mon " +
                                    "certificat de recherche positive, le cas échéant.";

                                lbl13.InnerText = "";
                                lbl14.InnerText = "";
                                lbl15.InnerText = "";
                                lbl16.InnerHtml = "";
                                lbl18.InnerText = "";
                                lbl19.InnerText = "Je consens";
                            }
                            else
                            {
                                lbl11.InnerText = "CONSENT OF PERSON WHO IS SUBJECT TO POLICY AUDIT";
                                lbl12.InnerText = "I, the undersigned, as a:" +
                                    "• Driver - partner(Uber)" +
                                    "authorize the Service de police de la Ville de Blainville to verify all the information which could show the existence of an impediment, " +
                                    "i.e., any information relating to a conviction, finding of guilt or charge relating to a criminal offence or an indictable offence:" +
                                    "•	committed in connection with the operation of remunerated passenger transportation services;" +
                                    "•	connected with the aptitudes and conduct required to provide remunerated passenger transportation services" +
                                    " or to carry on the occupation of taxi driver;" +
                                    "•	related to the traffic of narcotics, their importation or exportation as well as poppy and cannabis production," +
                                    " and provided for as the case may be in sections 5, 6 and 7 of the Controlled Drugs and Substances Act(S.C. 1996, c. 19)." +
                                    "For this purpose, I authorize that the Service de police de la Ville de Blainville make the verifications in all records " +
                                    "and data banks it has access to.The verification will cover a period of 5 years from the date of application." +
                                    "If I have marked one of the 4 checkboxes in this section, I also consent that a negative search certificate related to my person, " +
                                    "if any, be communicated to the Bureau du taxi, the SAAQ or Uber(in the case of driver-partners)." +
                                    "I also understand that only a fingerprint search can establish my identity with full accuracy." +
                                    "I also authorize the Service de police de la Ville de Blainville to verify and use the information obtained and to communicate them," +
                                    " if required, to any person, public or private body or to any Canadian police force, the assistance of which may be necessary " +
                                    "to validate or complete the information." +
                                    "I also authorize any person, any public or private body or any Canadian police force to communicate to the Service de police de la Ville de Blainville " +
                                    "any personal information about me the transfer of which which they could deem useful for the purpose of completing the search." +
                                    "Finally, I authorize the Service de police de la Ville de Blainville to send to my private email address, " +
                                    "listed above, my positive search certificate(if any).";

                                lbl13.InnerText = "";
                                lbl14.InnerText = "";
                                lbl15.InnerText = "";
                                lbl16.InnerHtml = "";
                                lbl18.InnerText = "";
                                lbl19.InnerText = "I agree";
                            }

                            div2.InnerText = "";

                           // divStep1.InnerText = "Étape 1";
                            //divconsanddec.InnerText = "Donner votre consentement et votre déclaration";
                            //divreadthe.InnerText = "Lire le ";
                            //divthengive.InnerText = "et apposer votre signature ci-dessous";
                            //footer.InnerText = "Droit d’auteur © 2018 ISB Canada, Tous droits réservés";
                            //technicaldifficulties.InnerText = "Si vous rencontrez des difficultés techniques, appelez-nous au 1-800-295-5732";

                            //bannerimg.Src = "Images/banner_fr.png";

                        }
                    }
                    //}


                    lblFirstName.InnerText = firstname;
                    lblMiddleName.InnerText = middlename;
                    lblSurname.InnerText = lastname;
                    lblUserID.InnerText = companyid.ToString();
                    //if (Session["lastname"] != null)
                    //{                        
                    //    lblSurname.InnerText = Session["lastname"].ToString();
                    //}
                    //if (Session["middlename"] != null)
                    //{
                    //    lblMiddleName.InnerText = Session["middlename"].ToString();
                    //}
                    //if (Session["firstname"] != null)
                    //{
                    //    lblFirstName.InnerText = Session["firstname"].ToString();
                    //}

                    segmentname = "";
                    string payload = GetPayload();
                    if (IsPayloadOlderThan(payload))
                    {
                        Response.Redirect("~/Failed.aspx?msg=link_expired");
                        return;
                    }
                    bool doesexist = CheckForDuplicateOnLoad(payload);
               
                    if (doesexist == true)
                    {
                        if (segmentname != "Link Clicked" && segmentname != "ISB_1" && segmentname != "ISB_2" && segmentname != "ISB_3")
                        {
                            totalbody.Visible = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString() == "FR")
                                {
                                    lblAlreadyUsed.Text = "Vous avez déjà utilisé ce lien pour la vérification";
                                    lblErrors.Text = "Vous avez déjà terminé ce";
                                }
                                else
                                {
                                    lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                    lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                                }
                            }
                            else
                            {
                                lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                            }
                        }

                    }
                    else
                    {
                        byte[] dummy = new byte[0];
                        InsertAIDOrder(payload, companyid, GetIPAddress(), "", "", dummy, "");
                    }

                    if ((DateTime.Now - TransactionTime).TotalMinutes<30 && segmentname == "ISB_1" || (DateTime.Now - TransactionTime).TotalMinutes < 30 && segmentname == "ISB_2")
                    {
                        //totalbody.Visible = false;
                        //if (Session["province"] != null)
                        //{
                        //    if (Session["province"].ToString() == "QC")
                        //    {
                        //        lblAlreadyUsed.Text = "Ce lien est déjà actif. Veuillez essayer après trente minutes";
                        //    }
                        //    else
                        //    {
                        //        lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                        //    }
                        //}
                        //else
                        //{
                        //    lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                        //}
                            
                    }
                    if(segmentname == "ISB_1")
                    {
                        string email2 = Session["email"].ToString();
                        string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                        string result = System.Text.RegularExpressions.Regex.Replace(email2, pattern, m => new string('X', m.Length));
                        //string result = "";
                        totalbody.Visible = false;
                        othermessage.InnerHtml = "Oops!  We noticed that your device is having trouble with this link!<br/> We’ve sent the link to your "+result+"  account.<br/>  Please check your email and click the link to complete the process! If you have any trouble please call 1.800.295.5732 and we’d be happy to help you over the phone.";

                        DataSet ds1 = new DataSet();
                        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0," + Session["companyid"].ToString() + ") order by companyid desc", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                da1.Fill(ds1);

                            }
                        }
                        string redirectlink = ISB_DOMAIN_NAME + "/v4/default.html?GUID=" + GUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"].ToString();

                        string emailbody = "Dear "+Session["firstname"].ToString()+ "<br/>Thank you for your attempt at the ID validation!We noticed your device was having trouble with the ID verification process.<br/> Please click <a href='"+redirectlink+"'> here </a> to complete the process. Make sure your smart device’s camera has access!You will need to take photos of your Driver’s License and a Selfie to complete the process. If you have any difficulties please call 1.800.295.5732 and we’d be happy to help you over the phone.";
                        if (Request.QueryString["landingpage"] == "yes")
                        {
                            SendEmailToPartner(email2, "MID Link", emailbody, Session["companyid"].ToString(), GUID);
                        }
                        //if (Session["province"] != null)
                        //{
                        //    if (Session["province"].ToString() == "QC")
                        //    {
                        //        lblAlreadyUsed.Text = "Vous avez dépassé le nombre maximal d'essais pour ce processus";
                        //    }
                        //    else
                        //    {
                        //        lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                        //    }
                        //}
                        //else
                        //{
                        //    lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                        //}
                    }
                    if (Request.QueryString["landingpage"] != "yes")
                    {
                        //if (Convert.ToInt32(Session["companyid"]) == 3653)
                        //{
                        //    if (Session["province"] != null)
                        //    {
                        //        if (Session["province"].ToString() == "QC")
                        //        {
                        //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=3653");
                        //        }
                        //        else
                        //        {
                        //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=3653");
                        //        }
                        //    }

                        //}
                        //if (Convert.ToInt32(Session["companyid"]) == 3391)
                        //{
                        //    if (Session["province"] != null)
                        //    {
                        //        if (Session["province"].ToString() == "QC")
                        //        {
                        //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=3391");
                        //        }
                        //        else
                        //        {
                        //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=3391");
                        //        }
                        //    }

                        //}

                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString() == "FR")
                            {
                                Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=" + Session["companyid"]);
                            }
                            else
                            {

                                Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=" + Session["companyid"]);
                            }
                            //if (Session["province"].ToString() == "QC")
                            //{
                            //    Server.Transfer("https://authenticated.isbc.ca/landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=" + Session["companyid"]);
                            //}
                            //else
                            //{

                            //    Server.Transfer("https://authenticated.isbc.ca/landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=" + Session["companyid"]);
                            //}
                        }



                    }

                    if (Convert.ToInt32(Session["companyid"]) == 3391 )
                    {
                        divreadthegoogle.InnerText = "Click on the link below to read the consent form and declare any previous offenses. Declaring offenses is optional but strongly recommended for confirming background check results.";
                        divreadthe.InnerText = "";
                        
                        lbl5google.InnerHtml = "<br/><br/>Click here to view consent and declare offenses";
                        lbl5.InnerText = "";
                        divthengive.InnerText = "";
                    }




                }
            }
        }
        catch(Exception ex)
        {
            try
            {
                string input1 = "";
                string url1 = "";
                querystring = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);

                if (Session["googlequerystring"] == null)
                {
                    Session["googlequerystring"] = querystring;
                }

                    input1 = Decryptt(HttpUtility.UrlDecode(querystring), "dxW0k2P8");
                    url1 = Request.Url.AbsoluteUri.Split('?')[0];

                if (input1.StartsWith("The input is not a valid B"))
                {
                    querystring = Session["googlequerystring"].ToString();
                    input1 = Decryptt(HttpUtility.UrlDecode(querystring), "dxW0k2P8");
                    url1 = Request.Url.AbsoluteUri.Split('?')[0];
                }
                

                
                


                string url = url1 + "?" + input1;

                Uri myuri = new Uri(url);
                var query = HttpUtility.ParseQueryString(input1);

                #region Populate Screen and Check Duplicates
                if (query.Get("ISBGUID") != null)
                {
                    Session["companyid"] = Convert.ToInt32(query.Get("companyid"));
                    Session["firstname"] = query.Get("firstname");
                    Session["middlename"] = query.Get("middlename");
                    Session["lastname"] = query.Get("lastname");
                    Session["dateofbirth"] = query.Get("date_of_birth");
                    string dob = Session["dateofbirth"].ToString().Replace('/', '-');
                    Session["pdl"] = query.Get("pdl");
                    string pdl = query.Get("pdl");
                    Session["email"] = query.Get("email");
                    Session["package"] = query.Get("package");
                    Session["dategenerated"] = query.Get("dategenerated");
                    Session["province"] = query.Get("prov");
                    Session["ISBGUID"] = query.Get("ISBGUID");
                    Session["lang"] = query.Get("lang");

                    if (Session["lastname"] != null)
                    {
                        //txtSurname.Value = Session["lastname"].ToString();
                        lblSurname.InnerText = Session["lastname"].ToString();
                    }
                    if (Session["middlename"] != null)
                    {
                        //txtMiddleName.Value = Session["middlename"].ToString();
                        lblMiddleName.InnerText = Session["middlename"].ToString();
                    }
                    if (Session["firstname"] != null)
                    {
                        //txtFirstname.Value = Session["firstname"].ToString();
                        lblFirstName.InnerText = Session["firstname"].ToString();
                    }
                    segmentname = "";

                    if (Convert.ToInt32(Session["companyid"]) == 3391 || Convert.ToInt32(Session["companyid"]) == 3439 || Convert.ToInt32(Session["companyid"]) == 3767 || Convert.ToInt32(Session["companyid"]) == 3769)
                    {
                        string payload = GetPayloadPinkerton();
                        //bool doesexist = CheckForDuplicate(payload);
                        bool doesexist = CheckForDuplicateOnLoad(payload);

                        //bool pinkertonduplicate = PinkertonDuplicateCheck(Session["email"].ToString());

                        if (Session["companyid"] != null)
                        {

                            bool MVRCheck = MVRCheckboxCheck(Convert.ToInt32(Session["companyid"]));
                            if (MVRCheck == false)
                            {
                                divMVRCheck.Visible = false;
                                chkConsent.Checked = true;
                            }
                            try
                            {
                                if (Convert.ToInt32(Session["companyid"]) == 3391 || Convert.ToInt32(Session["companyid"]) == 3439 || Convert.ToInt32(Session["companyid"]) == 3767 || Convert.ToInt32(Session["companyid"]) == 3769)
                                {
                                    divoffense.Visible = true;
                                }
                            }
                            catch
                            {

                            }
                        }
                        if (doesexist == true)
                        {
                            //if (segmentname != "Link Clicked")
                            if (segmentname != "Link Clicked" && segmentname != "ISB_1" && segmentname != "ISB_2" && segmentname != "ISB_3")
                            {
                                totalbody.Visible = false;
                                if (Session["province"] != null)
                                {
                                    if (Session["province"].ToString() == "QC")
                                    {
                                        lblAlreadyUsed.Text = "Vous avez déjà utilisé ce lien pour la vérification";
                                        lblErrors.Text = "Vous avez déjà terminé ce";
                                    }
                                    else
                                    {
                                        lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                        lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                                    }
                                }
                                else
                                {
                                    lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                    lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                                }
                            }

                        }
                        else
                        {


                            bool pinkertonduplicateresult = PinkertonDuplicateCheck(Session["firstname"].ToString(), Session["lastname"].ToString(), dob, Session["ISBGUID"].ToString(), payload);

                            if (pinkertonduplicateresult == false)
                            {
                                byte[] dummy = new byte[0];
                                InsertAIDOrder(payload, Convert.ToInt32(Session["companyid"]), GetIPAddress(), "", "", dummy, "");
                            }
                            else
                            {
                                //display duplicate message here
                                totalbody.Visible = false;
                                lblAlreadyUsed.Text = "Thank you for your interest in Google.  You’ve already provided your consent on a previous application and it is still valid. We will use that consent with this application.";

                            }

                            //byte[] dummy = new byte[0];
                            //InsertAIDOrder(payload, 3391, GetIPAddress(), "", "", dummy, "");
                        }
                        if ((DateTime.Now - TransactionTime).TotalMinutes < 30 && segmentname == "ISB_1" || (DateTime.Now - TransactionTime).TotalMinutes < 30 && segmentname == "ISB_2")
                        {
                            //totalbody.Visible = false;
                            //if (Session["province"] != null)
                            //{
                            //    if (Session["province"].ToString() == "QC")
                            //    {
                            //        lblAlreadyUsed.Text = "Ce lien est déjà actif. Veuillez essayer après trente minutes";
                            //    }
                            //    else
                            //    {
                            //        lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                            //    }
                            //}
                            //else
                            //{
                            //    lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                            //}

                        }
                        if (segmentname == "ISB_3")
                        {
                            //totalbody.Visible = false;
                            //if (Session["province"] != null)
                            //{
                            //    if (Session["province"].ToString() == "QC")
                            //    {
                            //        lblAlreadyUsed.Text = "Vous avez dépassé le nombre maximal d'essais pour ce processus";
                            //    }
                            //    else
                            //    {
                            //        lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                            //    }
                            //}
                            //else
                            //{
                            //    lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                            //}
                        }
                        if (Convert.ToInt32(Session["companyid"]) == 3391)
                        {
                            divreadthegoogle.InnerText = "Click on the link below to read the consent form and declare any previous offenses on your record. Your declaration will be used to confirm the results from your background check. If you do not declare your previous offenses, you may not qualify to participate in Local Services by Google.";
                            divreadthe.InnerText = "";

                            lbl5google.InnerHtml = "<br/><br/>Click here to view consent and declare offenses";
                            lbl5.InnerText = "";
                            divthengive.InnerText = "";


                            declarationdiv.InnerText = "Please declare any previous offenses on your record below. Your declaration will be used to confirm the results from your background check. If you do not declare your previous offenses, you may not qualify to participate in Local Services by Google.";
                        }
                        if (Request.QueryString["landingpage"] != "yes")
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString() == "FR")
                                {
                                    Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + Session["firstname"] + "&lang=FR&companyid=" + Session["companyid"]);
                                }
                                else
                                {
                                    Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + Session["firstname"] + "&lang=EN&companyid=" + Session["companyid"]);
                                }
                            }
                            else
                            {
                                Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + Session["firstname"] + "&lang=EN&companyid=" + Session["companyid"]);
                            }
                        }

                    }
                    else
                    {
                        var driverid = query.Get("driveruuid");
                        if (driverid == null)
                        {
                            companyid = Convert.ToInt32(query.Get("companyid"));
                            Session["companyid"] = Convert.ToInt32(query.Get("companyid"));
                        }
                        else
                        {

                            if (query.Get("companyid") != null)
                            {
                                companyid = Convert.ToInt32(query.Get("companyid"));
                                Session["companyid"] = Convert.ToInt32(query.Get("companyid"));
                            }
                            else
                            {
                                if (query.Get("pdl") != null || query.Get("package") != null)
                                {
                                    if (query.Get("pdl") == "bike" || query.Get("package") == "bike")
                                    {
                                        companyid = 3480;
                                        Session["companyid"] = 3480;
                                    }
                                    else
                                    {
                                        companyid = 3409;
                                        Session["companyid"] = 3409;
                                    }
                                }
                                else
                                {
                                    companyid = 3409;
                                    Session["companyid"] = 3409;
                                }
                            }
                        }
                        if (Session["companyid"] != null)
                        {

                            bool MVRCheck = MVRCheckboxCheck(Convert.ToInt32(Session["companyid"]));
                            if (MVRCheck == false)
                            {
                                divMVRCheck.Visible = false;
                                chkConsent.Checked = true;
                            }
                            try
                            {
                                if (Convert.ToInt32(Session["companyid"]) == 3391)
                                {
                                    divoffense.Visible = true;
                                }

                            }
                            catch
                            {

                            }

                        }
                        #endregion

                        driveruuid = query.Get("driveruuid");
                        firstname = query.Get("firstname");
                        middlename = query.Get("middlename");
                        lastname = query.Get("lastname");
                        dateofbirth = query.Get("date_of_birth");
                        pdl = query.Get("pdl");
                        email = query.Get("email");
                        package = query.Get("package");
                        dategenerated = query.Get("dategenerated");

                        Session["driveruuid"] = query.Get("driveruuid");
                        Session["firstname"] = query.Get("firstname");
                        Session["middlename"] = query.Get("middlename");
                        Session["lastname"] = query.Get("lastname");
                        Session["dateofbirth"] = query.Get("date_of_birth");
                        Session["pdl"] = query.Get("pdl");
                        Session["email"] = query.Get("email");
                        Session["package"] = query.Get("package");
                        Session["dategenerated"] = query.Get("dategenerated");
                        Session["province"] = query.Get("prov");
                        Session["productid"] = query.Get("productid");

                        Session["abstractprovince"] = query.Get("abstractprovince");


                        Session["language"] = query.Get("language");
                        if(Session["language"] == null)
                        {
                            Session["language"] = "EN";
                        }

                        if (Session["province"] != null || Session["language"] != null)
                        {
                            #region "French wording"
                            if (Session["province"].ToString() == "QC" || Session["language"].ToString() == "FR")
                            {

                                lblSurname.InnerText = "Nom de famille";
                                lblFirstName.InnerText = "Prénom";
                                lblMiddleName.InnerText = "Second prénom";
                                lbl5.InnerText = "formulaire de consentement et de déclaration ";
                                labelcheckbox1.InnerText = "Je reconnais avoir lu le formulaire de consentement";
                                labelchkbox2.InnerText = "En cochant cette case, vous fournissez à  ISB Canada votre consentement électronique pour apposer votre signature saisie ici sur le formulaire de consentement du dossier de conducteur provincial.";

                                Button1.Text = "Cliquez ici pour continuer";

                                lbl11.InnerText = "C. Consentement informé";
                                lbl12.InnerText = "AUTORISATION DE RECHERCHE – PAR LA PRÉSENTE, JE CONSENS À LA VÉRIFICATION du Répertoire national des casiers judiciaires selon les noms, la date de naissance, " +
                                    "le lieu d’utilisation et le casier judiciaire que j’ai déclaré. Je reconnais que cette vérification du Répertoire national des casiers judiciaires n’est pas confirmée par la " +
                                    "comparaison d’empreintes digitales, laquelle est la véritable façon de confirmer si un casier judiciaire existe dans le Répertoire national des casiers judiciaires.";
                                lbl13.InnerText = "SYSTÈMES D’INFORMATION DE LA POLICE – PAR LA PRÉSENTE, JE CONSENS À LA VÉRIFICATION des systèmes d’information de la police, qui fait partie d’une vérification du" +
                                    " Centre d’information de la police et qui consiste à vérifier les systèmes suivants : (cocher dans le cas échéant) :";
                                lbl14.InnerText = "Banque de données d’enquêtes du CIPC";
                                lbl15.InnerText = "Portail d’informations policières (PIP)";
                                lbl16.InnerHtml = "<strong>AUTORISATION ET RENONCIATION</strong>  de fournir une confirmation du casier judiciaire ou tout renseignement de la police." +
                                    "Je certifie que les renseignements que j’ai fournis dans la présente demande sont vrais et exacts à ma connaissance. J’accepte la divulgation des résultats de la vérification du casier judiciaire à " +
                                    "<strong>ISB Canada</strong>, située à Toronto, Ontario Canada";
                                lbl18.InnerText = "Par les présentes, je dégage et pour toujours tous les membres et tous les employés des services policiers effectuant la recherche de tout procès, toutes " +
                                    "réclamations ou demandes de dommages, de perte ou de préjudice que je pourrais subir par la suite ou en raison de la divulgation des renseignements par les services policiers de Cobourg à ISB Canada, Milton, Ontario.";
                                lbl19.InnerText = "Je consens";

                                div2.InnerText = "";

                                divStep1.InnerText = "Étape 1";
                                divconsanddec.InnerText = "Donner votre consentement et votre déclaration";
                                divreadthe.InnerText = "Lire le ";
                                divthengive.InnerText = "et apposer votre signature ci-dessous";
                                footer.InnerText = "Droit d’auteur © 2018 ISB Canada, Tous droits réservés";
                                technicaldifficulties.InnerText = "Si vous rencontrez des difficultés techniques, appelez-nous au 1-800-295-5732";

                                bannerimg.Src = "Images/banner_fr.png";


                                //lbl8.InnerHtml = "<input type=\"checkbox\" id=\"chkAgree\" name=\"chkAgree\" runat=\"server\" style=\"margin - left:4px\" /> Je reconnais avoir lu le formulaire de consentement";

                                //lbl9.InnerHtml = "<input type=\"checkbox\" id=\"chkConsent\" name=\"chkConsent\" runat=\"server\" style=\"display: inline - block; margin - left:-12px\" />En cochant cette case, vous fournissez à  ISB Canada votre consentement électronique pour apposer votre signature saisie ici sur le formulaire de consentement du dossier de conducteur provincial.";

                            }
                            #endregion
                        }


                       


                        lblFirstName.InnerText = firstname;
                        lblMiddleName.InnerText = middlename;
                        lblSurname.InnerText = lastname;
                        if (Session["lastname"] != null)
                        {
                            lblSurname.InnerText = Session["lastname"].ToString();
                        }
                        if (Session["middlename"] != null)
                        {
                            lblMiddleName.InnerText = Session["middlename"].ToString();
                        }
                        if (Session["firstname"] != null)
                        {
                            lblFirstName.InnerText = Session["firstname"].ToString();
                        }

                        segmentname = "";
                        string payload = GetPayloadPinkerton();
                        bool doesexist = CheckForDuplicateOnLoad(payload);

                        if (doesexist == true)
                        {
                            if (segmentname != "Link Clicked" && segmentname != "ISB_1" && segmentname != "ISB_2" && segmentname != "ISB_3")
                            {
                                totalbody.Visible = false;
                                if (Session["province"] != null || Session["language"].ToString() != null)
                                {
                                    if (Session["province"].ToString() == "QC" || Session["language"].ToString() == "FR")
                                    {
                                        lblAlreadyUsed.Text = "Vous avez déjà utilisé ce lien pour la vérification";
                                        lblErrors.Text = "Vous avez déjà terminé ce";
                                    }
                                    else
                                    {
                                        lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                        lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                                    }
                                }
                                else
                                {
                                    lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                    lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                                }
                            }

                        }
                        else
                        {
                            byte[] dummy = new byte[0];
                            InsertAIDOrder(payload, companyid, GetIPAddress(), "", "", dummy, "");
                        }

                        if ((DateTime.Now - TransactionTime).TotalMinutes < 30 && segmentname == "ISB_1" || (DateTime.Now - TransactionTime).TotalMinutes < 30 && segmentname == "ISB_2")
                        {
                            //totalbody.Visible = false;
                            //if (Session["province"] != null)
                            //{
                            //    if (Session["province"].ToString() == "QC")
                            //    {
                            //        lblAlreadyUsed.Text = "Ce lien est déjà actif. Veuillez essayer après trente minutes";
                            //    }
                            //    else
                            //    {
                            //        lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                            //    }
                            //}
                            //else
                            //{
                            //    lblAlreadyUsed.Text = "THIS LINK IS ALREADY ACTIVE. PLEASE TRY AFTER THIRTY MINUTES";
                            //}

                        }
                        if (segmentname == "ISB_1")
                        {
                            string email2 = Session["email"].ToString();
                            string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                            string result = System.Text.RegularExpressions.Regex.Replace(email2, pattern, m => new string('X', m.Length));
                            //string result = "";
                            totalbody.Visible = false;
                            othermessage.InnerHtml = "Oops!  We noticed that your device is having trouble with this link!<br/> We’ve sent the link to your " + result + "  account.<br/>  Please check your email and click the link to complete the process! If you have any trouble please call 1.800.295.5732 and we’d be happy to help you over the phone.";

                            DataSet ds1 = new DataSet();
                            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                            {
                                using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0," + Session["companyid"].ToString() + ") order by companyid desc", conn))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    conn.Open();
                                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                    da1.Fill(ds1);

                                }
                            }
                            string redirectlink = ISB_DOMAIN_NAME + "/default.html?GUID=" + GUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["province"].ToString();

                            string emailbody = "Dear " + Session["firstname"].ToString() + "<br/>Thank you for your interest in driving with Uber!We noticed your device was having trouble with the ID verification process.<br/> Please click <a href='" + redirectlink + "'> here </a> to complete the process. Make sure your smart device’s camera has access!You will need to take photos of your Driver’s License and a Selfie to complete the process. If you have any difficulties please call 1.800.295.5732 and we’d be happy to help you over the phone.";
                            SendEmailToPartner(email2, "MID Link", emailbody, Session["companyid"].ToString(), GUID);
                            //if (Session["province"] != null)
                            //{
                            //    if (Session["province"].ToString() == "QC")
                            //    {
                            //        lblAlreadyUsed.Text = "Vous avez dépassé le nombre maximal d'essais pour ce processus";
                            //    }
                            //    else
                            //    {
                            //        lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                            //    }
                            //}
                            //else
                            //{
                            //    lblAlreadyUsed.Text = "YOU HAVE EXCEEDED THE MAXIMUM NUMBER OF TRIES TO COMPLETE THE PROCESS";
                            //}
                        }
                        if (Request.QueryString["landingpage"] != "yes")
                        {
                            //if (Convert.ToInt32(Session["companyid"]) == 3653)
                            //{
                            //    if (Session["province"] != null)
                            //    {
                            //        if (Session["province"].ToString() == "QC")
                            //        {
                            //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=3653");
                            //        }
                            //        else
                            //        {
                            //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=3653");
                            //        }
                            //    }

                            //}
                            //if (Convert.ToInt32(Session["companyid"]) == 3391)
                            //{
                            //    if (Session["province"] != null)
                            //    {
                            //        if (Session["province"].ToString() == "QC")
                            //        {
                            //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=3391");
                            //        }
                            //        else
                            //        {
                            //            Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=3391");
                            //        }
                            //    }

                            //}
                            if (Convert.ToInt32(Session["companyid"]) == 3391)
                            {
                                divreadthegoogle.InnerText = "Click on the link below to read the consent form and declare any previous offenses. Declaring offenses is optional but strongly recommended for confirming background check results.";
                                divreadthe.InnerText = "";

                                lbl5google.InnerHtml = "<br/><br/>Click here to view consent and declare offenses";
                                lbl5.InnerText = "";
                                divthengive.InnerText = "";
                            }
                            if (Session["province"] != null || Session["language"].ToString() != null)
                            {
                                if (Session["province"].ToString() == "QC" || Session["language"].ToString() == "FR")
                                {
                                    Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=" + Session["companyid"]);
                                }
                                else
                                {

                                    Server.Transfer("landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=" + Session["companyid"]);
                                }
                                //if (Session["province"].ToString() == "QC")
                                //{
                                //    Server.Transfer("https://authenticated.isbc.ca/landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=FR&companyid=" + Session["companyid"]);
                                //}
                                //else
                                //{

                                //    Server.Transfer("https://authenticated.isbc.ca/landing.aspx?landing=yes&querystring=" + querystring + "&firstname=" + firstname + "&lang=EN&companyid=" + Session["companyid"]);
                                //}
                            }



                        }


                    }
                }
                #endregion
            }
            catch (Exception ex1)
            {
                totalbody.Visible = false;
                lblAlreadyUsed.Text = "THE LINK SEEMS TO BE BROKEN/le lien semble être cassé";
                lblErrors.Text = "PLEASE VERIFY THE LINK/Veuillez vérifier le lien";
                if (querystring != "")
                {
                  //  SendEmail("athangaraj@isbc.ca", "Broken Link", "The link is broken. Query String = " + querystring + "  ");
                }
            }

        }
        
    }



    protected void SubmitForm(EventArgs e, object sender)
    {        
        //everything else you had action.asp doing, only using C# code.
    }

    //Below Method is called when the user Clicks to proceed
    protected void Button1_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
        return;
        try
        {


            date2 = hdndate2.Value;
            offence2 = hdnoffence2.Value;
            location2 = hdnlocation2.Value;

            date3 = hdndate3.Value;
            offence3 = hdnoffence3.Value;
            location3 = hdnlocation3.Value;

            date4 = hdndate4.Value;
            offence4 = hdnoffence4.Value;
            location4 = hdnlocation4.Value;

            date5 = hdndate5.Value;
            offence5 = hdnoffence5.Value;
            location5 = hdnlocation5.Value;

            date6 = hdndate6.Value;
            offence6 = hdnoffence6.Value;
            location6 = hdnlocation6.Value;


            date7 = hdndate7.Value;
            offence7 = hdnoffence7.Value;
            location7 = hdnlocation7.Value;


            date8 = hdndate8.Value;
            offence8 = hdnoffence8.Value;
            location8 = hdnlocation8.Value;

            date9 = hdndate9.Value;
            offence9 = hdnoffence9.Value;
            location9 = hdnlocation9.Value;


            string querystring = "";
            string input = "";

            bool Agree = chkAgree.Checked;
            bool Consent = chkConsent.Checked;



            if (Agree && Consent)
            {
                try
                {



                    string payload;
                    try
                    {
                        payload = GetPayload();
                    }
                    catch
                    {
                        payload = GetPayloadPinkerton();
                    }
                    //payload = "driveruuid:1234;firstname:alex;middlename:anthony;lastname:thangaraj;date_of_birth:02031993;pdl:123;email:alexthangaraj@isbc.ca;package:1234;dategenerated:29062018;";
                    bool doesexist = CheckForDuplicate(payload);
                    // doesexist = false;

                    if (doesexist == true)
                    {
                        totalbody.Visible = false;
                        if (Session["province"] != null || Session["language"].ToString() != null)
                        {
                            if (Session["province"].ToString() == "QC" || Session["language"].ToString() == "FR")
                            {
                                lblAlreadyUsed.Text = "Vous avez déjà utilisé ce lien pour la vérification";
                                lblErrors.Text = "Vous avez déjà terminé ce";
                            }
                            else
                            {
                                lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                                lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                            }
                        }
                        else
                        {
                            lblAlreadyUsed.Text = "YOU HAVE ALREADY USED THIS LINK FOR VERIFICATION";
                            lblErrors.Text = "YOU ALREADY HAVE COMPLETED THIS";
                        }



                    }
                    else
                    {


                        string IPAddress = GetIPAddress();
                        string AIDGUID;

                        if (String.IsNullOrEmpty(GUID))
                        {

                            if (Session["ISBGUID"] == null)
                            {
                                AIDGUID = CallWebService();
                                // SendEmail("athangaraj@isbc.ca", "AIDGUID", "bp1");
                            }
                            else
                            {
                                AIDGUID = Session["ISBGUID"].ToString();
                            }
                            byte[] bits = new byte[] { 0x20 };
                            try
                            {
                                
                                    bits= GenerateHTMLtoPDFtobytes(AIDGUID);
                            }

                            catch
                            {
                               // SendEmail("athangaraj@isbc.ca", "BITS", "BITS ISSUE");
                            }
                            // SendEmail("athangaraj@isbc.ca", "HTML", "bp2");
                            string consent = "";
                            //string consent = "Offence1 :" + txtOffence1.Value + "Date1 :" +txtDate1.Value + "Location1 :" + txtLocation1.Value + ";" +
                            //    "Offence2 :" + txtOffence2.Value + "Date2 :" + txtDate2.Value + "Location1 :" + txtLocation2.Value + ";"+
                            //    "Offence3 :" + txtOffence3.Value + "Date2 :" + txtDate3.Value + "Location1 :" + txtLocation3.Value;

                            if (txtOffence1.Value.Trim().Length > 2)
                            {
                                consent += "Offence1 :" + txtOffence1.Value + "Date1 :" + txtDate1.Value + "Location1 :" + txtLocation1.Value + ";";
                            }

                            if (txtOffence2.Value.Trim().Length > 2)
                            {
                                consent += "Offence2 :" + txtOffence2.Value + "Date2 :" + txtDate2.Value + "Location2 :" + txtLocation2.Value + ";";
                            }

                            if (txtOffence3.Value.Trim().Length > 2)
                            {
                                consent += "Offence3 :" + txtOffence3.Value + "Date3 :" + txtDate3.Value + "Location3 :" + txtLocation3.Value;
                                consent += "Offence4 :" + offence2 + "Date4 :" + date2 + "Location4 :" + location2;
                                consent += "Offence5 :" + offence3 + "Date5 :" + date3 + "Location4 :" + location3;
                                consent += "Offence6 :" + offence4 + "Date6 :" + date4 + "Location4 :" + location4;
                                consent += "Offence7 :" + offence5 + "Date7 :" + date5 + "Location4 :" + location5;
                                consent += "Offence8 :" + offence6 + "Date8 :" + date6 + "Location4 :" + location6;
                                consent += "Offence9 :" + offence7 + "Date9 :" + date7 + "Location4 :" + location7;
                                consent += "Offence10 :" + offence8 + "Date10 :" + date8 + "Location4 :" + location8;
                                consent += "Offence11 :" + offence9 + "Date11 :" + date9 + "Location4 :" + location9;
                            }

                            // InsertAIDOrder(payload, Convert.ToInt32(Session["companyid"]), IPAddress, "", AIDGUID, bits, consent);
                            //UpdateAIDOrder(IPAddress, AIDGUID, bits, false);
                            try
                            {
                                using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                                {
                                    using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@aidguid", AIDGUID);
                                        cmd.Parameters.AddWithValue("@id", 8);
                                        cmd.Parameters.AddWithValue("@consentpdf", bits);
                                        cmd.Parameters.AddWithValue("@ip", GetIPAddress());
                                        cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
                                        cmd.Parameters.AddWithValue("@payload", payload);
                                        cmd.Parameters.AddWithValue("@ConsentDec", GetBrowserDetails());
                                        cmd.CommandTimeout = 90;
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        conn.Close();
                                       // SendEmail("athangaraj@isbc.ca", "UPDATE", "bp3" + AIDGUID + "  " + payload );
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SendEmail("athangaraj@isbc.ca", "UPDATE ISSUE -1", ex.Message);
                                try
                                {
                                    Thread.Sleep(2000);
                                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                                    {
                                        using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@aidguid", AIDGUID);
                                            cmd.Parameters.AddWithValue("@id", 8);
                                            cmd.Parameters.AddWithValue("@consentpdf", bits);
                                            cmd.Parameters.AddWithValue("@ip", GetIPAddress());
                                            cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
                                            cmd.Parameters.AddWithValue("@payload", payload);
                                            cmd.Parameters.AddWithValue("@ConsentDec", GetBrowserDetails());
                                            cmd.CommandTimeout = 90;
                                            
                                            conn.Open();
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                             SendEmail("athangaraj@isbc.ca", "UPDATE 2 worked", "bp3" + AIDGUID + "  " + payload );
                                        }
                                    }
                                }
                                catch(Exception ex1)
                                {
                                    SendEmail("athangaraj@isbc.ca", "UPDATE ISSUE -2", ex1.Message);
                                    lblErrors.Text = "Unfortunately we could not complete the process at this time. Please try again after 15 minutes";
                                    return;
                                }
                            }
                            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["isbcorporate_test"].ConnectionString))
                            //{
                            //    using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                            //    {
                            //        cmd.CommandType = CommandType.StoredProcedure;
                            //        cmd.Parameters.AddWithValue("@aidguid", AIDGUID);
                            //        cmd.Parameters.AddWithValue("@id", 8);
                            //        cmd.Parameters.AddWithValue("@consentpdf", bits);
                            //        cmd.Parameters.AddWithValue("@ip", GetIPAddress());
                            //        cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
                            //        cmd.Parameters.AddWithValue("@payload", payload);
                            //        cmd.Parameters.AddWithValue("@ConsentDec", GetBrowserDetails());
                            //        conn.Open();
                            //        cmd.ExecuteNonQuery();
                            //        conn.Close();
                            //    }
                            //}
                        }
                        else
                        {
                            AIDGUID = GUID;


                            byte[] bits = GenerateHTMLtoPDFtobytes(AIDGUID);

                            string consent = "";

                            //InsertAIDOrder(payload, companyid, IPAddress, "", AIDGUID, bits, consent);
                            UpdateAIDOrder(IPAddress, AIDGUID, bits, false);
                        }

                        if (Session["province"] != null)
                        {
                            if (Session["companyid"] != null)
                            {
                                //if (Session["province"].ToString() == "QC" && Convert.ToInt32(Session["companyid"]) == 3409)
                                //{
                                //    byte[] bits = GenerateHTMLtoPDFtobytes(AIDGUID);
                                //    UpdateAIDOrder(IPAddress, AIDGUID, bits, true);
                                //    Server.Transfer("thanks.aspx?uid=" + AIDGUID);
                                //}
                                //else
                                //{
                                //    Server.Transfer("Instructions.aspx?Instructionid=" + AIDGUID + "&lang=" + Session["province"].ToString() + "&companyid=" + Session["companyid"]);
                                //}


                                if (Request.QueryString["landingpage"] == "yes")
                                {
                                    if (Session["lang"] == null)
                                    {
                                        Session["lang"] = "EN";
                                    }

                                    //here
                                    // Server.Transfer("ValidateCredentials.aspx?Instructionid=" + AIDGUID + "&companyid=" + Session["companyid"] + "&lang=" + Session["lang"].ToString());

                                    // SendEmail("athangaraj@isbc.ca", "bp5", AIDGUID);
                                    //string compid = Request.QueryString["companyid"];
                                    //if (compid == null)
                                    //{
                                    //    compid = "0";
                                    //}
                                    //string lang = Request.QueryString["lang"];
                                    //if (lang == "FR")
                                    //{
                                    //    Session["lang"] = "FR";
                                    //}
                                    //else
                                    //{
                                    //    Session["lang"] = "EN";
                                    //}
                                    if (Session["lang"] == null)
                                    {
                                        Session["lang"] = "EN";
                                    }


                                    DataSet ds1 = new DataSet();
                                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                                    {
                                        using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0," + Session["companyid"] + ") order by companyid desc", conn))
                                        {
                                            cmd.CommandType = CommandType.Text;
                                            conn.Open();
                                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                            da1.Fill(ds1);

                                        }
                                    }

                                    //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID+"&docType="+ds1.Tables[0].Rows[0]["DocType"].ToString()+"&accountCode="+ds1.Tables[0].Rows[0]["AccountCode"].ToString()+"&lang="+lang, false); old
                                    //Response.Redirect("https://auth.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false); uber

                                    //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID="+AIDGUID+"&accountCode=12346&docType=00&lang="+Session["lang"]);


                                    //Stable version
                                    Response.Redirect(ISB_DOMAIN_NAME + "/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);
                                    return;
                                    //tohere
                                }
                                else
                                {
                                    if (Session["lang"] == null)
                                    {
                                        Session["lang"] = "EN";
                                    }
                                    // Server.Transfer("Instructions.aspx?Instructionid=" + AIDGUID + "&lang=" + Session["lang"].ToString() + "&companyid=" + Session["companyid"]);

                                    //here
                                    // Server.Transfer("ValidateCredentials.aspx?Instructionid=" + AIDGUID + "&companyid=" + Session["companyid"] + "&lang=" + Session["lang"].ToString());

                                   // SendEmail("athangaraj@isbc.ca", "bp6", AIDGUID);
                                    string compid = Request.QueryString["companyid"];
                                    if (compid == null)
                                    {
                                        compid = "0";
                                    }
                                    string lang = Request.QueryString["lang"];
                                    if (lang == "FR")
                                    {
                                        Session["lang"] = "FR";
                                    }
                                    else
                                    {
                                        Session["lang"] = "EN";
                                    }


                                    DataSet ds1 = new DataSet();
                                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                                    {
                                        using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0," + Session["companyid"] + ") order by companyid desc", conn))
                                        {
                                            cmd.CommandType = CommandType.Text;
                                            conn.Open();
                                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                            da1.Fill(ds1);

                                        }
                                    }

                                    //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID+"&docType="+ds1.Tables[0].Rows[0]["DocType"].ToString()+"&accountCode="+ds1.Tables[0].Rows[0]["AccountCode"].ToString()+"&lang="+lang, false); old
                                    //Response.Redirect("https://auth.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false); uber

                                    //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID="+AIDGUID+"&accountCode=12346&docType=00&lang="+Session["lang"]);


                                    //Stable version
                                    Response.Redirect(ISB_DOMAIN_NAME + "/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);
                                    return;
                                    //tohere
                                }
                                //Server.Transfer("Instructions.aspx?Instructionid=" + AIDGUID + "&lang=" + Session["province"].ToString() + "&companyid=" + Session["companyid"]);
                            }
                            else
                            {

                                //here
                                // Server.Transfer("ValidateCredentials.aspx?Instructionid=" + AIDGUID + "&companyid=" + Session["companyid"] + "&lang=" + Session["lang"].ToString());

                              //  SendEmail("athangaraj@isbc.ca", "bp7", AIDGUID);
                                string compid = Request.QueryString["companyid"];
                                if (compid == null)
                                {
                                    compid = "0";
                                }
                                string lang = Request.QueryString["lang"];
                                if (lang == "FR")
                                {
                                    Session["lang"] = "FR";
                                }
                                else
                                {
                                    Session["lang"] = "EN";
                                }


                                DataSet ds1 = new DataSet();
                                using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                                {
                                    using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0," + Session["companyid"] + ") order by companyid desc", conn))
                                    {
                                        cmd.CommandType = CommandType.Text;
                                        conn.Open();
                                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                        da1.Fill(ds1);

                                    }
                                }

                                //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID+"&docType="+ds1.Tables[0].Rows[0]["DocType"].ToString()+"&accountCode="+ds1.Tables[0].Rows[0]["AccountCode"].ToString()+"&lang="+lang, false); old
                                //Response.Redirect("https://auth.isbc.ca/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false); uber

                                //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID="+AIDGUID+"&accountCode=12346&docType=00&lang="+Session["lang"]);


                                //Stable version
                                Response.Redirect(ISB_DOMAIN_NAME + "/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);
                                return;
                                //tohere
                                //Server.Transfer("Instructions.aspx?Instructionid=" + AIDGUID + "&lang=" + Session["lang"].ToString() + "&companyid=" + Session["companyid"]);
                            }
                        }
                        else
                        {

                            //SendEmail("athangaraj@isbc.ca", "SENDING HERE", Session["companyid"]);
                            DataSet ds1 = new DataSet();
                            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                            {
                                using (SqlCommand cmd = new SqlCommand("SELECT   * from  MIDIDs where companyid in (0) order by companyid desc", conn))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    conn.Open();
                                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                                    da1.Fill(ds1);

                                }
                            }

                            Response.Redirect(ISB_DOMAIN_NAME + "/default.html?GUID=" + AIDGUID + "&docType=" + ds1.Tables[0].Rows[0]["DocType"].ToString() + "&accountCode=" + ds1.Tables[0].Rows[0]["AccountCode"].ToString() + "&lang=" + Session["lang"], false);
                            return;

                            if (Convert.ToInt32(Session["companyid"]) == 3391)
                            {
                                Server.Transfer("ValidateCredentials.aspx?companyid=3391" + "&lang=" + lan + "&querystring=" + querystring + "&landingpage=yes");
                            }
                            else
                            {
                                Server.Transfer("ValidateCredentials.aspx?companyid=3653" + "&lang=" + lan + "&querystring=" + querystring + "&landingpage=yes");
                            }
                            // Server.Transfer("Instructions.aspx?Instructionid=" + AIDGUID+"&companyid="+Session["companyid"]);


                        }
                        //Response.Redirect("https://authenticate.isbc.ca/v2/default.html?guid=" + AIDGUID,false); - duplicate

                        //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID, false);


                        //string consent = "<isb_off1>" + txtOffence1.Value + "</isb_off1><isboffdate1>" + txtDate1.Value + "</isboffdate1><isb_loc1>" + txtLocation1.Value + "</isb_loc1>";
                        //consent += "<isb_off2>" + txtOffence2.Value + "</isb_off2><isboffdate2>" + txtDate2.Value + "</isboffdate2><isb_loc2>" + txtLocation2.Value + "</isb_loc2>";
                        //consent += "<isb_off3>" + txtOffence3.Value + "</isb_off3><isboffdate3>" + txtDate3.Value + "</isboffdate3><isb_loc3>" + txtLocation3.Value + "</isb_loc3>";

                    }

                }
                catch (Exception ex)
                {
                    lblErrors.Text = "SOMETHING WENT WRONG" + ex.ToString();

                    // SendEmail("athangaraj@Isbc.ca", "Button Click Error", "There was an error in application EID" + ex.Message);
                }
            }
            else
            {
                if (Session["province"] != null)
                {
                    if (Session["province"].ToString() == "QC")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Veuillez cocher les cases pour confirmer que vous avez lu les conditions générales');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please check the box(es) to confirm that you have read the terms and conditions');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please check the box(es) to confirm that you have read the terms and conditions');", true);
                }

            }
        }
        catch(Exception ex)
        {

        }

    }

    #region Generate Payload
    public string GetPayload()
    {
        string productid;
        string abstractprovince;
        string language;
        if (Session["productid"] == null)
        {
            try
            {
                productid = GetProductidFromQueryString();
            } catch(Exception xs)
            {
                productid = "";
            }
        }
        else
        {
            productid = Session["productid"].ToString();
        }
        if (Session["abstractprovince"] == null)
        {
            abstractprovince = "";
        }
        else
        {
            abstractprovince = Session["abstractprovince"].ToString() ;
        }

        
        if (Session["language"] == null)
        {
            language = "";
        }
        else
        {
            language = Session["language"].ToString();
        }

        string payload;
        //if (Session["driveruuid"] == null)
        //{
        //    //if(Session["com"])
        //    payload = "companyid:" + Session["companyid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + "; lastname:" + Session["lastname"] +
        //    ";date_of_birth:" + Session["dateofbirth"] + "; pdl:" + Session["pdl"] +
        //    ";email:" + Session["email"] + "; package:" + Session["package"] + "; dategenerated:" + Session["dategenerated"] + "; province:"+Session["province"] + ";productid:" + productid + "; aidguid:" + Session["ISBGUID"];
        //}
        //else
        //{
        //    if (Session["province"] != null)
        //    {
        //        payload = "driveruuid:" + Session["driveruuid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + ";lastname:" + Session["lastname"] +
        //        ";date_of_birth:" + Session["dateofbirth"] + ";pdl:" + Session["pdl"] +
        //        ";email:" + Session["email"] + ";package:" + Session["package"] + ";dategenerated:" + Session["dategenerated"] + ";province:" + Session["province"] + ";productid:" + productid + ";language:" + language + ";";
        //    }
        //    else
        //    {
        //        payload = "driveruuid:" + Session["driveruuid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + ";lastname:" + Session["lastname"] +
        //       ";date_of_birth:" + Session["dateofbirth"] + ";pdl:" + Session["pdl"] +
        //       ";email:" + Session["email"] + ";package:" + Session["package"] + ";dategenerated:" + Session["dategenerated"] + ";province:" + ";productid:" + productid + 
        //       ";abstractprovince:"+ abstractprovince + ";language:" + language + ";";
        //    }


        //}
        string input;
        byte[] key = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
        string querystring;
        try
        {
           
             querystring = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);
            string url1 = Request.Url.AbsoluteUri.Split('?')[0];
           
        }
        catch
        {
            querystring = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);



            if (Session["googlequerystring"] == null)
            {
                Session["googlequerystring"] = querystring;
            }

            input = Decryptt(HttpUtility.UrlDecode(querystring), "dxW0k2P8");
            string url = Request.Url.AbsoluteUri.Split('?')[0];

            if (input.StartsWith("The input is not a valid B"))
            {
                querystring = Session["googlequerystring"].ToString();
                input = Decryptt(HttpUtility.UrlDecode(querystring), "dxW0k2P8");
                url = Request.Url.AbsoluteUri.Split('?')[0];
            }

        }

        if (Request.QueryString["querystring"] != null)
        {
            string q = Request.QueryString["querystring"];
            input = Decrypt.DecryptFernet(key, Request.QueryString["querystring"]);
        }
        else
        {
            input = Decrypt.DecryptFernet(key, querystring);
        }


        var query = HttpUtility.ParseQueryString(input);

        if (query.Get("driveruuid") == null)
        {
            //if(Session["companyid"] != null)
            //{
            //    payload = "companyid:" + Session["companyid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + "; lastname:" + Session["lastname"] +
            //";date_of_birth:" + Session["dateofbirth"] + "; pdl:" + Session["pdl"] +
            //";email:" + Session["email"] + "; package:" + Session["package"] + "; dategenerated:" + Session["dategenerated"] + "; province:"+Session["province"] + ";productid:" + productid + ";";

            //}
            //else
            //{

                payload = "companyid:" + query.Get("companyid") + ";firstname:" + query.Get("firstname") + ";middlename:" + query.Get("middlename") + ";lastname:" + query.Get("lastname") +
           ";date_of_birth:" + query.Get("date_of_birth") + ";pdl:" + query.Get("pdl") +
           ";email:" + query.Get("email") + ";package:" + query.Get("package") + ";dategenerated:" + query.Get("dategenerated") + ";province:" + query.Get("prov") + ";language:" + query.Get("lang") + ";productid:" + productid + ";";



            //}

        }
        else
        {
            //byte[] key = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
            ////string querystring = Request.QueryString["querystring"];
            //string input = Decrypt.DecryptFernet(key, Request.QueryString["querystring"]);
            //var query = HttpUtility.ParseQueryString(input);
            //payload = "driveruuid:" + driveruuid + ";firstname:" + firstname + ";middlename:" + middlename + ";lastname:" + lastname +
            //";date_of_birth:" + dateofbirth + ";pdl:" + pdl +
            //";email:" + email + ";package:" + package + ";dategenerated:" + dategenerated + ";";
            payload = "driveruuid:" + query.Get("driveruuid") + ";companyid:" + query.Get("companyid") + ";firstname:" + query.Get("firstname") + ";middlename:" + query.Get("middlename") + ";lastname:" + query.Get("lastname") +
          ";date_of_birth:" + query.Get("date_of_birth") + ";pdl:" + query.Get("pdl") +
          ";email:" + query.Get("email").Trim() + ";package:" + query.Get("package").Trim() + ";dategenerated:" + query.Get("dategenerated").Trim() + ";province:" + query.Get("prov") + ";language:" + query.Get("lang") + ";productid:" + productid + ";";


        }
        return payload;
    }


    public string GetPayloadPinkerton()
    {
        string productid;
        string abstractprovince;
        string language;
        if (Session["productid"] == null)
        {
            try
            {
                productid = GetProductidFromQueryString();
            }
            catch (Exception xs)
            {
                productid = "";
            }
        }
        else
        {
            productid = Session["productid"].ToString();
        }
        if (Session["abstractprovince"] == null)
        {
            abstractprovince = "";
        }
        else
        {
            abstractprovince = Session["abstractprovince"].ToString();
        }


        if (Session["language"] == null)
        {
            language = "";
        }
        else
        {
            language = Session["language"].ToString();
        }

        string payload;
        if (Session["driveruuid"] == null)
        {
            //if(Session["com"])
            payload = "companyid:" + Session["companyid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + "; lastname:" + Session["lastname"] +
            ";date_of_birth:" + Session["dateofbirth"] + "; pdl:" + Session["pdl"] +
            ";email:" + Session["email"] + "; package:" + Session["package"] + "; dategenerated:" + Session["dategenerated"] + "; province:" + Session["province"] + ";productid:" + productid + "; aidguid:" + Session["ISBGUID"];
        }
        else
        {
            if (Session["province"] != null)
            {
                payload = "driveruuid:" + Session["driveruuid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + ";lastname:" + Session["lastname"] +
                ";date_of_birth:" + Session["dateofbirth"] + ";pdl:" + Session["pdl"] +
                ";email:" + Session["email"] + ";package:" + Session["package"] + ";dategenerated:" + Session["dategenerated"] + ";province:" + Session["province"] + ";productid:" + productid + ";language:" + language + ";";
            }
            else
            {
                payload = "driveruuid:" + Session["driveruuid"] + ";firstname:" + Session["firstname"] + ";middlename:" + Session["middlename"] + ";lastname:" + Session["lastname"] +
               ";date_of_birth:" + Session["dateofbirth"] + ";pdl:" + Session["pdl"] +
               ";email:" + Session["email"] + ";package:" + Session["package"] + ";dategenerated:" + Session["dategenerated"] + ";province:" + ";productid:" + productid +
               ";abstractprovince:" + abstractprovince + ";language:" + language + ";";
            }


        }
       
        return payload;
    }
    #endregion

    #region Generate HTML Convert to PDF and Convert to Bytes
    public byte[] GenerateHTMLtoPDFtobytes(string AIDGUID)
    {
        string finalstr = "<html><head><style type='text/css'>table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;background-image: url('http://www.infosearchsite.com/search/images/DoNotCopy.jpg')}table.gridtable th {	border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;}</style></head><div><img src='http://www.infosearchsite.com/search/images/ISB_Logo_New.jpg'></div><table width='600' class='gridtable'>";
        finalstr = "<html><head><style type='text/css'>table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;background-image: url('http://www.infosearchsite.com/search/images/DoNotCopy.jpg')}table.gridtable th {	border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;}</style></head><div><img src='http://www.infosearchsite.com/search/images/ISB_Logo_New.jpg'></div>";
        finalstr += "<div style='font-family: verdana,arial,sans-serif;font-size:14px;'>CRIMINAL RECORD VERIFICATION Informed Consent Form</div><p></p>";
        finalstr += "<table width='800' class='gridtable'>";
        finalstr += "<tr><td colspan='4' bgcolor='#C4C1C0' align='left'><strong>A. Personal Information</strong></td></tr>";
        finalstr += "<tr><td width='15%'>Surname (last name):</td><td >" + Session["lastname"] + "</td><td>Given Name(s):" + Session["firstname"] + "</td><td>Middle Name(s):" + Session["middlename"] + "</td></tr>";
        finalstr += "<tr><td width='15%'>Surname (last name at birth):</td><td>"+
           // txtSurnameatbirth.Value
            "</td><td width='15%'>Former name(s):</td><td>"+
            //txtFormerName.Value
            "</td></tr>";
        finalstr += "<tr><td width='15%'>Place of birth(City,Province/State,Country):</td><td colspan='3'>&nbsp;</td></tr>";
        finalstr += "<tr><td width='15%'>Date of Birth(YYYY-MM-DD):</td><td  width='30%'>" + Session["dateofbirth"] + "</td>";
        finalstr += "<td width='15%'>Gender:</td><td>" + 
            //ddlGender.Value.ToString()
             "</td></tr>";
        //finalstr += "<tr><td width='15%'>Phone:</td><td  width='30%'>" + TextBox4.Text + TextBox4a.Text+ TextBox4b.Text +"</td><td width='15%'>Email:</td><td>" + TextBox16.Text + "</td></tr>";
        finalstr += "<tr><td width='15%'>Phone number(s):</td><td  width='30%'>" + 
            //txtPhone.Value 
            "</td><td width='15%'>Email address:</td><td>" + 
            //txtEmail.Value 
            "</td></tr>";
        finalstr += "<tr><td colspan='4'>Current Home Address:</td></tr>";
        finalstr += "<tr><td width='15%'>Number:</td><td  width='30%'>" + 
            //txtUnit.Value 
            " " + 
            //txtStreetNum.Value 
            "</td><td width='15%'>Street:</td><td  width='30%'>" + 
            //txtStreetName.Value 
            "</td></tr>";
        finalstr += "<tr><td width='15%'>City:</td><td  width='30%'>" 
            //+ txtCity.Value
            + "</td><td width='15%'>Province/Territory/State:</td><td  width='30%'>" 
            //+ ddlProvince.Value 
            + "</td></tr>";
        finalstr += "<tr><td width='15%'>Postal Code:</td><td colspan='3'>" 
            //+ txtPostalCode.Value 
            + "</td></tr>";



        finalstr += "<tr><td colspan='4'>Previous Home Address:</td></tr>";
        //finalstr += "<tr><td width='15%'>Number:</td><td  width='30%'>" + txtUnit1.Value + " "             + txtStreetNum1.Value + "</td><td width='15%'>Street:</td><td  width='30%'>" + txtStreetName1.Value 
        //    + "</td></tr>";
        //finalstr += "<tr><td width='15%'>City:</td><td  width='30%'>" + txtCity1.Value + "</td><td width='15%'>Province/Territory/State:</td><td  width='30%'>" + ddlProvince1.Value + "</td></tr>";
        //finalstr += "<tr><td width='15%'>Postal Code:</td><td colspan='3'>" + txtPostalCode1.Value + "</td></tr>";

        finalstr += "<tr><td colspan='4' bgcolor='#C4C1C0' align='left'><strong>B. Reason for the Criminal Record Verification</strong></td></tr>";
        finalstr += "<tr><td width='15%'>Reason for Request(example : Employment - Employer - Job Title):</td><td colspan='3'>Employment</td></tr>";
        finalstr += "<tr><td width='15%'>Organization Requesting Search:</td><td colspan='3'>ISB Canada</td></tr>";
        finalstr += "<tr><td width='15%'>Contact Name:</td><td  width='30%'>Jennifer Corbett</td><td width='15%'>Contact Phone Number:</td><td>905-875-6828</td></tr>";

        finalstr += "<tr><td colspan='4' bgcolor='#C4C1C0' align='left'><strong>C. Informed Consent</strong></td></tr>";
        finalstr += "<tr><td colspan='4' align='left'><strong>SEARCH AUTHORIZATION</strong> - I HEREBY CONSENT TO THE SEARCH OF the RCMP National Repository of Criminal Records based on the name(s), date of birth and where used, the declared criminal record history provided by myself. I understand that this verification of the National Repository of Criminal Records is not being confirmed by fingerprint comparison which is the only true means by which to confirm if a criminal record exists in the National Repository of Criminal Records.</td></tr>";
        finalstr += "<tr><td colspan='4' align='left'>POLICE INFORMATION SYSTEM(S) - 1 HEREBY CONSENT TO THE SEARCH OF police information systems, as part of a Police Information Check, which will consist of a search of the following systems (check applicable):</td></tr>";
        finalstr += "<tr><td width='15%'>X</td><td  width='30%'>CPIC Investigative Data Bank</td><td width='15%'>X</td><td  width='30%'>Police Information Portal(PIP)</td></tr>";
        finalstr += "<tr><td width='15%'></td><td  colspan='3'>OTHER:</td></tr>";
        finalstr += "<tr><td colspan='4' align='left'><strong>AUTHORIZATION AND WAIVER </strong> to provide a confirmation of criminal record or any police information.";
        finalstr += "<br />I certify that the information set out by me in this application is true and correct to the best of my ability.I consent to the release of the results of the criminal record check to ";
        // Name of the company
        //finalstr += " <u>Uber</u>, &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;located in <u>" + RadioButtonList2.SelectedItem.Text.ToString() + "</u><br/> ";
        finalstr += " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Company Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;City and Country<br/> ";
        finalstr += "<br />I hereby release and forever discharge all members and employees of the processing Police Service and the Royal Canadian Mounted Police from any and all actions, claims and demands for damage, loss or injury howsoever arising which may hereafter be sustained by myself as a result of the disclosure of information by the<br />";
        finalstr += "<u>Cobourg Police Service/Brockville Police Service/ Brantford Police Service</u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>ISB Canada</u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>Milton, Ontario</u>";
        finalstr += "<br/>Name of the Processing Police Service&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Company Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;City and Country";
        finalstr += "</td></tr>";

        finalstr += "<tr><td colspan='2'>Signature of Applicant:</td>";
        DateTime myDateTime = DateTime.Now;
        string signimgpath = "";
        string filename = "";
        if (WebSignature1.ImageUrl.Length > 0)
        {          
            string folder = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "SignatureImages";
            filename = "https://infosearchsite.com/MID/" + WebSignature1.ImageUrl.ToString();
            //https://infosearchsite.com/MID/1e7528b7-cad9-4c2f-aa1c-9651c5dbde9a.Png
            WebSignature1.ExportToImageOnly(folder, filename);
            signimgpath = WebSignature1.ImageUrl.ToString();
            
            finalstr += "<td colspan='2'><img src='" + filename + "'></td></tr>";
        }

        finalstr += "<tr><td colspan='2'>Date:</td><td colspan='2'>" + DateTime.Now.ToShortDateString() + "</td></tr>";

        finalstr += "<tr><td colspan='4' bgcolor='#C4C1C0' align='left'><strong>D.Identification Verification</strong></td></tr>";

        finalstr += "<tr><td colspan='2' align='left'>Witnessing Agent's Name</td><td colspan='2' align='left'>Identification (Verified)</td></tr>";
        finalstr += "<tr><td colspan='2' align='left'>Witnessing Agent's Signature</td><td colspan='2' align='left'>Type of Photo ID Viewed<br/>(Government Issued) & Secondary ID:</td></tr>";

        finalstr += "<tr><td colspan='4' align='left'>Name and location of the company where information will be stored in Canada - <strong>ISB Canada, Milton, ON</strong></td></tr>";
        finalstr += "<tr><td colspan='4' align='left'><strong>**Information related to this criminal record check is collected, retained and disclosed in accordance with applicable privacy legislation**</strong></td></tr>";
        finalstr += "<tr><td colspan='4' align='right'><strong>CRIMINAL RECORD VERIFICATION<br/>Informed Consent Form </strong></td></tr>";
        finalstr += "<tr><td colspan='4' align='left'>Declaration of Criminal Record</td></tr>";
        finalstr += "<tr><td colspan='4' align='left'>This form is required to be filled out and attached to your Informed Consent Form for a Criminal Record Verification." +
            "<br/>Surname<br/>Information is collected and disclosed in accordance with federal, provincial and municipal laws" +
            "<br/>A Declaration of Criminal Record does not constitute a Certified Criminal Record by the RCMP and may not contain all criminal record convictions." +
            "<br/>Applicants must declare all convictions for offences under Canadian federal law.<br/>Do not declare the following: " +
            "<br/><ul><li>A conviction for which you have received a Record Suspension { formerly pardon) in accordance with the Criminal Records Act;</li>" +
            "<li> A conviction where you were a young person under the Youth Criminal Justice Act;</ li ><li>An Absolute or Conditional Discharge, pursuant to section 730 of the Criminal Code;</li>" +
            "<li>An Absolute or Conditional Discharge, pursuant to section 730 of the Criminal Code;</li><li>An offence for which you were not convicted;</li>" +
            "<li> Any provincial or municipal offence, and;</li> <li> Any charges dealt with out side of Canada.</li></ ul >" +
            "<br/><strong>Note that a Certified Criminal Record can only be issued based on the submission of fingerprints to the RCMP National Repository of Criminal Record.</strong></td></tr>";


        finalstr += "<tr><td colspan='2' align='left'>Offence</td><td colspan='1' align='left'>Date of Sentence</td><td colspan='1' align='left'>Location</td></tr>" +
            "<tr><td colspan='2' align='left'>" + txtOffence1.Value + "</td><td colspan='1' align='left'>" + txtDate1.Value + "</td><td colspan='1' align='left'>" + txtLocation1.Value + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + txtOffence2.Value + "</td><td colspan='1' align='left'>" + txtDate2.Value + "</td><td colspan='1' align='left'>" + txtLocation2.Value + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + txtOffence3.Value + "</td><td colspan='1' align='left'>" + txtDate3.Value + "</td><td colspan='1' align='left'>" + txtLocation3.Value + "</td></tr>" +

            "<tr><td colspan='2' align='left'>" + offence2 + "</td><td colspan='1' align='left'>" + date2 + "</td><td colspan='1' align='left'>" + location2 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence3 + "</td><td colspan='1' align='left'>" + date3 + "</td><td colspan='1' align='left'>" + location3 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence4 + "</td><td colspan='1' align='left'>" + date4 + "</td><td colspan='1' align='left'>" + location4 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence5 + "</td><td colspan='1' align='left'>" + date5 + "</td><td colspan='1' align='left'>" + location5 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence6 + "</td><td colspan='1' align='left'>" + date6 + "</td><td colspan='1' align='left'>" + location6 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence7 + "</td><td colspan='1' align='left'>" + date7 + "</td><td colspan='1' align='left'>" + location7 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence8 + "</td><td colspan='1' align='left'>" + date8 + "</td><td colspan='1' align='left'>" + location8 + "</td></tr>" +
            "<tr><td colspan='2' align='left'>" + offence9 + "</td><td colspan='1' align='left'>" + date9 + "</td><td colspan='1' align='left'>" + location9 + "</td></tr>";


        finalstr += "<tr><td colspan='4' align='right'><img src=\"https://infosearchsite.com/search/images/isbLogoMain.jpg\" /></td></tr>";
        finalstr += "<tr><td colspan='4' align='left'><Strong>Consent for the release of personal information</Strong><br/><br/>" +
            "I , have applied for employment / contract work with .<br/><br/>" +
            "I understand that as a condition of my employment/contract work, the company will perform a full background check on me." +
            "These checks/searches may include some, or all the following: criminal search, drivers abstract, driver insurance history, credit history, employment verification, " +
            "education verification, verification of address for up to 10 years, employment references,Verification of Drivers license status, Terrorism watch list check," +
            "Validation of SIN number. <br/><br/>I hereby authorize the holder(s) of information, relating to the items checked off below, to disclose the information requested, " +
            "at any time, to the company and/or its authorized agents and ISB Canada.<br/><br/>I understand that the Company will use some or all the disclosed information provided, from any source to" +
            "evaluate me and confirm my suitability for employment/contract work.<br/><br/>I hereby release and forever discharge the holder(s) of information relating to" +
            "the above, including ISB Canada, and the Company, their respective affiliated entities and any former," +
            "current, and future partners, directors, officers, employees, agents, successors and assigns, including those belonging to affiliated entities," +
            "from any actions, claims, and demands of any kind whatsoever relating to the collection, disclosure, or use of this information by the holder(s) of information relating to the above items, ISB Canada or the Company." +
            "I further declare the information below, on my résumé/application, and provided verbally to the Company," +
            "is complete and accurate. I understand a false statement may disqualify me from employment and give cause for my dismissal if employed. </td></tr>";














        finalstr += "<tr><td colspan='2'>Signature of Applicant:</td>";
        DateTime myDateTime1 = DateTime.Now;
        string signimgpath1 = "";
        //if (WebSignature1.ImageUrl.Length > 0)
        //{
        //    //string folder = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Documents\Visual Studio Projects\Consent\Consent\SignatureImages";
        //    string folder = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString()+"SignatureImages";
        //    string filename = "https://infosearchsite.com/MID/"+ WebSignature1.ImageUrl.ToString() ;
        //    //https://infosearchsite.com/MID/1e7528b7-cad9-4c2f-aa1c-9651c5dbde9a.Png
        //    WebSignature1.ExportToImageOnly(folder,filename);
        //    signimgpath1 =  WebSignature1.ImageUrl.ToString();

        //    //signimgpath = signimgpath.Substring(1, signimgpath.Length - 1);
        //    //signimgpath = signimgpath.Substring(signimgpath.IndexOf("/"), signimgpath.Length - signimgpath.IndexOf("/"));
        //    //signimgpath = signimgpath.Substring(1, signimgpath.Length - 1);

        //    //finalstr += "<td><img src='" + System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + signimgpath + "'></td>";

        //    //finalstr += "<td colspan='2'><img src='" +signimgpath+ "'></td>";
        //    finalstr += "<td colspan='2'><img src='" + filename+"'></td></tr>";
        //}
        finalstr += "<td colspan='2'><img src='" + filename + "'></td></tr>";

        finalstr += "<tr><td colspan='2'>Date:</td><td colspan='2'>" + DateTime.Now.ToShortDateString() + "</td></tr>";
        finalstr += "</table>";
        finalstr += "<p></p><div style='font-family: verdana,arial,sans-serif;font-size:14px;'>ID</div><p></p>";

        //string localfilestr = "C:\\sites\\infosearchsite.com\\isbPortal\\TestINS-Temp\\uploads\\Uber_Consent_EBS_" + "TEST" + ".html";
        //string localfilestr = "C:\\Users\\athangaraj\\OneDrive - The Dalton Group of Companies\\Desktop\\HTML\\" + "TEST" + ".html";
        //string localfilestr = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "HTMLFiles\\" + "HTML"+ DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")+".html";


        //string localfilestr = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "HTMLFiles\\" + "HTML_" + AIDGUID + ".html";
        //string localfilestr = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin\"+"HTML_" + AIDGUID + ".html";
        string localfilestr = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\" + "HTML_" + AIDGUID + ".html";
        using (FileStream fs = new FileStream(localfilestr, FileMode.Create))
        {
            using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
            {
                w.WriteLine(finalstr);
            }
        }
        string datetime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");


        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //startInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\wkhtmltopdf.exe";
        //startInfo.FileName = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin\wkhtmltopdf.exe";
        string foldername = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\";
        //string filefolder = "file:///" +foldername.Replace('\\','/');
        //startInfo.FileName = foldername + "wkhtmltopdf.exe";
        startInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Documents\Visual Studio Projects\Consent\Consent\Bin\wkhtmltopdf.exe";
        startInfo.FileName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin\\wkhtmltopdf.exe";
        //startInfo.Arguments = "C:/Users/athangaraj/OneDrive%20-%20The%20Dalton%20Group%20of%20Companies/Desktop/HTMLTOPDF/TEST.html testpdf.pdf";
        startInfo.Arguments = "HTML_" +AIDGUID+".html"+ " " + "PDF_"+AIDGUID+".pdf";

        //startInfo.WorkingDirectory = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin";
        //startInfo.WorkingDirectory = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin";
        //startInfo.WorkingDirectory = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin";
        //startInfo.WorkingDirectory = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Documents\Visual Studio Projects\Consent\Consent\Bin";
        startInfo.WorkingDirectory = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin";
        startInfo.UseShellExecute = false;
        process.StartInfo = startInfo;
        process.Start();


        //string pdf = WKHtmlToPdf(localfilestr, datetime);

        //PdfConvert.ConvertHtmlToPdf(new PdfDocument
        //{
        //    Url = localfilestr,
        //    HeaderLeft = "[title]",
        //    HeaderRight = "[date] [time]",
        //    FooterCenter = "Page [page] of [topage]"

        //},
        //new PdfConvertEnvironment
        //{
        //    WkHtmlToPdfPath = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin\wkhtmltopdf.exe",
        //    TempFolderPath = Path.GetTempPath(),
        //    Timeout = 60000

        //},

        //new PdfOutput
        //{
        //    //OutputFilePath = "C:\\Users\\athangaraj\\OneDrive - The Dalton Group of Companies\\Desktop\\HTML\\" + "TEST" + "wkhtmltopdf-page.pdf"
        //    OutputFilePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "PDFFiles\\" + "PDF"+ datetime +".pdf"
        //});


        byte[] bytes = File.ReadAllBytes(localfilestr);
        //byte[] bytes = File.ReadAllBytes("C:\\Users\\athangaraj\\OneDrive - The Dalton Group of Companies\\Desktop\\HTML\\" + "TEST" + "wkhtmltopdf-page.pdf");
        //byte[] bytes = File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "PDFFiles\\" + "PDF"+ datetime +".pdf");

        //using (Stream file = File.OpenWrite(@"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\HTML\HTMLLL.html"))
        //{
        //    file.Write(bytes, 0, bytes.Length);
        //}

        //System.IO.File.WriteAllBytes(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "myfile.pdf", bytes);
        return bytes;
    }
    #endregion

    #region Get IP Address
    public string GetIPAddress()
    {
        HttpContext context = HttpContext.Current;
        //string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        string ipAddress = Request.UserHostAddress;

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }
    #endregion

    #region Call Web service for AID GUID
    public string CallWebService()
    {
        
        RequestISB client = new RequestISB();
        //string Package;
        //String sDate = DateTime.Now.ToString();
        //DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
        //String dy = datevalue.Day.ToString();
        //String mn = datevalue.Month.ToString();
        //String yy = datevalue.Year.ToString();

        //Package = "<ProductData>";
        //if (Session["firstname"] == null)
        //{
        //    Package += "<isb_FN>" + lblFirstName.InnerText + "</isb_FN>";
        //}
        //else
        //{
        //    Package += "<isb_FN>" + Session["firstname"] + "</isb_FN>";
        //}
        //if (Session["lastname"] == null)
        //{
        //    Package += "<isb_LN>" + lblSurname.InnerText + "</isb_LN>";
        //}
        //else
        //{
        //    Package += "<isb_LN>" + Session["lastname"] + "</isb_LN>";
        //}


        //Package += "<isb_Ref>" + "1993" + "</isb_Ref>";
        //Package += "<isb_DOL>" + yy + "-" + mn + "-" + dy + "</isb_DOL>";

        //// CHANGE THE PROVINCE TO THE DL PROVINCE ONCE THEY STARTS ORDERING THE DRIVER ABSTRACT TOO
        //Package += "<isb_Prov>" + "ON" + "</isb_Prov>";
        //Package += "<isb_UserID>" + ConfigurationManager.AppSettings["UserID_" + Session["companyid"]] + "</isb_UserID>";
        ////if (Request.QueryString["UserID"] != null)
        ////{
        ////    Package += "<isb_UserID>" + Request.QueryString["UserID"].ToString() + "</isb_UserID>";
        ////}
        ////else
        ////{
        ////    string userid = ConfigurationManager.AppSettings["UserID_15443"];
        ////    if (userid == "UserID_")
        ////    {

        ////        Package += "<isb_UserID>" + 15443 + "</isb_UserID>";
        ////    }
        ////    else
        ////    {
        ////        Package += "<isb_UserID>" + ConfigurationManager.AppSettings["UserID_" + Session["companyid"]] + "</isb_UserID>";
        ////    }
        ////SendEmail("UserID not received through URL", "Uber BC Form Submission Error Report");-- test
        ////}
        //Package += "</ProductData>";



        string username = ConfigurationManager.AppSettings["WebServiceUserName"];
        string password = ConfigurationManager.AppSettings["WebServicePassword"];


        client.Credentials = new NetworkCredential(username, password);
        client.PreAuthenticate = true;
        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);
        //PROD = false; //TEST
        client.UseDefaultCredentials = true;
        //try
        //{

        //SendEmail("athangaraj@isbc.ca", "STARTORDERPAYLOAD", "Package is " +  Package + "   Companyid is"+ Session["companyid"] + ""+ConfigurationManager.AppSettings["UserID_"+Session["companyid"]] + "Username is" + ConfigurationManager.AppSettings["WebServiceUserName"]);
        //SendEmail("athangaraj@isbc.ca", "PACKAGEPAYLOAD", Session["packagepayload"].ToString());
        string chkstatus="";
        if(Session["packagepayload"] != null)
        {
            if (ordercount == 0)
            {
                chkstatus = client.StartOrder(Session["packagepayload"].ToString(), "EBS", PROD, PROD);
                ordercount++;
            }
           //SendEmail("athangaraj@isbc.ca", "SESSIONPACKAGE", Session["packagepayload"].ToString());
        }
        else
        {
            byte[] key = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
            //string querystring = Request.QueryString["querystring"];
            string input = Decrypt.DecryptFernet(key, Request.QueryString["querystring"]);
            var query = HttpUtility.ParseQueryString(input);


            string Package;
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            Package = "<ProductData>";
            Package += "<isb_FN>" + query.Get("firstname") + "</isb_FN>";
            Package += "<isb_LN>" + query.Get("lastname") + "</isb_LN>";
            Package += "<isb_Ref>" + "1993" + "</isb_Ref>";
            Package += "<isb_DOL>" + yy + "-" + mn + "-" + dy + "</isb_DOL>";
            Package += "<isb_Prov>" + "ON" + "</isb_Prov>";
            Package += "<isb_UserID>" + ConfigurationManager.AppSettings["UserID_" + query.Get("companyid")] + "</isb_UserID>";
            Package += "</ProductData>";
            if (ordercount == 0)
            {
                chkstatus = client.StartOrder(Package, "EBS", PROD, PROD);
                ordercount++;
            }
            //SendEmail("athangaraj@isbc.ca", "QUERYPACKAGE", Package);
        }

        #region "capture guid"
        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[MIDWSPackageDetails] ([Payload],[GUID],[IPAddress],[CreatedOn],[Status]) VALUES (@Payload, @GUID, @IPAddress, getdate(),@Status)", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Payload", GetPayload());
                cmd.Parameters.AddWithValue("@GUID", chkstatus);
                cmd.Parameters.AddWithValue("@IPAddress", GetIPAddress());
                cmd.Parameters.AddWithValue("@Status", 1);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        return chkstatus;
        //}
        //catch(Exception ex)
        //{

           // SendEmail("athangaraj@isbc.ca", "STARTORDER", "Error was" + ex.Message + Package);
            //Guid g = Guid.NewGuid();

            //string chkstatus = g.ToString();
            //return chkstatus;
        //}
        
        //chkstatus = client.StartOrder(Package, "EBS", false, false);
       
    }
    #endregion

    #region Insert AID Order in Database
    public void InsertAIDOrder(string payload,int companyid,string ip,string wspackageid,string aidguid,byte[] consent,string consentdec)
    {
        //string consentpdf = Convert.ToString(consent);
        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
        {
            using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payload", payload);
                cmd.Parameters.AddWithValue("@companyid", companyid);
                cmd.Parameters.AddWithValue("@ip", ip);
                cmd.Parameters.AddWithValue("@id", 7);
                cmd.Parameters.AddWithValue("@wspackageid", wspackageid);
                cmd.Parameters.AddWithValue("@aidguid", aidguid);
                cmd.Parameters.AddWithValue("@consentpdf", consent);
                cmd.Parameters.AddWithValue("@ConsentDec", GetBrowserDetails());
                
                
                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();
                //string browser = Request.Browser.Type.ToString();
            }
        }

        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Isbcorporate_test"].ConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@payload", payload);
        //        cmd.Parameters.AddWithValue("@companyid", companyid);
        //        cmd.Parameters.AddWithValue("@ip", ip);
        //        cmd.Parameters.AddWithValue("@id", 7);
        //        cmd.Parameters.AddWithValue("@wspackageid", wspackageid);
        //        cmd.Parameters.AddWithValue("@aidguid", aidguid);
        //        cmd.Parameters.AddWithValue("@consentpdf", consent);
        //        cmd.Parameters.AddWithValue("@ConsentDec", GetBrowserDetails());


        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        //string browser = Request.Browser.Type.ToString();
        //    }
        //}
    }

    public  string GetBrowserDetails()
    {
        string browserDetails = string.Empty;
        System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
        browserDetails =
        "Name = " + browser.Browser + "," +
        "Type = " + browser.Type + ","
        + "Version = " + browser.Version + ","
        + "Major Version = " + browser.MajorVersion + ","
        + "Minor Version = " + browser.MinorVersion + ","
        + "Platform = " + browser.Platform + ","
        + "Is Beta = " + browser.Beta + ","
        + "Is Crawler = " + browser.Crawler + ","
        + "Is AOL = " + browser.AOL + ","
        + "Is Win16 = " + browser.Win16 + ","
        + "Is Win32 = " + browser.Win32 + ","
        + "Supports Frames = " + browser.Frames + ","
        + "Supports Tables = " + browser.Tables + ","
        + "Supports Cookies = " + browser.Cookies + ","
        + "Supports VBScript = " + browser.VBScript + ","
        + "Supports JavaScript = " + "," +
        browser.EcmaScriptVersion.ToString() + ","
        + "Supports Java Applets = " + browser.JavaApplets + ","
        + "Supports ActiveX Controls = " + browser.ActiveXControls
        + ","
        + "Supports JavaScript Version = " +
        browser["JavaScriptVersion"];
        return browserDetails;
    }
    #endregion

    #region Update AID Order in Database
    public void UpdateAIDOrder(string ip,string aidguid,byte[] consent,bool UberFrench)
    {
        if(segmentname == "Link Clicked")
        {
            segmentname = "ISB_1";
        }        
        if(segmentname == "ISB_1")
        {
            segmentname = "ISB_2";
        }
        else if(segmentname == "ISB_2")
        {
            segmentname = "ISB_3";
        }
        if (UberFrench == true)
        {
            segmentname = "Uber French";
            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {
                using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aidguid", aidguid);
                    cmd.Parameters.AddWithValue("@id", 6);
                    cmd.Parameters.AddWithValue("@consentpdf", consent);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        else
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {
                using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aidguid", aidguid);
                    cmd.Parameters.AddWithValue("@id", 5);
                    cmd.Parameters.AddWithValue("@consentpdf", consent);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["isbcorporate_test"].ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@aidguid", aidguid);
            //        cmd.Parameters.AddWithValue("@id", 5);
            //        cmd.Parameters.AddWithValue("@consentpdf", consent);
            //        cmd.Parameters.AddWithValue("@ip", ip);
            //        cmd.Parameters.AddWithValue("@aidsegmentname", segmentname);
            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}
        }
    }
    #endregion

    public class RequestISB : ISBWS.Request
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
            NetworkCredential credentials = base.Credentials as NetworkCredential;
            credentials.UserName = ConfigurationManager.AppSettings["WebServiceUserName"];
            credentials.Password = ConfigurationManager.AppSettings["WebServicePassword"];
            if (credentials != null)
            {
                string s = (((credentials.Domain != null) && (credentials.Domain.Length > 0)) ? (credentials.Domain + @"\") : string.Empty) + credentials.UserName + ":" + credentials.Password;
                s = Convert.ToBase64String(Encoding.Default.GetBytes(s));
                webRequest.Headers["Authorization"] = "Basic " + s;
            }
            return webRequest;
        }
    }

  

    public class RequestISBPinketron : ISBWS.Request
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
            NetworkCredential credentials = base.Credentials as NetworkCredential;
            credentials.UserName = ConfigurationManager.AppSettings["ProductDetailsUserName"];
            credentials.Password = ConfigurationManager.AppSettings["ProductDetailsPassword"];
            if (credentials != null)
            {
                string s = (((credentials.Domain != null) && (credentials.Domain.Length > 0)) ? (credentials.Domain + @"\") : string.Empty) + credentials.UserName + ":" + credentials.Password;
                s = Convert.ToBase64String(Encoding.Default.GetBytes(s));
                webRequest.Headers["Authorization"] = "Basic " + s;
            }
            return webRequest;
        }
    }

    #region Email
    static public string SendEmail(string EmailTo, string subject, string emailbody)
    {
        SmtpClient S = new SmtpClient();
        MailAddress to = new MailAddress(EmailTo);
        
        MailAddress from = new MailAddress("EIDApplication@isbc.ca");
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
        message.Bcc.Add("athangaraj@isbc.ca");
        message.IsBodyHtml = true;
        message.Body = emailbody;
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

    #region Duplicate Check
    public bool CheckForDuplicate(string payload)
    {

        int rowcount = 0;
        
        string AID_JSON = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {

                using (SqlCommand cmd = new SqlCommand(" select * from AIDOrders where payload = @payload and transdt> '2020-02-09' ", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@payload", payload);
                    //cmd.Parameters.AddWithValue("@aidjson", "");
                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        segmentname = sqlDataReader["AIDSegmentName"].ToString();
                        AID_JSON = sqlDataReader["AID_JSON"].ToString();
                        GUID = sqlDataReader["AIDGUID"].ToString();
                        TransactionTime = Convert.ToDateTime(sqlDataReader["Transdt"].ToString());
                    }

                    //rowcount = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
        }
        catch(Exception ex)
        {
           // SendEmail("athangaraj@isbc.ca", "DUPERROR", ""+ ex.Message);
        }

        //if (rowcount>0)
        if(String.IsNullOrEmpty(AID_JSON)) 
        {
            return false;
        }
        else if (String.IsNullOrEmpty(segmentname))
        {
            SendEmail("athangaraj@isbc.ca", "JSON present but segment name not present", "payload: " + payload + "<br/>JSON:" + AID_JSON);
            return false;            
        }
        else if(segmentname == "Link Clicked")
        {
            return false;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Duplicate Check On Load
    public bool CheckForDuplicateOnLoad(string payload)
    {

        int rowcount = 0;

        string AID_JSON = "";
        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand(" select count(*) from AIDOrders where payload = @payload ", conn))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@payload", payload);
        //        //cmd.Parameters.AddWithValue("@aidjson", "");

        //        conn.Open();
        //        rowcount = Convert.ToInt32(cmd.ExecuteScalar());
        //        conn.Close();
        //    }
        //}
        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
        {

            using (SqlCommand cmd = new SqlCommand(" select * from AIDOrders where payload = @payload and transdt> '2021-02-01' ", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@payload", payload);
                //cmd.Parameters.AddWithValue("@aidjson", "");
                conn.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                
                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        segmentname = sqlDataReader["AIDSegmentName"].ToString();
                    GUID = sqlDataReader["AIDGUID"].ToString();
                        TransactionTime = Convert.ToDateTime(sqlDataReader["Transdt"].ToString());
                        conn.Close();
                        return true;
                    }
                    else
                    {

                        conn.Close();
                        return false;
                    }
                

                //rowcount = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
        }


    }
    #endregion


    #region Decrypt ISBGUID link
    public string Decryptt(string sQuery, string sEncryptionKey)
    {
        byte[] key = new byte[] { };
        byte[] IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        string[] sChkKey = new[] { "_$$" };
        string sEncKey = "dxW0k2P8";
        byte[] inputByteArray = new byte[sQuery.Length + 1];
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes((sEncryptionKey.Substring(0, 8)));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(sQuery);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            string[] sDec = encoding.GetString(ms.ToArray()).Split(sChkKey, StringSplitOptions.RemoveEmptyEntries);
            if (!verifyCheckSum(sDec[0], sDec[1]))
                throw new Exception("Decryption Failed");
            else
                return sDec[0];
        }
        catch (Exception e)
        {
            return e.Message;
        }

    }
    public bool verifyCheckSum(string sQuery, string sChkSum)
    {
        if (calcCheckSum(sQuery) == sChkSum)
            return true;
        else
            return false;
    }
    public string calcCheckSum(string strQuery)
    {
        // Simple sum take all characters in query string , add ascii codes together for a check sum
        char[] chrSep = new char[] { '=', '&' };
        string[] sParts = strQuery.Split(chrSep);
        int chkSum = 0;
        foreach (string str in sParts)
        {
            foreach (int val in System.Text.Encoding.ASCII.GetBytes(str))
                chkSum += val;
        }
        return chkSum.ToString();
    }
    #endregion


    public bool MVRCheckboxCheck(int companyid)
    {
        int count = 0;
        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
        {
            using (SqlCommand cmd = new SqlCommand("select count(productid) from MIDProductsToOrder where companyid = @companyid and productid = 1660", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@companyid", companyid);

                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                //conn.Dispose();
            }
        }
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    static public string SendEmailToPartner(string EmailTo, string subject, string emailbody,string companyid, string guid)
    {
        SmtpClient S = new SmtpClient();
        MailAddress to = new MailAddress(EmailTo);

        MailAddress from = new MailAddress("EIDApplication@isbc.ca");
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
        message.Bcc.Add("athangaraj@isbc.ca");
        message.IsBodyHtml = true;
        message.Body = emailbody;
        //S.Host = "localhost";
        //S.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
        S.Host = "centos6.afimacglobal.com";
        S.Port = 25;
        S.UseDefaultCredentials = false;
        S.Credentials = new NetworkCredential("Donotreply@isbc.ca", "AFI1isb2");
        S.DeliveryMethod = SmtpDeliveryMethod.Network;
        message.Subject = subject;
        S.Send(message);


        if (!EmailTo.Contains("athangaraj"))
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
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
                    Value = 4
                };
                cmd.Parameters.Add(TypeID);
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();

            }
        }

        return "Email Sent";
    }



    public void WKHtmlToPdf()
    {
        //var fileName = " - ";
        //var wkhtmlDir = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin";
        //var wkhtml = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\wkhtmltopdf.exe";
        //var p = new Process();

        //p.StartInfo.CreateNoWindow = true;
        //p.StartInfo.RedirectStandardOutput = true;
        //p.StartInfo.RedirectStandardError = true;
        //p.StartInfo.RedirectStandardInput = true;
        //p.StartInfo.UseShellExecute = false;
        //p.StartInfo.FileName = wkhtml;
        //p.StartInfo.WorkingDirectory = wkhtmlDir;

        //string switches = "";
        //switches += "--print-media-type ";
        //switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
        //switches += "--page-size Letter ";
        //p.StartInfo.Arguments = switches + " " + url + " " + fileName;
        //p.Start();

        ////read output
        //byte[] buffer = new byte[32768];
        //byte[] file;
        //using (var ms = new MemoryStream())
        //{
        //    while (true)
        //    {
        //        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);

        //        if (read <= 0)
        //        {
        //            break;
        //        }
        //        ms.Write(buffer, 0, read);
        //    }
        //    file = ms.ToArray();
        //}

        //// wait or exit
        //p.WaitForExit(60000);

        //// read the exit code, close process
        //int returnCode = p.ExitCode;
        //p.Close();

        //return returnCode == 0 ? file : null;


        //string strArguments = null;
        //string CONSENTOPDF = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\" +   "test.pdf";
        //string html = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\htmltest.html";
        //string pdf = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\test.pdf";

        ////strArguments = localfilestr + " " + CONSENTOPDF;
        //strArguments = html  + " " + pdf;
        //System.Diagnostics.Process p = new System.Diagnostics.Process();
        //p.StartInfo.RedirectStandardError = true;
        //p.StartInfo.RedirectStandardInput = true;
        //p.StartInfo.RedirectStandardOutput = true;
        //p.StartInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\" + "wkhtmltopdf.exe";
        ////p.StartInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\HTMLTOPDF\" + "wkhtmltopdf.exe";
        //p.StartInfo.UseShellExecute = false;
        //p.StartInfo.Arguments = "--javascript-delay 9000 " + strArguments;

        //p.StartInfo.WorkingDirectory = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin";
        //p.Start();
        //p.WaitForExit(10000);
        //if (p.HasExited)
        //{
        //    //string result = p.StandardOutput.ReadToEnd();
        //    int chkcode = p.ExitCode;
        //}
        //p.Close();

        string strCmdText;
        //strCmdText = "/C wkhtmltopdf.exe htmltest.html testpdf.pdf";
        
        //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //startInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin\wkhtmltopdf.exe";
        startInfo.FileName = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin\wkhtmltopdf.exe";
        startInfo.Arguments = "C:/Users/athangaraj/OneDrive%20-%20The%20Dalton%20Group%20of%20Companies/Desktop/HTMLTOPDF/TEST.html testpdf.pdf";
        //startInfo.WorkingDirectory = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Desktop\wkhtmltox\bin";
        startInfo.WorkingDirectory = @"C:\sites\infosearchsite.com\isbPortal\PROD - INS\bin";
        startInfo.UseShellExecute = false;
        process.StartInfo = startInfo;
        process.Start();
    }

    public bool PinkertonDuplicateCheck(string firstname, string lastname, string dob, string isbguid, string payload)
    {
        try
        {
            string spresult;
            string rowid = "";
            string duplicatexml = "";
            string existingphonenumber = "";
            string gender = "";
            string transdt = "";

            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {

                using (SqlCommand cmd = new SqlCommand("WS_CheckDuplicate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@AIDGUID", isbguid);
                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    sqlDataReader.Read();


                    if (sqlDataReader.HasRows)
                    {
                        spresult = sqlDataReader["spresult"].ToString();
                        rowid = sqlDataReader["id"].ToString();
                        duplicatesegmentname = sqlDataReader["AIDSegmentName"].ToString();
                        duplicatetransid = sqlDataReader["AIDTransId"].ToString();
                        transdt = sqlDataReader["Transdt"].ToString();
                        duplicateguid = sqlDataReader["AIDGUID"].ToString();
                    }
                    else
                    {
                        spresult = "";
                    }

                    conn.Close();

                }

            }


            //replace with Harpreet sp

            // if sp condition is true then... continue... else dont do this...
            if (spresult != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(spresult);
                string phonenumber = doc.GetElementsByTagName("isb_appphone")[0].InnerXml.ToString();
                using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                {

                    using (SqlCommand cmd = new SqlCommand("select ProductXML from WSPackageDetails  where packageguid = @isbguid ", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@isbguid", Session["ISBGUID"]);
                        conn.Open();
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();

                        if (sqlDataReader.HasRows)
                        {
                            sqlDataReader.Read();

                            duplicatexml = sqlDataReader["ProductXML"].ToString();

                            XmlDocument doc2 = new XmlDocument();
                            doc2.LoadXml(duplicatexml);
                            existingphonenumber = doc2.GetElementsByTagName("isb_appphone")[0].InnerXml.ToString().Replace("-", "").Replace(" ", "");
                            gender = doc2.GetElementsByTagName("isb_Sex")[0].InnerXml.ToString();

                            //duplicateguid = sqlDataReader["AIDGUID"].ToString();
                            //duplicatetransid = sqlDataReader["AIDTransID"].ToString();
                            conn.Close();
                            //return true;
                        }
                        else
                        {
                            duplicatesegmentname = "";
                            duplicateguid = "";
                            conn.Close();
                            //return false;
                        }

                    }
                }
                if (phonenumber == existingphonenumber)
                {
                    if (duplicatesegmentname == "Good ID" && (Convert.ToDateTime(transdt).AddDays(330)) > DateTime.Now)
                    {
                        string invoicetransdt;
                        string vidresult;
                        string packagedetailid;
                        string paperport;

                        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                        {
                            using (SqlCommand cmd = new SqlCommand("WS_AIDOrders", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@payload", payload);
                                cmd.Parameters.AddWithValue("@companyid", 3391);
                                cmd.Parameters.AddWithValue("@ip", GetIPAddress());
                                cmd.Parameters.AddWithValue("@id", 9);
                                cmd.Parameters.AddWithValue("@wspackageid", "");
                                cmd.Parameters.AddWithValue("@aidguid", Session["ISBGUID"].ToString());
                                cmd.Parameters.AddWithValue("@AIDSegmentName", duplicatesegmentname);
                                cmd.Parameters.AddWithValue("@AIDTransID", duplicatetransid);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                        //CALL API

                        RequestISBPinketron client = new RequestISBPinketron();
                        string Package;





                        Package = "<ProductData><isb_dupedata>";
                        Package += "" + "</isb_dupedata><isb_appothername>" + Session["lastname"] + "</isb_appothername><isb_appsecondname></isb_appsecondname>" +
                            "<isb_DOB>" + dob + "</isb_DOB><isb_Sex>" + gender + "</isb_Sex><isb_POB></isb_POB><isb_appfirstname>" + Session["firstname"] + "</isb_appfirstname>" +
                            "<isb_appsurname>" + Session["lastname"] + "</isb_appsurname><isb_appfirstname>" + Session["firstname"] + " </isb_appfirstname>" +
                            "<isb_appsurname>" + Session["lastname"] + "</isb_appsurname></ProductData>";


                        string username = ConfigurationManager.AppSettings["ProductDetailsUserName"];
                        string password = ConfigurationManager.AppSettings["ProductDetailsPassword"];


                        client.Credentials = new NetworkCredential(username, password);
                        client.PreAuthenticate = true;
                        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);
                        client.UseDefaultCredentials = true;
                        string chkstatus = client.ProductDetails(Session["ISBGUID"].ToString(), Package, "1603", "EBS", true, true);
                        string pdi = chkstatus.Substring(chkstatus.IndexOf('[') + 1, chkstatus.Length - chkstatus.IndexOf('[') - 2);



                        string VIDinvoicedhtml = "<html> MID  TransID is  " + duplicatetransid + "</html>";

                        string localfilestr = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\" + @"midresult_" + duplicatetransid + ".html";
                        using (FileStream fs = new FileStream(localfilestr, FileMode.Create))
                        {
                            using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                            {
                                w.WriteLine(VIDinvoicedhtml);
                            }
                        }

                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                        string foldername = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\";

                        startInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Documents\Visual Studio Projects\Consent\Consent\Bin\wkhtmltopdf.exe";
                        startInfo.FileName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin\\wkhtmltopdf.exe";

                        startInfo.Arguments = "midresult_" + duplicatetransid + ".html" + " " + "midresult_" + duplicatetransid + ".pdf";

                        startInfo.WorkingDirectory = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin";
                        startInfo.UseShellExecute = false;
                        process.StartInfo = startInfo;
                        process.Start();


                        byte[] bytes = File.ReadAllBytes(foldername + "midresult_" + duplicatetransid + ".pdf");

                        string result = client.UploadBinaryFile(Session["ISBGUID"].ToString(), pdi, Convert.ToBase64String(bytes), "1603", "CONSENT.PDF", "CONSENT", "EBS", true, true);
                        //return chkstatus;


                        return true;


                    }
                    else
                    {
                        string invoicetransdt;
                        string vidresult;
                        string packagedetailid;
                        string paperport;
                        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                        {

                            //using (SqlCommand cmd = new SqlCommand("select * from invoicedetail a inner join packagedetails b on a.PackageId = b.PackageID where packageid = (select WebPackageID from WSPackage where PackageGUID = @duplicateguid) and a.ProductId = 1685 and b.productid = 1685", conn))
                            using (SqlCommand cmd = new SqlCommand("select* from invoicedetail as a inner join package as b on b.PackageID = a.PackageId inner join WSPackage as c on c.WebPackageID = b.PackageID inner join packagedetails as d on d.PackageDetailID = a.PackageDetailId where a.ProductId in (1685) and c.PackageGUID = @duplicateguid and a.CreatedDate > GETDATE() - 330", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@duplicateguid", duplicateguid);
                                conn.Open();
                                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                                if (sqlDataReader.HasRows)
                                {
                                    sqlDataReader.Read();
                                    invoicetransdt = sqlDataReader["createddate"].ToString();
                                    vidresult = sqlDataReader["policefile"].ToString();
                                    packagedetailid = sqlDataReader["packagedetailid"].ToString();
                                    paperport = sqlDataReader["paperportfolder"].ToString().Remove(sqlDataReader["paperportfolder"].ToString().LastIndexOf('\\'));
                                    string destination = @"\\10.10.2.5\d$\ISB\" + paperport + @"\vidresult_" + packagedetailid + ".pdf";
                                    conn.Close();

                                    //insert
                                    using (SqlConnection conn2 = new SqlConnection(DATABASE_CONNECTION))
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand("WS_AIDOrders", conn2))
                                        {
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Parameters.AddWithValue("@payload", payload);
                                            cmd2.Parameters.AddWithValue("@companyid", 3391);
                                            cmd2.Parameters.AddWithValue("@ip", GetIPAddress());
                                            cmd2.Parameters.AddWithValue("@id", 9);
                                            cmd2.Parameters.AddWithValue("@wspackageid", "");
                                            cmd2.Parameters.AddWithValue("@aidguid", Session["ISBGUID"].ToString());
                                            cmd2.Parameters.AddWithValue("@AIDSegmentName", duplicatesegmentname);
                                            cmd2.Parameters.AddWithValue("@AIDTransID", duplicatetransid);

                                            conn2.Open();
                                            cmd2.ExecuteNonQuery();
                                            conn2.Close();
                                        }
                                    }

                                    //call api


                                    RequestISBPinketron client = new RequestISBPinketron();
                                    string Package;





                                    Package = "<ProductData><isb_dupedata>";
                                    Package += "" + "</isb_dupedata><isb_appothername>" + Session["lastname"] + "</isb_appothername><isb_appsecondname></isb_appsecondname>" +
                                        "<isb_DOB>" + dob + "</isb_DOB><isb_Sex>" + gender + "</isb_Sex><isb_POB></isb_POB><isb_appfirstname>" + Session["firstname"] + "</isb_appfirstname>" +
                                        "<isb_appsurname>" + Session["lastname"] + "</isb_appsurname><isb_appfirstname>" + Session["firstname"] + " </isb_appfirstname>" +
                                        "<isb_appsurname>" + Session["lastname"] + "</isb_appsurname></ProductData>";


                                    string username = ConfigurationManager.AppSettings["ProductDetailsUserName"];
                                    string password = ConfigurationManager.AppSettings["ProductDetailsPassword"];


                                    client.Credentials = new NetworkCredential(username, password);
                                    client.PreAuthenticate = true;
                                    bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);
                                    client.UseDefaultCredentials = true;
                                    string chkstatus = client.ProductDetails(Session["ISBGUID"].ToString(), Package, "1603", "EBS", true, true);
                                    string pdi = chkstatus.Substring(chkstatus.IndexOf('[') + 1, chkstatus.Length - chkstatus.IndexOf('[') - 2);

                                    string VIDinvoicedhtml = "<html>VID invoiced on " + invoicetransdt + "  Result is " + vidresult + "</html>";

                                    string localfilestr = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\" + @"vidresult_" + packagedetailid + ".html";
                                    using (FileStream fs = new FileStream(localfilestr, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            w.WriteLine(VIDinvoicedhtml);
                                        }
                                    }



                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                                    string foldername = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "bin\\";

                                    startInfo.FileName = @"C:\Users\athangaraj\OneDrive - The Dalton Group of Companies\Documents\Visual Studio Projects\Consent\Consent\Bin\wkhtmltopdf.exe";
                                    startInfo.FileName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin\\wkhtmltopdf.exe";

                                    startInfo.Arguments = "vidresult_" + packagedetailid + ".html" + " " + "vidresult_" + packagedetailid + ".pdf";

                                    startInfo.WorkingDirectory = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath.ToString() + "Bin";
                                    startInfo.UseShellExecute = false;
                                    process.StartInfo = startInfo;
                                    process.Start();



                                    byte[] bytes = File.ReadAllBytes(foldername + "vidresult_" + packagedetailid + ".pdf");
                                    //string chkstatus = client.ProductDetails("5D048AB0-559C-4F9D-92B4-BF2077C6C46A", Package, "1603", "EBS", false, false);
                                    client.UploadBinaryFile(Session["ISBGUID"].ToString(), pdi, Convert.ToBase64String(bytes), "1603", "CONSENT.PDF", "PDF", "EBS", true, true);
                                    //return chkstatus;





                                    return true;
                                }
                                else
                                {

                                    conn.Close();
                                    return false;
                                }

                            }
                        }

                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        catch(Exception ex)
        {
            SendEmail("athangaraj@isbc.ca", "Pinkertonduplicateerror", ex.Message.ToString());
            return false;
        }

    }

    public string GetProductidFromQueryString()
    {
        string ProductId = "";
        byte[] key = Decrypt.Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
        string querystring = Request.Url.Query.Substring(Request.Url.Query.IndexOf('?') + 1);

        if (Request.QueryString["querystring"] != null)
        {
            querystring = Request.QueryString["querystring"];
        }
        querystring = Decrypt.DecryptFernet(key, querystring);

        NameValueCollection parsedStr = HttpUtility.ParseQueryString(querystring);

        if (parsedStr.AllKeys.Length > 1)
        {
            foreach (string s in parsedStr.AllKeys)
            {
                if (s == "productid")
                {
                    ProductId = parsedStr[s];
                    break;
                }
            }
        }
        return ProductId;
    }

    public bool IsPayloadOlderThan(string payload)
    {
        if (payload == null || payload == "") return false;

        int CompanyId = 0;
        string dategenerated = "";
        string[] payloadArray = payload.Split(';');

        for (int i = 0; i < payloadArray.Length; i++)
        {
            string pp = payloadArray[i];
            if (payloadArray[i].Contains("companyid:"))
            {
                CompanyId = Convert.ToInt32(payloadArray[i].Replace("companyid:", ""));
            }
            if (payloadArray[i].Contains("dategenerated:"))
            {
                dategenerated = payloadArray[i].Replace("dategenerated:", "");
                if(CompanyId > 0)
                {
                    break;
                }
            }
        }
        if (CompanyId <= 0) return false;

        int days = 0;
        if (ConfigurationManager.AppSettings["LinkExpiryThreshold_" + CompanyId] != null)
        {
            days = Convert.ToInt32(ConfigurationManager.AppSettings["LinkExpiryThreshold_" + CompanyId]);
        }
        if (days <= 0) return false;

        if (dategenerated != "" && (DateTime.Now - Convert.ToDateTime(dategenerated)).TotalDays > days)
        {
            return true;
        }
        return false;
    }
}