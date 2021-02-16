using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("Players", Schema = "main")]
    public partial class Player
    {
        public Player()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Mail { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PlayerBirthDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [InverseProperty(nameof(ActionsHistory.UserNameNavigation))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
        [InverseProperty(nameof(Pet.UserNameNavigation))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
