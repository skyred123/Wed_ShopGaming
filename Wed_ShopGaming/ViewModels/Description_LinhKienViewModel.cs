using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class Description_LinhKienViewModel
    {
        public string IdTSKT { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCheck { get; set; }
    }
    public class ListDescription_LinhKienViewModel
    {
        public List<Description_LinhKienViewModel> description_LinhKiens { get; set; } //= new List<bool>();
    }
}