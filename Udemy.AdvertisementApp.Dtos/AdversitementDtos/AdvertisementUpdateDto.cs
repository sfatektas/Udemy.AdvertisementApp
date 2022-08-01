﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos.AdversitementDtos
{
    public class AdvertisementUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

    }
}
