using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DotNet8ConsoleApp.DapperCustomService
{
	public class DapperService
	{
		private readonly string _connectionString;

		public DapperService(string connectionString)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
		}
		private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

		public List<T> Query<T>(string query, object? parameters = null)
		{
			using var db = CreateConnection();
			return db.Query<T>(query, parameters).ToList();
		}
	}
}
