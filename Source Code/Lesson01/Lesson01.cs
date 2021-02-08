using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" TT Design"); // In chữ "K team" sau đó xuống dòng.
            Console.Write(" Moi ban nhap ten cua minh: "); // In không xuống dòng.
            Console.WriteLine("Ten cua ban la: " + Console.ReadLine());
            /* 
              Quy tắc chung trong thực hiện lệnh là lệnh bên trong thực hiện trước rồi đến lệnh
              bên ngoài chứa nó.Do đó chạy đến đây chương trình sẽ thực hiện lệnh
              Console.ReadLine() sau đó thực hiện cộng chuỗi và cuối cùng in chuỗi ra màn hình.
            */
            Console.Write(" Moi ban nhap ngay sinh: ");
            Console.WriteLine(" Ngay sinh cua ban la: " + Console.ReadLine()); //Tương tự như trên
            Console.Write(" Moi ban nhap que quan: ");
            Console.WriteLine(" Que quan: " + Console.ReadLine()); // Tương tự như trên.
            Console.ReadKey();
        }
    }
}




