using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using MySqlConnector;


namespace Glihmware.SqlSp
{

  public class ConnInfo
  {
    public string serverName;
    public string user;
    public string password;
    public string dbName;
  }


  /// <summary>
  ///   Wrappers to obtain a `MySqlConnection`.
  /// </summary>
  public static class Conn
  {

    /// <summary>
    ///   Returns a connection from the given string.
    /// </summary>
    public static MySqlConnection FromString(string connStr)
    {
      return new MySqlConnection(connStr);
    }

    /// <summary>
    ///   Returns a connection from the connection string
    ///   stored in an environment variable.
    /// </summary>
    public static MySqlConnection FromEnv(string variableName)
    {
      throw new NotImplementedException();
    }


  }

}
