using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class LinhKienViewModels
    {
        public string id { get; set; }
        [DisplayName("Ten")]
        [Required]
        public string Name { get; set; }
        [DisplayName("So Luong")]
        [Required]

        [Index]
        public string Amount { get; set; }
        [DisplayName("Gia")]
        [Required]
        public string Price { get; set; }
        [DisplayName("Hang")]
        [Required]
        public string IdHang { get; set; }
        [DisplayName("Loai")]
        [Required]
        public string IdLoai { get; set; }
        public List<LoaiSP> LoaiSP { get; set; }
        public List<Hang> hangs { get; set; }

        public List<SanPham> sanPham { get; set;}

    }
}