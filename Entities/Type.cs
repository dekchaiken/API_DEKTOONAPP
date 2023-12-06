using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Cartoons = new HashSet<Cartoon>();
            Novels = new HashSet<Novel>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("typeId")]
        public int TypeId { get; set; }
        [Column("typeName")]
        [StringLength(200)]
        public string? TypeName { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<Cartoon> Cartoons { get; set; }
        [InverseProperty("Type")]
        public virtual ICollection<Novel> Novels { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Types")]
        public virtual ICollection<User> Users { get; set; }
    }
}
