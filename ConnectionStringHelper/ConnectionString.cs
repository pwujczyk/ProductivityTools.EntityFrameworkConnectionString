using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace ConnectionStringPT
{
    public static class ConnectionString
    {
        static string SQLClientProviderName = "System.Data.SqlClient";

        /// <summary>
        /// Returns connection string only with sql server name. Used for creating new database.
        /// Example: Data Source=.\sqlServerInstance;Integrated Security=True
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public static string GetSqlDataSourceConnectionString(string dataSource)
        {
            return ConnectionStringLightPT.ConnectionStringLight.GetSqlDataSourceConnectionString(dataSource);
        }

        /// <summary>
        /// Returns connection string with datasource and database name
        /// Example: Data Source=.\sqlServerInstance;Initial Catalog=DatabaseName;Integrated Security=True
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static string GetSqlServerConnectionString(string datasource, string databaseName)
        {
            return ConnectionStringLightPT.ConnectionStringLight.GetSqlServerConnectionString(datasource, databaseName);
        }
        
        /// <summary>
        /// Returns connection string which is needed for EntityFramework
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="databaseName"></param>
        /// <param name="metadataName"></param>
        /// <returns></returns>
        public static string GetSqlEntityFrameworkConnectionString(string datasource, string databaseName, string metadataName)
        {
            var connection = GetSqlServerConnectionString(datasource, databaseName);
            var r = GetEntityConnectionStringBuilder()
                .AddProviderName(SQLClientProviderName)
                .InitEntityBuilder(connection)
                .AddMetaData(metadataName);
            return r.ToString();
        }

        private static EntityConnectionStringBuilder GetEntityConnectionStringBuilder()
        {
            return new EntityConnectionStringBuilder();
        }

        private static EntityConnectionStringBuilder InitEntityBuilder(this EntityConnectionStringBuilder entityBuilder, string sqlBuilder)
        {
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            return entityBuilder;
        }

        //private static SqlConnectionStringBuilder GetSQLDataSource(string dataSource)
        //{
        //    var r = GetDataSource(dataSource).AddIntegratedSecurity();
        //    return r;
        //}

        private static EntityConnectionStringBuilder AddProviderName(this EntityConnectionStringBuilder entityBuilder, string providerName)
        {
            entityBuilder.Provider = providerName;
            return entityBuilder;
        }

        private static EntityConnectionStringBuilder AddMetaData(this EntityConnectionStringBuilder entityBuilder, string metadataName)
        {
            entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", metadataName); //AOEntities
            return entityBuilder;
        }

        //private static SqlConnectionStringBuilder GetDataSource(string dataSource)
        //{
        //    SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        //    sqlBuilder.DataSource = dataSource;
        //    return sqlBuilder;
        //}

        //private static SqlConnectionStringBuilder AddIntegratedSecurity(this SqlConnectionStringBuilder connectionStringBuilder)
        //{
        //    connectionStringBuilder.IntegratedSecurity = true;
        //    return connectionStringBuilder;
        //}


        //private static SqlConnectionStringBuilder AddInitialCatalog(this SqlConnectionStringBuilder connectionStringBuilder, string initialCatalog)
        //{
        //    connectionStringBuilder.InitialCatalog = initialCatalog;
        //    return connectionStringBuilder;
        //}
    }
}
