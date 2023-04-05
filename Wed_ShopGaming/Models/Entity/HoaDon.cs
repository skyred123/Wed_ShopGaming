using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class HoaDon
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Status { get; set; }

        public string Payments { get; set; }

        public string Price { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public  ICollection<CT_DH> CT_DHs { get; set; }
    }
}