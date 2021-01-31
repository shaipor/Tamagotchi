using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("Players", Schema = "main")]
    public partial class Players
    {
        public Players()
        {
            Pets = new HashSet<Pets>();
        }

        [Key]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Mail { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PlayerBirthDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [InverseProperty("UserNameNavigation")]
        public virtual ICollection<Pets> Pets { get; set; }
    }
}
