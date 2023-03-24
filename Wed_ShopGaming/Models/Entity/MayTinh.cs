using System;
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

        public virtual ICollection<LinhKien> LinhKiens { get; set; }
    }
}