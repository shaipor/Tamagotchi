using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("LifeCycles", Schema = "main")]
    public partial class LifeCycle
    {
        public LifeCycle()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int LifeCycleId { get; set; }
        [StringLength(20)]
        public string CycleName { get; set; }
        public int CycleDuration { get; set; }

        [InverseProperty(nameof(ActionsHistory.LifeCycle))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
        [InverseProperty(nameof(Pet.LifeCycle))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
