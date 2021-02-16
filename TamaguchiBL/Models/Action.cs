using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("Actions", Schema = "main")]
    public partial class Action
    {
        public Action()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
        }

        [Key]
        public int ActionId { get; set; }
        [Required]
        [StringLength(30)]
        public string ActionName { get; set; }
        public int ActionTypeId { get; set; }
        public int ActionEffection { get; set; }

        [ForeignKey(nameof(ActionTypeId))]
        [InverseProperty("Actions")]
        public virtual ActionType ActionType { get; set; }
        [InverseProperty(nameof(ActionsHistory.Action))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
    }
}
