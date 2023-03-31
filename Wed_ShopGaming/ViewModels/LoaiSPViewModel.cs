using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class LoaiLKViewModel
    {
        [DisplayName("Ma Loai")]
        [Required]
        public string Id { get; set; }

        [DisplayName("Ten Loai")]
        [Required]
        public string Name { get; set; }

        public ICollection<LoaiLK> Loais { get; set; }
    }
    public class LoaiMTViewModel
    {
        [DisplayName("Ma Loai")]
        [Required]
        public string Id { get; set; }

        [DisplayName("Ten Loai")]
        [Required]
        public string Name { get; set; }

        public ICollection<LoaiMT> Loais { get; set; }
    }
}