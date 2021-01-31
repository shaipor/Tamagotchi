using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiWebAPI.DataTransferObjects
{
    public class AnimalDTO
    {
        public int petId { get; set; }
        public string petName { get; set; }
        public string userName { get; set; }
        public double petWeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungerLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinesLevel { get; set; }
        
        public AnimalDTO() { }
        public AnimalDTO(Pets a)
        {
            petId = a.PetId;
           petName = a.PetName;
            userName = a.UserName;
            petWeight = a.Weigth;
            BirthDate = a.PetBirthDate;
            HungerLevel = a.HungerLevel;
            HygieneLevel = a.HygieneLevel;
            HappinesLevel = a.HappinesLevel;
        }
    }
}
