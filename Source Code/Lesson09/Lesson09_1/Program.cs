using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09
{
    class Program
    {
        #region Static
        static void Main1(string[] args)
        {
            Console.OutputEncoding = ASCIIEncoding.UTF8;
            // Biến tĩnh
            Box box01 = new Box();
            

            Box box02 = new Box();
            
            Box box03 = new Box();
            Box box04 = new Box();
            

            Console.WriteLine("Số lượng box đã tạo ra là: " + Box.CountBox);
            Console.ReadKey();

            // Phương thức tĩnh
            Box.Selfie();
            Console.ReadKey();

        }

        #endregion

        #region KeThua
        static void Main2(string[] args)
        {
            //Cat meomeo = new Cat();

            Cat meomeo = new Cat(500, 20, 2);
            meomeo.Info();
            meomeo.Speak();
            Console.ReadKey();

            //Gọi hàm trùng tên
            meomeo.TakeABath();
            Console.ReadKey();

            //Vấn đề cấp phát vùng nhớ
            Animal miumiu = new Cat();
            // Cat miuYo = new Animal();

        }
        #endregion

        #region DaHinh
        static void Main(string[] args)
        {

        }
        #endregion
    }

    class Box
    {
        //Thuoc tinh
        public double Dai;
        public double Rong;
        public double Cao;
        public double DTXQ;
        public double TheTich;
        //public int CountBoxx;

        public static int CountBox = 0;

        public static void Selfie()
        {
            Console.WriteLine("Xin chào! Tôi là họ nhà Box đẹp zai.");
        }

        //Ham Khoi tao
        public Box()
        {
            Dai = 0;
            Rong = 0;
            Cao = 0;
            CountBox++;
        }

    }

    class Animal
    {
        public Animal()
        {

        }
        protected double Weight;
        protected double Height;
        protected static int Legs;
        public void Info()
        {
            Console.WriteLine(" Weight: " + Weight + " Height: " + Height + " Legs: " +
            Legs);
        }

        //-----CÁC VẤN ĐỀ KẾ THỪA --------//
        //Vấn để khởi tạo
        public Animal(double w, double h, int l)
        {
            Weight = w;
            Height = h;
            Legs = l*2;
        }

        //Vấn đề hàm trùng tên.
        public void TakeABath()
        {
            Console.WriteLine("Take a bath by water");
        }

    }

    class Dog: Animal
    {
        //base.TakeABath();

        public new void TakeABath()
        {
            // tam bang nuoc
            base.TakeABath();
            // 
            Console.WriteLine("Take a bath by licking");
        }
    }

    class Cat : Animal
    {

        public Cat() //vấn đề khởi tạo => ko dùng đk.
        {
            //Lớp Cat kế thừa lớp Animal
            Weight = 500;
            Height = 20;
            Legs = 2;
        }


        public void Speak()
        {
            Console.WriteLine("I am Cat. meo meo meo...");
        }

        //-----CÁC VẤN ĐỀ KẾ THỪA --------//
        //Vấn đề khởi tạo phải gọi lại với từ khóa base
        public Cat(double weight, double height, int legs) : base(weight, height, legs)
        {

        }

        //Vấn đề hàm trùng tên
        public new void TakeABath()
        {
            Console.WriteLine("Take a bath by licking");
            base.TakeABath();
        }


    }
}
