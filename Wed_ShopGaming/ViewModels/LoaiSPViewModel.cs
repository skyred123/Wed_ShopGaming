using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class LoaiSPViewModel
    {
        [DisplayName("Ten Loai")]
        [Required]
        public string Name { get; set; }

        public ICollection<LoaiSP> Loais { get; set; }
    }
}