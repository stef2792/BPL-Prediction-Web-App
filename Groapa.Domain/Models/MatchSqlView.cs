using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Groapa.Domain.Models
{
    [Table("Matches")]
    public class MatchSqlView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchID { get; set; }
        public string Season { get; set; }
        public int? Round { get; set; }
        public DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public virtual MatchDetailsSqlView MatchDetails { get; set; }
    }
}
