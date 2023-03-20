using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public long Price { get; set; }
        public Guid IdHang { get; set; }
        [ForeignKey(nameof(IdHang))]
        public Hang Hang { get; set; }
    }
}