using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class HangSPViewModel
    {
        [DisplayName("Ma Hang")]
        [Required]
        public string Id { get; set; }

        [DisplayName("Hang")]
        [Required]
        public string Name { get; set; }

        public ICollection<Hang> Hangs { get; set; }
    }
}