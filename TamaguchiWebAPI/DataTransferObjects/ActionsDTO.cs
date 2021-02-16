using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiWebAPI.DataTransferObjects
{
    public class ActionsDTO
    {
        public int actionId { get; set; }
        public string actionName { get; set; }
        public int actionTypeId { get; set; }
        public int actionEffection { get; set; }
        
        public ActionsDTO() { }
        public ActionsDTO(TamaguchiBL.Models.Action a)
        {
            actionId = a.ActionId;
            actionName = a.ActionName;
            actionTypeId = a.ActionTypeId;
            actionEffection = a.ActionEffection;
        }
    }
}
