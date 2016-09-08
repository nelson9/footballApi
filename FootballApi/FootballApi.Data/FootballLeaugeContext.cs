using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Models;

namespace FootballApi.Data
{
    public class FootballLeaugeContext : DbContext
    {
        public FootballLeaugeContext()
            : base("FootballLeaugeContext")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchResult> MatchResult { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MatchResult>()
                .HasRequired(m => m.HomeTeam)
                    .WithMany(t => t.HomeResults)
                    .HasForeignKey(m => m.HomeTeamId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchResult>()
                .HasRequired(m => m.AwayTeam)
                    .WithMany(t => t.AwayResults)
                    .HasForeignKey(m => m.AwayTeamId)
                    .WillCascadeOnDelete(false);
        }
    }
}
