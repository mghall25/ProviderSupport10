using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProviderSupport.Models
{
    public class Client
    {
        [Display(Name="Client ID")]
        public int ClientID { get; set; }

        [Required]
        [Display(Name ="Prime No")]
        public string PrimeNo { get; set; }

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

        [Required]
        [StringLength(50, ErrorMessage = "Enter a name less than 50 characters long.")]
        [Display(Name = "Em Contact Name")]
        public string EmergencyName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Em Email")]
        public string EmergencyEmail { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Em Phone")]
        public string EmergencyPhone { get; set; }

        [Display(Name = "PA")]
        public int? CounsPaID { get; set; }

        [Display(Name ="Archived?")]
        public bool? Archived { get; set; }

        [Display(Name = "Client Name")]
        public string ClientFullName
        {
            get
            {
                return FirstName.Trim() + " " + LastName.Trim();
            }
        }

        public virtual CounsPa CounsPa { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}