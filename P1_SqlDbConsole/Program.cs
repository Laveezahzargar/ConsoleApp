using P1_SqlDbConsole.Services;

namespace P1_SqlDbConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Data Base CRUD Console App");
        Console.WriteLine("Intializing.......");
        Console.WriteLine("Loading Environment Variables .....");

        EnvService envService = new EnvService();
        SqlService sqlService = new SqlService(envService.LoadEnv("CONNECTION_STRING"));

        Console.WriteLine("Option 1 : Create a New User");
        Console.WriteLine("Option 2 : Find an Existing User");
        Console.WriteLine("Option 3 : Update an Existing User");
        Console.WriteLine("Option 4 : Delete an Existing User");

        string Option = Console.ReadLine();

        if (Option == "1")
        {
            Console.WriteLine("To Create A New User!");

            Console.WriteLine("Enter Username");
            string Username = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string Password = Console.ReadLine();

            string EncryptedPass = BCrypt.Net.BCrypt.HashPassword("Password");

            sqlService.CreateUser(Username, Email, EncryptedPass);
        }
        else if (Option == "2")
        {
            Console.WriteLine("To Find An Existing User!");

            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();

            sqlService.FindUser(Email);

        }
        else if (Option == "3")
        {
            Console.WriteLine("To Update An Existing User!");

            Console.WriteLine("Enter Email To Find User");
            string Email = Console.ReadLine();

            Console.WriteLine("Enter New Username");
            string NewUsername = Console.ReadLine();

            Console.WriteLine("Enter New Password");
            string NewPassword = Console.ReadLine();

            string EncryptedNewPass = BCrypt.Net.BCrypt.HashPassword("NewPassword");

            sqlService.UpdateUser(Email , NewUsername , NewPassword);

        }
        else if (Option == "4")
        {
            Console.WriteLine("To Delete An Existing User!");

            Console.WriteLine("Enter Email To Find User");
            string Email = Console.ReadLine();

            sqlService.DeleteUser(Email);

        }
        else
        {
            Console.WriteLine("Kindly Select An Appropriate Option!");
        }
        
    }
}
