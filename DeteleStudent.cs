
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using ConsoleTableExt;
using System.IO;

namespace Delete_Students
{
    public class DeleteStudent
    {
        public void Delete_Student()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("-----------------------Delete Student---------------------");
            Console.WriteLine("==========================================================");
            Console.Write("Enter Student No: ");
            string studentNo = Console.ReadLine() ?? "".TrimEnd(' ');
            int choice;
            
            if (AuthenticateStudent(studentNo))
            {
                try
                {
                    int studentId = GetStudentId(studentNo);
                    Display_Student(studentId);
                    
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("1. Yes.");
                        Console.WriteLine("2. No.");
                        Console.Write("Your Choice: ");
                        choice = Convert.ToInt32(Console.ReadLine()??"".TrimEnd(' '));

                        switch (choice)
                        {
                            case 1 :
                                Delete_Students(studentId);
                                break;
                            case 2 :
                                break;
                        }
                    } while (choice != 2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error!\n Not found Student please re-enter.");
            }
        }

        //Hàm lấy id của student trong mysql dựa vào student No 
        public int GetStudentId(string student_no)
        {
            int StudentId = -1;

            // Kết nối đến cơ sở dữ liệu
            MySqlConnection connection = Connection.GetConnection();
            // Tạo command để thực thi thủ tục lưu trữ
            string StoredProcedure = ""; // ghi tên procedure ở đây
            using (MySqlCommand command = new MySqlCommand(StoredProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("", student_no); // ghi tên student no ở đây (cái student no mà đặt tên trong StoredProcedure)
                command.Parameters.Add("", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;  // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                command.ExecuteNonQuery();

                if (command.Parameters[""].Value != DBNull.Value) // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                {
                    StudentId = Convert.ToInt32(command.Parameters[""].Value); // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                }

                return StudentId;
            }
        }

        static bool AuthenticateStudent(string studentNo) // tìm kiếm xem mã student no đã nhập có tồn tại hay không
        {
            MySqlConnection connection = Connection.GetConnection();
            string StoredProcedure = ""; //StoredProcedure tìm kiếm student no có tồn tại hay không 
            using (var command = new MySqlCommand(StoredProcedure, connection))
            {
                command.Parameters.AddWithValue("", studentNo);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        // hàm xóa sinh viên bằng cách truy vấn sql Storedprocedure dựa vào student id
        public static void Delete_Students(int student_id)
        {
            MySqlConnection connection = Connection.GetConnection();
            string StoredProcedure = "";
            using (var command = new MySqlCommand(StoredProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("", student_id);

                command.ExecuteNonQuery();
                Console.WriteLine("Successfully!");
            }
        }

        // hàm hiển thị sinh viên bằng cách truy vấn sql Storedprocedure dựa vào student id
        public static void Display_Student(int student_id)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            MySqlConnection connection = Connection.GetConnection();
            string StoredProcedure = "";
            MySqlCommand command = new MySqlCommand(StoredProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("", student_id);

            MySqlDataReader reader = command.ExecuteReader();

            var table = new List<List<string>>();

            //thêm tiêu đề bảng
            var header = new List<string> { "Student No", "Name", "Class", "Brith Date", "Gender" };
            table.Add(header);

            while (reader.Read())
            {
                string StudentNo = reader.GetString("");// Student no tương úng trong StoredProcedure
                string Name = reader.GetString("");  // Tương đối với name của bạn
                string Class = reader.GetString("");
                DateTime BirthDate = reader.GetDateTime("");
                // Type enum của Gender chưa bt ghi thế nào nên sẽ ghi sau :)))
                
                
                var row = new List<string>
                {
                    StudentNo,
                    Name,
                    Class,
                    BirthDate.ToString(),
                    //ghi Gender ở đây
                };

                table.Add(row);
            }

            reader.Close();
            connection.Close();


            //hiển thị bảng
            int columnCount = table[0].Count;
            int[] columnWidths = new int[columnCount];

            for(int i = 0; i < columnCount; i++)
            {
                columnWidths[i] = table.Max(Row => Row[i].Length);//
            }

            foreach(var row in table)
            {
                for(int i = 0; i < columnCount; i++)
                {
                    Console.Write(row[i].PadRight(columnWidths[i] + 2));
                }
                Console.WriteLine();
            }
        }

    }

}

