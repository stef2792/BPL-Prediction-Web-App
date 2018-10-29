using Groapa.Domain.Models;
using Groapa.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groapa.Domain.DataService
{
    public class MatchesSeeder
    {
        private readonly GroapaContext groapaContext;
        private readonly IHostingEnvironment hosting;
        private readonly UserManager<UserSqlView> userManager;

        public MatchesSeeder(GroapaContext groapaContext, IHostingEnvironment hosting, UserManager<UserSqlView> userManager)
        {
            this.groapaContext = groapaContext;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            groapaContext.Database.EnsureCreated();

            UserSqlView user = await userManager.FindByEmailAsync("stefmitea@gmail.com");

            if(user == null)
            {
                user = new UserSqlView
                {
                    FirstName = "Stef",
                    LastName = "Mitea",
                    Email = "stefmitea@gmail.com",
                    UserName = "stef2792"
                };

                var result = await userManager.CreateAsync(user, "Password01!");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user");
                }
            }

            if (!groapaContext.Matches.Any())
            {
                IEnumerable<MatchSqlView> matches = AddMatches();
                groapaContext.AddRange(matches);
                groapaContext.SaveChanges();

            }
        }

        private IEnumerable<MatchSqlView> AddMatches()
        {
            var filePath = Path.Combine(hosting.ContentRootPath, "../Groapa.Domain/Data/MatchLoad.json");
            var json = File.ReadAllText(filePath);
            var matches = JsonConvert.DeserializeObject<IEnumerable<MatchInsertViewModel>>(json)
                                     .Select(x => new MatchSqlView
                                     {
                                         Season = x.Season,
                                         Round = x.Round,
                                         Date = DateTime.Parse(x.Date, new CultureInfo("fr-FR", true)),
                                         HomeTeam = x.HomeTeam,
                                         AwayTeam = x.AwayTeam,
                                         HomeScore = x.HomeScore,
                                         AwayScore = x.AwayScore,
                                         MatchDetails = new MatchDetailsSqlView
                                         {
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
            return matches;
        }
    }
}
