using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instructions : System.Web.UI.Page
{
    static string AIDGUID;
    string companyid;
    string lan  ;
    string landing;
    string querystring;
    string DATABASE_CONNECTION;

    protected void Page_Load(object sender, EventArgs e)
    {

        AIDGUID = Request.QueryString["Instructionid"];
        //AIDGUID = "58E20558-692D-4B92-B6A7-BB0DB1C0B712";
        lan = Request.QueryString["lang"];
        landing = Request.QueryString["landing"];
        querystring = Request.QueryString["querystring"];

        Configuration configuration = new Configuration();
        DATABASE_CONNECTION = configuration.GetConnectionString();


        if (!IsPostBack)
        {
            if (lan != null)
            {
                if (lan == "QC")
                {
                    lbl22.InnerText = "Instructions pour le permis de conduire";
                    lbl23.InnerText = "1. Tenez fermement votre téléphone dans la position paysage";
                    lbl24.InnerText = "2. Assurez-vous de placer votre pièce d’identité sur un fond contrastant (non blanc ou noir)";
                    lbl25.InnerText = "3. Assurez-vous de n’avoir aucun reflet. Placez la pièce d’identité au centre et assurez-vous que tous les coins figurent dans le cadre de la caméra ";
                    lbl26.InnerText = "Instructions pour un autoportrait";
                    lbl27.InnerText = "1. Ne portez pas de couvre-chef";
                    lbl28.InnerText = "2. Assurez-vous qu’il n’y a aucun reflet";
                    lbl29.InnerText = "3. Enlevez toute paire de lunettes";
                    lbl30.InnerText = "4. Assurez-vous de regarder la caméra et non à côté";
                    lbl31.InnerText = "Veuillez garder la fenêtre de navigateur ouverte jusqu’à ce que vous obteniez des résultats – une lumière verte ou rouge pour la vérification de votre identité";

                    btnContinue.InnerText = "Je comprends. Passons à l’étape suivante";

                    redirect.InnerHtml = "Vous pouvez continuer en <span id=\"count\"></span> seconds en cliquant sur \"Je comprends et désire continuer\" ";

                    lbl32.InnerText = "";
                    lblhead.InnerText = "";

                    btnContinue.Attributes["data-language"] = "FR";

                }
            }
        }
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('You are about to leave this page.Please do not close this window or click the Back button on your browser until completing the process');", true);
    }

    protected void btnContinue_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (AIDGUID != null)
            {

                using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                {
                    using (SqlCommand cmd = new SqlCommand("select companyid from AIDOrders where AIDGUID = @aidguid ", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@aidguid", AIDGUID);

                        conn.Open();
                        companyid = Convert.ToString(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);


            if (Request.QueryString["landingpage"] == "yes")
            {
                Server.Transfer("ValidateCredentials.aspx?companyid=3653" + "&lang=" + lan+"&querystring="+querystring+"&landingpage=yes");
            }
            else
            {
                Server.Transfer("ValidateCredentials.aspx?Instructionid=" + AIDGUID + "&companyid=" + companyid + "&lang=" + lan);
            }
            
            //Response.Redirect("https://authenticate.isbc.ca/webui/default.html?GUID=" + AIDGUID, false);

            //DayOfWeek day = DateTime.Now.DayOfWeek;
            //if(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            //{

            //}
        }
        catch(Exception ex)
        {
            //Server.Transfer("ValidateCredentials.aspx?Instructionid=" + AIDGUID );
            SendEmail("athangaraj@Isbc.ca", "ERROR IN EID APPLICATION", "There was an error in application EID" + ex.Message);
        }



    }


    static public string SendEmail(string EmailTo, string subject, string emailbody)
    {
        SmtpClient S = new SmtpClient();
        MailAddress to = new MailAddress(EmailTo);

        MailAddress from = new MailAddress("EIDApplication@isbc.ca");
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
        message.To.Add("athangaraj@isbc.ca");
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

}