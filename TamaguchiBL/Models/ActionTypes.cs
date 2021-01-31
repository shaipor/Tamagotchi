using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("ActionTypes", Schema = "main")]
    public partial class ActionTypes
    {
        public ActionTypes()
        {
            Actions = new HashSet<Actions>();
        }

        [Key]
        public int ActionTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string ActionTypeName { get; set; }
        public bool IsAffectingHunger { get; set; }
        public bool IsAffectingHappines { get; set; }
        public bool IsAffectingHygiene { get; set; }

        [InverseProperty("ActionType")]
        public virtual ICollection<Actions> Actions { get; set; }
    }
}
