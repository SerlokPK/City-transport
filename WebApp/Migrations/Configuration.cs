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
                var lineDbModel = new LineDbModel() { Name = "Sangaj-Z. Stanica", Number = 21, LineType = LineType.SUBURBAN };
                var lineDbModel1 = new LineDbModel() { Name = "Kac-Z. Stanica", Number = 22, LineType = LineType.SUBURBAN };
                var lineDbModel2 = new LineDbModel() { Name = "Budisava-Z. Stanica", Number = 23, LineType = LineType.SUBURBAN };
                var lineDbModel3 = new LineDbModel() { Name = "Kovilj-Z. Stanica", Number = 24, LineType = LineType.SUBURBAN };
                var lineDbModel4 = new LineDbModel() { Name = "LIMAN-STRAND", Number = 1, LineType = LineType.URBAN };
                var lineDbModel5 = new LineDbModel() { Name = "NASELJE-LIMAN", Number = 7, LineType = LineType.URBAN };
                var lineDbModel6 = new LineDbModel() { Name = "NASELJE-STRAND", Number = 8, LineType = LineType.URBAN };
                var lineDbModel7 = new LineDbModel() { Name = "CENTAR-TELEP", Number = 12, LineType = LineType.URBAN };
                var stationDbModel = new StationDbModel() { Address = "ZeleznickaAdresa", Name = "Zeleznicka", X = 45.264748, Y = 19.829873 };
                var stationDbModel1 = new StationDbModel() { Address = "KisackaAdresa", Name = "Kisacka", X = 45.260885, Y = 19.841863 };
                var stationDbModel2 = new StationDbModel() { Address = "CentarAdresa", Name = "Centar", X = 45.254836, Y = 19.841820 };

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

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 45.264117, Y = 19.830434 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 45.264630, Y = 19.831539 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel, X = 45.265415, Y = 19.833524 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 45.263871, Y = 19.830477 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 45.263109, Y = 19.830885 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel1, X = 45.261560, Y = 19.831726 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 45.260812, Y = 19.832659 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 45.261824, Y = 19.836285 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel2, X = 45.262349, Y = 19.838211 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 45.262300, Y = 19.840244 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 45.261284, Y = 19.841639 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel3, X = 45.260468, Y = 19.842867 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 45.259369, Y = 19.842545 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 45.257480, Y = 19.841771 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel4, X = 45.256001, Y = 19.841639 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 45.254120, Y = 19.842245 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 45.252893, Y = 19.839343 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel5, X = 45.251911, Y = 19.837144 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 45.250752, Y = 19.834832 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 45.249200, Y = 19.829249 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel6, X = 45.249194, Y = 19.825223 });

                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 45.258107, Y = 19.818746 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 45.257405, Y = 19.816645 });
                dbContext.SaveChanges(); repository3.Add(new VehicleDbModel() { LineDbModel = lineDbModel7, X = 45.256476, Y = 19.813888 });

                #endregion

                #region Prices
                Repository<PriceDbModel, int> repository4 = new Repository<PriceDbModel, int>(dbContext);
                repository4.Add(new PriceDbModel() { Cost = 51, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Daily });
                repository4.Add(new PriceDbModel() { Cost = 151, PassengerType = PassengerType.Regular, TicketType = TicketType.Daily });
                repository4.Add(new PriceDbModel() { Cost = 101, PassengerType = PassengerType.Student, TicketType = TicketType.Daily });

                repository4.Add(new PriceDbModel() { Cost = 52, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Monthly });
                repository4.Add(new PriceDbModel() { Cost = 152, PassengerType = PassengerType.Regular, TicketType = TicketType.Monthly });
                repository4.Add(new PriceDbModel() { Cost = 102, PassengerType = PassengerType.Student, TicketType = TicketType.Monthly });

                repository4.Add(new PriceDbModel() { Cost = 53, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Yearly });
                repository4.Add(new PriceDbModel() { Cost = 153, PassengerType = PassengerType.Regular, TicketType = TicketType.Yearly });
                repository4.Add(new PriceDbModel() { Cost = 103, PassengerType = PassengerType.Student, TicketType = TicketType.Yearly });

                repository4.Add(new PriceDbModel() { Cost = 54, PassengerType = PassengerType.Pensioner, TicketType = TicketType.Time });
                repository4.Add(new PriceDbModel() { Cost = 154, PassengerType = PassengerType.Regular, TicketType = TicketType.Time });
                repository4.Add(new PriceDbModel() { Cost = 104, PassengerType = PassengerType.Student, TicketType = TicketType.Time });
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
