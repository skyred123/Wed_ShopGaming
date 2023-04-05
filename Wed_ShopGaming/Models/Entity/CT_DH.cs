using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class CT_DH
    {
        [Key]
        [Column(Order = 1)]
        public string SanPhamId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string HoaDonId { get; set; }

        public string Amount { get; set; }
        public string Price { get; set; }
        [ForeignKey("HoaDonId")]
        public HoaDon HoaDon { get; set; }
        [ForeignKey("SanPhamId")]
        public SanPham SanPham { get; set; }
    }
}