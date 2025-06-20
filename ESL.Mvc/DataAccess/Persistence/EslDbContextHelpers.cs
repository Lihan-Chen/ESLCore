﻿namespace ESL.Mvc.DataAccess.Persistence
{
    public static class EslDbContextHelpers  //internal
    {
        // ConnectionString for the class library
        //public const string esl_connectionString = "user id=esl;password=MWDesl01_#;data source=dev7.world;Persist Security Info=false;Min Pool Size=10;Connection Lifetime=120;";

        // SQLite
        public const string sqlite_connectionString = "DataSource=app.db;Cache=Shared";

        // ODEV41 "data source=ODev41.world;user id=esl;password=MWDesl01_#;Persist Security Info=false;Min Pool Size=10;Connection Lifetime=120;"
        public const string esl_connectionString = "Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;";

        // Note -
        // alternatively, https://dotnettutorials.net/lesson/database-connection-string-in-entity-framework-core/
        // 1. use Microsoft.Extensions.Configuration 
        // 2. use appsettings.json (on project) for configuration builder
        //    var configBuilder = new ConfigurationBuilder().AddJsonFile(“appsettings.json”).Build();
        // 3. Get the Section to Read from the Configuration File
        //    var configSection = configBuilder.GetSection(“ConnectionStrings”);

        // 4. Get the Configuration Values based on the Config key.
        //    var connectionString = configSection[“SQLServerConnection”] ?? null;

        // 5. Set appsettings.json file “Copy to Output Directory” property to “Copy always.”
    }
}
