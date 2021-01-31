using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("PetStatus", Schema = "main")]
    public partial class PetStatus
    {
        public PetStatus()
        {
            Pets = new HashSet<Pets>();
        }

        [Key]
        public int StatusId { get; set; }
        [StringLength(20)]
        public string StatusName { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Pets> Pets { get; set; }
    }
}
