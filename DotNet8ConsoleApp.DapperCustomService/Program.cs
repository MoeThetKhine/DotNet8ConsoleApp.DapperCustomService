namespace DotNet8ConsoleApp.DapperCustomService;

public class Program
{
	private static readonly string _connectionString = "Data Source=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

	private static readonly DapperService _dapperService = new(_connectionString);

	public static async Task Main()
	{
		await Read();
		//await Create("Sample Title", "Sample Author", "Sample Content", false);
		//await Update(1, "Updated Title", "Updated Author", "Updated Content");
		//await Delete(1);
	}

	public static async Task Read()
	{
		try
		{
			var lst = await _dapperService.QueryAsync<BlogModel>(Query.GetAllBlogsQuery);

			foreach (var item in lst)
			{
				Console.WriteLine($"Blog Id: {item.BlogId}");
				Console.WriteLine($"Blog Title: {item.BlogTitle}");
				Console.WriteLine($"Blog Author: {item.BlogAuthor}");
				Console.WriteLine($"Blog Content: {item.BlogContent}");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error reading blogs: {ex.Message}");
		}
	}


}