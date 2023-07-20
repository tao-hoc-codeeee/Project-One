using System.Data;
using System.Net.Mail;
public class Addstudents : Studentsinfo
{
    public int year = 0;
    public int day = 0;
    public int month = 0;
    // public Addstudents()
    // {
    //     name_of_student = "";
    //     students_mail = "";
    //     students_phonenumber = "";
    //     students_sex = "";
    //     studentsaddress = "";
    //     studentsno = "";
    // }
    public void Enterstudentinfo()
    {
        Students_name = Entername();
        Students_email = Enteremailaddress();
        Students_phone = EnterphoneNumber();
        Students_gender = Entergender();
        Students_birthday = Enterbirthdate();
        Students_no = EnterStudentno();
        Console.Write("Are you sure?(Enter Y or N):");
        string a = Console.ReadLine()??"".ToUpper();
        if(a == "Y")
        {
            Console.WriteLine("Complete");
            // Console.WriteLine("Name :"+name_of_student);
            // Console.WriteLine("Gender :"+students_sex);
            // Console.WriteLine("Phone :"+students_phonenumber);
            // Console.WriteLine("UID :"+studentsno);
            // Console.WriteLine("Birthday:"+students_birth);
        }
    }
    public string Entername()
    {
        //Them ten hoc sinh
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine()??"";
        return name;
    }
    public string ReStudents_no()
    {
        Random a = new Random();
        int number = a.Next(10,99);
        return number.ToString();
    }
    public string EnterStudentno()
    {
        //tao uid hoc sinh
        string no = ReStudents_no(); 
        string id = no+Students_phone;
        return id;
    }
    public string Enteremailaddress()
    {
        //Dien dia chi email
        Console.Write("Enter email_address:");
        string email = Console.ReadLine()??"";
        int i = chekcmail(email);
         // check email
        if(i!=1)
        {
            Console.WriteLine("Wrong email format");
        }
        return email;
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
    public string EnterphoneNumber()
    {
        //dien so dien thoai hs
        Console.Write("Enter phonenumber:");
        string Phonenumber = Console.ReadLine()??"";
        while(Phonenumber.Length !=10)
        {
            Console.WriteLine("Invalid phone number format. Please enter again!");
        }
        return Phonenumber;
    }
    public string Entergender()
    {
        //dien gioi tinh
        Console.Write("Enter gender (enter F or M):");
            string gender = Console.ReadLine()??"".ToUpper();
            if(gender != "F" || gender != "M")
            {
                Console.WriteLine("Invalid gender. Please re-enter.");
            }
            return gender;
    }
    public DateTime Enterbirthdate()
    {
        //dien ngay thang nam sinh
        DateTime a = new DateTime();
        Console.Write("Enter birthday:");
        year = Convert.ToInt32(Console.ReadLine());
        day = Convert.ToInt32(Console.ReadLine());
        month = Convert.ToInt32(Console.ReadLine());
        return a = new DateTime(year, month, day);
    }
}