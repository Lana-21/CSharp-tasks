using System;
using System.Collections.Generic;
using System.Text;

namespace Home10EVENT
{
    public record class DailyTemperature(double MaxTemp, double MinTemp);
    public static class TemperatureExtensions
    {
        public static DailyTemperature GetDayWithMaxDifference(this DailyTemperature[] temperatures)
        {
            if (temperatures == null || temperatures.Length == 0)
                return null;
            DailyTemperature maxDiffDay = temperatures[0];
            double maxDiff = maxDiffDay.MaxTemp - maxDiffDay.MinTemp;
            foreach (var day in temperatures)
            {
                double diff = day.MaxTemp - day.MinTemp;
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                    maxDiffDay = day;
                }
            }
            return maxDiffDay;
        }
    }
}
