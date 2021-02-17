using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    
    public partial class ActionsHistory
    {
        public ActionsHistory()
        {

        }
        public ActionsHistory(Action ac)
        {
            this.Action = ac;
        }
        public ActionsHistory(Action ac,Pet p)
        {
            this.ActionId = ac.ActionId;
            this.Action = ac;
            this.Pet = p;
            this.Status = p.Status;
            this.StatusId = p.StatusId;
            this.PetAge = p.PetAge;
            this.ActionTime = DateTime.Now;
            this.LifeCycle = p.LifeCycle;
            this.HungerLevel = p.HungerLevel;
            this.HygieneLevel = p.HygieneLevel;
            this.HappinesLevel = p.HappinesLevel;
            this.UserName = p.UserName;
            this.UserNameNavigation = p.UserNameNavigation;
        }
        
    }
}
