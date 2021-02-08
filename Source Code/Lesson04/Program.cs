using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C = System.Console;
namespace Lesson04
{
    class Program
    {
        // ****** DYNAMIC *********//

        #region Dynamic

        static void Main1(string[] args)
        {
            C.WriteLine("**** Test dynamic program *****");

            dynamic strValue = "TT Design";
            strValue++;

        }

        static void Main2(string[] args)
        {
            string nameCom = "TT Design";
            string description = "This is our company!";

            dynamic dynamicName = nameCom;

            C.WriteLine($"We are in {nameCom}, {description}");
            //=> We are in TT Design, This is our company!
            C.ReadKey();

            //anonymous 
            var person = new
            {
                Name = "Hoan",
                Tuoi = 16
            };
        }

        #endregion


        // ****** GOTO *********//

        #region Goto

        //VD01;
        static void Main3(string[] args)
        {
            int a = 2;
            if (a == 2)
            {
                goto a_Is_2;
            }
            else
            {
                goto a_Is_1;
            }
            C.WriteLine("Do something here!");

        a_Is_1:
            Console.WriteLine("A == 1");
        a_Is_2:
            C.WriteLine("A == 2");

            C.ReadKey();
        }

        //VD02 Ket hop vs Switch;
        static void Main4(string[] args)
        {
            int a = 2;
            switch (a)
            {
                case 1:
                    C.WriteLine("Case 1");
                    break;
                case 2:
                    C.WriteLine("Case 2");
                    goto case 1;
                    C.WriteLine("Case 2 was choose");
                    break;
                case 3: // label case 3
                    C.WriteLine("Case 3");
                    break;
            }
            Console.ReadKey();
        }

        //VD 03 Vong lap vo tan
        static void Main5(string[] args)
        {
            string strValue = "Hello guy!";

        Start:

            // Do something here
            Console.WriteLine("I am Hoan.");
            Console.WriteLine(strValue + "\n\n");

            goto Start;
            C.ReadKey();
        }

        #endregion


        // ****** FOR *********//
        // VD01:
        static void Main6(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                //Do something here
                C.WriteLine($"PROGRAM: {i}");
                C.WriteLine("TT Design hello you!");
                C.WriteLine("************************\n");

            }
            C.ReadKey();
        }

        //VD02 Lặp vô tận:
        static void Main(string[] args)
        {
            for (; ; )
            {
                C.WriteLine("TT Design hello you!");
                C.WriteLine("************************\n");
            }
        }

    }
}
