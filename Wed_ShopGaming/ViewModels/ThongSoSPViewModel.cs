using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class ThongSoSPViewModel
    {
        [DisplayName("Ma Loai")]
        [Required]
        public string Id { get; set; }

        [DisplayName("Ten")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Loai")]
        [Required]
        public string IdLoai { get; set; }

        public List<ThongSo> listThongSos = new List<ThongSo>();
        public List<LoaiSP> listloaiSPs = new List<LoaiSP>();

    }
}