using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Microsoft.Data.SqlClient;

namespace MyProjectCursovay.Sourse
{
    public class Connect
    {
        public static string GetConnectionStringSqlServer()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "(local)",
                InitialCatalog = "Test",
                UserID = "user",
                Password = "root",
                IntegratedSecurity = false,
                TrustServerCertificate = true
            }.ConnectionString;
        }

    }
}
