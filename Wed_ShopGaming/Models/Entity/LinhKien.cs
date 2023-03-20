using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class LinhKien
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdLoaiSP { get; set; }
        public Guid IdThongSo { get; set; }
        public Guid IdDMSP { get; set; }
        public Guid IdSanPham { get; set; }

        [ForeignKey(nameof(IdSanPham))]
        public SanPham SanPham { get; set; }
        [ForeignKey(nameof(IdLoaiSP))]
        public LoaiSP LoaiSP { get; set; }

        [ForeignKey(nameof(IdThongSo))]
        public ThongSo ThongSo { get; set; }

        [ForeignKey(nameof(IdDMSP))]
        public DMSP DMSP { get; set; }
    }
}