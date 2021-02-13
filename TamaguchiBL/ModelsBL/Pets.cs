using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace TamaguchiBL.Models
{
   
    public partial class Pets
    {
        public Pets(string name)
        {
            this.PetName = name;
            //this.UserName = UIMain.CurrentPlayer.UserName;
            this.StatusId = 1;
            this.PetBirthDate = DateTime.Now;
            this.Weigth = 3;
            this.HappinesLevel = 5;
            this.HungerLevel = 5;
            this.HygieneLevel = 5;
            //this.UserNameNavigation = UIMain.CurrentPlayer;
            this.LifeCycleId = 1;
        }

        public void FeedAnimal(Actions at)
        {
            try
            {
                int hungerLevel = this.HungerLevel;
                //write the activity
                Actions activity = new Actions();

                int ActionTypeId = at.ActionTypeId;
                //Add more logic here!!
                double weigth = this.Weigth + 0.5 * this.Weigth;
                if (this.HungerLevel + activity.ActionEffection <= 5)
                    hungerLevel = this.HungerLevel + activity.ActionEffection;
                else
                    this.HungerLevel = 5;
                if (this.HungerLevel >= 3)
                    this.StatusId = 1;

                using (var db = new TamagotchiContext())
                {
                    //update the animal
                    this.Weigth = weigth;
                    ActionsHistory newAction = new ActionsHistory();
                    //newAction.UserName = UIMain.CurrentPlayer.UserName;
                    newAction.StatusId = this.StatusId;
                    newAction.PetId = this.PetId;
                    newAction.PetAge = this.PetAge;
                    newAction.Action = at;
                    newAction.ActionId = at.ActionId;
                    newAction.ActionTime = DateTime.Now;
                    newAction.LifeCycleId = this.LifeCycleId;
                    newAction.HungerLevel = this.HungerLevel;
                    newAction.HygieneLevel = this.HygieneLevel;
                    newAction.HappinesLevel = this.HappinesLevel;
                    //newAction.LifeCycle = db.LifeCycles.Where(a => a.LifeCycleId == this.LifeCycleId).FirstOrDefault();
                    //newAction.Pet = db.Pets.Where(p => p.PetId == this.PetId).FirstOrDefault();
                    newAction.UserName = this.UserName;





                    //this.ActionsHistory.Add(newAction);
                    db.AddActionHistory(newAction);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("somthing went wrong");
                Console.WriteLine(e);
            }
            
        }

        public void Play(Actions a, string userName)
        {
            int HappinesLevel = this.HappinesLevel;
            //write the activity
            Actions activity = new Actions();

            int ActionTypeId = a.ActionTypeId;
            //Add more logic here!!
            if (this.HappinesLevel + activity.ActionEffection <= 5)
                HappinesLevel = this.HappinesLevel + activity.ActionEffection;
            else
                this.HappinesLevel = 5;
            if (this.HappinesLevel >= 3)
                this.StatusId = 1;

            using (var context = new TamagotchiContext())
            {
                //update the animal
                ActionsHistory newAction = new ActionsHistory();
                newAction.UserName = this.UserName;
                newAction.StatusId = this.StatusId;
                newAction.PetId = this.PetId;
                newAction.PetAge = this.PetAge;
                newAction.Action = a;
                newAction.ActionId = a.ActionId;
                newAction.ActionTime = DateTime.Now;
                newAction.LifeCycleId = this.LifeCycleId;
                newAction.HungerLevel = this.HungerLevel;
                newAction.HygieneLevel = this.HygieneLevel;
                newAction.HappinesLevel = this.HappinesLevel;


                //this.ActionsHistory.Add(newAction);
                context.AddActionHistory(newAction);
                context.SaveChanges();
            }
           
        }

        //public bool HasActiveAnimal(Players player)
        //{
        //    return this.UserNameNavigation.Pets.Any(a => a.UserName != player.UserName);
        //}

    }
}
