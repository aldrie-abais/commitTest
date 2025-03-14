namespace TestingPlace;
using DotNetEnv;
using MySql.Data.MySqlClient;

public partial class Form1 : Form
{   
      CRUDQueries crud = new CRUDQueries();
         
    public Form1()
    {
       
         
         InitializeComponent();
         crud.Read();
        
    }

    private void btnRegister_Click(object sender, EventArgs e)
{
    
    string username = txtUsername.Text;
    string password = txtPassword.Text;
    string confirmPassword = txtConfirmPassword.Text;
    string email = txtEmail.Text;

    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
        string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email))
    {
        MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    if (password != confirmPassword)
    {
        MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Create a Register object
    Register newUser = new Register(username, password, confirmPassword, email);
    Register sqlUser = new Register(username,password,email);
    
    crud.Insert(sqlUser);

    // Display success message
    MessageBox.Show($"Registration Successful!\nUsername: {newUser.Username}\nEmail: {newUser.Email}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
}

   private void btnUpdate_Click(object sender, EventArgs e)
{
    string username = txtUsername.Text.Trim();
    string newEmail = txtEmail.Text.Trim();
    string newUsername = txtNewUsername.Text.Trim();

    // Ensure at least one field is provided for an update
    if (string.IsNullOrWhiteSpace(username))
    {
        MessageBox.Show("⚠️ Please enter the current username!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    if (string.IsNullOrWhiteSpace(newUsername) && string.IsNullOrWhiteSpace(newEmail))
    {
        MessageBox.Show("⚠️ Enter new details to update!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Call the UpdateUser method
    bool success = crud.Update(username, newUsername, newEmail);

    if (success)
    {
        MessageBox.Show("✅ User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
        MessageBox.Show("⚠️ Update failed or no changes made.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}   

private void btnDelete_Click(object sender, EventArgs e)
{
    string username = txtUsername.Text.Trim(); // Assuming you have a TextBox named txtUsername

    if (string.IsNullOrWhiteSpace(username))
    {
        MessageBox.Show("⚠️ Please enter a username to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    bool isDeleted = crud.Delete(username);
    if (isDeleted)
    {
        txtUsername.Clear(); // Clear the textbox after successful deletion
    }
}

      private void ShowMessage(object sender, EventArgs e)
    {
        MessageBox.Show("Button was clicked!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}