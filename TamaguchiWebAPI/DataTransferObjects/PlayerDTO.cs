using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiWebAPI.DataTransferObjects
{
    public class PlayerDTO
    {
        public string UserName { get; set; }
        public string PlayerName { get; set; }
        public string PlayerFamilyName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PlayerDTO() { }
        public PlayerDTO(Players p)
        {
            UserName = p.UserName;
            PlayerFamilyName = p.LastName;
            PlayerName = p.FirstName;
            BirthDate = p.PlayerBirthDate;
            Email = p.Mail;
        }
    }
}
