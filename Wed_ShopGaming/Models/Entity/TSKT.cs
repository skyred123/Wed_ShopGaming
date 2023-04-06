using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_ShopGaming.Models.Entity
{
    public class TSKT
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CT_TSKT> CT_TSKTs { get; set; }
    }
}