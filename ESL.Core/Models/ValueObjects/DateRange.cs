using ESL.Core.Models.BusinessEntities.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ValueObjects
{
    public abstract class DateRange : ValueObject
    {
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }

        public DateRange(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date must be earlier than end date.");
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsWithinRange(DateOnly date)
        {
            return date >= StartDate && date <= EndDate;
        }

        public bool Contains(DateOnly date)
        {
            return date >= StartDate && date <= EndDate;
        }

        public bool Overlaps(DateRange other)
        {
            return StartDate < other.EndDate && EndDate > other.StartDate;
        }

        public override string ToString()
        {
            return $"[{StartDate:yyyy-MM-dd} - {EndDate:yyyy-MM-dd}]";
        }

        public TimeSpan GetDuration()
        {
            return EndDate.ToDateTime(TimeOnly.MinValue) - StartDate.ToDateTime(TimeOnly.MinValue);
        }
    }

}
