using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.ViewModels
{
    public class Details_MayTinhViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsCheck { get; set; }
    }
    public class ListDetails_MayTinhViewModel
    {
        public List<Details_MayTinhViewModel> Details_MayTinh { get; set; } //= new List<bool>();
    }
}