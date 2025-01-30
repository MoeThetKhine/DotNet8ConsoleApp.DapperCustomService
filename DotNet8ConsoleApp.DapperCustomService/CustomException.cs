namespace DotNet8ConsoleApp.DapperCustomService;

#region CustomException

public class CustomException : Exception
{
	public CustomException(string? message) : base(message) { }
}

#endregion