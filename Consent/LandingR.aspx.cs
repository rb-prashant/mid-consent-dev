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

public partial class LandingR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Session["id"] = Request.QueryString["id"];
            Session["id"] = "1";

            Session["firstname"] = Request.QueryString["firstname"];
            Session["language"] = Request.QueryString["lang"];
            Session["companyid"] = Request.QueryString["companyid"];


            Session["firstname"] = "Alex";
            Session["language"] = "FR";
            Session["companyid"] = "3409";
            Session["province"] = "QC";
            Session["package"] = "RS";

            //DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select payload from Uberreruns where id= @id", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", Session["id"].ToString());
                    conn.Open();
                    string payload = cmd.ExecuteScalar().ToString();
                    conn.Close();

                }
            }

            if (Session["language"].ToString() == "FR")
            {
                divwelcometxt.InnerText = " Bonjour " + Session["firstname"] + ",";
                bannerimg.Src = "https://infosearchsite.com/MID/Images/banner_fr.png";


                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
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
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString))
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
                  //  divlist.InnerHtml = ds.Tables[0].Rows[0][7].ToString() + ds.Tables[0].Rows[0][8].ToString();
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
    }

    protected void btnContinue_Click(object sender, System.EventArgs e)
    {
    }

}