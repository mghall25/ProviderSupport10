using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProviderSupport.Models
{
    public class CounsPa
    {

        public int CounsPaID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Counselor/PA")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNum { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public int BillToOrgID { get; set; }
        public virtual BillToOrg BillToOrg { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}