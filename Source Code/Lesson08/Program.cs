using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson08
{
    class Program
    {
        static void Main1(string[] args)
        {
            Person hoan = new Person();
            hoan.Name = "Pham Hoan";
            hoan.Age = 18;

            Person khu = new Person();
            khu.Name = "Van Khu";
            khu.Age = 16;

            Person hieu = new Person();
            hieu.Name = "Trong Hieu";
            hieu.Age = 14;

            hoan.Speak();
            khu.Speak();
            
            hieu.Speak();
            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            Person noname = new Person();
            noname.Speak();
            //Console.ReadKey();
            for(int i =1; i<2; i++ )
            {
                Person hoan = new Person("Hoan");
                hoan.Speak();
                Console.ReadKey();
                break;
            }

            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            //Tao ra class (Box) /Dai, Rong, Cao
            // Nhap thong tin / Tinh dientich xq, the tich 
            //Tu in ra

            double sum = 0;
            for(int i =1; i<=10; i++)
            {
                Box hlp = new Box(i, i, i);
                hlp.InThongTin();
                sum += hlp.TheTich;
            }
            Console.WriteLine("TONG THE TICH LA: "+sum);
            Console.ReadKey();

        }
    }

    class Box
    {
        //Thuoc tinh
        public double Dai;
        public double Rong;
        public double Cao;
        public double DTXQ;
        public double TheTich;

        //Ham Khoi tao
        public Box()
        {
            Dai = 0;
            Rong = 0;
            Cao = 0;
        }
        public Box(double dai, double rong, double cao)
        {
            Dai = dai;
            Rong = rong;
            Cao = cao;
            TinhDienTichXQ();
            TinhTheTich();
        }

        // Phuong thuc
        public void NhapThongTin()
        {
            Console.WriteLine("Moi nhap dai rong cao:");

            Dai = Convert.ToDouble(Console.ReadLine());
            Rong = Convert.ToDouble(Console.ReadLine());
            Cao = Convert.ToDouble(Console.ReadLine());

            TinhDienTichXQ();
            TinhTheTich();
        }

        public double TinhDienTichXQ()
        {
            DTXQ = (Dai + Rong)*2 * Cao;
            return DTXQ;
        }

        public double TinhTheTich()
        {
            TheTich = Dai * Rong*Cao;
            return TheTich;
        }
        public void InThongTin()
        {
            Console.WriteLine($"Hop co kich thuoc:{Dai}x{Rong}x{Cao}");
            Console.WriteLine($"Hop co thong so DTXQ:{DTXQ}");
            Console.WriteLine($"Hop co thong so TheTich:{TheTich}");
            Console.WriteLine($"********************");
        }
    }

     class Person
    {
        public string Name;
        public int Age;
        public string Address;

        private string TenBoNhi;
        public void Speak()
        {
            Console.WriteLine($"Hello guy! My name is {Name}. I am {Age} years old!");
            Console.WriteLine(TenBoNhi);
        }


        //Constructor
        public Person() //ko doi so
        {
            Name = "NoName";
            Age = 1;
            Address = "Ha Noi";
        }

        public Person(string name, int age = 10) //co doi so
        {
            Name = name;
            Age = age;
        }

        //De constructor
        ~Person()
        {
            MessageBox.Show($"{Name} is deconstructing...");
        }

       
    }

    class Student
    {
        public string Name;
        public int Age;

        private double Math;
        private double Physic;

        private string grade;
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }

    
}
