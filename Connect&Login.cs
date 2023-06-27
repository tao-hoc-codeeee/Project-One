using MySql.Data.MySqlClient;
public class Connection
{
    //private string connectionString = "server=localhost;user id=root;password=nhatdo25;port=3306;database=StudentManagement1;";
    public static MySqlConnection GetConnection()
    {
        MySqlConnection myconnection = new MySqlConnection
        {
            ConnectionString = @"server=localhost;user id=root;password=nhatdo25;port=3306;database=StudentManagement1;"
        };
        myconnection.Open();
        return myconnection;
    }
}
// public class LoginCheck
// {
//     private string loginstring = "Completed";
//     public string Login(string ID, string password)
//     {
//         return loginstring;
//     }
// }
public class LoginUI
{
    public int i = -1;
    public string pass ="";
    public string? ID; 
    public void Login()
    {
        Console.WriteLine("\t\t\t\tLogin\t\t\t\t");
        Console.Write("Enter your ID :");
        ID = Console.ReadLine()??"";
        Console.Write("Enter your password :");
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if(key.Key != ConsoleKey.Backspace)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                Console.Write("\b");
            }
        }
        while (key.Key != ConsoleKey.Enter);
    }
}
