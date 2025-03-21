
using DotNetEnv;
using MySql.Data.MySqlClient;
public class connectionSql {

    private string connectionString, connectionString2;
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

            //connectionString2 = $"server={server};database={db};uid={user};pwd={pass};";
        connectionString = $"server=localhost;database=draftdb;uid=root;pwd=root;";

            //MessageBox.Show(connectionString2 + "\n" + connectionString);

            conn = new MySqlConnection(connectionString);
            //conn.Open();
            Console.WriteLine("✅ Connection Successful!");
            
        return conn;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error connecting to database: " + ex.Message);
            Console.WriteLine("Error connecting to database: " + ex.Message);
            return null;
        }
    }

   
}