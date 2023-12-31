using System;
using System.Data;
using System.Net.Mail;
using System.Text;
using MySql.Data.MySqlClient;

public class Addstudents 
{
    // public int year = 0;
    // public int day = 0;
    // public int month = 0;
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
        Students students = new Students();
        students.Students_name = Entername();
        students.Students_email = Enteremailaddress();
        students.Students_phone = EnterphoneNumber();
        students.Students_gender = Entergender();
        students.Students_birthday = Enterbirthdate();
        students.Students_address = EnterAddress();
        students.Students_no = EnterStudentno(students.Students_phone);
        students.Student_password = RandomPassword();
        Add_Student(students);
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
    public string EnterStudentno(string Students_phone)
    {
        //tao uid hoc sinh
        string no = ReStudents_no();
        string id = no + Students_phone;
        return id;
    }
    public string RandomPassword()
    {
        Random password = new Random();
        int number = password.Next(100000,999999);
        return number.ToString();
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
        string Phonenumber = Console.ReadLine()?? "";
        if(Phonenumber.Length != 10)
        {
            Console.WriteLine("Invalid phone number format. Please enter again!");
        }
        return Phonenumber;
    }
    public string Entergender()
    {
        //dien gioi tinh
        Console.Write("Enter gender (enter F or M):");
        string gender = Console.ReadLine()?? "";
        if (gender == "f" || gender =="F" ) gender = "Female";
        if(gender == "M"|| gender =="m") gender = "Male";
        return gender;
    }
    public string EnterAddress()
    {
        Console.Write("Enter address:");
        string address = Console.ReadLine()??"";
        return address;
    }
    public DateTime Enterbirthdate()
    {
        //dien ngay thang nam sinh
        Console.WriteLine("Enter birthday.");
        Console.Write("Enter year :");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter day :");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter month:");
        int month = int.Parse(Console.ReadLine());
        DateTime a = new DateTime(year, month, day);
        return a;
    }
    // thêm dữ liệu vào csdl
    public static void Add_Student(Students students)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        // Kết nối đến cơ sở dữ liệu
        MySqlConnection connection = Connection.GetConnection();

        // Tạo command để thực thi thủ tục lưu trữ-
        string StoredProcedure = "Addstudent"; // ghi tên procedure ở đây
        using(MySqlCommand command = new MySqlCommand(StoredProcedure,connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("studentUID",students.Students_no);
            command.Parameters["@studentUID"].Direction= System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("passwords",students.Student_password);
            command.Parameters["@passwords"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("studentname",students.Students_name);
            command.Parameters["@studentname"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("genderstudent",students.Students_gender);
            command.Parameters["@genderstudent"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("studentphone",students.Students_phone);
            command.Parameters["@studentphone"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("emailstudent",students.Students_email);
            command.Parameters["@emailstudent"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("birthdaystudent",students.Students_birthday);
            command.Parameters["@birthdaystudent"].Direction = System.Data.ParameterDirection.Input;
            command.Parameters.AddWithValue("studentaddress",students.Students_address);
            command.Parameters["@studentaddress"].Direction = System.Data.ParameterDirection.Input;
            Int32 recordsAffected = command.ExecuteNonQuery();
            // Thực thi thủ tục lưu trữ
            Console.WriteLine("successfully!");
        }
    }
}