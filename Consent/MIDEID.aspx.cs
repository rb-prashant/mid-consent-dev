using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class MIDEID : System.Web.UI.Page
{
    string ISB_DOMAIN_NAME;
    string DATABASE_CONNECTION;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtFirstName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BEBEBE");
        txtSecondName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BEBEBE");
        txtLastName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BEBEBE");

        Configuration configuration = new Configuration();
        DATABASE_CONNECTION = configuration.GetConnectionString();

        //CreateTestOrder();
        //string redirectlink = CallAPI("", CreateTestOrder());
        //Response.Redirect(redirectlink);
        if (!IsPostBack)
        {
            string guid =  Request.QueryString["guid"];
            string lang = Request.QueryString["lan"];

            //guid = "C7D6AC66-81FB-40C6-851E-6A60E1F76865";

           // CallAPI("", guid);
            lang = "EN";
            Session["guid"] = guid;
            Session["lang"] = lang;
            //guid = "66D10427-1410-41D3-8E15-D057A2408D18";
            string firstname ="";
            string middlename = "";
            string lastname = "";
            string dob = "";
            string email = "";
            string province = "";

            string payload;

            using (SqlConnection conn = new SqlConnection(DATABASE_CONNECTION))
            {
                using (SqlCommand cmd = new SqlCommand("select payload from AIDOrders  where AIDGUID =  @guid", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@guid", guid);

                    conn.Open();
                    payload = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();



                }
            }

            string St = payload.ToString();
            try
            {
                int pFrom = St.IndexOf("firstname:") + "firstname:".Length;
                int pTo = St.LastIndexOf(";middle");

                firstname = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }
            try
            {
                int pFrom = St.IndexOf("middlename:") + "middlename:".Length;
                int pTo = St.LastIndexOf(";lastname");

                middlename = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }
            try
            {
                int pFrom = St.IndexOf("lastname:") + "lastname:".Length;
                int pTo = St.LastIndexOf(";date_");

                lastname = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }
            try
            {
                int pFrom = St.IndexOf("date_of_birth:") + "date_of_birth:".Length;
                int pTo = St.LastIndexOf(";pdl");

                dob = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }
            try
            {
                int pFrom = St.IndexOf("email:") + "email:".Length;
                int pTo = St.LastIndexOf(";package");

                email = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }

            try
            {
                int pFrom = St.IndexOf("province:") + "province:".Length;
                int pTo = St.LastIndexOf(";productid");

                province = St.Substring(pFrom, pTo - pFrom);
            }
            catch
            {

            }

            txtFirstName.Text = firstname;
            txtSecondName.Text = middlename;
            txtLastName.Text = lastname;
            txtDob.Value = dob;
            txtEmail.Value = email;
            txtCurrentProvince.Text = province;

            if (Session["lang"] != null)
            {
                
                if (Session["lang"].ToString() == "FR")
                {
                    lblEidlanding.InnerHtml = "Malheureusement, nous n’avons pas été en mesure de valider votre identité. <br/>" +
                        "Pour compléter le processus de validation, ISB aimerait utiliser notre outil de validation d’identité électronique(eID).  La vérification d’identité à l’aide de l’eID est effectuée par l’intermédiaire d’Equifax à l’aide de son produit appelé eID Verifier.On vous posera 4 questions en fonction de vos antécédents de crédit. On peut vous poser de fausses questions(c’est - à - dire des questions pièges) ainsi que de vraies questions.Si la question ne se rapporte pas à vous, vous devriez répondre avec \"aucune de ces réponses\".Ce n’est pas une vérification de crédit et n’affecte pas votre pointage de crédit. Equifax utilise simplement les informations de vos antécédents de crédit pour vérifier votre identité avec des questions que vous seul devez connaître les réponses. <br/>" +
                        "Cet outil ne donne pas à Uber accès à vos informations de crédit ou à vos réponses aux questions d’eID.La seule information qui est fournie à Uber au sujet de votre vérification eID est de savoir si vous avez été en mesure de prouver votre identité. <br/>" +
                        "S’il vous plaît confirmer les détails ci - dessous et cochez la case pour donner votre consentement pour commencer le processus eID. ";
                    Label1.Text = "Prénom";
                    Label2.Text = "deuxième prénom";
                    Label3.Text = "nom de famille";
                    Label4.Text = "DDN";
                    Label15.Text = "Numéro de téléphone";
                    Label16.Text = "e-mail";
                    Label14.Text = "genre";
                    Label5.Text = "rue";
                    Label6.Text = "ville";
                    Label7.Text = "Province";
                    Label8.Text = "Code postal";
                    Label9.Text = "Depuis combien de temps vivez-vous à cette adresse?";
                    Label10.Text = "rue";
                    Label11.Text = "ville";
                    labelcheckbox1.InnerText = "J'accepte de donner mon consentement pour l'eID";
                    Button1.Text = "Soummetre";


                }
            }
            else
            {
                Session["lang"] = "EN";
            }
            //CallAPI(payload,guid);

        }
         
    }

    public string CallAPI(string payload,string guid)
    {
        
        RequestISB client = new RequestISB();
        string Package;
        //RequestISB client = new RequestISB();

        //14EC7D71 - 3423 - 47E5 - B1F0 - E3057C7BE268


        Package = "<ProductData><isb_dupedata>";



        string Productxml1;

        Productxml1 = "<ProductData>";
        Productxml1 += "<DupeData>testSertp10-fggbvfg14shs110811</DupeData>";
        Productxml1 += "<isb_appothername>LAM</isb_appothername>";
        Productxml1 += "<isb_DOB>12/06/1949</isb_DOB>";
        Productxml1 += "<isb_Sex>Male</isb_Sex>";
        Productxml1 += "<isb_SIN></isb_SIN>";
        Productxml1 += "<isb_eidveriemail>salvador@apowerltd.ca</isb_eidveriemail>";
        Productxml1 += "<isb_appcurrentstreet>38 BERNARD CLOSE NW</isb_appcurrentstreet>";
        Productxml1 += "<isb_appcurrentcity>Calgary</isb_appcurrentcity>";
        Productxml1 += "<isb_appcurentprov>AB</isb_appcurentprov>";
        Productxml1 += "<isb_appcurentpostal>T3K2H3</isb_appcurentpostal>";
        Productxml1 += "<isb_appphone>7785529643</isb_appphone>";
        Productxml1 += "<isb_eidaddduration1>More than 2 Years</isb_eidaddduration1>";
        Productxml1 += "<isb_vermode601n602>eIDVerifier</isb_vermode601n602>";
        //Productxml1 += "<isb_vermode601n602>MID</isb_vermode601n602>";
        Productxml1 += "<isb_language>English</isb_language>";
        Productxml1 += "</ProductData>";

        Productxml1 = "<ProductData><DupeData>testSertp10-fffffdvv2s:018</DupeData><isb_DOB>12/06/1949</isb_DOB><isb_Sex>Male</isb_Sex><isb_SIN></isb_SIN><isb_eidveriemail>salvador@apowerltd.ca</isb_eidveriemail><isb_appcurrentstreet>38BERNARDCLOSENW</isb_appcurrentstreet><isb_appcurrentcity>Calgary</isb_appcurrentcity><isb_appcurentprov>AB</isb_appcurentprov><isb_appcurentpostal>T3K2H3</isb_appcurentpostal><isb_appphone>7785529643</isb_appphone><isb_eidaddduration1>Morethan2Years</isb_eidaddduration1><isb_vermode601n602>eIDVerifier</isb_vermode601n602><isb_language>English</isb_language><isb_appfirstname>HING</isb_appfirstname><isb_appsurname>LAM</isb_appsurname></ProductData>";


        Random rnd = new Random();
        int number = rnd.Next(1000000, 9999999);
        Productxml1 = "<ProductData><isb_appothername>Harlicksssss</isb_appothername><isb_DOB>06/05/1972</isb_DOB><isb_Sex>Female</isb_Sex><isb_provToSearch>AB</isb_provToSearch><isb_eidveriemail>Simon.Hedlund@contractor.com</isb_eidveriemail><isb_vermode601n602>eIDVerifier</isb_vermode601n602><isb_appphone>4032000000</isb_appphone><isb_language>English</isb_language><isb_appcurrentstreet>45 INVERNESS GATE SE</isb_appcurrentstreet><isb_appcurrentcity>CALGARY</isb_appcurrentcity><isb_appcurentprov>AB</isb_appcurentprov><isb_appcurentpostal>T2Z4N1</isb_appcurentpostal><isb_eidaddduration1>More than 2 Years</isb_eidaddduration1><random>" + number.ToString() + "</random><isb_appfirstname>Kate </isb_appfirstname><isb_appsurname>Harlicksssss</isb_appsurname></ProductData>";


        Productxml1 = "<ProductData>";
        Productxml1 += "<DupeData>"+number.ToString()+"</DupeData>";
        Productxml1 += "<isb_appothername>LAM</isb_appothername>";
        Productxml1 += "<isb_DOB>12/06/1949</isb_DOB>";
        Productxml1 += "<isb_Sex>Male</isb_Sex>";
        Productxml1 += "<isb_SIN></isb_SIN>";
        Productxml1 += "<isb_eidveriemail>salvador@apowerltd.ca</isb_eidveriemail>";
        Productxml1 += "<isb_appcurrentstreet>38 BERNARD CLOSE NW</isb_appcurrentstreet>";
        Productxml1 += "<isb_appcurrentcity>Calgary</isb_appcurrentcity>";
        Productxml1 += "<isb_appcurentprov>AB</isb_appcurentprov>";
        Productxml1 += "<isb_appcurentpostal>T3K2H3</isb_appcurentpostal>";
        Productxml1 += "<isb_appphone>77855296431</isb_appphone>";
        Productxml1 += "<isb_eidaddduration1>More than 2 Years</isb_eidaddduration1>";
        Productxml1 += "<isb_vermode601n602>eIDVerifier</isb_vermode601n602>";
        //Productxml1 += "<isb_vermode601n602>MID</isb_vermode601n602>";
        Productxml1 += "<isb_language>English</isb_language>";
        Productxml1 += "</ProductData>";



        Productxml1 = "<ProductData>";
        Productxml1 += "<DupeData>" + number.ToString() + "</DupeData>";
        Productxml1 += "<isb_appothername>THEORET</isb_appothername>";
        Productxml1 += "<isb_appsurname>THEORET</isb_appsurname>";
        Productxml1 += "<isb_DOB>03/03/1989</isb_DOB>";
        Productxml1 += "<isb_Sex>Male</isb_Sex>";
        Productxml1 += "<isb_SIN>811223395</isb_SIN>";
        Productxml1 += "<isb_eidveriemail>salvador@apowerltd.ca</isb_eidveriemail>";
        Productxml1 += "<isb_appcurrentstreet>147 Rue des lilas</isb_appcurrentstreet>";
        Productxml1 += "<isb_appcurrentcity>Les Cedres</isb_appcurrentcity>";
        Productxml1 += "<isb_appcurentprov>QC</isb_appcurentprov>";
        Productxml1 += "<isb_appcurentpostal>J7T3J4</isb_appcurentpostal>";
        Productxml1 += "<isb_appphone>4502000543</isb_appphone>";
        Productxml1 += "<isb_eidaddduration1>More than 2 Years</isb_eidaddduration1>";
        Productxml1 += "<isb_vermode601n602>eIDVerifier</isb_vermode601n602>";
        //Productxml1 += "<isb_vermode601n602>MID</isb_vermode601n602>";
        Productxml1 += "<isb_language>English</isb_language>";
        Productxml1 += "</ProductData>";





        string username = ConfigurationManager.AppSettings["ProductDetailsUserName"];
        string password = ConfigurationManager.AppSettings["ProductDetailsPassword"];
        username = "CrawfordComp";
        password = "NbY#2F@gYu";

        //Uber
        username = "AuthenticIDWS";
        password = "Nb&7G@fKlA89!j";
       // guid = "9AED5020-E6AF-4F73-8336-3F018784ECB6";



        client.Credentials = new NetworkCredential(username, password);
        client.PreAuthenticate = true;
        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);
        client.UseDefaultCredentials = true;
        //string chkstatus = client.ProductDetails(guid, Productxml1, "1680", "EBS", true, true);

        //test env
        //string chkstatus = client.ProductDetails(guid, payload, "1680", "EBS", false, true);

        //prod env
        string chkstatus = client.ProductDetails(guid, payload, "1680", "EBS", true, true);
        string pdi = chkstatus.Substring(chkstatus.IndexOf('[') + 1, chkstatus.Length - chkstatus.IndexOf('[') - 2);




        //string pdi = "pdi=33927;https://www.infosearchsite.com/eIDVerifier_test/eID_Click.aspx?d16TewWG7%2fr82ccyY76pMW6XMOKn2OgrmpHdrP9NOdiajnxLkQQ4IL0rKMAK%2bxTY8HViHzWSM%2bnxOS8f8H396g%3d%3";
        string[] inf = chkstatus.Split(';');
        string link = "";
        try
        {
          // link  = inf[1].ToString().Replace("eID_Click", "Verifier");
            link = inf[1].ToString();
        }
        catch
        {
            link = "";
        }
        Response.Redirect(link);

        return link ;
    }


    public string CreateTestOrder()
    {
        RequestISB client = new RequestISB();
        string Package;
        String sDate = DateTime.Now.ToString();
        DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
        String dy = datevalue.Day.ToString();
        String mn = datevalue.Month.ToString();
        String yy = datevalue.Year.ToString();

        //Package = "<ProductData>";
        //Package += "<isb_FN>" + "HING" + "</isb_FN>";
        //Package += "<isb_LN>" + "LAM" + "</isb_LN>";
        //Package += "<isb_Ref>" + "1993" + "</isb_Ref>";
        //Package += "<isb_DOL>" + "1949-06-12" + "</isb_DOL>";

        Package = "<ProductData>";
        Package += "<isb_FN>" + "Kate" + "</isb_FN>";
        Package += "<isb_LN>" + "Harlick" + "</isb_LN>";
        Package += "<isb_Ref>" + "1993" + "</isb_Ref>";
        Package += "<isb_DOL>" + "1972-05-15" + "</isb_DOL>";


        Package += "<isb_Prov>" + "AB" + "</isb_Prov>";

        {
            string userid = ConfigurationManager.AppSettings["UserID_" + Session["companyid"]];
            //Package += "<isb_UserID>" + 15978 + "</isb_UserID>";
            Package += "<isb_UserID>" + 14334 + "</isb_UserID>";
            //SendEmail("UserID not received through URL", "Uber BC Form Submission Error Report");-- test
        }
        Package += "</ProductData>";

        //Package = "<ProductData><isb_appothername>1989-03-03</isb_appothername><isb_DOB>03/03/1989</isb_DOB><isb_Sex>Female</isb_Sex><isb_provToSearch>QC</isb_provToSearch><isb_eidveriemail>proxtra46@gmail.com</isb_eidveriemail><isb_vermode601n602>eIDVerifier</isb_vermode601n602><isb_appphone>4502000000</isb_appphone><isb_language>English</isb_language><isb_appcurrentstreet>147RUEDESLILAS</isb_appcurrentstreet><isb_appcurrentcity>LESCEDRES</isb_appcurrentcity><isb_appcurentprov>QC</isb_appcurentprov><isb_appcurentpostal>J7T3J4</isb_appcurentpostal><isb_eidaddduration1>Morethan2Years</isb_eidaddduration1><random>157616204915513</random><isb_appfirstname>KIM</isb_appfirstname><isb_appsurname>THEORET</isb_appsurname></ProductData>";
        string username = ConfigurationManager.AppSettings["WebServiceUserName"];
        string password = ConfigurationManager.AppSettings["WebServicePassword"];
        username = "Uber";
        password = "yt%&@we67D";

        client.Credentials = new NetworkCredential(username, password);
        client.PreAuthenticate = true;
        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);
        client.UseDefaultCredentials = true;
        string chkstatus = client.StartOrder(Package, "EBS", false, false);
        return chkstatus;
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Enabled = false;
        string firstname = txtFirstName.Text;
        string middlename = txtSecondName.Text;
        string surname = txtLastName.Text;
        string currentstreet = txtCurrentStreet.Text;
        string currentcity = txtCurrentCity.Text;
        string currentprov = txtCurrentProvince.Text;
        string currentpostal = txtCurrentPostal.Text.Trim();
        string dob = txtDob.Value.Trim();
        string phone = txtPhone.Value.Trim();
        string eidduration = "Less than 2 years";
        string language = "English";
        if (Session["lang"].ToString() == "FR")
        {
            language = "Franch";
        }


        int duration = Convert.ToInt16(ddyears.Value);
        if(duration ==2)
        {
            eidduration="More than 2 years";
        }

        Random rnd = new Random();
        int number = rnd.Next(1000000, 9999999);


        string Package = "<ProductData>";
        string gender = "Male";

        string email = "";
        Package += "<isb_dupedata>" +number + "</isb_dupedata><isb_appothername>" + surname + "</isb_appothername><isb_appsecondname></isb_appsecondname>" +
        "<isb_DOB>" + dob + "</isb_DOB><isb_Sex>" + gender + "</isb_Sex><isb_POB></isb_POB><isb_appfirstname>" + firstname + "</isb_appfirstname>" +
        "<isb_appsurname>" + surname + "</isb_appsurname>" +
        "<isb_eidveriemail>" + email + "</isb_eidveriemail>" +
        "<isb_appcurrentstreet>" + currentstreet + "</isb_appcurrentstreet>" +
        "<isb_appcurrentcity>" + currentcity + "</isb_appcurrentcity>" +
        "<isb_appcurentprov>" + currentprov + "</isb_appcurentprov>" +
        "<isb_appcurentpostal>" + currentpostal + "</isb_appcurentpostal>" +
        "<isb_appphone>" + phone + "</isb_appphone>" +
        "<isb_eidaddduration1>" + eidduration + "</isb_eidaddduration1>" +
        "<isb_vermode601n602>eIDVerifier</isb_vermode601n602>" +
        "<isb_language>" + language + "</isb_language>" +
        "<isb_eidveriemail>" + email + "</isb_eidveriemail>" +
        "</ProductData>";





        //Random rnd = new Random();
        //int number = rnd.Next(1000000, 9999999);

       // Package = "<ProductData><isb_appothername>Harlick</isb_appothername><isb_DOB>05/15/1972</isb_DOB><isb_Sex>Female</isb_Sex><isb_provToSearch>AB</isb_provToSearch><isb_eidveriemail>Simon.Hedlund@contractor.com</isb_eidveriemail><isb_vermode601n602>eIDVerifier</isb_vermode601n602><isb_appphone>4032000000</isb_appphone><isb_language>English</isb_language><isb_appcurrentstreet>45 INVERNESS GATE SE</isb_appcurrentstreet><isb_appcurrentcity>CALGARY</isb_appcurrentcity><isb_appcurentprov>AB</isb_appcurentprov><isb_appcurentpostal>T2Z4N1</isb_appcurentpostal><isb_eidaddduration1>More than 2 Years</isb_eidaddduration1><random>"+number.ToString()+"</random><isb_appfirstname>Kate </isb_appfirstname><isb_appsurname>Harlick</isb_appsurname></ProductData>";
        string guid = Session["guid"].ToString();
        CallAPI(Package, guid);
    }
}


