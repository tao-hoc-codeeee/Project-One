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
        string password = ReadPassword();
    }

    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Nếu phím không phải là Enter, xử lý xóa ký tự
            if (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Xóa ký tự cuối cùng trong mật khẩu và di chuyển con trỏ về trước
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Delete)
                {
                    // Thêm ký tự vào mật khẩu và hiển thị dấu *
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Xuống dòng sau khi người dùng nhấn Enter
        return password;
    }
}
