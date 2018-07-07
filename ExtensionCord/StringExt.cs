/*
# Extensions to Strings

The functionality of strings is fairly comprehensive in the .NET framework.
There are some additions we can still come up with.
*/
namespace ExtensionCord
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public static class StringExt
	{
		/*
		## Repeat a String _n_ Times

		The following method duplicates a string as many times as specified
		by the parameter.
		*/
		public static string Times (this string what, int times)
		{
			var sb = new StringBuilder ();

			for (int i = 0; i < times; i++)
				sb.Append (what);

			return sb.ToString ();
		}
		/*
		## IEnumerable<char> to String

		For some reason there is no ready, efficient way of converting
		an enumerable of chars into string. We provide that functionality
		with the `CharsToString` method.
		*/
        public static string CharsToString (this IEnumerable<char> chars)
        {
            var sb = new StringBuilder ();
            foreach (var ch in chars)
                sb.Append (ch);
            return sb.ToString ();
        }
		/*
		## Trimming Strings

		`System.String` class provides methods to trim characters from the 
		beginning or from the end of strings. They do not allow, however, for a
		way to specify the maximum number of characters removed. Let's fix that
		by providing our own versions. 
		*/
		public static string TrimStart (this string str, int maxChars, 
			params char[] trimChars)
		{
			trimChars = UseDefaultsIfNotSpecified (trimChars);
			var cnt = Math.Min (str.Length, maxChars);
			var i = 0;
			while (i < cnt && str[i].In (trimChars))
				i++;
			return i == 0 ? str :
				str.Remove (0, i);
		}

		public static string TrimEnd (this string str, int maxChars,
			params char[] trimChars)
		{
			trimChars = UseDefaultsIfNotSpecified (trimChars);
			var len = str.Length;
			var last = Math.Max (len - maxChars, 0);
			var i = len;
			while (i > last && str[i - 1].In (trimChars))
				i--;
			return i == len ? str :
				str.Remove (i, len - i);
		}

		public static string Trim (this string str, int maxChars,
			params char[] trimChars) =>
			str.TrimStart (maxChars, trimChars).TrimEnd (maxChars, trimChars);

		private static char[] UseDefaultsIfNotSpecified (char[] trimChars)
		{
			if (trimChars == null || trimChars.Length == 0)
				trimChars = new char[] { ' ', '\t', '\n', '\r' };
			return trimChars;
		}
	}
}
