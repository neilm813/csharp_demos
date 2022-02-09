using System;
using System.Collections.Generic;

namespace AbstractAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Hero dylan = new Hero("MightWarrior89");
            Hero lynn = new Hero("AllmightWarrior89");
            Bunker orcBunker = new Bunker("Orc House");

            dylan.Attack(lynn);
            dylan.Attack(lynn);
            dylan.Attack(orcBunker);
        }
    }
}
