using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProviderSupport.DAL;

namespace ProviderSupport.Models
{
    public class Transaction
    {
        // constructor
        public Transaction()
        {
            TimeStamp = DateTime.Now;
            ServiceTypeEmplID = null;
        }
               
        public int TransactionID { get; set; }
                
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name ="Provider")]
        public int ProviderID { get; set; }

        [Required]
        [Display(Name ="Client")]
        public int ClientID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Service Date")]
        public DateTime DateWorked { get; set; }
        
        [Display(Name ="Service Type")]
        public int ServiceTypeID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]      
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "Time Out")]
        public DateTime TimeOut { get; set; }

        [Display(Name ="Description")]
        public string ServiceDesc { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Progress Notes")]
        public string ProgressNote { get; set; }

        [Display(Name = "Odometer Start")]
        public int? OdometerStart { get; set; }

        [Display(Name = "Odometer End")]
        public int? OdometerEnd { get; set; }

        [Display(Name = "Travel Purpose")]
        public string TravelPurpose { get; set; }

        [Display(Name = "Vendor")]
        public string ExpenseVendor { get; set; }

        [Display(Name = "Purpose")]
        public string ExpensePurpose { get; set; }

        [Display(Name = "Amount")]
        public int? ExpenseAmount { get; set; }

        [Display(Name = "Empl Svc Sub-Type")]
        public int? ServiceTypeEmplID { get; set; }

        [Display(Name = "Direct Support Hours")]
        public int? EmploymentDirSuppHrs { get; set; }

        public bool? IsDuplicate { get; set; }

        public DateTime? WhenInvoiced { get; set; }

        public DateTime? WhenSentToExprs { get; set; }

        public DateTime? WhenPaidToPayroll { get; set; }
        
        public virtual Provider Provider { get; set; }
        public virtual Client Client { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ServiceTypeEmpl ServiceTypeEmpl { get; set; }
    }
}