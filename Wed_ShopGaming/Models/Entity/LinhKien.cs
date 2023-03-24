using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class LinhKien
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(128)]
        public string IdLoaiSP { get; set; }

        [ForeignKey(nameof(Id))]
        public SanPham SanPham { get; set; }
        

        [ForeignKey(nameof(IdLoaiSP))]
        public LoaiSP LoaiSP { get; set; }
        public virtual ICollection<MayTinh> MayTinhs { get; set; }
        public virtual ICollection<TSKT> TSKTs { get; set; }
    }
}