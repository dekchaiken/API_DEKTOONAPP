using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("Novel")]
    public partial class Novel
    {
        public Novel()
        {
            AdmManageNovels = new HashSet<AdmManageNovel>();
        }

        [Key]
        [Column("novelId")]
        public int NovelId { get; set; }
        [Column("noveIName")]
        [StringLength(200)]
        public string? NoveIname { get; set; }
        [Column("novelSubtitle")]
        [StringLength(500)]
        public string? NovelSubtitle { get; set; }
        [Column("novelCover")]
        public string? NovelCover { get; set; }
        [Column("novelCreate", TypeName = "date")]
        public DateTime? NovelCreate { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }
        [Column("typeId")]
        public int? TypeId { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Novels")]
        public virtual Type? Type { get; set; }
        [InverseProperty("Novel")]
        public virtual ICollection<AdmManageNovel> AdmManageNovels { get; set; }
    }
}
