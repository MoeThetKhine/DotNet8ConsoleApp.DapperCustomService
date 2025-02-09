﻿namespace DotNet8ConsoleApp.DapperCustomService;

public class Program
{
	private static readonly string _connectionString = "Data Source=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

	private static readonly DapperService _dapperService = new(_connectionString);

	#region Main

	public static async Task Main()
	{
		await Read();
		//await Create("Sample Title", "Sample Author", "Sample Content", false);
		//await Update(1, "Updated Title", "Updated Author", "Updated Content");
		//await Delete(1);
	}

	#endregion

	#region Read

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

	#endregion

	#region Create

	public static async Task Create(string title, string author, string content, bool deleteFlag)
	{
		try
		{
			var parameters = new 
			{
				BlogTitle = title, 
				BlogAuthor = author, 
				BlogContent = content, 
				DeleteFlag = deleteFlag 
			};

			int result = await _dapperService.ExecuteAsync(Query.CreateBlogQuery, parameters);

			Console.WriteLine(result > 0 ? "Insert Successful" : "Insert Failed");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error creating blog: {ex.Message}");
		}
	}

	#endregion

	#region Update

	public static async Task Update(long id, string title, string author, string content)
	{
		try
		{
			var parameters = new 
			{ 
				BlogId = id, 
				BlogTitle = title, 
				BlogAuthor = author, 
				BlogContent = content
			};
			int result = await _dapperService.ExecuteAsync(Query.UpdateBlogQuery, parameters);

			Console.WriteLine(result > 0 ? "Update Successful" : "Update Failed");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error updating blog: {ex.Message}");
		}
	}

	#endregion

	#region Delete

	public static async Task Delete(int id)
	{
		try
		{
			var parameters = new { BlogId = id };
			int result = await _dapperService.ExecuteAsync(Query.DeleteBlogQuery, parameters);

			Console.WriteLine(result > 0 ? "Delete Successful" : "Delete Failed");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error deleting blog: {ex.Message}");
		}
	}

	#endregion

}