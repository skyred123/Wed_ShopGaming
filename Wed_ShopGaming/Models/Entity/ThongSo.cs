using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class ThongSo
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdLoaiSP { get; set; }

        [ForeignKey(nameof(IdLoaiSP))]
        public LoaiSP LoaiSP { get; set; }
    }
}