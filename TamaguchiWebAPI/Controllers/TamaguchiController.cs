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
            Player p = context.Login(userName, pass);

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

        [Route("GetAllGames")]
        [HttpGet]
        public List<ActionsDTO> GetAllGames()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
           
            if (pDto != null)
            {
                List<TamaguchiBL.Models.Action> list = context.GetAllGames();
                List<ActionsDTO> listDTO = new List<ActionsDTO>();
                if (list != null)
                {
                    foreach (TamaguchiBL.Models.Action a in list)
                    {
                        listDTO.Add(new ActionsDTO(a));
                    }
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return listDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("Play")]
        [HttpPost]
        public void Play([FromBody] ActionsDTO actionsDTO)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
           
            if (pDto != null)
            {

                Player p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                Pet pet = p.Pets.Where(a => a.LifeCycleId == 1).FirstOrDefault();
                //TamaguchiBL.Models.Action action = new TamaguchiBL.Models.Action
                //{
                //    ActionName = actionsDTO.actionName,
                //    ActionEffection = actionsDTO.actionEffection,
                //    ActionId = actionsDTO.actionId
                //};
                TamaguchiBL.Models.Action ac = context.Actions.Where(a => a.ActionId == actionsDTO.actionId).FirstOrDefault();
                context.Play(pet, ac);
                  Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
        }

        [Route("GetAnimals")]
        [HttpGet]
        
        public List<PetsDTO> GetAnimals()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                List<PetsDTO> list = new List<PetsDTO>();
                if (p != null)
                {
                    foreach (Pet pa in p.Pets)
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

        [Route("GetFeedingActions")]
        [HttpGet]
        public List<ActionsDTO> GetFeedingActions()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");

            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                List<ActionsDTO> list = new List<ActionsDTO>();

                if (p != null)
                {
                    foreach (TamaguchiBL.Models.Action ac in context.showFeedingActions())
                    {

                        list.Add(new ActionsDTO(ac));

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

        [Route("FeedAnimal")]
        [HttpPost]
        public PetsDTO Feed([FromQuery] int actionId)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");

            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                TamaguchiBL.Models.Action ac =context.Actions.Where(a => a.ActionId == actionId).FirstOrDefault();
                Pet pe = p.Pets.Where(a => a.LifeCycleId == 1).FirstOrDefault();
                if (pe == null)
                    return null;
                else
                {
                    context.FeedAnimal(pe, ac);

                    Console.WriteLine($"the pet ate {ac.ActionName}");
                    //Console.ReadKey();
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                    return new PetsDTO(pe);
                }
                //p.Pets.Where(a => a.LifeCycleId == 0).FirstOrDefault().FeedAnimal(context.Actions.Where(x=>x.ActionId== actionId).FirstOrDefault());
                 
                
              
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("HasActiveAnimal")]
        [HttpPost]
        public bool HasActiveAnimal()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");

            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                return p.HasActiveAnimal();
            }
            else
                return false;
        }



    }


}

