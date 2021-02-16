using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("ActionsHistory", Schema = "main")]
    public partial class ActionsHistory
    {
        [Key]
        public int HistoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        public int PetId { get; set; }
        public int ActionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ActionTime { get; set; }
        public int LifeCycleId { get; set; }
        public int PetAge { get; set; }
        public int StatusId { get; set; }
        public int HungerLevel { get; set; }
        public int HappinesLevel { get; set; }
        public int HygieneLevel { get; set; }

        [ForeignKey(nameof(ActionId))]
        [InverseProperty("ActionsHistories")]
        public virtual Action Action { get; set; }
        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("ActionsHistories")]
        public virtual LifeCycle LifeCycle { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty("ActionsHistories")]
        public virtual Pet Pet { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PetStatus.ActionsHistories))]
        public virtual PetStatus Status { get; set; }
        [ForeignKey(nameof(UserName))]
        [InverseProperty(nameof(Player.ActionsHistories))]
        public virtual Player UserNameNavigation { get; set; }
    }
}
