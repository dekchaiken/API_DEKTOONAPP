using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("CartoonPicture")]
    public partial class CartoonPicture
    {
        [Key]
        [Column("cartoonPicId")]
        public int CartoonPicId { get; set; }
        [Column("cartoonPicContent")]
        [StringLength(200)]
        public string? CartoonPicContent { get; set; }
        [Column("cartoonEpId")]
        public int? CartoonEpId { get; set; }

        [ForeignKey("CartoonEpId")]
        [InverseProperty("CartoonPictures")]
        public virtual CartoonEp? CartoonEp { get; set; }
    }
}
