using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

public class CRUDQueries{

  // Create an instance of the connectionSql class
    private connectionSql conn = new connectionSql();

    public void Read(){
        
        try{        
                // Create a MySqlConnection instance by calling the connectSql() method from the conn object
                using MySqlConnection connection = conn.connectSql();

                //Open the connection from your server to the database
                connection.Open();

                Console.WriteLine("Connecting to database...");

                //create a query 
                string query = "SELECT * FROM users";

                // Create a MySqlCommand to execute the SQL query using the database connection
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                // Execute the query and retrieve the results using MySqlDataReader
                using MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Executing query...");


                if (!reader.HasRows){
                    Console.WriteLine("No data found!");
                    return;
                }

                while (reader.Read()){
                    Console.WriteLine($"ID: {reader["pkUserID"]}, User: {reader["username"]}");
                }
            }
        catch (Exception ex){
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    public void Insert(Register reg){
         try{        
                // Create a MySqlConnection instance by calling the connectSql() method from the conn object
                using MySqlConnection connection = conn.connectSql();

                //Open the connection from your server to the database
                connection.Open();

                Console.WriteLine("Connecting to database...");

                //create a query 
                string query = "INSERT INTO users(username,password,email) VALUES (@username,@password,@email)";

                // Create a MySqlCommand to execute the SQL query using the database connection
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@username", reg.Username);
                cmd.Parameters.AddWithValue("@password", reg.Password);
                cmd.Parameters.AddWithValue("@email", reg.Email);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                Console.WriteLine(rowsAffected > 0 ?"✅ User inserted successfully!":"⚠️ No rows inserted.");

            }
        catch (Exception ex){
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    public bool Update(string username, string newUsername, string newEmail)
{
    try
    {
        using MySqlConnection connection = conn.connectSql();
        connection.Open();

        // Fetch user ID using the getUserId function
        int userId = getUserId(username);
        if (userId == -1)
        {
            MessageBox.Show("⚠️ User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        //{username = @newUsername,email = @newEmail}

        // Build update query dynamically
        string updateQuery = "UPDATE users SET ";
        List<string> fields = new List<string>();

        if (!string.IsNullOrWhiteSpace(newUsername))
        {
            fields.Add("username = @newUsername");
        }
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            fields.Add("email = @newEmail");
        }

        if (fields.Count == 0) // No fields to update
        {
            MessageBox.Show("⚠️ No data provided for update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        updateQuery += string.Join(", ", fields) + " WHERE pkUserID = @id";

        using MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
        updateCmd.Parameters.AddWithValue("@id", userId);
        
        if (!string.IsNullOrWhiteSpace(newUsername))
        {
            updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
        }
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            updateCmd.Parameters.AddWithValue("@newEmail", newEmail);
        }

        int rowsAffected = updateCmd.ExecuteNonQuery();
        return rowsAffected > 0;
    }
    catch (Exception ex)
    {
        MessageBox.Show("❌ Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}

public bool Delete(string username)
{
    try
    {
        using MySqlConnection connection = conn.connectSql();
        connection.Open();

        // Fetch user ID using getUserId function
        int userId = getUserId(username);
        if (userId == -1)
        {
            MessageBox.Show("⚠️ User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Confirm deletion with the user
        DialogResult confirmDelete = MessageBox.Show($"Are you sure you want to delete user '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirmDelete != DialogResult.Yes)
        {
            return false;
        }

        // Delete the user
        string deleteQuery = "DELETE FROM users WHERE pkUserID = @id";
        using MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
        deleteCmd.Parameters.AddWithValue("@id", userId);

        int rowsAffected = deleteCmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            MessageBox.Show("✅ User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        else
        {
            MessageBox.Show("⚠️ Deletion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("❌ Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}


public int getUserId(string username)
{
    try
    {
        using MySqlConnection connection = conn.connectSql();
        connection.Open();

        Console.WriteLine("Connecting to database...");

        string query = "SELECT pkUserID FROM users WHERE username = @username";
        using MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@username", username);

        object result = cmd.ExecuteScalar();
        if (result == null)
        {
            Console.WriteLine("No data found!");
            return -1;
        }

        return Convert.ToInt32(result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        return -1;
    }
}



}