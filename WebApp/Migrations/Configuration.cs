namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;
    using WebApp.Persistence;
    using WebApp.Persistence.Models;
    using WebApp.Persistence.Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var lineDbModel = new LineDbModel() { Name = "Sangaj", Number = 21, LineType = LineType.SUBURBAN };
                var lineDbModel1 = new LineDbModel() { Name = "Kac", Number = 22, LineType = LineType.SUBURBAN };
                var lineDbModel2 = new LineDbModel() { Name = "Budisava", Number = 23, LineType = LineType.SUBURBAN };
                var lineDbModel3 = new LineDbModel() { Name = "Kovilj", Number = 24, LineType = LineType.SUBURBAN };
                var lineDbModel4 = new LineDbModel() { Name = "LIMAN-STRAND", Number = 1, LineType = LineType.URBAN };
                var lineDbModel5 = new LineDbModel() { Name = "NASELJE-LIMAN", Number = 7, LineType = LineType.URBAN };
                var lineDbModel6 = new LineDbModel() { Name = "NASELJE-STRAND", Number = 8, LineType = LineType.URBAN };
                var lineDbModel7 = new LineDbModel() { Name = "CENTAR-TELEP", Number = 12, LineType = LineType.URBAN };
                var stationDbModel = new StationDbModel() { Address = "ZeleznickaAdresa", Name = "Zeleznicka", X = 100.100, Y = 5.5 };
                var stationDbModel1 = new StationDbModel() { Address = "KisackaAdresa", Name = "Kisacka", X = 200.200, Y = 10.10 };
                var stationDbModel2 = new StationDbModel() { Address = "CentarAdresa", Name = "Centar", X = 19.2223949, Y = 15.15 };

                #region StationLineModels
                Repository<StationLineDbModel, int> repository2 = new Repository<StationLineDbModel, int>(dbContext);
                repository2.Add(new StationLineDbModel() { Line = lineDbModel, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel1, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel1, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel2, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel2, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel2, Station = stationDbModel2 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel3, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel3, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel4, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel4, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel5, Station = stationDbModel2 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel6, Station = stationDbModel });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel6, Station = stationDbModel1 });
                dbContext.SaveChanges(); repository2.Add(new StationLineDbModel() { Line = lineDbModel7, Station = stationDbModel2 });
                dbContext.SaveChanges();
                #endregion

                #region Departures
                #region workdays
                Repository<DepartureDbModel, int> repository = new Repository<DepartureDbModel, int>(dbContext);
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion

                #region saturdays
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion

                #region sundays
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Direction = Direction.A, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DepartureDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Direction = Direction.B, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion
                #endregion

                #region Vehicles
                Repository<VehicleDbModel, int> repository3 = new Repository<VehicleDbModel, int>(dbContext);

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 1.1, Y = 1.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 1.2, Y = 1.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 1.3, Y = 1.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 2.1, Y = 2.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 2.2, Y = 2.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 2.3, Y = 2.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 3.1, Y = 3.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 3.2, Y = 3.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 3.3, Y = 3.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 4.1, Y = 4.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 4.2, Y = 4.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 4.3, Y = 4.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 5.1, Y = 5.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 5.2, Y = 5.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 5.3, Y = 5.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 6.1, Y = 6.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 6.2, Y = 6.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 6.3, Y = 6.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 7.1, Y = 7.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 7.2, Y = 7.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 7.3, Y = 7.33 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 8.1, Y = 8.11 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 8.2, Y = 8.22 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 8.3, Y = 8.33 });

                #endregion

                #region Prices
                Repository<PriceDbModel, int> repository4 = new Repository<PriceDbModel, int>(dbContext);
                repository4.Add(new PriceDbModel() { Cost = 50, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Daily });
                repository4.Add(new PriceDbModel() { Cost = 150, PassengerType = PassengerType.Regular, TicketType = TicketType.Daily });
                repository4.Add(new PriceDbModel() { Cost = 100, PassengerType = PassengerType.Student, TicketType = TicketType.Daily });

                repository4.Add(new PriceDbModel() { Cost = 50, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Monthly });
                repository4.Add(new PriceDbModel() { Cost = 150, PassengerType = PassengerType.Regular, TicketType = TicketType.Monthly });
                repository4.Add(new PriceDbModel() { Cost = 100, PassengerType = PassengerType.Student, TicketType = TicketType.Monthly });

                repository4.Add(new PriceDbModel() { Cost = 50, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Yearly });
                repository4.Add(new PriceDbModel() { Cost = 150, PassengerType = PassengerType.Regular, TicketType = TicketType.Yearly });
                repository4.Add(new PriceDbModel() { Cost = 100, PassengerType = PassengerType.Student, TicketType = TicketType.Yearly });

                repository4.Add(new PriceDbModel() { Cost = 50, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Time });
                repository4.Add(new PriceDbModel() { Cost = 150, PassengerType = PassengerType.Regular, TicketType = TicketType.Time });
                repository4.Add(new PriceDbModel() { Cost = 100, PassengerType = PassengerType.Student, TicketType = TicketType.Time });
                #endregion

                dbContext.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            try
            {


                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Admin" };

                    manager.Create(role);
                }

                if (!context.Roles.Any(r => r.Name == "Controller"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Controller" };

                    manager.Create(role);
                }

                if (!context.Roles.Any(r => r.Name == "AppUser"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "AppUser" };

                    manager.Create(role);
                }

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
                {
                    var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                    userManager.Create(user);
                    userManager.AddToRole(user.Id, "Admin");
                }

                if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
                {
                    var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                    userManager.Create(user);
                    userManager.AddToRole(user.Id, "AppUser");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
