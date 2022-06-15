using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisementManagement.Domain.POCO
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
    }
}
