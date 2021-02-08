using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BTVN_09
{
    class Program
    {
        static void Main(string[] args)
        {
            //5Loai ve HP, DN, NT, QN, HCM 
            string[] inputPlace = { "HP", "DN", "NT", "QN", "HCM" };
            double[] inputPrice = { 50, 80, 120, 150, 250 };

            TickKet[] AllTicket = new TickKet[5];
            for (int i = 0; i < 5; i++)
            {
                TickKet ticket = new TickKet();
                ticket.Flight = inputPlace[i];
                ticket.date = $"{i*2+3}/1/2021";
                ticket.SetPrice(inputPrice[i]);
                AllTicket[i] = ticket;
            }

            //10 Hanh Khach, A, B, C, D, E, F, G, H, I ,K

            //Mua ramdom (1-10 lan) ~ random ve
            string[] AllName = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K" };
            Client[] AllClients = new Client[10];

            for (int j = 0; j < 10; j++)
            {
                Client client = new Client();
                client.Name = AllName[j];
                client.Age = j + 20;
                client.Gender = (Gender)(client.Age % 3);

                client.BuyTikets(AllTicket);
                client.ReArrangeTicket();
                client.CalTotalPrice();
                client.PrintInfor();

                AllClients[j] = client;
                Thread.Sleep(1000); //Fix
            }
            Console.WriteLine("\n\nEnter to sort clients?");
            Console.ReadKey();

            Console.WriteLine("--------- SORTING CLIENTS AS PRICE--------\n");
            double[] uniqueMoney = new double[AllClients.Length]; //Fix 0 later

            int k = 0;
            foreach (var client in AllClients)
            {
                if (!uniqueMoney.Contains(client.TotalPrice))
                {
                    uniqueMoney[k] = client.TotalPrice;
                    k++;
                }
            }

            Array.Sort(uniqueMoney);
            Array.Reverse(uniqueMoney);
            Console.WriteLine("{0,-8}{1,-8}", "Price", "Clients");
            foreach (var price in uniqueMoney)
            {
                if (price == 0) continue;
                Console.Write("{0,-8}", price + "$");
                foreach (var client in AllClients)
                {
                    if (client.TotalPrice == price) Console.Write(client.Name + "   ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }

    class TickKet
    {
        public string Flight;
        public string date;

        private double price;
        public void SetPrice(double p)
        {
            price = p;
        }

        public double GetPrice()
        {
            return price;
        }

    }

    class Person
    {
        public string Name;
        public int Age;
        public Gender Gender;

    }

    class Client : Person
    {
        public TickKet[] AllTickets;
        public TickKet[] UniqueTickets;
        public int[] UniqueNumberTicket;

        public double TotalPrice;

        private Random randomBuyTicketNumber = new Random();
        private Random randomTicketType = new Random(); // One randomObject for seed issue
        public void BuyTikets(TickKet[] allTicket)
        {
            int ticketNums = allTicket.Length;

            //Random so ve' 1-10
            int randomBuyTickets = randomBuyTicketNumber.Next(1, 11);
            AllTickets = new TickKet[randomBuyTickets];

            for (int i = 0; i < randomBuyTickets; i++)
            {
                int randomTicketNumber = randomTicketType.Next(0, ticketNums);
                AllTickets[i] = allTicket[randomTicketNumber];
            }
        }

        public void ReArrangeTicket()
        {
            UniqueTickets = AllTickets.Distinct().ToArray();

            UniqueNumberTicket = new int[UniqueTickets.Length];
            for (int i = 0; i < UniqueTickets.Length; i++)
            {
                int count = 0;
                foreach (var tick in AllTickets)
                {
                    if (tick.Flight == UniqueTickets[i].Flight)
                    {
                        count++;
                    }
                }
                UniqueNumberTicket[i] = count;
            }
        }

        public void CalTotalPrice()
        {
            foreach (var tick in AllTickets)
            {
                TotalPrice += tick.GetPrice();
            }
        }

        public void PrintInfor()
        {
            Console.WriteLine($"***************** CLIENT INFORMATION - {Name} ******************");
            Console.WriteLine($"Name: {Name},   Age: {Age},   Gender: {Gender},    Tickets: {AllTickets.Length}" + "\n");
            Console.WriteLine("---------- Ticket table----------");
            Console.WriteLine("{0,-8}{1,-15}{2,-8}{3,-8}", "Flight", "Date", "Price", "Number");
            for (int i = 0; i < UniqueTickets.Length; i++)
            {
                TickKet tick = UniqueTickets[i];
                int number = UniqueNumberTicket[i];
                Console.WriteLine("{0,-8}{1,-15}{2,-8}{3,-8}", tick.Flight, tick.date, $"{tick.GetPrice()}$", number);
                Console.Write("\n");

            }
            Console.WriteLine($"Total price is: {TotalPrice}$");
            Console.Write("\n\n\n");
        }
    }


    enum Gender
    {
        Male = 0,
        Female = 1,
        Bisexual = 2,
    }
}
