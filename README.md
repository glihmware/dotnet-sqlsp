# SqlSp: netstandard2.0

Wrapper to handle stored procedure using Sql/Mysql connectors. (Only async at this time)

The connectors that are used in the current projet are:

1. MySqlConnector (https://github.com/mysql-net/MySqlConnector)
   `> dotnet add package MySqlConnector`

2. SqlConnector (to be defined, it will be MSFT's one)


Basic examples:

```C#
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using MySqlConnector;

using Glihmware.SqlSp;


namespace Example
{
  class Program
  {
    static async Task Main(string[] args)
    {

      try
      {
        using (
          MySqlConnection conn =
          Conn.FromString("Server=<server>;User ID=<user>;Password=<pass>;Database=<db>")
        )
        {
          using (MySqlCommand cmd = Sp.NewSpCmd("sp_noarg", conn))
          {
            DataTable res = await Sp.CallReader(cmd);
          }

          using (MySqlCommand cmd = Sp.NewSpCmd("sp_witharg", conn))
          {
            cmd.Parameters.Add(new MySqlParameter("arg", MySqlDbType.Int32) { Value = 123 });
            // If the connection is already open, `CallReader` will not throw.
            DataTable res = await Sp.CallReader(cmd);
          }
        }
      }
      catch (MySqlException e)
      {
        // MySqlException (i.g. the sp doesn't exist)
        // ArgumentException (i.g. the sp argument name is not one of the sp arguments)
      }

    }
  }
}

```