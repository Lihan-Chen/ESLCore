//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Configuration;



namespace mvc4ESL.Models.Dal
{
    /// <summary>
    /// The AppConfiguaration class contains read-only properties that are essentially short cuts to settings in the web.config file.
    /// </summary>
    public static class AppConfiguration
  {
      
        //OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder(GetConnectionString());   
   
      #region Public Properties

        /// <summary>
        /// Returns the connectionstring  for the application.
        /// </summary>
        
        // For Dve7
        // public static string ConnectionString =>  "Data Source=dev7.world;Persist Security Info=false;User ID=esl;Password=esl;Unicode=True;Min Pool Size=10;Connection Lifetime=120;";
        
        // For Unit Testing
        public static string DefaultConnection => "DataSource=app.db;Cache=Shared";


        #endregion

        #region Private Properties

        //private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionESL"].ConnectionString;

        //private static string GetConnectionString()
        //{
        //    // To avoid storing the connection string in your code, 
        //    // you can retrieve it from a configuration file.  
        //    return "Data Source=dev7.world;Persist Security Info=True";
        //}

        #endregion

        // The following comes from Drew
        //read the connection string
        //string tempConnStr = config.ConnectionStrings["NameOfConnStringFromWebConfig"].ConnectionString; 

        //string connectionstring;	    
        // OracleConnectionStringBuilder ocsb;

        // ocsb = new OracleConnectionStringBuilder();

        // ocsb.ConnectionString = tempConnstr;    //from above - read from config file
        // ocsb.UserID = name;		                   //user-supplied - session variable?
        // ocsb.Password = pwd;		                  //user-supplied - session variable?
        //connectionstring = ocsb.ToString();          //save as string to be used in creating OracleConnections  or save in Session variable instead
    }
}