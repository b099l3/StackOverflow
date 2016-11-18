using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace NodaTimeTest
{
	public class NodaTimeHelper
	{
		public static IEnumerable<LocalDateTime> GetDaylightSavingTransitions(DateTimeZone timeZone, int year)
		{
			var yearStart = new LocalDateTime(year, 1, 1, 0, 0).InZoneLeniently(timeZone).ToInstant();
			var yearEnd = new LocalDateTime(year + 1, 1, 1, 0, 0).InZoneLeniently(timeZone).ToInstant();
			var intervals = timeZone.GetZoneIntervals(yearStart, yearEnd);

			return intervals.Select(x => x.IsoLocalEnd).Where(x => x.Year == year);
		}

		public static List<DateTimeZone> GetDateTimeZones()
		{
			var provider = DateTimeZoneProviders.Tzdb;
			var list = new List<DateTimeZone>();
			foreach (var id in provider.Ids)
			{
				var zone = provider[id];
				list.Add(zone);
			}
			return list;
		}
	}
}
