using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class LinhKienViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [DisplayName("Ten")]
        public string Name { get; set; }
        [Required]
        [DisplayName("So Luong")]
        public string Amount { get; set; }
        [Required]
        [DisplayName("Gia")]
        public string Price { get; set; }
        [Required]
        [DisplayName("Hang")]
        public string IdHang { get; set; }
        [DisplayName("Thong So")]
        [Required]
        public string IdThongSo { get; set; }
        public List<SanPham> listLinhKien { get; set; }
    }
}