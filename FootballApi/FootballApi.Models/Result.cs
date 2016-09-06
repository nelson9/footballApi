using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    public enum Result
    {
        [Description("Home Win")]
        HomwWin = 1,
        [Description("Away Win")]
        AwayWin,
        [Description("Draw")]
        Draw
    }
}
