using Delete_Students;


public class MenuLoginActivity
{
    public int j ;
    public void MenuLogin()
    {
        try
        {
            MenuAdministrator menuAdministrator = new MenuAdministrator();
            menuAdministrator.Mainmenu();
        }
        catch
        {
            Console.WriteLine("Sorry!\nSomething went wrong, please try again in a few minutes!" );
        }


    }
}

public class MenuAdministrator
{
    public int j ;
    public Addstudents addstudents = new Addstudents();
    public void Mainmenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("-------------------Student Mananagement-------------------");
            Console.WriteLine("==========================================================");
            Console.WriteLine("1. Update Academic Transcript Of Student.");
            Console.WriteLine("2. Update Data Student.");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("==========================================================");
            Console.Write("Your Choice: ");
            j = Convert.ToInt32(Console.ReadLine() ?? "".TrimEnd(' '));
            switch (j)
            {
                case 1:
                    break;
                case 2:
                    MenuUpdateStudent();
                    break;
                default:
                    Console.WriteLine("Please re-enter"); Console.ReadKey();
                    break;
            }
        } while (j != 0);
    }
    public void MenuUpdateStudent()
    {

        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("----------------------Update Student----------------------");
            Console.WriteLine("==========================================================");
            Console.WriteLine("1 . Delete student.");
            Console.WriteLine("2 . Change information.");
            Console.WriteLine("3 . Add new students.");
            Console.WriteLine("4 . Ban or Reverse.");
            Console.WriteLine("5 . Back.");
            Console.WriteLine("==========================================================");
            Console.Write("Your Choice: ");
            j = Convert.ToInt32(Console.ReadLine() ?? "".TrimEnd(' '));
            switch (j)
            {
                case 1:
                    DeleteStudent deleteStudent = new DeleteStudent();  // Tạo đối tượng từ class DeleteStudent trong namespace Delete_Students
                    deleteStudent.Delete_Student();  // Gọi hàm Delete_Student từ đối tượng deleteStudent
                    break;
                case 3:
                    addstudents.Enterstudentinfo();
                    break;
                default:
                    Console.WriteLine("Please re-enter"); Console.ReadKey();
                    break;
            }
        } while (j != 0);
    }

}