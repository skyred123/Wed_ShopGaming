using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class CT_LinhKien
    {
        [StringLength(128)]
        public string IdLinhKien { get; set; }
        [StringLength(128)]
        public string IdMayTinh { get; set; }

        [ForeignKey(nameof(IdLinhKien))]
        public LinhKien LinhKien { get; set; }
        [ForeignKey(nameof(IdMayTinh))]
        public MayTinh MayTinh { get; set; }
    }
}