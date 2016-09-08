using System.ComponentModel;

namespace FootballApi.Models.Enums
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
