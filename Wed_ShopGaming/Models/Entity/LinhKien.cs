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
        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(128)]
        public string IdLoaiLK { get; set; }

        [ForeignKey(nameof(Id))]
        public SanPham SanPham { get; set; }
        

        [ForeignKey(nameof(IdLoaiLK))]
        public LoaiLK LoaiLK { get; set; }
        public virtual ICollection<CT_LinhKien> CT_LinhKiens { get; set; }

        public virtual ICollection<CT_TSKT> CT_TSKTs { get; set; }
    }
}