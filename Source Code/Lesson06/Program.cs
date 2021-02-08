using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    class Program
    {
        /// <summary>
        /// Gọi hàm từ hàm Main
        /// </summary>
        /// <param name="args"></param>
        static void Main1(string[] args)
        {
            MyFirstFunction();
            MySecondFunction();
            Console.ReadKey();
        }

        // Vì hàm Main có static nên các hàm con sẽ phải có static (Đặc tính này sẽ được học trong các bài sau) 
        /// <summary>
        /// Khai báo hàm có kiểu trả về void
        /// </summary>
        static void MyFirstFunction()
        {
            Console.WriteLine("Hello you! This message comes from Function01");
            return;
        }

        static void MySecondFunction()
        {
            Console.WriteLine("How are you? This message comes from Function02");
        }

        static void Main2(string[] args)
        {
            MyFirstFunction();
            MySecondFunction();

            MyFirstFunction();
            MySecondFunction();

            MyFirstFunction();
            MySecondFunction();

            MyFirstFunction();
            MySecondFunction();

            Console.ReadKey();
        }

        /// <summary>
        /// Hàm có kiểu trả về khác void
        /// </summary>
        /// <param name="args"></param>
        static int GetCurrentYear()
        {
            int year;
            year = DateTime.Now.Year;

            return year;
        }

        static void Main3(string[] args)
        {
            int current = GetCurrentYear();
            Console.WriteLine("Nam hien tai la: " + current);
            Console.ReadKey();
        }

        /// **** PARAMETERS *****/
        #region Vidu01
        static int a, b;
        static void Main4(string[] args)
        {
            a = 5;
            b = 6;
            int c = Sum();
            Console.WriteLine("Tong 2 so la: " + c);
            Console.ReadKey();

            // CÁCH 2
            int d = AnotherSum(a, b);
            Console.WriteLine("Tong 2 so la: " + d);
            Console.ReadKey();
        }

        static int Sum()
        {
            return a + b;
        }

        static int AnotherSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        #endregion

        #region Vidu02
        static void Mai5n(string[] args)
        {
            int firstNum = 0;
            int secondNum = 3;

            // in ra màn hình 10 lần tổng 2 số
            for (int count = 0; count < 10; count++)
            {
                PrintSumTwoNumber(firstNum, secondNum);
                // tính toán để tạo ra 2 số mới. Không quan trọng lắm
                firstNum += count;
                secondNum += count * 2 % 5;
            }
            Console.ReadKey();
        }
        static void PrintSumTwoNumber(int firstNumber, int secondNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber,
            SumTwoNumber(firstNumber, secondNumber));
        }
        static int SumTwoNumber(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        #endregion


        // ****** BIẾN TOÀN CỤC & BIẾN CỤC BỘ *********
        // biến toạn cục của các hàm nằm trong class Program
        static int value = 5;
        static void Main(string[] args)
        {
            // in ra màn hình biến toàn cục
            Console.WriteLine(value);
            // thay đổi giá trị của value
            value = 10;
            // kết quả gọi hàm này sẽ không thay đổi vì ưu tiên biến cục bộ hơn
            PrintSomeThing();
            Console.ReadKey();
        }

        static void PrintSomeThing()
        {
            int value = 9;
            Console.WriteLine(value);
        }
    }
}


