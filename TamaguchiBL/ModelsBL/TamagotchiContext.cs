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

        public Players Login(String userName, String password)
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

        public void AddPlayer(Players p)
        {
            this.Players.Add(p);

        }
        public void AddActionHistory(ActionsHistory ah)
        {
            this.ActionsHistory.Add(ah);
        }
        public void AddPet(Pets p)
        {
            this.Pets.Add(p);

        }
        public List<Actions> showFeedingActions()
        {
            const int Feedind_Id = 1;
            List<Actions> list = this.Actions.Where(a => a.ActionTypeId == Feedind_Id).ToList();
            return list;

        }
        public bool IsAlive(Players p)
        {
            const int DEAD_STATUS = 4;
            foreach (Pets a in p.Pets)
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


