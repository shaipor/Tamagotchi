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
            petId = a.PetId;
            petName = a.PetName;
            userName = a.UserName; ;
            petWeight = a.Weigth;
            petAge = a.PetAge;
            BirthDate = a.PetBirthDate;
            HungerLevel = a.HungerLevel;
            HygieneLevel = a.HygieneLevel;
            HappinesLevel = a.HappinesLevel;
            StatusId = a.StatusId;
            LifeCycleId = a.LifeCycleId;
        }
    }
}
