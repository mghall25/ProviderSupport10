using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProviderSupport.Models
{
    public class Provider
    {   
        [Display(Name="Provider ID")]
        public int ProviderID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter a name less than 50 characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter a name less than 50 characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNum { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PayRate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "CPR Exp. Date")]
        public DateTime CprExpDate { get; set; }

        public bool? Archived { get; set; }

        [Display(Name = "Provider Name")]
        public string FullName
        {
            get
            {
                return FirstName.Trim() + " " + LastName.Trim();
            }
        }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}