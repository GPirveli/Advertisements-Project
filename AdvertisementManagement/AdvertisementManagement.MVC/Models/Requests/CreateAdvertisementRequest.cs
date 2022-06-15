using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.MVC.Models.Requests
{
    public class CreateAdvertisementRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string PhoneNumber { get; set; }
    }
}
