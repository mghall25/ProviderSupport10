using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ProviderSupport.DAL
{
    public class ProviderSupportConfiguration : DbConfiguration
    {
        public ProviderSupportConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}