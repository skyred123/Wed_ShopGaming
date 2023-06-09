﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class MayTinh
    {
        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(128)]
        public string IdCH { get; set; }

        [ForeignKey(nameof(IdCH))]
        public CauHinh CauHinh { get; set;}
        [ForeignKey(nameof(Id))]
        public SanPham SanPham { get; set;}

        public string IdLoaiMT { get; set; }

        [ForeignKey(nameof(IdLoaiMT))]
        public LoaiMT LoaiMT { get; set; }
        public virtual ICollection<CT_LinhKien> CT_LinhKiens { get; set; }
    }
}