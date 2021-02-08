using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07
{
    class Program
    {
        // ********** VÒNG LẶP FOREACH ***********/

        #region ForEach
        static void Main1(string[] args)
        {
            //VD Lỗi
            int[] collection = new int[5];
            foreach (int item in collection)
            {
                // item = 2;
            }

            //VD Tính tổng
            int[] IntArray = { 1, 5, 2, 4, 6 };
            int Sum = 0;
            /*
            * Sử dụng foreach để duyệt mang và in giá trị của các phần tử trong mang.
            * Đồng thời tân dụng vòng lặp để tính tổng các phần tử trong mang.
            */
            foreach (int item in IntArray)
            {
                Console.Write("\t" + item);
                Sum += item;
            }

            Console.WriteLine("\n Sum = " + Sum);
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            /* Kiểm tra tốc độ của for */
            // using System.Diagnostics

            Stopwatch start = new Stopwatch();
            start.Start();

            int[] IntArray = new int[Int32.MaxValue / 100]; //(21474836 ptu)
            int s = 0;
            int Length = IntArray.Length;
            for (int i = 0; i < Length; i++)
            {
                s += IntArray[i];
            }

            start.Stop();
            Console.WriteLine(" Thoi gian chay cua for: {0} giay {1} mili giay",
                start.Elapsed.Seconds, start.Elapsed.Milliseconds);


            /* Kiểm tra tốc độ của foreach */
            Stopwatch start2 = new Stopwatch();
            start2.Start();
            int[] IntArray2 = new int[Int32.MaxValue / 100];
            int s2 = 0;
            foreach (int item in IntArray2)
            {
                s2 += item;
            }

            start2.Stop();
            Console.WriteLine(" Thoi gian chay cua foreach: {0} giay {1} mili giay",
                start2.Elapsed.Seconds, start2.Elapsed.Milliseconds);
            Console.ReadKey();
        }
        static void Main3(string[] args)
        {
            /*Khai báo 1 LinkedList chưa các số nguyên int và khởi tạo giá trị cho nó.*/

            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10000; i++)
            {
                list.AddLast(i);

            }

            /* Kiểm tra tốc độ của for */
            Stopwatch st = new Stopwatch();
            int s1 = 0, length = list.Count;
            st.Start();
            for (int i = 0; i < length; i++)
            {
                s1 += list.ElementAt(i);
            }

            st.Stop();

            /* Kiểm tra tốc độ của foreach */
            Stopwatch st2 = new Stopwatch();
            int s2 = 0;
            st2.Start();
            foreach (int item in list)
            {
                s2 += item;
            }

            st2.Stop();

            /* In ra giá trị tính tổng giá trị các phần tử khi duyệt bằng for và foreach để
            chắc chắn rằng ca 2 đều chạy đúng */
            Console.WriteLine(" s1 = {0} s2 = {1}", s1, s2);
            Console.WriteLine(" Thoi gian chay cua for = {0} giay {1} mili giay",
                st.Elapsed.Seconds, st.Elapsed.Milliseconds);
            Console.WriteLine(" Thoi gian chay cua foreach = {0} giay {1} mini giay",
                st2.Elapsed.Seconds, st2.Elapsed.Milliseconds);
            Console.ReadKey();
        }
        #endregion

        // ********** STRING ***********/

        #region String
        static void Main4(string[] args)
        {
            string a = "TTDesignCompany";
            a.Replace("TT", "T&T");

            Console.WriteLine(a);
            Console.ReadKey();

            a = a.Replace("TT", "T&T");
            Console.WriteLine(a);
            Console.ReadKey();
        }
        static void Main5(string[] args)
        {
            string FullName;
            string Result = "";
            Console.Write("Moi ban nhap doan van bat ky: ");
            FullName = Console.ReadLine();

            /* Cắt các khoảng trắng dư ở đầu và cuối chuỗi */
            FullName = FullName.Trim();

            while (FullName.IndexOf("  ") != -1)
            {
                FullName = FullName.Replace("  ", " ");
            }


            string[] SubName = FullName.Split(' ');

            for (int i = 0; i < SubName.Length; i++)
            {
                string FirstChar = SubName[i].Substring(0, 1);
                string OtherChar = SubName[i].Substring(1);
                SubName[i] = FirstChar.ToUpper() + OtherChar.ToLower();
                Result += SubName[i] + " ";

            }
            Console.WriteLine("Doan van correct la: " + Result);
            Console.ReadKey();
        }
        #endregion


        // *********** STRUCT ***********//

        #region Struct
        //VD01: KhaiBao
        struct SinhVien
        {
            public int MSSV;
            public string HoTen;
            public string NoiSinh;
            public int CMND;
        }
        //VD02: Su Dung
        struct Student
        {
            public int MSV;
            public string HoTen;
            public double Toan;
            public double Ly;
            public double Van;
            public double DiemTrungBinh;
            public string XepLoai;
        }
        static void NhapThongTinSinhVien(ref Student SV)
        {
            Console.Write(" Ma so: ");
            SV.MSV = int.Parse(Console.ReadLine());
            Console.Write(" Ho ten: ");
            SV.HoTen = Console.ReadLine();
            Console.Write(" Diem toan: ");
            SV.Toan = Double.Parse(Console.ReadLine());
            Console.Write(" Diem ly: ");
            SV.Ly = Double.Parse(Console.ReadLine());
            Console.Write(" Diem van: ");
            SV.Van = Double.Parse(Console.ReadLine());

        }
        static void DanhGiaKetQuaSV(ref Student SV)
        {

            double DTB = (SV.Toan + SV.Ly + SV.Van) / 3;
            SV.DiemTrungBinh = Math.Round(DTB, 2);
            if (DTB < 5)
            {
                SV.XepLoai = "Trung Binh";
            }
            else if (DTB < 8)
            {
                SV.XepLoai = "Kha";
            }
            else
            {
                SV.XepLoai = "Gioi";
            }
        }
        static void Main6(string[] args)
        {
            //  Khai báo 1 kiểu dữ liệu SinhVien với các trường thông tin như đề bài.

            Student SV = new Student();
            Console.WriteLine(" Nhap thong tin sinh vien: ");
            NhapThongTinSinhVien(ref SV);

            Console.WriteLine("*********");
            Console.WriteLine("Danh gia ket qua sinh vien vua nhap la: ");
            DanhGiaKetQuaSV(ref SV);

            Console.WriteLine($"Diem TB cua sinh vien {SV.HoTen} la: " + SV.DiemTrungBinh);
            Console.WriteLine($"Xep loai sinh vien {SV.HoTen} la: " + SV.XepLoai);
            Console.ReadKey();
        }
        #endregion

        // *********** ENUMERABLE ***********//

        #region Enum

        enum XepLoai
        {
            TrungBinh = 4,
            Kha = 7,
            Gioi = 9,
            XuatSac = 10
        }

        //VD01: Choi game co 4 levels
        enum Level
        {
            Easy = 0,
            Normal = 1,
            Hard = 2,
            VeryHard = 3
        }
        //Su dung 
        static void Main(string[] args)
        {
            string LevelName;
            Level startLevel = Level.Normal;

            //Chon level choi game.
            Console.WriteLine("Moi ban chon level choi game (0~3) :");
            int userChoose = int.Parse(Console.ReadLine());

            if (userChoose == (int)Level.Easy)
            {
                LevelName = "You chose Easy level";
            }
            else
            {
                LevelName = "You did not choose Easy level";
            }

            // ép kiểu ngược lại từ số nguyên sang kiểu liệt kê
            Level normal = (Level)1;

        }
        #endregion


    }
}


