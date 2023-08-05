using MySql.Data.MySqlClient;
public class UpdateInfo
{
    public void UpdateallUImain()
    {
        
        Console.WriteLine("Enter UID :");
        string UID = Console.ReadLine()??"";
        while(checkUID(UID)== false)
        {
            Console.WriteLine("Wrong UID");
            break;
        }
            UpdateUI1();
        
        
    }
    public bool checkUID(string UID)
    {
        MySqlConnection connection = Connection.GetConnection();
        connection.Open();
        string query = $"SELECT COUNT(*) FROM students WHERE student_no = @UID";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UID", UID);
            int a = Convert.ToInt32(command.ExecuteScalar());
            return a > 0;
    }
    public void UpdateUI1()
    {
        while(true)
        {
            Console.WriteLine("1. Change name");
            Console.WriteLine("2. Change address");
            Console.WriteLine("3. Change phone number");
            Console.WriteLine("4. Change email");
            Console.WriteLine("Choice:");
            int a = Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1 : break;
                case 2 : break;
            }
        }
    }
    public void Updateall()
    {
        Console.WriteLine("Enter name:");
        Console.WriteLine("Enter emailaddress:");
        Console.WriteLine("Enter address:");
        Console.WriteLine("Enter phone number:");
        Console.WriteLine("Complete!");
    }

}