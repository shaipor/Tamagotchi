using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    [Table("Pets", Schema = "main")]
    public partial class Pets
    {
        public Pets()
        {
            ActionsHistory = new HashSet<ActionsHistory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetId { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string PetName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PetBirthDate { get; set; }
        public double Weigth { get; set; }
        public int PetAge { get; set; }
        public int HungerLevel { get; set; }
        public int HappinesLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int StatusId { get; set; }
        public int LifeCycleId { get; set; }

        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PetStatus.Pets))]
        public virtual PetStatus Status { get; set; }
        [ForeignKey(nameof(UserName))]
        [InverseProperty(nameof(Players.Pets))]
        public virtual Players UserNameNavigation { get; set; }
        [InverseProperty("Pet")]
        public virtual ICollection<ActionsHistory> ActionsHistory { get; set; }
    }
}
