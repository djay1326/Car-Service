using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailInUse", controller: "Starting")]
        public string Email { get; set; }

        //[Required]
        [Phone]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string State { get; set; }
        public string Postalcode { get; set; }

        public int Id { get; set; }

        [Display(Name = "Choose Profile Picture for your account")]
        //[Required(ErrorMessage = "Please choose profile image")]
        public IFormFile CoverPhoto { get; set; }

        public string CoverUrl { get; set; }

        public IFormFileCollection GalleryFiles { get; set; }
        
    }
}
