using ProviderSupport.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProviderSupport.Models
{
    public class ServiceType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceTypeID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter up to 50 characters.")]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Enter up to 150 characters.")]
        [Display(Name = "Long Description")]
        public string DescLong { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}