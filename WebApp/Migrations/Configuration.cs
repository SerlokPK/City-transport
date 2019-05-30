namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
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
                var stationDbModel1 = new StationDbModel() { Address = "ZeleznickaAdresa", Name = "Kisacka", X = 200.200, Y = 10.10 };
                var stationDbModel2 = new StationDbModel() { Address = "ZeleznickaAdresa", Name = "Centar", X = 300.300, Y = 15.15 };

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
                Repository<DeparturesDbModel, int> repository = new Repository<DeparturesDbModel, int>(dbContext);
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.WORKDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion

                #region saturdays
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SATURDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion

                #region sundays
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel1, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel2, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel3, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel4, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel5, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 10, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 11, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 12, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 13, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel6, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });

                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                dbContext.SaveChanges(); repository.Add(new DeparturesDbModel() { LineDbModel = lineDbModel7, DayType = DayType.SUNDAY, Time = new DateTime(2019, 1, 1, 14, 10, 10) });
                #endregion
                #endregion

                dbContext.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            try
            {
                /*
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
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
