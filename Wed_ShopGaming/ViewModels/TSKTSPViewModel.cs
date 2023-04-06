using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class TSKTSPViewModel
    {
        [DisplayName("Ma Loai")]
        public string Id { get; set; }

        [DisplayName("Ten")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Mo Ta")]
        [Required]
        public string Description { get; set; }

        public List<TSKT> listTSKT = new List<TSKT>();

    }
}