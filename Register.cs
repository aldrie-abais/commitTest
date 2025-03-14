public class Register
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }

    public Register(string username, string password, string confirmPassword, string email)
    {
        Username = username;
        Password = password;
        ConfirmPassword = confirmPassword;
        Email = email;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Register(string username,string password, string email){
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}