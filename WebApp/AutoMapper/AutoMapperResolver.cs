using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Persistence.Models;

namespace WebApp.AutoMapper
{
    public static class AutoMapperResolver
    {
        public static List<Line> ResloveStationLinesToLines(ICollection<StationLineDbModel> stationLines)
        {
            List<Line> retVal = new List<Line>();

            foreach (var stationLineDbModel in stationLines.ToList())
            {
                var line = new Line()
                {
                    Id = stationLineDbModel.Line.Id,
                    Name= stationLineDbModel.Line.Name,
                    Number = stationLineDbModel.Line.Number,
                    Stations = new List<Station>()
                };

                foreach (var stationLineDbModel2 in stationLineDbModel.Line.StationLines)
                {
                    line.Stations.Add(new Station()
                    {
                        Id = stationLineDbModel2.Station.Id,
                        Address = stationLineDbModel2.Station.Address,
                        Name = stationLineDbModel2.Station.Name,
                        X = stationLineDbModel2.Station.X,
                        Y = stationLineDbModel2.Station.Y
                    });
                }

                retVal.Add(line);
            }

            return retVal;
        }

        public static List<Station> ResloveStationLinesToStations(ICollection<StationLineDbModel> stationLines)
        {
            List<Station> retVal = new List<Station>();

            foreach (var stationLineDbModel in stationLines.ToList())
            {
                var line = new Station()
                {
                    Id = stationLineDbModel.Station.Id,
                    Name = stationLineDbModel.Station.Name,
                    Address = stationLineDbModel.Station.Address,
                    X = stationLineDbModel.Station.X,
                    Y = stationLineDbModel.Station.Y,
                    Lines = new List<Line>()
                };

                foreach (var stationLineDbModel2 in stationLineDbModel.Station.StationLines)
                {
                    line.Lines.Add(new Line()
                    {
                        Id = stationLineDbModel2.Line.Id,
                        Number = stationLineDbModel2.Line.Number
                    });
                }

                retVal.Add(line);
            }

            return retVal;
        }

        public static List<string> ResloveDepartureDbModelToDeparture(ICollection<DepartureDbModel> departures)
        {
            List<string> retVal = new List<string>();

            foreach (var departure in departures)
            {
                retVal.Add(departure.Time.ToString("HH:mm"));
            }

            return retVal;
        }
    }
}