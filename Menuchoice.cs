public class MenuAdministrator
{
    public int j = -1;
    public void Mainmenu()
    {
        while(j!=0)
        {
            Console.WriteLine("Student Mananagement");
            Console.WriteLine("1. Display all data");
            Console.WriteLine("2. Update data");
            Console.WriteLine("0. Exit");
            Console.Write("   #Choice :");
            j = Convert.ToInt32(Console.ReadLine());
            switch(j)
            {
                case 1: break;
            }
        }
    }
    public void MenuUpdateStudent()
    {
        while(j!=0)
        {
            Console.WriteLine("1 . Delete student");
            Console.WriteLine("2 . Change information");
            Console.WriteLine("3 . Add new students");
            Console.WriteLine("4 . Ban or Reverse");
            Console.WriteLine("5 . Exit");
        }
    }
}