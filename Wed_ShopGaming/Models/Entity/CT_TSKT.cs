using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class CT_TSKT
    {
        [Key]
        public string id { get; set; }
        public string IdLinhKien { get; set; }
        public string IdTSKT { get; set; }

        [ForeignKey("IdTSKT")]
        public TSKT TSKT { get; set; }
        [ForeignKey("IdMayTinh")]
        public LinhKien LinhKien { get; set; }
    }
}