using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Applicaton.Helpers
{
    public static class EnumerablePropertyAccessorExtensions
	{
		public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property)
		{
			return enumerable.OrderBy(x => GetProperty(x, property));
		}
		public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> enumerable, string property)
		{
			return enumerable.OrderByDescending(x => GetProperty(x, property));
		}

		private static object GetProperty(object o, string propertyName)
		{
			return o.GetType().GetProperty(propertyName).GetValue(o, null);
		}
	}
}
