using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = System.Console;

namespace Lesson05
{
    class Program
    {
        // *********** WHILE **************

        #region While

        //VD 01
        static void Main(string[] args)
        {
            int countLoop = 0;
            int countLoopTime = 0;

            int valueNum = 10;
            int loopTime = 5;

            // Vẽ từ trên xuống LoopTime lần
            while (countLoopTime < loopTime)
            {
                countLoop = 0;
                // vẽ từ trái qua valueNum lần
                while (countLoop < valueNum)
                {
                    Console.Write("{0,8}", countLoop);
                    countLoop++;
                }
                // Mỗi khi hoàn thành một vòng lặp nhỏ thì lại xuống dòng chuẩn vị vẽ lần tiếp theo
                Console.WriteLine();
                countLoopTime++;
            }
            Console.ReadKey();
        }
        //VD 02
        static void Main2(string[] args)
        {
            int Row = 20;
            int Col = 50;

            char drawChar = '@';
            char insideChar = '.';

            int curRow = 1;
            int curCol = 1;

            // Vẽ từ trên xuống
            while (curRow <= Row)
            {
                curCol = 1;
                // Vẽ từ trái sang
                while (curCol <= Col)
                {
                    if (curRow == 1 || curRow == Row || curCol == 1 || curCol == Col)
                    {
                        Console.Write(drawChar); //lúc này là ký tự (@)
                    }
                    else
                    {
                        Console.Write(insideChar); //lúc này là ký tự rỗng ' '
                    }
                    curCol++;
                }

                // mỗi lần vẽ xong một hàng thì xuống dòng
                Console.WriteLine();
                curRow++;
            }
            Console.ReadKey();
        }

        #endregion

        // *********** DO WHILE **************//

        #region DO WHILE

        //VD01
        static void Main5(string[] arg)
        {
            int countLoop = 0;
            int countLoopTime = 0;
            int valueNum = 10;
            int loopTime = 5;
            int minRandomValue = 0;
            int maxRandomValue = 100;

            Random rand = new Random();
            // Vẽ từ trên xuống LoopTime lần
            do
            {
                countLoop = 0;
                // vẽ từ trái qua valueNum lần
                do
                {
                    int showValue = rand.Next(minRandomValue, maxRandomValue);
                    Console.Write("{0,8}", showValue);
                    countLoop++;
                }
                while (countLoop < valueNum);
                Console.WriteLine();
                countLoopTime++;
            }
            while (countLoopTime < loopTime);
            Console.ReadKey();
        }
        //VD02
        static void Main6(string[] arg)
        {
            int Row = 20;
            int Col = 50;

            char drawChar = '@';
            char insideChar = '.';

            int curRow = 1;
            int curCol = 1;

            do
            {
                curCol = 1;
                do
                {
                    //Code here
                    if (curRow == 1 || curCol == 1 || curRow == Row || curCol == Col)
                    {
                        C.Write("@");
                    }
                    else
                    {
                        C.Write(".");
                    }
                    curCol++;
                } while (curCol <= Col);
                C.WriteLine();
                curRow++;
            }
            while (curRow <= Row);
            C.ReadKey();
        }

        #endregion

        // *********** MẢNG 1 CHIỀU **************//
        static void Main7(string[] arg)
        {
            /*
            * Khai báo mảng 1 chiều kiểu string và có tên là TTDesign
            * Sau đó thực hiện cấp phát vùng nhớ với số phần tử tối đa của mảng là 3.
            */
            string[] TTDesign = new string[3];

            //CÁCH 1: Khai báo và cấp phát vùng nhớ
            string[] Array = new string[3];

            //CÁCH 2: Khai báo, cấp phát và khởi tạo giá trị cho mảng
            string[] TTD = new string[] { "TT Design", "This is our company!" };

            //CÁCH 3: Khởi tạo giá trị cho mảng
            int[] IntArray = { 3, 9, 10 };


            //Sử dụng mảng
            int first = IntArray[0];
            string name = TTD[0];

            //Thêm hoặc sửa phần tử
            Array[0] = "Pham Hoan";
            Array[1] = "Van Khu";
            Array[2] = "Van Son";

            C.WriteLine($"Vi tri 2 (Before): {Array[1]}");
            Array[1] = "Khu Kaka";
            C.WriteLine($"Vi tri 2 (After): {Array[1]}");

            //Phương thức của mảng
            int max = IntArray.Max();
            C.WriteLine(max);
            C.ReadKey();


        }

        static void Main8(string[] arg)
        {
            C.OutputEncoding = Encoding.Unicode;

            int[] bangGtr = { 3, 7, 0, 5, 9, 6, 4 };

            for (int i = 0; i < 7; i++)
            {
                C.WriteLine($"Gía trị thứ {i} trong mảng là: {bangGtr[i]}");
            }

            C.ReadKey();
        }
        /// <summary>
        /// BT01: Xóa phần tử thứ i trong mảng
        /// </summary>
        /// <param name="arg"></param>
        public static void Main9(string[] arg)
        {

            int n;
            int[] arr = new int[100];

            int j;


            Console.Write("\nXoa phan tu vi tri i cua mang trong C#:\n");
            Console.Write("------------------------------------------\n");

            Console.Write("Nhap so phan tu can luu giu vao trong mang: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap {0} phan tu vao trong mang:\n", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu - {0}: ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Nhap so thu tu phan tu xoa trong mang: ");
            j = Convert.ToInt32(Console.ReadLine());

            int[] newArr = new int[n - 1];
            for (int i = 0; i < n; i++)
            {
                if (i < j)
                {
                    newArr[i] = arr[i];
                }
                else if (i > j)
                {
                    newArr[i - 1] = arr[i];
                }
            }
            Console.Write("Mảng ban đầu là: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");

            Console.Write("Mảng sau xoa phần tử {0} đầu là: ", j);
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write(newArr[i] + " ");
            }
            Console.Write("\n");
            Console.ReadKey();
        }
        /// <summary>
        /// BT02: In ra các phần tử duy nhất trong mảng
        /// </summary>
        /// <param name="arg"></param>
        public static void Main10(string[] arg)
        {

            int n, bien_dem = 0;
            int[] arr = new int[100];
            int i;


            Console.Write("\nIn cac phan tu duy nhat cua mang trong C#:\n");
            Console.Write("------------------------------------------\n");

            Console.Write("Nhap so phan tu can luu giu vao trong mang: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap {0} phan tu vao trong mang:\n", n);
            for (i = 0; i < n; i++)
            {
                Console.Write("Phan tu - {0}: ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            /*kiem ta cac phan tu giong nhau*/
            Console.Write("\nCac phan tu duy nhat duoc tim thay trong mang la: \n");
            for (i = 0; i < n; i++)
            {
                bien_dem = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    if (arr[i] == arr[j])
                    {
                        bien_dem++;
                    }
                }

                /*In gia tri cua vi tri hien tai trong mang - la gia tri duy nhat 
                khi con tro van chua gia tri ban dau cua no.*/
                if (bien_dem == 0)
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.Write("\n\n");

            Console.ReadKey();
        }
    }
}
