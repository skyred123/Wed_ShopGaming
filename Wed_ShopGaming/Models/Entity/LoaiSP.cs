﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class LoaiSP
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}