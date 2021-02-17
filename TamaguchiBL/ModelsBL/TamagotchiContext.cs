using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

using System.Threading;


namespace TamaguchiBL.Models
{
    public partial class TamagotchiContext
    {

        public Player Login(String userName, String password)
        {
            var data = this.Players.Where(s => s.UserName.Equals(userName) && s.Password.Equals(password)).ToList();
            if (data.Count == 1)
            {
                return data.First();
            }
            else
            {
                return null;
            }
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);

        }
        public void AddActionHistory(ActionsHistory ah)
        {
            try
            {
                this.ActionsHistories.Add(ah);
            }
            catch(Exception e)
            {
                Console.WriteLine("somthing went wrong{0}",e);
            }
           
        }
        public void FeedAnimal(Pet p, Action feed)
        {
            try 
            { 
                p.FeedAnimal(feed);
                ActionsHistory newAction = this.ActionsHistories.CreateProxy();
                //newAction.UserName = UIMain.CurrentPlayer.UserName;
                newAction.StatusId = p.StatusId;
                newAction.PetAge = p.PetAge;
                newAction.ActionTime = DateTime.Now;
                 newAction.LifeCycle = p.LifeCycle;
                 newAction.HungerLevel = p.HungerLevel;
                newAction.HygieneLevel = p.HygieneLevel;
                newAction.HappinesLevel = p.HappinesLevel;
                //newAction.UserName = p.UserName;


                p.ActionsHistories.Add(newAction);
                this.SaveChanges();
            }

            catch(Exception e)
            {
              
            }
        }

        public void Play(Pet p, Action play)
        {
            try
            {

                p.Play(play);
                //p.HappinesLevel += play.ActionEffection;
                //if (p.HappinesLevel > 5)
                //    p.HappinesLevel = 5;

                ActionsHistory action = this.ActionsHistories.CreateProxy();
                action.StatusId = p.StatusId;
                action.PetAge = p.PetAge;
                action.ActionTime = DateTime.Now;
                action.LifeCycle = p.LifeCycle;
                action.HungerLevel = p.HungerLevel;
                action.HygieneLevel = p.HygieneLevel;
                action.HappinesLevel = p.HappinesLevel;


                p.ActionsHistories.Add(action);
                this.SaveChanges();
            }

            catch (Exception e)
            {

            }
        }
        public void AddPet(Pet p)
        {
            this.Pets.Add(p);

        }
        public List<Action> showFeedingActions()
        {
            const int Feedind_Id = 1;
            List<Action> list = this.Actions.Where(a => a.ActionTypeId == Feedind_Id).ToList();
            return list;

        }

        public List<Action> GetAllGames()
        {
            const int PLAYINGID = 2;
            List<Action> list = this.Actions.Where(a => a.ActionTypeId == PLAYINGID).ToList();
            return list;

        }

        public bool IsAlive(Player p)
        {
            const int DEAD_STATUS = 4;
            foreach (Pet a in p.Pets)
            {
                if (a.StatusId != DEAD_STATUS)
                    return true;

            }
            return false;
        }
        public bool PlayerExistByUserName(string userName)
        {
            return Players.Any(p => p.UserName == userName);
        }
        public bool IsEmpty(string s)
        {
            if (s == "")
                return true;
            return false;

        }
        public string checkString(string s, string type)
        {
            while (IsEmpty(s))
            {
                Console.WriteLine("invalid {0}, try again", type);
                s = Console.ReadLine();
            }
            return s;

        }
        public string checkGender(string gen)
        {
            while (gen != "male" && gen != "female")
            {
                Console.WriteLine("invalid gender, try again");
                gen = Console.ReadLine();
            }
            return gen;

        }
        //public DateTime  checkDate(string date)
        //{
        //    while (!((date) is DateTime))
        //    {
        //        Console.WriteLine("invalid birth date, try again");
        //        date =DateTime.Parse(Console.ReadLine());
        //    }
        //    return gen;
        //}
    }
}


