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
        [Key]
        public string id { get; set; }
        public string IdLinhKien { get; set; }
        public string IdMayTinh { get; set; }

        [ForeignKey("IdMayTinh")]
        public MayTinh MayTinh { get; set; }
        [ForeignKey("IdMayTinh")]
        public LinhKien LinhKien { get; set;}
    }
}