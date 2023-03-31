using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class HinhAnh
    {
        [StringLength(128)]
        public string Id { get; set; }

        public int STT { get; set; }
        public byte[] Img { get; set; }
        [StringLength(128)]
        public string IDSanPham { get; set; }
        [ForeignKey(nameof(IDSanPham))]
        public SanPham SanPham { get; set; }
    }
}