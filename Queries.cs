using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using BloodBankManagementSystem;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using ZstdSharp.Unsafe;

namespace BloodBankManagementSystem
{
    public class CRUDQueries
    {

        // Create an instance of the connectionSql class
        private connectionSql conn = new connectionSql();

        public void Read()
        {

            try
            {
                // Create a MySqlConnection instance by calling the connectSql() method from the conn object
                using MySqlConnection connection = conn.connectSql();

                //Open the connection from your server to the database
                connection.Open();
                MessageBox.Show("11");


                Console.WriteLine("Connecting to database...");

                //create a query 
                string query = "SELECT * FROM Donors";

                // Create a MySqlCommand to execute the SQL query using the database connection
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                // Execute the query and retrieve the results using MySqlDataReader
                using MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Executing query...");
                MessageBox.Show("33");


                if (!reader.HasRows)
                {
                    Console.WriteLine("No data found!");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["donorID"]}, User: {reader["name"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //public void displayStock(AddBloodStock addStock)
        //{
        //    try
        //    {
        //        // Create a MySqlConnection instance by calling the connectSql() method from the conn object
        //        using MySqlConnection connection = conn.connectSql();

        //        //Open the connection from your server to the database
        //        connection.Open();
        //        MessageBox.Show("11");


        //        Console.WriteLine("Connecting to database...");

        //        //create a query 
        //        string query = "SELECT * FROM BloodStock";

        //        // Create a MySqlCommand to execute the SQL query using the database connection
        //        using MySqlCommand cmd = new MySqlCommand(query, connection);

        //        // Execute the query and retrieve the results using MySqlDataReader
        //        using MySqlDataReader reader = cmd.ExecuteReader();
        //        Console.WriteLine("Executing query...");
        //        MessageBox.Show("33");


        //        if (!reader.HasRows)
        //        {
        //            Console.WriteLine("No data found!");
        //            return;
        //        }

        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"ID: {reader["donorID"]}, User: {reader["name"]}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        public void NewDonor(Register reg)
        {
            try
            {

                // Create a MySqlConnection instance by calling the connectSql() method from the conn object
                using MySqlConnection connection = conn.connectSql();

                MessageBox.Show("1");

                //Open the connection from your server to the database
                connection.Open();
                MessageBox.Show("2");


                if (connection == null)
                {
                    MessageBox.Show("❌ Connection failed: MySqlConnection is null.");
                    return;
                }

                Console.WriteLine("Connecting to database...");
                MessageBox.Show("3");

                //create a query 
                string query = "INSERT INTO Donors(name,email,fatherName,motherName) VALUES (@name,@email,@fatherName, @motherName)";
                MessageBox.Show("4");

                // Create a MySqlCommand to execute the SQL query using the database connection
                using MySqlCommand cmd = new MySqlCommand(query, connection);
                MessageBox.Show("5");


                cmd.Parameters.AddWithValue("@name", reg.Name);
                cmd.Parameters.AddWithValue("@email", reg.Email);
                cmd.Parameters.AddWithValue("@fatherName", reg.FatherName);
                cmd.Parameters.AddWithValue("@motherName", reg.MotherName);

                MessageBox.Show("6");

                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show("7");

                Console.WriteLine(rowsAffected > 0 ? "✅ User inserted successfully!" : "⚠️ No rows inserted.");
                MessageBox.Show("Rows Affected: " + rowsAffected);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void AddStock(AddBloodStock AStock)
        {
            try
            {
                using MySqlConnection connection = conn.connectSql();

                MessageBox.Show("1");

                //Open the connection from your server to the database
                connection.Open();
                MessageBox.Show("2");


                if (connection == null)
                {
                    MessageBox.Show("❌ Connection failed: MySqlConnection is null.");
                    return;
                }

                //create a query 
                string query = "UPDATE BloodStocks SET bloodQty = @bloodQty WHERE bloodGroup = @bloodGroup";
                MessageBox.Show("4");

                // Create a MySqlCommand to execute the SQL query using the database connection
                using MySqlCommand cmd = new MySqlCommand(query, connection);
                MessageBox.Show("5");


                cmd.Parameters.AddWithValue("@bloodGroup", AStock.BloodGroup);
                cmd.Parameters.AddWithValue("@bloodQty", AStock.BloodQty);

                MessageBox.Show("6");

                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show("7");

                Console.WriteLine(rowsAffected > 0 ? "✅ User inserted successfully!" : "⚠️ No rows inserted.");
                MessageBox.Show("Rows Affected: " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //public bool Update(string username, string newUsername, string newEmail)
        //{
        //    try
        //    {
        //        using MySqlConnection connection = conn.connectSql();
        //        connection.Open();

        //        // Fetch user ID using the getUserId function
        //        int userId = getUserId(username);
        //        if (userId == -1)
        //        {
        //            MessageBox.Show("⚠️ User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //        //{username = @newUsername,email = @newEmail}

        //        // Build update query dynamically
        //        string updateQuery = "UPDATE users SET ";
        //        List<string> fields = new List<string>();

        //        if (!string.IsNullOrWhiteSpace(newUsername))
        //        {
        //            fields.Add("username = @newUsername");
        //        }
        //        if (!string.IsNullOrWhiteSpace(newEmail))
        //        {
        //            fields.Add("email = @newEmail");
        //        }

        //        if (fields.Count == 0) // No fields to update
        //        {
        //            MessageBox.Show("⚠️ No data provided for update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }

        //        updateQuery += string.Join(", ", fields) + " WHERE pkUserID = @id";

        //        using MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
        //        updateCmd.Parameters.AddWithValue("@id", userId);

        //        if (!string.IsNullOrWhiteSpace(newUsername))
        //        {
        //            updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
        //        }
        //        if (!string.IsNullOrWhiteSpace(newEmail))
        //        {
        //            updateCmd.Parameters.AddWithValue("@newEmail", newEmail);
        //        }

        //        int rowsAffected = updateCmd.ExecuteNonQuery();
        //        return rowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("❌ Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        //public bool Delete(string username)
        //{
        //    try
        //    {
        //        using MySqlConnection connection = conn.connectSql();
        //        connection.Open();

        //        // Fetch user ID using getUserId function
        //        int userId = getUserId(username);
        //        if (userId == -1)
        //        {
        //            MessageBox.Show("⚠️ User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }

        //        // Confirm deletion with the user
        //        DialogResult confirmDelete = MessageBox.Show($"Are you sure you want to delete user '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (confirmDelete != DialogResult.Yes)
        //        {
        //            return false;
        //        }

        //        // Delete the user
        //        string deleteQuery = "DELETE FROM users WHERE pkUserID = @id";
        //        using MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
        //        deleteCmd.Parameters.AddWithValue("@id", userId);

        //        int rowsAffected = deleteCmd.ExecuteNonQuery();
        //        if (rowsAffected > 0)
        //        {
        //            MessageBox.Show("✅ User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("⚠️ Deletion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("❌ Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}


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

        public int getBloodStock(string username)
        {
            try
            {
                using MySqlConnection connection = conn.connectSql();
                connection.Open();

                Console.WriteLine("Connecting to database...");

                string query = "SELECT bloodQty FROM BloodStocks WHERE bloodGroup = @username";
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
}