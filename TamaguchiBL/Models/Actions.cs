using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("Actions", Schema = "main")]
    public partial class Actions
    {
        public Actions()
        {
            ActionsHistory = new HashSet<ActionsHistory>();
        }

        [Key]
        public int ActionId { get; set; }
        [Required]
        [StringLength(30)]
        public string ActionName { get; set; }
        public int ActionTypeId { get; set; }
        public int ActionEffection { get; set; }

        [ForeignKey(nameof(ActionTypeId))]
        [InverseProperty(nameof(ActionTypes.Actions))]
        public virtual ActionTypes ActionType { get; set; }
        [InverseProperty("Action")]
        public virtual ICollection<ActionsHistory> ActionsHistory { get; set; }
    }
}
