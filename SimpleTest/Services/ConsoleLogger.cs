using SimpleTest.Interfaces;

namespace SimpleTest.Services
{
	internal class ConsoleLogger : ILogger
	{
		public void Log(string stuff)
		{
			Console.WriteLine(stuff);
		}

		public void StartLogging(string startMessage = "Start logging.")
		{
			Log(startMessage);
		}

		public void EndLogging(string startMessage = "End logging.")
		{
			Log(startMessage);
		}
	}
}
