using System;
using System.Collections.Generic;

namespace AbstractAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero("Hero1");
            Hero hero2 = new Hero("Hero2");

            Bunker bunker1 = new Bunker("Bunker1");

            hero1.Attack(bunker1);
            hero1.Attack(bunker1);

            hero1.Attack(hero2);

            Console.WriteLine(bunker1.Floors);
        }
    }
}
