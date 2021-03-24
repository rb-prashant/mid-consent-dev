using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Failed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ErrorMsg = Request.QueryString["msg"];
        if (ErrorMsg != null)
        {
            if (ErrorMsg == "link_expired")
            {
                ErrorMsgResponse.InnerHtml = "<p style='padding: 10px 24px; font-size: 3vw;'><strong>Uh Oh!</strong><br/> This link has expired. A new link has been requested for you however it can take up to 7 days to receive it.</p>";
            }
        }
    }
}