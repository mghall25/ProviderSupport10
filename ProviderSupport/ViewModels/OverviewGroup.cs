using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProviderSupport.ViewModels
{
    public class OverviewGroup
    {
        //[DataType(DataType.Date)]
        //public DateTime? BirthDate { get; set; }

        public int ProviderCount { get; set; }
        public int ClientCount { get; set; }
        public int TransactionCount { get; set; }
    }
}