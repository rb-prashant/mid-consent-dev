using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class TestPage : System.Web.UI.Page
{
    static string DATABASE_CONNECTION;
    static string sEncKey = "dxW0k2P8";

    protected void Page_Load(object sender, EventArgs e)
    {
        //IsPayloadOlderThan("driveruuid:ad4fd6d2-262f-4d66-a27f-365fbdb0b7ee;companyid:;firstname:Jean-francois;middlename:;lastname:Ouellet;date_of_birth:1992-02-04;pdl:O430504029203;email:jeanfrancois.ouellet@hotmail.com;package:111;dategenerated:2021-03-15;province:QC;language:;productid:;", 7);


        Configuration configuration = new Configuration();
        DATABASE_CONNECTION = configuration.GetConnectionString();
        DataSet ds16 = new DataSet();
        string payload = "";
        string productdetails = "";
        string UI = "";
        string logvalue = "";


        payload = "companyid=3391&firstname=Prashant&middlename=&lastname=Sharma&Prov=ON&date_of_birth=03/03/1989&pdl=&email=prashant.sharma@redblink.net&package=&dategenerated=2021-3-4&ISBGUID=&productid=1603&driveruuid=ad4fd6d2-262f-4d66-a27f-365fbdb0b7ee&lang=English&abstractprovince=OT";
        string encodedurl = System.Web.HttpUtility.UrlEncode(Encrypt(payload, sEncKey));

        string decr = Decryptt(HttpUtility.UrlDecode(encodedurl), sEncKey);
        /*try
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from  WSPackageDetails WHERE WSPackageDetailID = 35450", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataAdapter ds15 = new SqlDataAdapter(cmd);

                    ds15.Fill(ds16);
                    UI = "";

                    payload = "companyid=" + ds16.Tables[0].Rows[0]["ProductID"].ToString();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(ds16.Tables[0].Rows[0]["ProductXML"].ToString());
                    payload += "&firstname=Prashant";
                    try
                    {
                        payload += "&middlename=" + doc.DocumentElement.SelectSingleNode("/ProductData/isb_appsecondname").InnerText;
                    }
                    catch
                    {
                        payload += "&middlename=";
                    }
                    payload += "&lastname=Sharma";
                    payload += "&Prov=ON&date_of_birth=" + doc.DocumentElement.SelectSingleNode("/ProductData/isb_DOB").InnerText;
                    payload += "&pdl=&email=prashant.sharma@redblink.net";
                    payload += "&package=&dategenerated=" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    payload += "&ISBGUID=" + UI;
                    if (productdetails.ToLower().IndexOf("<nondriverrequest>yes</nondriverrequest>") > 0)// this xml check is for ecommerce orders where candidate is  
                                                                                                         // non driver and should have an option for a passport or DL. So i am adding the PDL=111 and alex will take care of it from there 
                    {
                        payload = payload.Replace("&pdl=", "");
                        payload += "&pdl=111";
                    }
                    if (productdetails.ToLower().IndexOf("<nondriverrequest>no</nondriverrequest>") > 0)// this xml check is for ecommerce orders where candidate is  
                                                                                                        // non driver and should have an option for a passport or DL. So i am adding the PDL=111 and alex will take care of it from there 
                    {
                        payload = payload.Replace("&pdl=", "");
                        payload += "&pdl=driver";
                    }
                    // adding the productid for UBER 
                    if ((ds16.Tables[0].Rows[0]["ProductID"].ToString() == "3653") || *//*(ds16.Tables[0].Rows[0]["ProductID"].ToString() == "3409")*//* true)
                    {
                        try
                        {
                            payload += "&productid=1603";
                            payload += "&driveruuid=ad4fd6d2-262f-4d66-a27f-365fbdb0b7ee";
                            payload += "&lang=" + doc.DocumentElement.SelectSingleNode("/ProductData/isb_language").InnerText;
                            payload += "&abstractprovince=OT";
                        }
                        catch (Exception ex)
                        {
                            logvalue += logvalue + "Datetime : " + DateTime.Now.ToString() + "<br/><br/>" + payload + "<br />CompanyID - " + ds16.Tables[0].Rows[0]["ProductID"].ToString() + "<br/><br/>Error<br/><br/>" + ex.ToString() + "<br/><br/>";
                            *//*SendEmail(payload + "<br />CompanyID - " + ds16.Tables[0].Rows[0]["companyid"].ToString() + "<br/><br/>Error<br/><br/>" + ex.ToString(), "Payload before encoded", "hsidhu@isbc.ca");
                            logtoTexFile(logvalue);*//*
                        }
                    }
                    else
                    {
                        if (doc.DocumentElement.SelectSingleNode("/ProductData/isb_language") == null)
                        {
                            payload += "&lang=";
                        }
                        else
                        {
                            payload += "&lang=" + doc.DocumentElement.SelectSingleNode("/ProductData/isb_language").InnerText;
                        }
                    }

                    string encodedurl = System.Web.HttpUtility.UrlEncode(Encrypt(payload, sEncKey));
                    Console.WriteLine(payload);
                    Console.WriteLine(encodedurl);
                }
            }
        }
        catch(Exception ex1)
        {

        }*/
    }

    public bool IsPayloadOlderThan(string payload, int days)
    {
        if (payload == null || payload == "") return false;
        if (days <= 0) return false;

        string dategenerated = "";
        string[] payloadArray = payload.Split(';');

        for(int i=0; i < payloadArray.Length; i++)
        {
            string pp = payloadArray[i];
            if (payloadArray[i].Contains("dategenerated:"))
            {
                dategenerated = payloadArray[i].Replace("dategenerated:", "");
                break;
            }
        }

        DateTime aa = DateTime.Now;
        double tt = (DateTime.Now - Convert.ToDateTime(dategenerated)).TotalDays;


        if (dategenerated != "" && (DateTime.Now - Convert.ToDateTime(dategenerated)).TotalDays > days)
        {
            return true;
            /*using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[UberExpiredLinks]    ([payload],[driveruuid],[statusid],[transdt])    VALUES (@payload,@driveruuid,0,getdate())", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@payload", GetPayload());
                    cmd.Parameters.AddWithValue("@driveruuid", Session["driveruuid"].ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }*/
        }
        return false;
    }

    public string Encrypt(string sQuery)
    {
        return Encrypt(sQuery, sEncKey);
    }

    public string Encrypt(string sQuery, string SEncryptionKey)
    {
        string[] sChkKey = new[] { "_$$" };
        byte[] IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        sQuery = sQuery + sChkKey[0] + calcCheckSum(sQuery);
        try
        {
            byte[] key = System.Text.Encoding.UTF8.GetBytes((SEncryptionKey.Substring(0, 8)));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(sQuery);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }

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

    public bool verifyCheckSum(string sQuery, string sChkSum)
    {
        if (calcCheckSum(sQuery) == sChkSum)
            return true;
        else
            return false;
    }

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
}