using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class CauHinhSPViewModel
    {
        [DisplayName("Ma Cau Hinh")]
        [Required]
        public string Id { get; set; }

        [DisplayName("Cau Hinh")]
        [Required]
        public string Name { get; set; }

        public ICollection<CauHinh> CauHinhs { get; set; }
    }
}