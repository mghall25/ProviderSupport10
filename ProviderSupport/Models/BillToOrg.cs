using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProviderSupport.Models
{
    public class BillToOrg
    {
        public int BillToOrgID { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        [StringLength(50)]
        public string Name { get; set; }

        // 1-ODDS, 2-VR, 3-Self-Pay, 4-APD, 5-CH
        [Required]
        [Display(Name = "Org Type")]
        [Range(1,5)]
        public int Type { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNum { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]        
        [Display(Name = "Addr Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Addr Line 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Addr Line 3")]
        public string Address3 { get; set; }

        public virtual ICollection<CounsPa> CounsPas { get; set; }
    }
}
