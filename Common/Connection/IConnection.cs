using System.Data.Common;

namespace Common.Connection
{
    public interface IConnection
    {
        DbConnection OpenNewConnection();
    }
}
