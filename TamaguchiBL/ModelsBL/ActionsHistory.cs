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
        
    }
}
