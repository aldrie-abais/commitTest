
using DotNetEnv;
using MySql.Data.MySqlClient;
public class connectionSql {

    private string connectionString;
    private MySqlConnection conn;

    public MySqlConnection connectSql()
{
    try
    {
        Env.Load();
        Console.WriteLine("Loading .env files");

        string server = Env.GetString("MYSQL_SERVER");
        string port = Env.GetString("MYSQL_PORT");
        string db = Env.GetString("MYSQL_DATABASE");
        string user = Env.GetString("MYSQL_USER");
        string pass = Env.GetString("MYSQL_PASSWORD");

        connectionString = $"server={server};database={db};uid={user};pwd={pass};";
        // connectionString = $"server=localhost;database=winforms;uid=root;pwd=root;";

        conn = new MySqlConnection(connectionString);

        //Check if connection to database is succesful
        Console.WriteLine(conn == null ? "❌ Database connection failed!" : "✅ Database Connection successful");

        return conn;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error connecting to database: " + ex.Message);
        return null;
    }
}

   
}