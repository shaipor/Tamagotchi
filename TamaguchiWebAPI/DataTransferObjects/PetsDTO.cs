using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiWebAPI.DataTransferObjects
{
    public class PetsDTO
    {
        public int petId { get; set; }
        public string petName { get; set; }
        public string userName { get; set; }
        public double petWeight { get; set; }
        public double petAge { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungerLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinesLevel { get; set; }
        public int StatusId { get; set; }
        public int LifeCycleId { get; set; }

        public PetsDTO() { }
        public PetsDTO(Pets a)
        {
            petId = this.petId;
            petName = this.petName;
            userName = this.userName;
            petWeight = this.petWeight;
            petAge = this.petAge;
            BirthDate = this.BirthDate;
            HungerLevel = this.HungerLevel;
            HygieneLevel = this.HygieneLevel;
            HappinesLevel = this.HappinesLevel;
            StatusId = this.StatusId;
            LifeCycleId = this.LifeCycleId;
        }
    }
}
