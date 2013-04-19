using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class dbWebService : System.Web.Services.WebService {

    [WebMethod]
    public string Details(int sID) {

        //connect to the database 
        String connStr = ConfigurationManager.ConnectionStrings["connStr_wsTest3"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        String SQL = "SELECT [CompanyName],[City],[Country] FROM [Suppliers] WHERE SupplierID = " + sID;
        cmd.CommandText = SQL;
        cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                return dr.GetValue(i).ToString();
            }

        }
        conn.Close();

        //to return - Company Name, City & Country
        return "Hello World";
    }
    
}
