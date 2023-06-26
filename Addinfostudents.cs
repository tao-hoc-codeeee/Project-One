using System.Net.Mail;

public class Addinfostudent : Studentsinfo
{
    public string genderfemale = "F";
    public string gendermale = "M";
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
        //nhap ten
        Console.WriteLine("Enter name:");
        name_of_student = Console.ReadLine()??"";
        
        //nhap email
        Console.Write("Enter email_address:");
        string email = Console.ReadLine()??"";
        int i = chekcmail(email); // check email
        while(i!=1)
        {
            Console.WriteLine("Wrong email format");
        }
        email = students_mail;

        //nhap so dien thoai
        students_phonenumber = Number_Phone();

        //nhap goi tinh
        students_sex = Gender();
        
        //nhap nam sinh
        Console.Write("Enter birthday:");
        year = Convert.ToInt32(Console.ReadLine());
        day = Convert.ToInt32(Console.ReadLine());
        month = Convert.ToInt32(Console.ReadLine());
        students_birth = new DateTime(year, month, day);
        
        //nhap email
        Console.Write("Enter address:");
        studentsaddress = Console.ReadLine()??"";

        //hien thi lai thong tin cho nguoi dung xac minh lai 1 lam nua
        Console.WriteLine("Information :");
        Console.WriteLine("Name : {0}", name_of_student);
        Console.WriteLine("ID :", studentsno);
        Console.WriteLine("Email : {0}", students_mail);
        Console.WriteLine("Gender : {0}", students_sex);
        Console.WriteLine("Birthday : {0}", students_birth);
        Console.WriteLine("Phonenumber : {0}", students_phonenumber);
        Console.WriteLine("Address : {0}", studentsaddress);

    }
    
    // ham check email
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

    // ham check gioi tinh
    public string Gender()
    {
        while(true)
        {
            Console.Write("Enter gender (enter F or M):");
            string gender = Console.ReadLine()??"".ToUpper();
            if(gender == "F" || gender == "M")
            {
                return gender;
            }
            else
            {
                Console.WriteLine("Invalid gender. Please re-enter.");
            }
        }
    }

    // ham check so dien thoai
    public string Number_Phone()
    {
        while(true)
        {
            Console.Write("Enter phonenumber:");
            string Phonenumber = Console.ReadLine()??"";
            int length = Phonenumber.Length;

            if(length == 10 || length == 11)
            {
                return Phonenumber;
            }
            else
            {
                Console.WriteLine("Invalid phone number format. Please enter again!");
            }
        }
    }

    
}