﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("PetStatus", Schema = "main")]
    public partial class PetStatus
    {
        public PetStatus()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int StatusId { get; set; }
        [StringLength(20)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(ActionsHistory.Status))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
        [InverseProperty(nameof(Pet.Status))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
