using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Users : IdentityUser<int>
    {
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        
        public string PostalCode { get; set; }
        [Required]
        public string Name { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose Profile Picture for your account")]
        //[Required(ErrorMessage = "Please choose profile image")]
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
    }
}
