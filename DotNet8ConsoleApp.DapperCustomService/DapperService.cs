namespace DotNet8ConsoleApp.DapperCustomService;

public class DapperService
{
	private readonly string _connectionString;

	public DapperService(string connectionString)
	{
		_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
	}
	private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

	#region Query

	public List<T> Query<T>(string query, object? parameters = null)
	{
		using var db = CreateConnection();
		return db.Query<T>(query, parameters).ToList();
	}

	#endregion

	#region QueryAsync

	public async Task<List<T>> QueryAsync<T>(string query, object? parameters = null)
	{
		using var db = CreateConnection();
		var result = await db.QueryAsync<T>(query, parameters);
		return result.ToList();
	}

	#endregion

	#region QueryFirstOrDefault

	public T? QueryFirstOrDefault<T>(string query, object? parameters = null)
	{
		using var db = CreateConnection();
		return db.QueryFirstOrDefault<T>(query, parameters);
	}

	#endregion

	#region QueryFirstOrDefaultAsync

	public async Task<T?> QueryFirstOrDefaultAsync<T>(string query, object? parameters = null)
	{
		using var db = CreateConnection();
		return await db.QueryFirstOrDefaultAsync<T>(query, parameters);
	}

	#endregion

	#region Execute

	public int Execute(string sql, object? parameters = null)
	{
		using var db = CreateConnection();
		return db.Execute(sql, parameters);
	}

	#endregion

	#region ExecuteAsync

	public async Task<int> ExecuteAsync(string sql, object? parameters = null)
	{
		using var db = CreateConnection();
		return await db.ExecuteAsync(sql, parameters);
	}

	#endregion

}
