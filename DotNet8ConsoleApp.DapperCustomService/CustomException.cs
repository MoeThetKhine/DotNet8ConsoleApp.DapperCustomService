namespace DotNet8ConsoleApp.DapperCustomService;

public class CustomException : Exception
{
	public CustomException(string? message) : base(message) { }
}
