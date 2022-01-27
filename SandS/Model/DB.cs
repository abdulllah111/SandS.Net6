using MySql.Data.MySqlClient;

namespace SandS.Model
{
    internal class DB
    {
        public static MySqlConnection GetCon { get; private set; }

        public static void Open()
        {
            var connStr = "server=localhost;user=root;database=timetable;password=root;";
            GetCon = new MySqlConnection(connStr);
            GetCon.Open();
        }

        public static void Close()
        {
            GetCon.Close();
        }
    }
}