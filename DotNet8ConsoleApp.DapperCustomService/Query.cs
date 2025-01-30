using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8ConsoleApp.DapperCustomService
{
	public class Query
	{
		public static string GetAllBlogsQuery { get; } =
		@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] ORDER BY BlogId DESC";

		public static string CreateBlogQuery { get; } =
		"INSERT INTO dbo.Tbl_Blog (BlogTitle, BlogAuthor, BlogContent, DeleteFlag)" +
			" VALUES (@BlogTitle, @BlogAuthor, @BlogContent, @DeleteFlag);";

		public static string UpdateBlogQuery { get; } =
		@"UPDATE dbo.Tbl_Blog 
	  SET BlogTitle = @BlogTitle, 
	      BlogAuthor = @BlogAuthor, 
	      BlogContent = @BlogContent 
	  WHERE BlogId = @BlogId";

		public static string DeleteBlogQuery { get; } =
		@"UPDATE dbo.Tbl_Blog 
		  SET DeleteFlag = 1 
		  WHERE BlogId = @BlogId";

	}
}
