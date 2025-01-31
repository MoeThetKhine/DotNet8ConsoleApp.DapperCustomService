namespace DotNet8ConsoleApp.DapperCustomService;

public class Program
{
	private static readonly string _connectionString = "Data Source=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

	private static readonly DapperService _dapperService = new(_connectionString);
}