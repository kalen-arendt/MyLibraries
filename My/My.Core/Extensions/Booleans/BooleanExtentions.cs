using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace My.Core.Extensions.Booleans
{
	public static class BooleanExtentions
	{
		public static void IfThenElse(this bool condition, Action action1, Action action2)
		{
			if (condition)
			{
				action1 ();
			}
			else
			{
				action2 ();
			}
		}

		public static void IfThenElse<T>(this T obj, bool condition, Action action1, Action action2)
		{
			if (condition)
			{
				action1();
			}
			else
			{
				action2();
			}
		}
	}
}
