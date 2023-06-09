﻿using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.ViewModels
{
    public class LinhKienViewModels
    {
        public string id { get; set; }
        [DisplayName("Ten")]
        [Required]
        public string Name { get; set; }
        [DisplayName("So Luong")]
        [Required]

        [Index]
        public string Amount { get; set; }
        [DisplayName("Gia")]
        [Required]
        public string Price { get; set; }
        [DisplayName("Hang")]
        [Required]
        public string IdHang { get; set; }
        [DisplayName("Loai")]
        [Required]
        public string IdLoai { get; set; }
        public List<LoaiLK> LoaiSP { get; set; }
        public List<Hang> hangs { get; set; }

        public List<SanPham> sanPham { get; set;}

    }
    public class MayTinhViewModel
    {
        public string id { get; set; }
        [DisplayName("Ten")]
        [Required]
        public string Name { get; set; }
        [DisplayName("So Luong")]
        [Required]

        [Index]
        public string Amount { get; set; }
        [DisplayName("Gia")]
        [Required]
        public string Price { get; set; }

        [DisplayName("Hang")]
        [Required]
        public string IdHang { get; set; }

        [DisplayName("Cau Hinh")]
        [Required]
        public string IdCauHinh { get; set; }
        public List<CauHinh> CauHinh { get; set; }
        public List<Hang> hangs { get; set; }
        public List<SanPham> SanPham { get; set; }
        public string IdLoai { get; set; }
        public List<LoaiMT> LoaiSP { get; set; }
    }
    public class PagingSPViewModel
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; } 
        public int? page { get; set; } 
        public int totalPage { get; set; }

        public IPagedList<HinhAnhMainViewModel> LapTop { get; set; }
        public IPagedList<HinhAnhMainViewModel> MayTinh { get; set; }
        public IPagedList<HinhAnhMainViewModel> LinhKien { get;set; }
        public IPagedList<HinhAnhMainViewModel> DanhChoBan { get; set; }
    }
    public class GioHangViewModel
    {
        public SanPham sanPham { get; set; }
        public int count { get; set; }
    }
}
