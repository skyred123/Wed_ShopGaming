using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class GioHang
    {
        [Key]
        [StringLength(128)]
        [Column(Order = 1)]
        public string SanPhamId { get; set; }
        [Key]
        [StringLength(128)]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public int Count { get; set; }
        public SanPham SanPham { get; set; }

        public ApplicationUser User { get; set; }
    }
}