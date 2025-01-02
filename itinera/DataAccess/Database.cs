using MySql.Data.MySqlClient;

namespace ItinerariApp.DataAccess
{
    public static class Database
    {
        private static readonly string ConnectionString =
            "Server=localhost;Database=itinera;Uid=root;Pwd=;";

        // Ottieni una nuova connessione al database
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
