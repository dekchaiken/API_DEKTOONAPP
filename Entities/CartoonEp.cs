using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("CartoonEP")]
    public partial class CartoonEp
    {
        public CartoonEp()
        {
            CartoonPictures = new HashSet<CartoonPicture>();
        }

        [Key]
        [Column("cartoonEpId")]
        public int CartoonEpId { get; set; }
        [Column("cartoonEpNo")]
        [StringLength(3)]
        public string? CartoonEpNo { get; set; }
        [Column("cartoonEpName")]
        [StringLength(500)]
        public string? CartoonEpName { get; set; }
        [Column("cartoonEpSubtitle")]
        [StringLength(200)]
        public string? CartoonEpSubtitle { get; set; }
        [Column("cartoonId")]
        public int? CartoonId { get; set; }

        [ForeignKey("CartoonId")]
        [InverseProperty("CartoonEps")]
        public virtual Cartoon? Cartoon { get; set; }
        [InverseProperty("CartoonEp")]
        public virtual ICollection<CartoonPicture> CartoonPictures { get; set; }
    }
}
