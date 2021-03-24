using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class UploadImage : System.Web.UI.Page
{
    string guid;
    string DATABASE_CONNECTION;

    protected void Page_Load(object sender, EventArgs e)
    {
        guid = Request.QueryString["uploadimgid"];
        guid = "123456";

        Configuration configuration = new Configuration();
        DATABASE_CONNECTION = configuration.GetConnectionString();

        if (!Page.IsPostBack)
        {
            
            //Session["thanks"] = "NO";
        }

       
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        //Files is folder Name

        //string filename = Path.GetFileName(fuSample.FileName);
        //fuSample.SaveAs(Server.MapPath("Files") + "//" + fuSample.FileName);
        //lblMessage.Text = "File Successfully Uploaded";
        //lblUpload.Text = "Thanks for the upload";


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

              //  string strTestFilePath2 = uplFileUploader2.PostedFile.FileName; // This gets the full file path on the client's machine ie: c:\test\myfile.txt
                //string strTestFileName2 = Path.GetFileName(strTestFilePath2); // use the System.IO Path.GetFileName method to get specifics about the file without needing to parse the path as a string
                //Int32 intFileSize2 = uplFileUploader2.PostedFile.ContentLength;
                //string strContentType2 = uplFileUploader2.PostedFile.ContentType;

                // Convert the uploaded file to a byte stream to save to your database. This could be a database table field of type Image in SQL Server
                //Stream strmStream2 = uplFileUploader2.PostedFile.InputStream;
                //Int32 intFileLength22 = (Int32)strmStream2.Length;
                byte[] bytUpfile2 = new byte[intFileLength + 1];
               // strmStream2.Read(bytUpfile2, 0, intFileLength);
               // strmStream2.Close();

                saveFileToDb(bytUpfile, bytUpfile2, guid); // or use uplFileUploader.SaveAs(Server.MapPath(".") + "filename") to save to the server's filesystem.
               
                uplFileUploader.Visible = false;
                // uplFileUploader2.Visible = false;
                btnContinue.Visible = false;
               
                lblUpload.Text = "Thank You! The images have been uploaded successfully";
            }
            catch (Exception err)
            {
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
    protected void saveFileToDb(byte[] bytUpfile,byte[] bytUpfile2, string guid)
    {
        string testDbConnection = DATABASE_CONNECTION;
        // string testDbConnection = "Data Source=VMCorpDev1;Initial Catalog=PropertyManagement;Persist Security Info=True;User ID=ais_devel;Password=devel";
        // string strInsertStmt = string.Format("INSERT INTO [PropMgtFileAttachments] ([AttachedFileName],[CreatedBy],[CreatedDt],[AttachedFile]) VALUES ('{0}','John Doe',GETDATE(),@TestFile)", strTestFileName);
        string strInsertStmt = string.Format("insert into AIDUploadImage values (@GUID,@TestFile,@TestFile2,@statusid, getdate())");

        using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
        {
            SqlCommand cmdCommand = conn.CreateCommand();
            cmdCommand.CommandText = strInsertStmt;
            cmdCommand.CommandType = System.Data.CommandType.Text;
            cmdCommand.Parameters.AddWithValue("@TestFile", bytUpfile);
            cmdCommand.Parameters.AddWithValue("@TestFile2", bytUpfile2);
            cmdCommand.Parameters.AddWithValue("@GUID", guid);
            cmdCommand.Parameters.AddWithValue("@statusid", 1);
            cmdCommand.Connection.Open();
            cmdCommand.ExecuteNonQuery();
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        lblUpload.Text = "Thanks for the Upload";
    }
}