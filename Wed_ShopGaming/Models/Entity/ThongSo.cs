using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class ThongSo
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        public string Name { get; set; }
        [StringLength(128)]
        public string IdLoaiSP { get; set; }

        [ForeignKey(nameof(IdLoaiSP))]
        public LoaiSP LoaiSP { get; set; }

        public virtual ICollection<LinhKien> LinhKiens { get; set; }
    }
}