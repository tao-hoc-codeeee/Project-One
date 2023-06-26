public class MenuAdministrator
{
    public int j = -1;
    public void Mainmenu()
    {
        while(j!=0)
        {
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
    public void MenuDisplay()
    {
        
    }
}