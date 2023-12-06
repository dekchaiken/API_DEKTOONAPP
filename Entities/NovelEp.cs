using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("NovelEP")]
    public partial class NovelEp
    {
        [Key]
        [Column("novelEpId")]
        public int NovelEpId { get; set; }
        [Column("novelEPNo")]
        [StringLength(3)]
        public string? NovelEpno { get; set; }
        [Column("novelEPName")]
        [StringLength(500)]
        public string? NovelEpname { get; set; }
        [Column("novelEPSubtitle")]
        [StringLength(200)]
        public string? NovelEpsubtitle { get; set; }
        [Column("novelEPContent")]
        public string? NovelEpcontent { get; set; }
        [Column("novelId")]
        public int? NovelId { get; set; }
    }
}
