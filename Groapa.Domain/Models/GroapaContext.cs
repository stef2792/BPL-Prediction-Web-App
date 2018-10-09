using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groapa.Domain.Models
{
    public class GroapaContext :DbContext
    {
        public GroapaContext(DbContextOptions<GroapaContext> options):base(options)
        {

        }

        public DbSet<MatchSqlView> Matches { get; set; }
        public DbSet<MatchDetailsSqlView> MatchDetails { get; set; }

    }
}
