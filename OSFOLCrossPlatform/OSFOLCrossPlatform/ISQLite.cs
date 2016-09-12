using System;
using SQLite;

namespace OSFOLCrossPlatform
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}