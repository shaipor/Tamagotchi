using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("Pets", Schema = "main")]
    public partial class Pet
    {
        public Pet()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
        }

        [Key]
        public int PetId { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string PetName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PetBirthDate { get; set; }
        public double Weigth { get; set; }
        public int PetAge { get; set; }
        public int HungerLevel { get; set; }
        public int HappinesLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int StatusId { get; set; }
        public int LifeCycleId { get; set; }

        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("Pets")]
        public virtual LifeCycle LifeCycle { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PetStatus.Pets))]
        public virtual PetStatus Status { get; set; }
        [ForeignKey(nameof(UserName))]
        [InverseProperty(nameof(Player.Pets))]
        public virtual Player UserNameNavigation { get; set; }
        [InverseProperty(nameof(ActionsHistory.Pet))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
    }
}
