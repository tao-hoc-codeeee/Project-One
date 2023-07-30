using Delete_Students;


public class MenuLoginActivity
{
    public int j = -1;
    public void MenuLogin()
    {
        // while(j!=0)
        // {
        LoginUI loginUI = new LoginUI();
        loginUI.Login();
        MenuAdministrator menuAdministrator = new MenuAdministrator();
        menuAdministrator.Mainmenu();
        //menuAdministrator.MenuUpdateStudent();
        //Console.Clear();
        //}
    }
}

public class MenuAdministrator
{
    public int j = -1;
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
            Console.WriteLine("1. Display all data.");
            Console.WriteLine("2. Update data.");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("==========================================================");
            Console.Write("Your Choice: ");
            j = Convert.ToInt32(Console.ReadLine()??"".TrimEnd(' '));
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
            j = Convert.ToInt32(Console.ReadLine()??"".TrimEnd(' '));
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