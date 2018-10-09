using Groapa.Domain.Models;
using Groapa.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Groapa.Domain.DataService
{
    public class MatchesSeeder
    {
        private readonly GroapaContext groapaContext;
        private readonly IHostingEnvironment hosting;

        public MatchesSeeder(GroapaContext groapaContext, IHostingEnvironment hosting)
        {
            this.groapaContext = groapaContext;
            this.hosting = hosting;
        }

        public void Seed()
        {
            groapaContext.Database.EnsureCreated();
            if (!groapaContext.Matches.Any())
            {
                var filePath = Path.Combine(hosting.ContentRootPath,"Data/matches.json");
                var json = File.ReadAllText(filePath);
                var matches = JsonConvert.DeserializeObject<IEnumerable<MatchInsertViewModel>>(json)
                                         .Select(x => new MatchSqlView {
                                             Season = x.Season,
                                             Round = x.Round,
                                             Date = x.Date,
                                             HomeTeam = x.HomeTeam,
                                             AwayTeam = x.AwayTeam,
                                             HomeScore = x.HomeScore,
                                             AwayScore = x.AwayScore,
                                             MatchDetails = new MatchDetailsSqlView {
                                                                    HTHome = x.HTHome,
                                                                    HTAway = x.HTAway,
                                                                    Referee = x.Referee,
                                                                    Stadium = x.Stadium,
                                                                    HomeShots = x.HomeShots,
                                                                    AwayShots = x.AwayShots,
                                                                    HomeOnTarget = x.HomeOnTarget,
                                                                    AwayOnTarget = x.AwayOnTarget,
                                                                    HomeCorners = x.HomeCorners,
                                                                    AwayCorners = x.AwayCorners,
                                                                    HomeYellows = x.HomeYellows,
                                                                    AwayYellows = x.AwayYellows,
                                                                    HomeReds = x.HomeReds,
                                                                    AwayReds = x.AwayReds,
                                                                    B365H = x.B365H,
                                                                    B365D = x.B365D,
                                                                    B356A = x.B356A,
                                                                    BWH = x.BWH,
                                                                    BWD = x.BWD,
                                                                    BWA = x.BWA
                                                 },

                                         });
                groapaContext.AddRange(matches);

                groapaContext.SaveChanges();

            }
        }
    }
}
