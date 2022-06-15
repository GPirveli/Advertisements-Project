﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.Web.Models.Requests
{
    public class CreateAdvertisementRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
    }
}
