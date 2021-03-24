using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Landing : System.Web.UI.Page
{
    string querystring;
    string firstname; 
    string language; 
    string companyid;
    string DATABASE_CONNECTION;

    protected void Page_Load(object sender, EventArgs e)
    {
        //SendEmail("athangaraj@isbc.ca", "Pageloaded", "" + DateTime.Now);


        Session["firstname"] = Request.QueryString["firstname"];
        Session["language"] = Request.QueryString["lang"];
        Session["companyid"] = Request.QueryString["companyid"];
        Session["landingpageloadedalready"] = "YES";
        Button1.Visible = false;


        //if (Session["pageloadedalready"] == "YES")

        //for testing
        //Session["firstname"] = "alex";
        //Session["language"] = "EN";
        //Session["companyid"] = "3409";
        //Session["landingpageloadedalready"] = "YES";
        //Session["province"] = "ON";
        //Session["package"] = "";

        Configuration configuration = new Configuration();
        DATABASE_CONNECTION =  configuration.GetConnectionString();


        if (!IsPostBack)
        {
            
            if (DateTime.Now > Convert.ToDateTime("2018-10-31 23:59:59"))
            {
                Session["pageloadedalready"] = "YES";
                //landingdiv.InnerText = "This link is no longer active. Please visit your nearest Greenlight Hub to complete your background check.";
               // btnContinue.Visible = false; //uberrs
                if (Session["language"].ToString() == "FR")
                {
                    divwelcometxt.InnerText = " Bonjour " + Session["firstname"] + ",";
                    bannerimg.Src = "https://infosearchsite.com/MID/Images/banner_fr.png";


                    DataSet ds = new DataSet();
                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 6 and langugateid = 2 and companyid in (0," + Session["companyid"] + ") order by companyid desc", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            conn.Open();
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                            da1.Fill(ds);

                        }
                    }

                    div2.InnerText = ds.Tables[0].Rows[0][1].ToString();
                    div3.InnerText = ds.Tables[0].Rows[0][2].ToString();
                    div4.InnerHtml = ds.Tables[0].Rows[0][3].ToString();
                    
                    divlist.InnerHtml = ds.Tables[0].Rows[0][7].ToString();
                    if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                    {
                        divlist.InnerHtml = ds.Tables[0].Rows[0][7].ToString() + ds.Tables[0].Rows[0][8].ToString();
                    }
                    btnContinue.InnerText = ds.Tables[0].Rows[0][4].ToString();
                    btnLater.InnerText = ds.Tables[0].Rows[0][5].ToString();
                    footer.InnerText = ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    Session["pageloadedalready"] = "YES";


                    divwelcometxt.InnerText = " Hi " + Session["firstname"] + ",";



                    DataSet ds = new DataSet();
                    using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from MVIDEMailTemp where templateid = 6 and langugateid = 1  and companyid in (0," + Session["companyid"] + ") order by companyid desc", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            conn.Open();
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                            da1.Fill(ds);

                        }
                    }

                    div2.InnerText = ds.Tables[0].Rows[0][1].ToString();
                    div3.InnerText = ds.Tables[0].Rows[0][2].ToString();
                    div4.InnerHtml = ds.Tables[0].Rows[0][3].ToString();
                    divlist.InnerHtml = ds.Tables[0].Rows[0][7].ToString();
                    if (Session["province"].ToString() == "QC" && Session["package"].ToString() == "RS")
                    {
                        divlist.InnerHtml = ds.Tables[0].Rows[0][7].ToString() + ds.Tables[0].Rows[0][8].ToString();
                    }
                    btnContinue.InnerText = ds.Tables[0].Rows[0][4].ToString();
                    btnLater.InnerText = ds.Tables[0].Rows[0][5].ToString();
                    footer.InnerText = ds.Tables[0].Rows[0][6].ToString();

                    //if (Session["companyid"].ToString() == "3409")
                    //{

                    //    buttons.Visible = false;
                    //}
                }

            }
            else
            {
                Session["querystring"] = Request.QueryString["querystring"];
            }
        }
    }
    protected void btnContinue_Click(object sender, System.EventArgs e)
    {
        //SendEmail("athangaraj@isbc.ca", "Button Clicked", "BUTTON WAS CLICKED AT "+DateTime.Now.ToString() +"Session variables " + Session["firstname"] + "" + Session["language"] + "" + Session["pageloadedalready"]);
        try
        {
            //Server.Transfer("instructions.aspx?landing=yes&querystring="+querystring);
            Server.Transfer("ValidateCredentials.aspx?querystring="+ Request.QueryString["querystring"]+"&landing=yes&landingpage=yes");
        }
        catch(Exception ex)
        {
            //SendEmail("athangaraj@Isbc.ca", "ERROR IN EID APPLICATION", "There was an error in application EID" + ex.Message);
        }
    }


    protected void button1_Click(object sender, System.EventArgs e)
    {
        divwelcometxt.InnerText = "Health Screen Survey";
        landingdiv.Visible = false;
        healthdiv.Visible = true;
        div2.InnerText = "";
        buttons.Visible = true;
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