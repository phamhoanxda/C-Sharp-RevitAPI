using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_09_2_Abstract_Interface
{
    class Program
    {
        static void Main1(string[] args)
        {
            Animal cat = new Cat();
            Animal dog = new Dog();

            cat.Speak();
            dog.Speak();

            Console.ReadKey();

        }
        static void Main2(string[] args)
        {
            Animal_2 cat2 = new Cat_2();
            Animal_2 dog2 = new Dog_2();

            cat2.Speak();
            dog2.Speak();

            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            IPerson black = new BlackPeople();
            black.Speak();
            Console.ReadKey();

        }
    }

    // 	Từ khoá virtual và từ khoá override:


    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine(" Animal is speaking. . .");
        }
    }
    class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine(" Cat is speaking. . .");
        }
    }
    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine(" Dog is speaking. . .");
        }
    }


    // PHƯƠNG THỨC THUẦN ẢO ABSTRACT
    abstract class Animal_2
    {
        /*
        Khai báo phương thức thuần ảo nên không cần định nghĩa nội dung cho
        phương thức
        */
        public abstract void Speak();
    }

    class Cat_2 : Animal_2
    {
        public override void Speak()
        {
            Console.WriteLine(" Cat is speaking. . .");
        }
    }
    class Dog_2 : Animal_2
    {
        public override void Speak()
        {
            Console.WriteLine(" Dog is speaking. . .");
        }
    }



    // INTERFACE

    interface IPerson
    { 
        //Không chứa pros
        void Speak();// mặc định là public
    }

    class BlackPeople : IPerson
    {
        public void Speak() // mặc định là public từ Iterface
        {
            Console.WriteLine("I am a black person!");
        }
    }
}
