using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProviderSupport.Models
{
    public class ServiceTypeEmpl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceTypeEmplID { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter up to 50 characters.")]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Enter up to 150 characters.")]
        [Display(Name = "Long Description")]
        public string DescLong { get; set; }

        [Display(Name = "Allow Entry on MultiDate Form")]
        public bool MultiDateEntry { get; set; }

        [Display(Name = "VR Service")]
        public bool VrService { get; set; }

        public decimal? Track1Fee { get; set; }
        public decimal? Track2Fee { get; set; }
        public decimal? Track3Fee { get; set; }

        public bool? FlatFeeService { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}