using System.Net.Mail;

public class Addinfostudent : Studentsinfo
{
    public string genderfemale = "Female";
    public string gendermale = "Male";
    public int year = 0;
    public int day = 0;
    public int month = 0;
    public Addinfostudent()
    {
        name_of_student = "";
        students_mail = "";
        students_phonenumber = "";
        students_sex = "";
        studentsaddress = "";
        studentsno = "";
    }
    public void Addstudent()
    {
        Console.WriteLine("Enter name:");
        name_of_student = Console.ReadLine()??"";
        Console.Write("Enter email_address:");
        string email = Console.ReadLine()??"";
        int i = chekcmail(email);
        while(i!=1)
        {
            Console.WriteLine("Wrong email format");
        }
        email = students_mail;
        Console.Write("Enter phonenumber:");
        students_phonenumber = Console.ReadLine()??"";
        Console.Write("Enter gender (enter F or M):");
        string sexual = Console.ReadLine()??"";
        students_sex = Gender(sexual);
        Console.Write("Enter birthday:");
        year = Convert.ToInt32(Console.ReadLine());
        day = Convert.ToInt32(Console.ReadLine());
        month = Convert.ToInt32(Console.ReadLine());
        students_birth = new DateTime(year, month, day);
        Console.Write("Enter address:");
        studentsaddress = Console.ReadLine()??"";
        Console.WriteLine("Information :");
        Console.WriteLine("Name : {0}", name_of_student);
        Console.WriteLine("ID :", studentsno);
        Console.WriteLine("Email : {0}", students_mail);
        Console.WriteLine("Gender : {0}", students_sex);
        Console.WriteLine("Birthday : {0}", students_birth);
        Console.WriteLine("Phonenumber : {0}", students_phonenumber);
        Console.WriteLine("Address : {0}", studentsaddress);
        
    }
    //Kiem tra dinh dang email
    public int chekcmail(string mail)
    {
        try{
            MailAddress m = new MailAddress(mail);
            return 1;
        }
        catch (FormatException)
        {
            return 0;
        }
    }
    // Tra ve gioi tinh de luu
    public string Gender(string gender)
    {
        if(gender == "F" && gender == "f")
        {
            return genderfemale;
        }
        else
        {
            return gendermale;
        }
    }
    //Kiem tra ngay thang co chuan khong
    public bool checkDatetime(int year, int month, int day)
    {
        if(month == 2 && day >28)
        {
            return false;
        }
        if(month == 2 && year %4==0 && day <29)
        {
            return false;
        }
        if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month ==10 || month == 12 && day <31)
        {
            return false;
        }
        if (day > 32)
        {
            return false;
        }
        if (month >13)
        {
            return false;
        }
        if (month == 4 || month == 6 || month == 9 || month == 11 && day > 30)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}