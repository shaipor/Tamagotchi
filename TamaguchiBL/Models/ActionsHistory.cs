using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("ActionsHistory", Schema = "main")]
    public partial class ActionsHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [InverseProperty(nameof(Actions.ActionsHistory))]
        public virtual Actions Action { get; set; }
        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty(nameof(LifeCycles.ActionsHistory))]
        public virtual LifeCycles LifeCycle { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty(nameof(Pets.ActionsHistory))]
        public virtual Pets Pet { get; set; }
    }
}
