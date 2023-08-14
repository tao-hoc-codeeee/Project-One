
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
            
            try
            {

            
            if (AuthenticateStudent(studentNo))
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
            else
            {
                Console.WriteLine("Error!\n Not found Student please re-enter.");
            }
            }
            catch
            {
                Console.WriteLine("Sorry!\nSomething went wrong, please try again in a few minutes!");
            }
        }

        //Hàm lấy id của student trong mysql dựa vào student No 
        public int GetStudentId(string student_no)
        {
            int StudentId = -1;

            // Kết nối đến cơ sở dữ liệu
            MySqlConnection connection = Connection.GetConnection();
            // Tạo command để thực thi thủ tục lưu trữ
            string StoredProcedure = "sp_GetStudentId"; // ghi tên procedure ở đây
            using (MySqlCommand command = new MySqlCommand(StoredProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentNo", student_no); // ghi tên student no ở đây (cái student no mà đặt tên trong StoredProcedure)
                command.Parameters.Add("@StudentId", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;  // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                command.ExecuteNonQuery();

                if (command.Parameters["@StudentId"].Value != DBNull.Value) // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                {
                    StudentId = Convert.ToInt32(command.Parameters["@StudentId"].Value); // ghi tên student id ở đây (cái student id mà đặt tên trong StoredProcedure)
                }

                return StudentId;
            }
        }

        static bool AuthenticateStudent(string studentNo) // tìm kiếm xem mã student no đã nhập có tồn tại hay không
        {
            MySqlConnection connection = Connection.GetConnection();
            string StoredProcedure = "sp_AuthenticateStudent"; //StoredProcedure tìm kiếm student no có tồn tại hay không 
            using (var command = new MySqlCommand(StoredProcedure, connection))
            {
                command.Parameters.AddWithValue("@UID", studentNo);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        // hàm xóa sinh viên bằng cách truy vấn sql Storedprocedure dựa vào student id
        public static void Delete_Students(int student_id)
        {
            MySqlConnection connection = Connection.GetConnection();
            string StoredProcedure = "sp_DeleteProduct";
            using (var command = new MySqlCommand(StoredProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@productId", student_id);

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
            command.Parameters.AddWithValue("@StudentId", student_id);// student id tương ứng trong storedProcedure

            MySqlDataReader reader = command.ExecuteReader();

            var table = new List<List<string>>();

            //thêm tiêu đề bảng
            var header = new List<string> { "Student No", "Name", "Class", "Brith Date", "Gender" };
            table.Add(header);

            // Tính toán chiều dài tối đa của mỗi cột
            int[] columnWidths = new int[header.Count];
            for (int i = 0; i < header.Count; i++)
            {
                columnWidths[i] = header[i].Length;
            }


            while (reader.Read())
            {
                string StudentNo = reader.GetString("student_no");// Student no tương úng trong StoredProcedure
                string Name = reader.GetString("student_name");  // Tương đối với name của bạn
                string Class = reader.GetString("class_name");
                DateTime BirthDate = reader.GetDateTime("birth_date");
                string Gender = reader.GetString("gender");

                // Cập nhật chiều dài tối đa của mỗi cột dựa trên dữ liệu mới
                columnWidths[0] = Math.Max(columnWidths[0], StudentNo.Length);
                columnWidths[1] = Math.Max(columnWidths[1], Name.Length);
                columnWidths[2] = Math.Max(columnWidths[2], Class.Length);
                columnWidths[3] = Math.Max(columnWidths[3], BirthDate.ToString().Length);
                columnWidths[4] = Math.Max(columnWidths[4], Gender.Length);
                
                
                var row = new List<string>
                {
                    StudentNo,
                    Name,
                    Class,
                    BirthDate.ToString(),
                    Gender
                };

                table.Add(row);
            }

            reader.Close();
            connection.Close();


            // Thêm dấu " - " cho mỗi dòng
            var separator = new List<string>();
            for (int i = 0; i < header.Count; i++)
            {
                separator.Add(new string('-', columnWidths[i] + 2));
            }

            // Hiển thị bảng
            foreach (var row in table)
            {
                for (int i = 0; i < header.Count; i++)
                {
                    Console.Write("| " + row[i].PadRight(columnWidths[i]) + " ");
                }
                Console.WriteLine("|");
                if (row == header)
                {
                    Console.Write("+");
                    foreach (var width in columnWidths)
                    {
                        Console.Write(new string('-', width + 2) + "+");
                    }
                    Console.WriteLine();
                }
            }

            // Dòng " - " cuối cùng
            Console.Write("+");
            foreach (var width in columnWidths)
            {
                Console.Write(new string('-', width + 2) + "+");
            }
            Console.WriteLine();

        }

    }

}

