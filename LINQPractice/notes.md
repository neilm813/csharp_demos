# LINQ Intro

## Description

- LINQ stands for Language Integrated Query. It is a way to query `IEnumerable` data types directly in C# in a way that is similar to how you query a database with SQL, except you don't need to write SQL strings in C# to do it.
- Later, we will use LINQ with the Entity Framework (EF) Object Relational Mapper (ORM) to query our database via collections of C# classes that are related and mapped to database tables.

## Lambdas

```cs
List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();
```

- The above LINQ query filters a list of numbers into a new list of numbers greater than 10. `.Where` is a LINQ method and the `=>` is a lambda function containing our query instructions which is passed into the LINQ method so LINQ knows what we want.
- A lambda is also known as a fat arrow function and an anonymous function. Lambdas are identifiable by the fat arrow `=>` symbol which is used in other languages as well.

### Parts of a Lambda

- A lambda function has two parts, the part to the left of the `=>` is a parameter for the function, and to the right of the `=>` is an expression for querying.
- The parameter to the left of the `=>` can be named anything since parameters are like variables. Parameters hold the data that was inputted (passed in) to the function.
- LINQ queries iterate over a list and execute the lambda function `foreach` item in the list, passing the current item into the lambda's parameter so the expression to the right of the `=>` can refer check each item for querying.
- You can hover over the lambda parameter to see what data type it is.
- The expression on the right is either a 'predicate' or a 'selector'.

### Lambda Parameter Naming

- In general, parameters should be named after the data they will contain, such as `num` for a number, or if that number represents a score, `score` could be more descriptive. However, lambdas are a shorthand function, so shorthand param names are often convention, such as `n` when querying a list of numbers, `u` when querying a list of `User` class instances, or `tm` when querying a list of `TextMessage` class instances.
- This is similar to how people name aliases in SQL when using the `AS` keyword to give an alias to a table name.

### Lambda Selector

```cs
people.Min(person => person.Age);
```

- A lambda selector is used for certain LINQ methods that only need to be told what property / column to use.

### Lambda Predicate

- In grammar, a predicate is one of the main two parts of a sentence, modifying the subject.
- A lambda predicate is identifiable by noticing that the right side of the `=>` evaluates into a boolean, such as using comparison operators or methods that return booleans.

```cs
List<Person> namedNeil = persons.Where(person => person.FirstName == "Neil").ToList();
```

- The `==` equality comparison operator evaluates to a boolean, when your lambda returns a true to `.Where`, LINQ knows it found something you were looking for.

```cs
List<Person> nameStartsWithN = persons.Where(p => p.FirstName.StartsWith("N")).ToList();
```

- `.StartsWith` returns a boolean, it is doing a comparison internally.

## Common Methods

- The dialogue box that appears in VSCode when you are typing out a method or if you hover over one will give you hints on how to use the method, whether it wants a lambda selector or a predicate, and what it returns.

### `.FirstOrDefault`

- Used to find one item from a list, the first one that matches your query (the first time your lambda returns true when given each item iteratively).
- `Default` means if none is found, the default value for that data type is used. For classes, `null` is the default value, so you will need to deal with possible null values. `0` is the default value for `int`.

```cs
// Person? means it could be null if not found.
Person? jane = persons.FirstOrDefault(p => p.FirstName == "Jane");
```

### `.Where`

- Takes a lambda predicate, used to create a new filtered collection. None, some, or all of the items could be filtered out depending on how many match the query.

```cs
List<string> longWords = words.Where(w => w.Length > 10).ToList();
List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
```

### `.Any`

```cs
bool isJohnHere = persons.Any(p => p.FirstName == "John");
```

- This is like `.FirstOrDefault` except instead of returning the whole item found, it just returns true if found or false if nothing was found.

## More Examples

- You can chain multiple LINQ methods to form more complex queries and use results from previous queries to compose new queries with them.

```cs
List<Person> alphabetizedSeniors = persons
  .Where(p => p.Age > 60)
  .OrderBy(p => p.FirstName);
```

```cs
int oldestYear = movies.Min(m => m.Year);
Movie? oldestMovie = movies.FirstOrDefault(m => m.Year == oldestYear);
```
