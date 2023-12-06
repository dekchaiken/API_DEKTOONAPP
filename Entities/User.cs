using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Types = new HashSet<Type>();
        }

        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("userName")]
        [StringLength(200)]
        public string? UserName { get; set; }
        [Column("userFullName")]
        [StringLength(500)]
        public string? UserFullName { get; set; }
        [Column("userEmail")]
        [StringLength(200)]
        public string? UserEmail { get; set; }
        [Column("userPassword")]
        [StringLength(20)]
        public string? UserPassword { get; set; }
        [Column("userStatus")]
        public bool? UserStatus { get; set; }
        [Column("adminId")]
        public int? AdminId { get; set; }

        [ForeignKey("AdminId")]
        [InverseProperty("Users")]
        public virtual Admin? Admin { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Users")]
        public virtual ICollection<Type> Types { get; set; }
    }
}