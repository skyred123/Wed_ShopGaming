﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class CauHinh
    {
        [StringLength(128)]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MayTinh> MayTinhs { get; set; }
    }
}