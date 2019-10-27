<div align="center">
    <a href="https://github.com/alexmurari/Exprelsior/">
    <img alt="Exprelsior" width="400" src="https://user-images.githubusercontent.com/11204378/67624226-37b9ec80-f804-11e9-9751-ec3d361163a3.png">
  </a>
  <p>
    A .NET Standard library that dynamically create lambda expressions.
  </p>
  <a href="https://www.nuget.org/packages/Exprelsior">
    <img src="https://img.shields.io/nuget/vpre/Exprelsior.svg?style=flat-square">
  </a>
</div>

## What is Exprelsior?

Exprelsior is a .NET Standard library that enables .NET developers to create strongly-typed 
lambda expressions from pure text using it's own query syntax or from the expression builder method.

The query text is directly converted to lambda expressions, which means that developers 
can pass any query string by URI to an API HTTP GET method, for example, and it will be 
directly parsed to an strongly typed lambda expression.


## Let's start with some examples

* #### The Expression Builder

    ```csharp
    public class Foo
    {
        public string Name { get; set; }
    }
    
    public IEnumerable<Foo> GetFoos()
    {
        Expression<Func<Foo,bool>> expression = ExpressionBuilder.CreateBinary<Foo>(nameof(Foo.Name), "John", ExpressionOperator.StartsWith);
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
        Expression<Func<Foo,bool>> expression = ExpressionBuilder.CreateBinaryFromQuery<Foo>(query);

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

The query is then built by the ``` ExpressionBuilder.CreateBinaryFromQuery<Foo>(query) ``` method.

The resulting expression is: 
> (t => t.Name == "Stan Lee")

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

#### Supported types

> String

> Numeric Types

> DateTime

> Boolean

> Char

> Guid

> Collections of the above types

#### Accessing properties in lower levels

Exprelsior supports accesing properties in lower levels of an object using the dot character (".").

> eq('DateOfBirth.Date', '1922-12-28')

The resulting expression is: 
> t => (t.DateOfBirth.Date == 1922/12/28 00:00:00)

#### Representing null values

Exprelsior supports null values on the query syntax.

> eq('MiddleName', '\$!NULL!\$')

The resulting expression is: 
> (t => t.MiddleName == null)

Just remember that null values can only be used with nullable properties.

#### I want to join multiple queries together!
*Got that covered!*

> eq('Name', 'Stan Lee')+OR+gte('Age', '85')

The resulting expression is: 
> (t => t.Name == "Stan Lee" OrElse t.Age >= 85)

The same result can be achieved with the ``` CreateBinary ``` method.

```csharp
using Exprelsior.Shared.Extensions;

var exp1 = ExpressionBuilder.CreateBinary<Foo>(nameof(Foo.Name), "Stan", ExpressionOperator.StartsWith);
var exp2 = ExpressionBuilder.CreateBinary<Foo>(nameof(Foo.Age), 85, ExpressionOperator.GreaterThanOrEqual);

var fullExp = exp1.Or(exp2);

// Use fullExp normally...
```

##### The aggregate operators

> "**+AND+**" -> "AndAlso" or "&&"

> "**+OR+**" -> "OrElse" or "||"

###### Extension Methods
  
> leftExp.And(rightExp);

> leftExp.Or(rightExp);

## Licence

[MIT License (MIT)](./LICENSE)
