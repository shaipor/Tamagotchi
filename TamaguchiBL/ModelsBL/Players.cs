using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace TamaguchiBL.Models
{

    public partial class Player
    {
        public bool HasActiveAnimal()
        {
            const int DEAD_STATUS = 4;
            return this.Pets.Any(a => a.StatusId != DEAD_STATUS);
        }
        public List<Object> GetHistory()
        {
            const int DEAD_STATUS = 4;


            Pet pt = this.Pets.Where(p => p.StatusId != DEAD_STATUS).FirstOrDefault();
            List<Object> list = (from ActionsHistory in pt.ActionsHistories
                                 where (ActionsHistory.PetId == pt.PetId)
                                 select new
                                 {
                                     PetName = ActionsHistory.Pet.PetName,
                                     ActionName = ActionsHistory.Action.ActionName,
                                     Happines = ActionsHistory.Pet.HappinesLevel,
                                     Hygiene = ActionsHistory.Pet.HygieneLevel,
                                     Hunger = ActionsHistory.Pet.HungerLevel,
                                     ActionDate = ActionsHistory.ActionTime
                                 }).ToList<Object>();


            return list;

        }

    }


}
