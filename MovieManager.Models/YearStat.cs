using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Models
{
    public class YearStat
    {
        public YearStat(int year, int count, double averageRate)
        {
            Year = year;
            Count = count;
            AverageRate = averageRate;
        }

        public int Year { get; }
        public int Count { get; }
        public double AverageRate { get; }

        public override bool Equals(object? obj)
        {
            return this.GetHashCode() == obj?.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Count, AverageRate);
        }
    }
}
