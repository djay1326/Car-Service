using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class GarageImages
    {
        [Key]
        public int ImageId {get;set;}

        public virtual int GarageId { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFileCollection GalleryFiles { get; set; }
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
        
        [NotMapped]
        public List<GarageImages> Gallery { get; set; }

        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }
    }
}
