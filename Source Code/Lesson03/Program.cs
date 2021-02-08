using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    class Program
    {
        // ************** CÂU LỆNH IF ELSE ***************
        // Dạng thiếu
        static void Main(string[] args)
        {
            string T = "TT Design";
            if (T == "TT Design") Console.WriteLine("This is our company!");

            /* 
             Biểu thức điều kiện sử dụng toán tử == đề so sánh xem giá trị biến T có bằng “TT Design” hay không.
             Nếu bằng trả thì trả về true ngược lại thì trả về false.

             In ra màn hình chữ “This is our company!” nếu biểu thức trên đúng.
            */
            Console.ReadKey();
        }

        // Dạng đủ
        static void Main2(string[] args)
        {
            string T = "TT Design";

            if (T == "TT Design") // Nếu giá trị T bằng “TT Design” thì
                Console.WriteLine("This is our company!"); // In ra màn hình “This is our company!”

            else // Ngược lại thì
                Console.WriteLine("This is not our company!"); // In ra màn hình “This is not our company!”
            Console.ReadKey();
        }

        //Lưu ý sử dụng
        // VD 01
        static void Main3(string[] args)
        {
            int T = 5;

            if (T > 0 && T < 10)
                Console.WriteLine("T is in range from 0 to 10");
            else
                Console.WriteLine("T is out of range from 0 to 10");

            Console.ReadKey();
        }

        //vd 02
        static void Main4(string[] args)
        {
            /*
            If <Biểu thức điều kiện 1>
            {
                If <Biểu thức điều kiện 2>
                {
                    <Câu lệnh thực hiện 1>
                }
                else
                {
                    <Câu lệnh thực hiện 2>
                }

                <Câu lệnh thực hiện 3>
            }
            Else
            {
                If <Biểu thức điều kiện 3>
                {
                    <Câu lệnh thực hiện 4>
                }

                If <Biểu thức điều kiện 4>
                {
                    <Câu lệnh thực hiện 5>
                }
                 <Câu lệnh thực hiện 6>
             }

            */
        }

        //VD 03
        //Viết chương trình giải phương trình bậc 1: Ax + B = 0
        static void Main5(string[] args)
        {
            string strA, strB;
            int A, B;
            double Nghiem;

            Console.WriteLine(" *************************************************** ");
            Console.WriteLine(" *                                                 * ");
            Console.WriteLine(" *    Chuong trinh giai phuong trinh Ax + B = 0    * ");
            Console.WriteLine(" *                                                 * ");
            Console.WriteLine(" *************************************************** ");

            Console.Write(" Moi nhap so A: ");
            strA = Console.ReadLine();

            Console.Write(" Moi nhap so B: ");
            strB = Console.ReadLine();

            if (int.TryParse(strA, out A) == false || int.TryParse(strB, out B) == false)
            //  kiểm tra người dùng có thực sự nhập số nguyên vào hay không.
            // Nếu ép kiểu thành công sẽ trả về true, ngược lại trả về false
            {
                Console.WriteLine(" Du lieu nhap sai !");

                return;
                // Lệnh này tạm hiểu là dừng và thoát chương trình mà không thực hiện những câu lệnh sau nó nữa.
                // Sẽ được tìm hiểu chi tiết trong bài sau
            }
            else
            {
                Console.WriteLine("\n Phuong trinh cua ban vua nhap la: {0}x + {1} = 0", A, B);
                if (A == 0)
                {
                    Console.WriteLine("\n Phuong trinh co vo so nghiem !");
                }
                else if (B == 0)
                {
                    Console.WriteLine("\n Phuong trinh co nghiem x = 0");
                }
                else
                {
                    Nghiem = (double)-B / A; // Ép kiểu để cho ra kết quả chính xác
                    Console.WriteLine("\n Phuong trinh co nghiem x = {0}", Nghiem);
                }
            }

            Console.ReadKey();
        }

        //VD 04
        static void Main6(string[] args)
        {
            int machine;
            string UserChose;
            string MachineChose;
            bool? UserWin = null;


            Console.WriteLine(" *************************************************** ");
            Console.WriteLine(" *                                                 * ");
            Console.WriteLine(" *    Chao ban den vs tro choi Keo, Bua, Bao       * ");
            Console.WriteLine(" *                                                 * ");
            Console.WriteLine(" *************************************************** ");

            Console.Write(" Moi ban nhap vao ban chon gi? : ");
            UserChose = Console.ReadLine();

            Random ranDom = new Random();
            machine = ranDom.Next(1, 4);

            if (machine == 1)
            {
                MachineChose = "Keo";
            }
            else if (machine == 2)
            {
                MachineChose = "Bua";
            }
            else
            {
                MachineChose = "Bao";
            }


            if (UserChose == "Keo")
            {
                if (MachineChose == "Keo") UserWin = null;
                if (MachineChose == "Bua") UserWin = false;
                if (MachineChose == "Bao") UserWin = true;
            }
            else if (UserChose == "Bua")
            {
                if (MachineChose == "Bua") UserWin = null;
                if (MachineChose == "Bao") UserWin = false;
                if (MachineChose == "Keo") UserWin = true;
            }
            else if (UserChose == "Bao")
            {
                if (MachineChose == "Bao") UserWin = null;
                if (MachineChose == "Keo") UserWin = false;
                if (MachineChose == "Bua") UserWin = true;
            }
            else //Du lieu nhap sai
            {
                Console.WriteLine(" Du lieu nhap sai !");
                Console.ReadKey();
                return;
                // Lệnh này tạm hiểu là dừng và thoát chương trình mà không thực hiện những câu lệnh sau nó nữa.
                // Sẽ được tìm hiểu chi tiết trong bài sau
            }

            if (UserWin == true)
            {
                Console.WriteLine(" Chuc mung ban da thang!\nMay chon:" + MachineChose);
            }
            else if (UserWin == false)
            {
                Console.WriteLine(" Xin loi ban da thua!\nMay chon:" + MachineChose);
            }
            else
            {
                Console.WriteLine("Ban hoa!\nMay cung chon: " + MachineChose);
            }

            Console.ReadKey();
        }

        // *********************** SWITCH CASE *******************
        static void Main7(string[] args)
        {
            int T = 10;

            switch (T) // giá trị biểu thức la giá trị của biến T (kiểu số nguyên)
            {
                case 3: // các giá trị so sánh cũng la kiểu số nguyên
                    Console.WriteLine("TT Design"); // lệnh thực hiện nếu T = 3
                    break; // lệnh thoát ra khỏi cấu trúc
                case 9:
                    Console.WriteLine("Design"); // tương tự
                    break;
                case 10:
                    Console.WriteLine("This is our company!"); // tương tự
                    break;
            }
        }
        static void Main8(string[] args)
        {
            int T = 10;

            switch (T) // giá trị biểu thức la giá trị của biến T (kiểu số nguyên)
            {
                case 3: // các giá trị so sánh cũng la kiểu số nguyên
                    Console.WriteLine("TT Design"); // lệnh thực hiện nếu T = 3
                    break; // lệnh thoát ra khỏi cấu trúc
                case 9:
                    Console.WriteLine("Design"); // tương tự
                    break;
                case 10:
                    Console.WriteLine("This is our company!"); // tương tự
                    break;
                default:
                    Console.WriteLine("Try to connect to TT Design"); // tương tự
                    break;
            }
        }

        // OBJECT - VAR
        static void Main9(string[] args)
        {
            /* Vì biến StringVariable được khởi tạo giá trị kiểu chuỗi
             * nên trình biên dịch sẽ hiểu biến này như là biến kiểu string.
             */

            var varString = "TTDesign";
            // Khai báo tường minh biến kiểu string
            string Content = "TTDesign";

            // In giá trị của biến StringVariable và biến Content
            Console.WriteLine(varString);
            Console.WriteLine(Content);
        }
    }
}
