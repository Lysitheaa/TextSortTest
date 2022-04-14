using SimpleTest.Interfaces;
using SimpleTest.Services;
using System.Text.RegularExpressions;

namespace SimpleTest
{
	public static partial class MyTest
	{
		private const char splitChar = ' ';
		private static readonly Regex prohibitedCharsRegEx = new(@"[\.,;']");
		private static readonly ILogger consoleLogger = new ConsoleLogger();

		public static string TextFormatter(string originalText)
		{
			OriginalValueValidation(originalText);

			consoleLogger.StartLogging();

			string formattedValue = PerformFormatting(originalText);

			consoleLogger.EndLogging();

			return formattedValue;
		}

		private static void OriginalValueValidation(string originalText)
		{
			if (originalText == null)
			{
				throw new NullReferenceException("Received value is null");
			}
		}

		private static string PerformFormatting(string originalText)
		{
			IEnumerable<string> words = originalText
				.Split(splitChar)
				.RemoveChars(prohibitedCharsRegEx)
				.OrderText();

			string formattedValue = string.Join(splitChar, words);

			return formattedValue;
		}

		private static IEnumerable<string> OrderText(
			this IEnumerable<string> words) =>
			words
				.OrderBy(s => s.ToLower())
				.ThenBy(s => IndexOfFirstUpperCase(s))
				.ToList();

		private static int? IndexOfFirstUpperCase(string value) =>
			value
				.Select((c, i) => Tuple.Create(c, i))
				.Where(x => char.IsUpper(x.Item1))
				.Min<Tuple<char, int>, int?>(x => x.Item2)
				??
				int.MaxValue;

		private static IEnumerable<string> RemoveChars(
			this IEnumerable<string> words,
			Regex rmovingRegex) =>
			words.Select(s => rmovingRegex.Replace(s, string.Empty));
	}
}
