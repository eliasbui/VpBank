using System.Data;
using Common.Settings;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Context;

/// <summary>
///     DataContext
/// </summary>
public class DataContext
{
    #region Methods Public

    /// <summary>
    ///   Create the connection to the database.
    /// </summary>
    /// <returns>connection string </returns>
    public IDbConnection CreateConnection()
    {
        var connectionString =
            $"Host={_dbSettings.Server};Port = {_dbSettings.Port}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }

    #endregion

    #region Private Variables

    private readonly DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    #endregion
}