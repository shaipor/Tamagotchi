using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace TamaguchiBL.Models
{
   
    public partial class Pet
    {
        public Pet(string name)
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

       
            public void FeedAnimal(Action at)
            {
                try
                {
                    int hungerLevel = this.HungerLevel;
                    //write the activity
               

                    int ActionTypeId = at.ActionTypeId;
                    //Add more logic here!!
                    double weigth = this.Weigth + 0.5 * this.Weigth;
                    if (this.HungerLevel + at.ActionEffection <= 5)
                        hungerLevel = this.HungerLevel + at.ActionEffection;
                    else
                        this.HungerLevel = 5;
                    if (this.HungerLevel >= 3)
                        this.StatusId = 1;

               
                        //update the animal
                        this.Weigth = weigth;
                   
                
                }
                catch(Exception e)
                {
                
                }
            
            }

        public void Play(Action a)
        {
            this.HappinesLevel += a.ActionEffection;
            if (this.HappinesLevel > 5)
                this.HappinesLevel = 5;



            //int HappinesLevel = this.HappinesLevel;
            ////write the activity
            //Action activity = new Action();
            //int ActionTypeId = a.ActionTypeId;
            ////Add more logic here!!
            //if (this.HappinesLevel + activity.ActionEffection <= 5)
            //    HappinesLevel = this.HappinesLevel + activity.ActionEffection;
            //else
            //    this.HappinesLevel = 5;

           
            //if (this.HappinesLevel >= 3)
            //    this.StatusId = 1;

            //using (var context = new TamagotchiContext())
            //{
            //    //update the animal
            //    ActionsHistory newAction = new ActionsHistory();
            //    newAction.UserName = this.UserName;
            //    newAction.StatusId = this.StatusId;
            //    newAction.PetId = this.PetId;
            //    newAction.PetAge = this.PetAge;
            //    newAction.Action = a;
            //    newAction.ActionId = a.ActionId;
            //    newAction.ActionTime = DateTime.Now;
            //    newAction.LifeCycleId = this.LifeCycleId;
            //    newAction.HungerLevel = this.HungerLevel;
            //    newAction.HygieneLevel = this.HygieneLevel;
            //    newAction.HappinesLevel = this.HappinesLevel;


            //    //this.ActionsHistory.Add(newAction);
            //    context.AddActionHistory(newAction);
            //    context.SaveChanges();
            //}

        }

        //public bool HasActiveAnimal(Players player)
        //{
        //    return this.UserNameNavigation.Pets.Any(a => a.UserName != player.UserName);
        //}

    }
}
