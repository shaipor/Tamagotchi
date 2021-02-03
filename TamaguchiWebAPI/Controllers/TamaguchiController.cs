using Microsoft.AspNetCore.Mvc;
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

        [Route("GetPets")]
        [HttpGet]
        public List<PetDTO> GetPets()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Players p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                List<PetDTO> list = new List<PetDTO>();
                if (p != null)
                {
                    foreach (Pets pa in p.Pets)
                    {
                        list.Add(new PetDTO(pa));
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
                Players p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
                List<ActionsDTO> list = new List<ActionsDTO>();

                if (p != null)
                {
                    foreach (Actions ac in context.showFeedingActions())
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

        //[Route("Feed")]
        //[HttpGet]
        //public List<ActionsDTO> Feed([FromQuery] int actionTypeNum)
        //{
        //    PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");

        //    if (pDto != null)
        //    {
        //        Players p = context.Players.Where(pp => pp.UserName == pDto.UserName).FirstOrDefault();
        //        List<ActionsDTO> list = new List<ActionsDTO>();

        //        if (p != null)
        //        {
        //            foreach (Actions ac in context.showFeedingActions())
        //            {

        //                list.Add(new ActionsDTO(ac));

        //            }
        //        }
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

        //        return list;
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        //        return null;
        //    }
        //}

    }


}