public class RequestISB : ISBWS.Request
{
    protected override WebRequest GetWebRequest(Uri uri)
    {
        HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
        NetworkCredential credentials = base.Credentials as NetworkCredential;
        credentials.UserName = ConfigurationManager.AppSettings["WebServiceUserName"];
        credentials.Password = ConfigurationManager.AppSettings["WebServicePassword"];
        //credentials.UserName = "CrawfordComp";
        //credentials.Password = "NbY#2F@gYu";
        if (credentials != null)
        {
            string s = (((credentials.Domain != null) && (credentials.Domain.Length > 0)) ? (credentials.Domain + @"\") : string.Empty) + credentials.UserName + ":" + credentials.Password;
            s = Convert.ToBase64String(Encoding.Default.GetBytes(s));
            webRequest.Headers["Authorization"] = "Basic " + s;
        }
        return webRequest;
    }
}


//public class RequestISB_Test : ISBWS_Test.Request
//{
//    protected override WebRequest GetWebRequest(Uri uri)
//    {
//        HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
//        NetworkCredential credentials = base.Credentials as NetworkCredential;
//        credentials.UserName = ConfigurationManager.AppSettings["WebServiceUserName"];
//        credentials.Password = ConfigurationManager.AppSettings["WebServicePassword"];
//        //credentials.UserName = "CrawfordComp";
//        //credentials.Password = "NbY#2F@gYu";
//        if (credentials != null)
//        {
//            string s = (((credentials.Domain != null) && (credentials.Domain.Length > 0)) ? (credentials.Domain + @"\") : string.Empty) + credentials.UserName + ":" + credentials.Password;
//            s = Convert.ToBase64String(Encoding.Default.GetBytes(s));
//            webRequest.Headers["Authorization"] = "Basic " + s;
//        }
//        return webRequest;
//    }
//}

