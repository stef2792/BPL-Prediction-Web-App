﻿// <auto-generated />
using Groapa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Groapa.Domain.Migrations
{
    [DbContext(typeof(GroapaContext))]
    partial class GroapaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Groapa.Domain.Models.MatchDetailsSqlView", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AwayCorners");

                    b.Property<int?>("AwayOnTarget");

                    b.Property<int?>("AwayReds");

                    b.Property<int?>("AwayShots");

                    b.Property<int?>("AwayYellows");

                    b.Property<decimal?>("B356A");

                    b.Property<decimal?>("B365D");

                    b.Property<decimal?>("B365H");

                    b.Property<decimal?>("BWA");

                    b.Property<decimal?>("BWD");

                    b.Property<decimal?>("BWH");

                    b.Property<int?>("HTAway");

                    b.Property<int?>("HTHome");

                    b.Property<int?>("HomeCorners");

                    b.Property<int?>("HomeOnTarget");

                    b.Property<int?>("HomeReds");

                    b.Property<int?>("HomeShots");

                    b.Property<int?>("HomeYellows");

                    b.Property<string>("Referee");

                    b.HasKey("MatchID");

                    b.ToTable("MatchDetails");
                });

            modelBuilder.Entity("Groapa.Domain.Models.MatchSqlView", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AwayScore");

                    b.Property<string>("AwayTeam");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("HomeScore");

                    b.Property<string>("HomeTeam");

                    b.Property<int?>("MatchDetailsMatchID");

                    b.Property<int?>("Round");

                    b.Property<string>("Season");

                    b.HasKey("MatchID");

                    b.HasIndex("MatchDetailsMatchID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Groapa.Domain.Models.MatchSqlView", b =>
                {
                    b.HasOne("Groapa.Domain.Models.MatchDetailsSqlView", "MatchDetails")
                        .WithMany()
                        .HasForeignKey("MatchDetailsMatchID");
                });
#pragma warning restore 612, 618
        }
    }
}
