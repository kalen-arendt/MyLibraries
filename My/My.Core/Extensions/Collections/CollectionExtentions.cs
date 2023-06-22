using System;
using System.Collections.Generic;

namespace My.Core.Extensions.Collections
{
	public static class CollectionExtentions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
		{
			int i = 0;
			foreach (T item in enumerable)
			{
				action(item, i++);
			}
		}
	}
}
