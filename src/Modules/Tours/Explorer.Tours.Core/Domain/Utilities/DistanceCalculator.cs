using Explorer.Tours.Core.Domain.TourExecutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Utilities
{
    internal class DistanceCalculator
    {
        private const double EarthRadiusInKm = 6371.0;
        public static double CalculateDistance(PointTask currentPoint, Position currentPosition)
        {
            double currentPositionLatInRad = currentPosition.Latitude * Math.PI / 180;
            double currentPointLatInRad = currentPoint.Point.Latitude * Math.PI / 180;

            double deltaLatInRad = (currentPoint.Point.Latitude - currentPosition.Latitude) * Math.PI / 180;
            double deltaLongInRad = (currentPoint.Point.Longitude - currentPosition.Longitude) * Math.PI / 180;

            double a = Math.Pow(Math.Sin(deltaLatInRad / 2), 2) +
                       Math.Cos(currentPointLatInRad) * Math.Cos(currentPositionLatInRad) *
                       Math.Pow(Math.Cos(deltaLongInRad / 2), 2);

            return EarthRadiusInKm * Math.Asin(Math.Sqrt(a));
        }
    }
}
