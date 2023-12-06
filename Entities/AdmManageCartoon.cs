using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("AdmManageCartoon")]
    public partial class AdmManageCartoon
    {
        [Key]
        [Column("adminId")]
        public int AdminId { get; set; }
        [Key]
        [Column("cartoonId")]
        public int CartoonId { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime? DateTime { get; set; }

        [ForeignKey("AdminId")]
        [InverseProperty("AdmManageCartoons")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("CartoonId")]
        [InverseProperty("AdmManageCartoons")]
        public virtual Cartoon Cartoon { get; set; } = null!;
    }
}
