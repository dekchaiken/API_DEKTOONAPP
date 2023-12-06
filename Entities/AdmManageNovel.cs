using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("AdmManageNovel")]
    public partial class AdmManageNovel
    {
        [Key]
        [Column("adminId")]
        public int AdminId { get; set; }
        [Key]
        [Column("novelId")]
        public int NovelId { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime? DateTime { get; set; }

        [ForeignKey("AdminId")]
        [InverseProperty("AdmManageNovels")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("NovelId")]
        [InverseProperty("AdmManageNovels")]
        public virtual Novel Novel { get; set; } = null!;
    }
}
