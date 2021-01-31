using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("LifeCycles", Schema = "main")]
    public partial class LifeCycles
    {
        public LifeCycles()
        {
            ActionsHistory = new HashSet<ActionsHistory>();
        }

        [Key]
        public int LifeCycleId { get; set; }
        [StringLength(20)]
        public string CycleName { get; set; }
        public int CycleDuration { get; set; }

        [InverseProperty("LifeCycle")]
        public virtual ICollection<ActionsHistory> ActionsHistory { get; set; }
    }
}
