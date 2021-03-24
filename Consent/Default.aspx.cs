using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Utils.fBrowserIsMobile())
        {
            HttpContext.Current.Response.Redirect("http://stackoverflow.com");
        }
        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("success.aspx");
    }
}