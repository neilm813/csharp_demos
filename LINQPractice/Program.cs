using LINQPractice;

List<Country> countries = new List<Country>()
{

    new Country("Saudi Arabia", "Middle East", "Riyadh", 34810000, "In 2017, 400 ancient 'gates' were discovered in the Arabian Desert by using Google Earth."),

    new Country("Peru", "Latin America", "Lima", 32971846, "Peru actually has the highest sand dune in the World!"),

    new Country("Andorra", "Europe", "Andorra la Vella", 77265, "The capital is the highest capital city in Europe at around 1,023 metres (3,356 feet)."),

    new Country("Chile", "Latin America", "Santiago", 19120000, "Chile is home to one of the most powerful powerful observatory for studying the universe."),

    new Country("Albania", "Europe", "Tirana", 2838000, "The oldest lake in Europe (Ohrid) is found in Albania.")
};

// [] Use LINQ to find the First country that is in the "Latin America" region.
// Print the result.
Country? firstFoundLatinAmerican = countries.FirstOrDefault(c => c.Region == "Latin America");
Console.WriteLine($"First found Latin American country: {firstFoundLatinAmerican}");

// [] Find the first country from the region "Oceania" and print it
// if none is found, print "No Oceania country found."
Country? firstOceania = countries.FirstOrDefault(c => c.Region == "Oceania");

if (firstOceania == null)
{
    Console.WriteLine("No Oceania country found.");
}
else
{
    Console.WriteLine(firstOceania);
}

// [] Find the first country that is above 20,000,000 population
// AND in "Latin America" and then print it.
Country? highPopLatinAmerican = countries
    .FirstOrDefault(c => c.Population > 20000000 && c.Region == "Latin America");

Console.WriteLine($"Highest pop Latin American country in our dataset: {highPopLatinAmerican}");

// [] Find all countries WHERE the population is over 10000000 and print them
IEnumerable<Country> highPopCountries = countries.Where(c => c.Population > 10000000);
PrintEach(highPopCountries, $"High Pop countries:");

// [] Find all countries WHERE their name starts with "A" and print them.
// Also print the number of countries found.
List<Country> countriesStartingWithA = countries
    .Where(c => c.Name.StartsWith("A")).ToList();
PrintEach(countriesStartingWithA, $"{countriesStartingWithA.Count} countries that start with A:");

// [] Find the highest population and print that int (only the int).
// hint, look up how to use LINQ to find the max.
int highestPop = countries.Max(c => c.Population);
Console.WriteLine($"The highest population is: {highestPop}");

// [] Use the highest population variable to find and print the
// name of the country with that population.
Country? mostPopulated = countries.FirstOrDefault(c => c.Population == highestPop);

if (mostPopulated != null)
{
    Console.WriteLine($"Most populated country: {mostPopulated.Name}");
}

// [] Print all the countries alphabetically by name.
IEnumerable<Country> alphabetizedCountries = countries.OrderBy(c => c.Name);
PrintEach(alphabetizedCountries, "Alphabetized countries.");

// [] Print the countries that are above 10000000 population alphabetically
// by name.
IEnumerable<Country> highPopAlphabetizedCountries = countries
    .Where(c => c.Population > 10000000)
    .OrderBy(c => c.Name);
PrintEach(highPopAlphabetizedCountries, "Alphabetized high pop countries.");

// [] Bonus: Redo the above query, but this time use LINQ to only Select the
// countries name so that only the names are printed.

IEnumerable<string> highPopAlphabetizedCountries2 = countries
    .Where(c => c.Population > 10000000)
    .OrderBy(c => c.Name)
    .Select(c => c.Name);
PrintEach(highPopAlphabetizedCountries2, "Alphabetized high pop countries.");

// [] Is there a country whose name is longer than 10 letters?
// Only a boolean is being asked for, so that's all your query needs to return
// Hint: look up how "linq methods that return boolean"
bool isAnyCountryNameLongerThan10 = countries.Any(c => c.Name.Length > 10);
Console.WriteLine($"Is any country name longer than 10? {isAnyCountryNameLongerThan10}");


// Helper method to print each item in a List or IEnumerable.
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);

    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}