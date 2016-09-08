using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Data.Generic;
using FootballApi.Models;

namespace FootballApi.Data.Repositories
{
    public class TeamRepository : Repository<Team>
    {
        public FootballLeaugeContext FootballLeaugeContext
        {
            get
            {
                return Context as FootballLeaugeContext;
            }
        }

        public TeamRepository(FootballLeaugeContext context) : base(context){ }
    }
}
