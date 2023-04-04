using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class SanPham
    {
        [StringLength(128)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public long Price { get; set; }
        [StringLength(128)]
        public string IdHang { get; set; }

        [ForeignKey(nameof(IdHang))]
        public Hang Hang { get; set; }

        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual LinhKien LinhKien { get; set; }

        public virtual MayTinh MayTinh { get; set; }
    }
}