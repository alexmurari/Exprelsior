<div align="center">
    <a href="https://github.com/alexmurari/Exprelsior/">
    <img alt="MahApps.Metro" width="400" src="https://user-images.githubusercontent.com/11204378/67624226-37b9ec80-f804-11e9-9751-ec3d361163a3.png">
  </a>
  <p>
    A .NET Standard library that dynamically create lambda expressions.
  </p>
</div>

## What is Exprelsior?

Exprelsior is a .NET Standard library that enables .NET developers to create strongly-typed 
lambda expressions from pure text using it's own query syntax or from the expression builder method.

It has it's own full text query syntax, that is directly converted to lambda expressions, 
which means that developers can pass any query string by URI to an API HTTP GET method, for example, 
and it will be directly parsed to an strongly typed lambda expression.


## Let's start with some examples

* #### The Expression Builder

    ```csharp
    public class Foo
    {
        public string Name { get; set; }
    }
    
    public IEnumerable<Foo> GetFoos()
    {
        Expression<Func<Foo,bool>> expression = ExpressionBuilder.CreateBinaryExpression<Foo>(nameof(Foo.Name), "John", ExpressionOperator.StartsWith);
        List<Foo> FooList = new List<Foo>(); // Assume list is populated.

        // The generated expression is t => t.Name.StartsWith("John")
        
        return FooList.Where(expression.Compile());
    }
    ```

* #### The Dynamic Query
  
```csharp
    public class Foo
    {
        public string Name { get; set; }
    }

    public IEnumerable<Foo> GetFoos()
    {
        string query = "sw('Name', 'John')";
        Expression<Func<Foo,bool>> expression = DynamicQueryBuilder.Build<Foo>(query);

        List<Foo> FooList = new List<Foo>(); // Assume list is populated.

        // The generated expression is t => t.Name.StartsWith("John")
        
        return FooList.Where(expression.Compile());
    }
```

## Explaining the query syntax

> eq('Name', 'Stan Lee')

The query syntax is straightforward, it consists of three elements:

* The operator -> "**eq**" which, in this case, stands for "**equals**" or "**==**".

* The property to be compared -> "**'Name'**" which, in this case, is the "**Name**" property from the "**Foo**" class.

* The value to compare the property -> "**'Stan Lee'**".

The query is then built by the ``` DynamicQueryBuilder.Build<Foo>(query) ``` method.

The resulting expression is: ``` (t => t.Name == "Stan Lee") ```

*Simple, isn't?*

#### What about collection values?

*We support them too!*

> cov('Name', ['Stan Lee', 'Kevin Feige', 'Robert Downey Jr.'])

The resulting expression is: 
> t => value(System.String[]).Contains(t.Name, value(System.OrdinalIgnoreCaseComparer))

#### The query operators

> "**EQ**" -> "EQUAL" or "=="

> "**NE**" -> "NOT EQUAL" or "!="

> "**LT**" -> "LESS THAN" or "<"

> "**LTE**" -> "LESS THAN OR EQUAL" or "<="

> "**GT**" -> "GREATER THAN" or ">"

> "**GTE**" -> "GREATER THAN OR EQUAL" or ">="

> "**CT**" -> "CONTAINS" or "X => X.Contains(Y)"

> "**COV**" -> "CONTAINS ON VALUE" or "X => Y.Contains(X)"

> "**SW**" -> "STARTS WITH" or "X => X.StartsWith("Blah")" (strings only)

> "**EW**" -> "ENDS WITH" or "X => X.EndsWith("Blah")" (strings only)

#### Accessing properties in lower levels

Exprelsior supports accesing properties in lower levels of an object using the dot character (".").

> eq('DateOfBirth.Date', '1922-12-28')

The resulting expression is: 
> t => (t.DateTime.Date == 1922/12/28 00:00:00)

## Licence

[MIT License (MIT)](./LICENSE.md)