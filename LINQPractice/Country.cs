using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQPractice
{
    public class Country
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Capital { get; set; }

        public int Population { get; set; }
        public string FunFact { get; set; }

        public Country(string name, string region, string capital, int population, string funFact)
        {
            Name = name;
            Region = region;
            Capital = capital;
            Population = population;
            FunFact = funFact;
        }

        public override string ToString()
        {
            return $@"
Name: {Name}
Region: {Region}
Capital: {Capital}
Population: {Population}
            ";
        }
    }
}