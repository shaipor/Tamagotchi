using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("ActionTypes", Schema = "main")]
    public partial class ActionType
    {
        public ActionType()
        {
            Actions = new HashSet<Action>();
        }

        [Key]
        public int ActionTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string ActionTypeName { get; set; }
        public bool IsAffectingHunger { get; set; }
        public bool IsAffectingHappines { get; set; }
        public bool IsAffectingHygiene { get; set; }

        [InverseProperty(nameof(Action.ActionType))]
        public virtual ICollection<Action> Actions { get; set; }
    }
}
