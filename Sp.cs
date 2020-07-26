using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using MySqlConnector;


namespace Glihmware.SqlSp
{

  /// <summary>
  ///   Wrapper to call a stored procedure through `MySqlCommand`.
  /// </summary>
  public static class Sp
  {

    /// <summary>
    ///   Allocates a new command associated to a store procedure.
    /// </summary>
    public static MySqlCommand NewSpCmd(string spName, MySqlConnection conn)
    {
      MySqlCommand cmd = new MySqlCommand(spName, conn);
      cmd. CommandType = CommandType.StoredProcedure;
      return cmd;
    }

    /// <summary>
    ///   Executes a command linked to a stored procedure that may return row(s).
    /// </summary>
    public async static Task<DataTable>
    CallReader(MySqlCommand cmd)
    {
      if (cmd.Connection.State == ConnectionState.Closed)
      {
        await cmd.Connection.OpenAsync();
      }

      DataTable dt = new DataTable();
      dt.Load(await cmd.ExecuteReaderAsync());

      await cmd.Connection.CloseAsync();

      return dt;
    }
  }

}
