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

		public async Task<List<T>> QueryAsync<T>(string query, object? parameters = null)
		{
			using var db = CreateConnection();
			var result = await db.QueryAsync<T>(query, parameters);
			return result.ToList();
		}

		public T? QueryFirstOrDefault<T>(string query, object? parameters = null)
		{
			using var db = CreateConnection();
			return db.QueryFirstOrDefault<T>(query, parameters);
		}

		public async Task<T?> QueryFirstOrDefaultAsync<T>(string query, object? parameters = null)
		{
			using var db = CreateConnection();
			return await db.QueryFirstOrDefaultAsync<T>(query, parameters);
		}
	}
}
