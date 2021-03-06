﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Groapa.Domain.Models.ViewModels
{
    public class MatchInsertViewModel
    {
        public string Season { get; set; }
        public int? Round { get; set; }
        public string Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int? HTHome { get; set; }
        public int? HTAway { get; set; }
        public string Referee { get; set; }
        public string Stadium { get; set; }
        public int? HomeShots { get; set; }
        public int? AwayShots { get; set; }
        public int? HomeOnTarget { get; set; }
        public int? AwayOnTarget { get; set; }
        public int? HomeCorners { get; set; }
        public int? AwayCorners { get; set; }
        public int? HomeYellows { get; set; }
        public int? AwayYellows { get; set; }
        public int? HomeReds { get; set; }
        public int? AwayReds { get; set; }
        public decimal? B365H { get; set; }
        public decimal? B365D { get; set; }
        public decimal? B356A { get; set; }
        public decimal? BWH { get; set; }
        public decimal? BWD { get; set; }
        public decimal? BWA { get; set; }
    }
}
