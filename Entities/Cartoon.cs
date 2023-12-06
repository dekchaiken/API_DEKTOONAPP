using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("Cartoon")]
    public partial class Cartoon
    {
        public Cartoon()
        {
            AdmManageCartoons = new HashSet<AdmManageCartoon>();
            CartoonEps = new HashSet<CartoonEp>();
        }

        [Key]
        [Column("cartoonId")]
        public int CartoonId { get; set; }
        [Column("cartoonName")]
        [StringLength(200)]
        public string? CartoonName { get; set; }
        [Column("cartoonSubtitle")]
        [StringLength(500)]
        public string? CartoonSubtitle { get; set; }
        [Column("cartoonCover")]
        public string? CartoonCover { get; set; }
        [Column("typeId")]
        public int? TypeId { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Cartoons")]
        public virtual Type? Type { get; set; }
        [InverseProperty("Cartoon")]
        public virtual ICollection<AdmManageCartoon> AdmManageCartoons { get; set; }
        [InverseProperty("Cartoon")]
        public virtual ICollection<CartoonEp> CartoonEps { get; set; }
    }
}
