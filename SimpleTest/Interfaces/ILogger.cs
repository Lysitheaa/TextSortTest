namespace SimpleTest.Interfaces
{
	internal interface ILogger
	{
		void Log(string stuff);

		void StartLogging(string startMessage = "Start logging.");

		void EndLogging(string startMessage = "End logging.");
	}
}
