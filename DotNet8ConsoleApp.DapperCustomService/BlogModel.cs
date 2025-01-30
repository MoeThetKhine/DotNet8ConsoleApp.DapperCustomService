﻿namespace DotNet8ConsoleApp.DapperCustomService;

#region Blog Model

public class BlogModel
{
	public long BlogId { get; set; }
	public string? BlogTitle { get; set; }
	public string? BlogAuthor { get; set; }
	public string? BlogContent { get; set; }
	public bool DeleteFlag { get; set; }
}

#endregion
