using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                command.Parameters.AddWithValue("",studentNo);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

    }

}

