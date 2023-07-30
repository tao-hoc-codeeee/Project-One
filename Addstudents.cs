using System;
using System.Data;
using System.Net.Mail;
using System.Text;
using MySql.Data.MySqlClient;

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
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("==========================================================");
        Console.WriteLine("----------------------Add New Student---------------------");
        Console.WriteLine("==========================================================");
        Students_name = Entername();
        Students_email = Enteremailaddress();
        Students_phone = EnterphoneNumber();
        Students_gender = Entergender();
        Students_birthday = Enterbirthdate();
        Students_no = EnterStudentno();
        Console.Write("Are you sure?(Enter Y or N):");
        string a = Console.ReadLine() ?? "".ToUpper();
        if (a == "Y")
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
        Console.Write("Enter name:");
        string name = Console.ReadLine() ?? "".TrimEnd(' ');
        return name;
    }
    public string ReStudents_no()
    {
        Random a = new Random();
        int number = a.Next(10, 99);
        return number.ToString();
    }
    public string EnterStudentno()
    {
        //tao uid hoc sinh
        string no = ReStudents_no();
        string id = no + Students_phone;
        return id;
    }
    public string Enteremailaddress()
    {
        //Dien dia chi email
        Console.Write("Enter email_address:");
        string email = Console.ReadLine() ?? "".TrimEnd(' ');
        int i = chekcmail(email);
        // check email
        if (i != 1)
        {
            Console.WriteLine("Wrong email format");
        }
        return email;
    }
    //Kiem tra dinh dang email
    public int chekcmail(string mail)
    {
        try
        {
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
        string Phonenumber = Console.ReadLine() ?? "".TrimEnd(' ');
        while (Phonenumber.Length != 10)
        {
            Console.WriteLine("Invalid phone number format. Please enter again!");
        }
        return Phonenumber;
    }
    public string Entergender()
    {
        //dien gioi tinh
        Console.Write("Enter gender (enter F or M):");
        string gender = Console.ReadLine() ?? "".ToUpper().TrimEnd(' ');
        if (gender != "F" || gender != "M")
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


    // thêm dữ liệu vào csdl
    public static void Add_Student(string StudentNo, string Passwrod, string StudentName, string Gender, string PhoneNumber, string Email, DateTime BrithDate, string Address)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        // Kết nối đến cơ sở dữ liệu
        MySqlConnection connection = Connection.GetConnection();

        // Tạo command để thực thi thủ tục lưu trữ
        string StoredProcedure = "sp_AddStudent"; // ghi tên procedure ở đây
        using(MySqlCommand command = new MySqlCommand(StoredProcedure,connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("",StudentNo);
            command.Parameters.AddWithValue("",Passwrod);
            command.Parameters.AddWithValue("",StudentName);
            command.Parameters.AddWithValue("",Gender);
            command.Parameters.AddWithValue("",PhoneNumber);
            command.Parameters.AddWithValue("",Email);
            command.Parameters.AddWithValue("",BrithDate);
            command.Parameters.AddWithValue("",Address);


            // Thực thi thủ tục lưu trữ
            command.ExecuteNonQuery();
            Console.WriteLine("successfully!");
        }
    }
}