using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class HinhAnhViewModel
    {
        public string Id { get; set; }
        public string IDSanPham { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ListHinhAnhViewModel
    {
        public List<HinhAnhViewModel>HinhAnhs { get; set; }
    }
}