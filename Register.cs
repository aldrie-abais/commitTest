public class Register
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    

    public Register(string name, string email, string fatherName, string motherName)
    {
        Name = name;
        Email = email;
        FatherName = fatherName;
        MotherName = motherName;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Register(string name, string email)
    {
        Name = name;
        Email = email;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}