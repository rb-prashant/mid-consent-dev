using System;
using System.Configuration;

/// <summary>
/// Summary description for Configuration
/// </summary>
public class Configuration
{
    string ISB_DOMAIN_NAME;
    string DATABASE_CONNECTION;

    public string GetConnectionString()
    {
        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);

        if (PROD)
        {
            DATABASE_CONNECTION = ConfigurationManager.ConnectionStrings["Infosearchsite_Test"].ConnectionString;
        }
        else
        {
            DATABASE_CONNECTION = ConfigurationManager.ConnectionStrings["Isbcorporate_Test"].ConnectionString;
        }

        return DATABASE_CONNECTION;
    }

    public string GetISBDomainName()
    {
        bool PROD = Convert.ToBoolean(ConfigurationManager.AppSettings["ProdEnvironment"]);

        if (PROD)
        {
            ISB_DOMAIN_NAME = "https://auth.isbc.ca";
        }
        else
        {
            ISB_DOMAIN_NAME = "https://authtest.isbc.ca";
        }

        return ISB_DOMAIN_NAME;
    }
}