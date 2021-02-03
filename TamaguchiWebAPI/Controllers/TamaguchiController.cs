﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TamaguchiBL.Models;
using TamaguchiWebAPI.DataTransferObjects;

namespace TamaguchiWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        TamagotchiContext context;
        public TamaguchiController(TamagotchiContext context)
        {
            this.context = context;
        }
        #endregion
        [Route("Login")]
        [HttpGet]
        public PlayerDTO Login([FromQuery] string userName, [FromQuery] string pass)
        {
            Players p = context.Login(userName, pass);

            //Check user name and password.
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("SignUp")]
        [HttpGet]
        public PlayerDTO SignUp([FromBody] string UserName, string PlayerName,  string PlayerFamilyName, string Email, DateTime BirthDate)
        {
            Players p = new Players(PlayerName);
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            Players pp= context.AddPlayer(p);
        }

        [Route("GetAnimals")]
        [HttpGet]
        public List<PetsDTO> GetAnimals()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Players p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                List<PetsDTO> list = new List<PetsDTO>();
                if (p != null)
                {
                    foreach (Pets pa in p.Pets)
                    {
                        list.Add(new PetsDTO(pa));
                    }
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                return list;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

    }
}
