using ProviderSupport.Models;
using System;
using System.Collections.Generic;

namespace ProviderSupport.ViewModels
{
    public class BillToOrgIndexData
    {   // creates a view model for a three-part page for BillToOrg
        public IEnumerable<BillToOrg> BillToOrgs { get; set; }
        public IEnumerable<CounsPa> CounsPas { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}