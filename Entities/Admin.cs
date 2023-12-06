using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dektoon.Entities
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            AdmManageCartoons = new HashSet<AdmManageCartoon>();
            AdmManageNovels = new HashSet<AdmManageNovel>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("adminId")]
        public int AdminId { get; set; }
        [Column("adminEmail")]
        [StringLength(200)]
        public string? AdminEmail { get; set; }
        [Column("adminPassword")]
        [StringLength(20)]
        public string? AdminPassword { get; set; }

        [InverseProperty("Admin")]
        public virtual ICollection<AdmManageCartoon> AdmManageCartoons { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<AdmManageNovel> AdmManageNovels { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<User> Users { get; set; }
    }
}
