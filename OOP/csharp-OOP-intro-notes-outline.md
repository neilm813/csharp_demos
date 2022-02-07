# OOP

- Use OopExample project or something similar, Hungry Ninja example also provided in case students need the extra help
- [Hungry Ninja Learn Platform](http://learn.codingdojo.com/m/25/5699/40136)

---

## Member

- Anything listed within a class definition
- 3 types
  1. Fields
     - vars declared within the class
  2. Methods
     - functions within a class
     - can be 'overloaded'
       - multiple methods with same name but must have different params so they can be differentiated (diff method signatures)
       - optional parameters can prevent the need to overload, reduce code, and improve readability
         - optional parameters were implemented later, so overloading is still very common
         - optional parameters can cause problems if exposed publicly as an API and then a default value or a param rename
         - other issues [Optional Parameter Caveats](https://lostechies.com/jimmybogard/2010/05/18/caveats-of-c-4-0-optional-parameters/)
  3. Properties
     - typically used to provide safety controls over your fields
     - appear like a field, but behave like a method
     - use `get` and `set` 'accessors'
     - `get` aka 'getter' invoked when property name is used and returns a value of the prop type (could return a private field's val)
     - `set` aka 'setter' is invoked by assignment with a `value` keyword that holds the new value being assigned

---

### Auto-implemented Properties

- `public string Name { get ; set; }`
  - generates a backing field
- backing field or backing store: A private field that stores the data exposed by a public property.

---

### Why Use Properties Over Public Fields?

- Gives you more control
  - can put extra logic in the get & set
- Properties are necessary for data binding, which is used by frameworks
  - Data binding, in the context of .NET, is the method by which controls on a user interface (UI) of a client application are configured to fetch from, or update data into, a data source, such as a database or XML document.
- Properties allows for versioning: if later you need extra logic, adding logic to the getter or setter won't break existing code.
- Properties also allow for other advanced techniques that we won't get into (reflection)

## Project Setup

1. `dotnet new console -o ProjectName`
2. R-click -> add class

### Constructor Example (ctor snippet)

- ```csharp
      public Food(string name, int cal, bool spicy, bool sweet)
      {
        Name = name;
        Calories = cal;
        IsSpicy = spicy;
        IsSweet = sweet;
      }
      // when printing a class instance, .ToString is called
      public override string ToString()
      {
        return $"Name: {Name}, Calories: {Calories}, IsSpicy: {IsSpicy}, IsSweet: {IsSweet}";
      }
  ```

## Take Aways

- Notice new class is `public` and inside our project `namespace` which means we can access the class from any other files that we are working in the same `namespace`
- While in a class you can use `this.` but don't have to
- `private` fields should be camelCased because sometimes there is a private and public prop of the same name. Many prefer to prefix private props with an underscore b/c it's harder to accidentally type the private prop name when it has the same name as a public prop
