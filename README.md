<div align="center">
    <a href="https://github.com/alexmurari/Exprelsior/">
    <img alt="Exprelsior" width="400" src="https://user-images.githubusercontent.com/11204378/67624226-37b9ec80-f804-11e9-9751-ec3d361163a3.png">
  </a>
  <p>
    <strong>A .NET Standard lambda expression generator for building dynamic predicates.</strong>
  </p>
  <p>
  <a href="https://www.nuget.org/packages/Exprelsior/latest">
    <img alt="Nuget" src="https://img.shields.io/nuget/v/Exprelsior?style=plastic">
  </a>
  <a href="https://ci.appveyor.com/project/alexmurari/exprelsior/branch/master">
    <img src="https://img.shields.io/appveyor/ci/alexmurari/exprelsior/master?style=plastic">
  </a>
  <a href="https://ci.appveyor.com/project/alexmurari/exprelsior/branch/master/tests">
    <img src="https://img.shields.io/appveyor/tests/alexmurari/exprelsior/master?compact_message&style=plastic">
  </a>
  <a href="https://app.codacy.com/manual/alexmurari/Exprelsior/dashboard?bid=15099717">
    <img alt="Codacy branch grade" src="https://img.shields.io/codacy/grade/13449ade8973436395314a32a3c5fe6d/master?style=plastic">
  </a>
  <a href="https://github.com/alexmurari/Exprelsior/blob/master/LICENSE">
    <img src="https://img.shields.io/github/license/alexmurari/exprelsior?style=plastic">
  </a>
  </p>
  <p>
  <a href="https://www.nuget.org/packages/Exprelsior/absoluteLatest">
    <img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Exprelsior?label=nuget-dev&style=plastic">
  </a>
  <a href="https://ci.appveyor.com/project/alexmurari/exprelsior/branch/dev">
    <img alt="AppVeyor branch" src="https://img.shields.io/appveyor/ci/alexmurari/exprelsior/dev?label=build-dev&style=plastic">
  </a>
  <a href="https://ci.appveyor.com/project/alexmurari/exprelsior/branch/dev/tests">
    <img src="https://img.shields.io/appveyor/tests/alexmurari/exprelsior/dev?compact_message&label=tests-dev&style=plastic">
  </a>
  <a href="https://app.codacy.com/manual/alexmurari/Exprelsior/dashboard?bid=15099716">
    <img alt="Codacy branch grade" src="https://img.shields.io/codacy/grade/13449ade8973436395314a32a3c5fe6d/dev?label=code%20quality-dev&style=plastic">
  </a>
  </p>
</div>

## What is Exprelsior?

Exprelsior is a .NET Standard library that enables .NET developers to dynamically create strongly-typed 
binary lambda expressions from pure text using it's own query syntax.

With support to all major .NET data types, including nullable types, nested properties and it's own query syntax, Exprelsior
brings the creation of dynamic predicates to a whole new level.

---

## Table of Contents

1. [Overview](#1-overview)
2. [Usage](#2-usage)
   1. [Query Syntax Example](#query-syntax-example)
   2. [Expression Builder Example](#expression-builder-example)
   3. [Property Accessor Example](#property-accessor-example)
3. [The Query Syntax](#3-the-query-syntax)
   1. [Query Elements](#query-elements)
   2. [Creating Simple Queries](#simple-queries)
   3. [Creating Composite Queries](#composite-queries)
   4. [Accessing Nested Properties](#accessing-nested-properties)
   5. [Representing Null Values](#representing-null-values)
4. [Supported Operators, Types and Keywords](#4-supported-operators-types-and-keywords)
   1. [Comparison Operators](#comparison-operators)
   2. [Compose Operators](#compose-operators)
   3. [Data Types](#data-types)
   4. [Keywords](#keywords)
5. [License](#5-license)

---

## 1. Overview

The objective of this library is to build binary lambda expressions in a dynamic manner.

Example:

```csharp
Expression<Func<Foo, bool>> exp = t => t.Name == "Bar"; // Just a simple predicate
```

Building the above expression using the ***ExpressionBuilder.CreateBinary\<T>*** method:

```csharp
var exp = ExpressionBuilder.CreateBinary<Foo>("Name", "Bar", ExpressionOperator.Equal);
// result: t => t.Name == "Bar"
```

Building the above expression using the ***ExpressionBuilder.CreateBinaryFromQuery\<T>*** method:
  
```csharp
string query = "eq('Name', 'Bar')";
var exp = ExpressionBuilder.CreateBinaryFromQuery<Foo>(query);
// result: t => t.Name == "Bar"
```
---

## 2. Usage

Usages examples for generating dynamic lambda expressions.

###  Query Syntax Example

```csharp
[HttpGet]
public async Task<IActionResult> Get([FromQuery] string query)
{
    // query = "gte('Age', '30')" (without double quotes)
    var exp = ExpressionBuilder.CreateBinaryFromQuery<Foo>(query);
    
    // exp = t => t.Age >= 30

    var result = await FooRepository.GetAsync(predicate: exp);
    
    return result;
}
```
  
### Expression Builder Example

```csharp
[HttpGet]
public async Task<IActionResult> Get([FromQuery] int @operator, [FromQuery] string propertyName, [FromQuery] object value)
{
    // @operator = 5 / property = Age / value = 30
    var exp = ExpressionBuilder.CreateBinary<Foo>(propertyName, value, (ExpressionOperator)@operator);
    
    // exp = t => t.Age >= 30

    var result = await FooRepository.GetAsync(predicate: exp);
    
    return result;
}
```

### Property Accessor Example

```csharp
[HttpGet]
public async Task<IActionResult> Get()
{
    var accessor = ExpressionBuilder.CreateAccessor<Foo>("DateOfBirth.Date");

    // accessor = (Expression<Func<Foo, object>>) t => t.DateOfBirth.Date

    var result = await FooRepository.Query.OrderBy(accessor).ToList();

    return result;
}
```

---

## 3. The Query Syntax

Query syntax description.

### Query Elements

##### Query with single value:
> eq('Name', 'John')

##### Elements of a single-value query:
> operator(property, value)

##### Query with collection of values:
> cov('Name', ['John', 'Johnny', 'Mark', 'Myles', 'Alex'])

##### Elements of a multi-value query:
> operator(property, [collection of values])

##### Elements Description:

> **Operator**: Describes which operation the query performs.
> 
> **Property**: The name of the property that the expression will compare. Supports nested properties.
> 
> **Value/Collection Of Values**: The effective value that the expression will compare the property with.
> It can be a single value or a collection of values.

##### Elements Syntax:

> **Operator**: First query element. No quotes. Precedes the opening parentheses.
>
> > Ex. "**eq**('Property', 'Value')".
>
> **Property**: First query element inside de parenthesis. Surrounded by single quotes.
> Procedes the opening parentheses and precedes the comma separating this element from the value element.
> Consists of simple property name or dot-separated path to the property when nested.
>
> > Ex. "eq(**'Property'**, 'Value')".
> > 
> > Ex. "eq(**'Property.Property2.Property3'**, 'Value')".
>
> **Value (when single)**: Second query element inside the parentheses. Surrounded by single quotes.
> Procedes the comma separating this element from the property element and precedes the closing parenthesis.
> Consists of value representations.
>
> > Ex. "eq('Property', **'Value'**)".
>
> **Value (when multiple)**: Second query element inside the parentheses. Surrounded by square brackets.
> Procedes the comma separating this element from the property element and precedes the closing parenthesis.
> Consists of multiple value representations, each one surrounded by single quotes. Resembles an array.
>
> > Ex. "eq('Property', **['Value', 'Value2', 'Value3']**)".

### Simple Queries

Simple queries are essentially translated to a single expression:

> "eq('Property', 'Value')".

Gets translated to:

> t => t.Property == Value
  
### Composite Queries

Exprelsior supports query composition, where multiple queries can be chained together, generating
an composite expression.

> "eq('Property', 'Value')+**AND**+gt('Property2', 'Value2')".

Gets translated to:

> t => t.Property == Value **&&** t.Property2 > Value2

Multiple levels of query composition are supported:

> "eq('Property', 'Value')+**AND**+gt('Property2', 'Value2')+**OR**+cov('Property3', ['Value3', 'Value4', 'Value5'])".

Which gets translated to:

> t => t.Property == Value **&&** t.Property2 > Value2 **||** collection.Contains(t.Property3)

##### Composite Query Syntax:

> **Compose Operator**: Joins two queries together. Surrounded by plus signs.
> Procedes the previous query closing parentheses and precedes the next query first element.
>
> > Ex. "eq('Property', 'Value')+**AND**+ne('Property2', 'Value2')".

### Accessing nested properties

Exprelsior supports nested properties access.

> "eq('Property.Property2', 'Value')"

Gets translated to:

> t => t.Property.Property2 == value

This is specially useful for checking only the date or time part of a DateTime object:

> "eq('DateTime.Date', '2019-12-31')"

Gets translated to *something like*:

> t => t.DateTime.Date == DateTime(2019, 12, 31)

### Representing null values

Exprelsior supports null values on the query syntax.

> "eq('Property', '!\$NULL\$!')"

Gets translated to:

> t => t.Property == null

## 4. Supported Operators, Types and Keywords

Comprehensive list of the types and operators supported by Exprelsior.

### Comparison Operators

| Operator | Symbol | Query | Expression Builder |
| --- | --- | --- | --- |
| Equal | == | eq | ExpressionOperator.Equal |
| Not Equal | != | ne | ExpressionOperator.NotEqual |
| Less Than | < | lt | ExpressionOperator.LessThan |
| Less Than Or Equal | <= | lte | ExpressionOperator.LessThanOrEqual |
| Greater Than | > | gt | ExpressionOperator.GreaterThan |
| Greater Than Or Equal | >= | gte | ExpressionOperator.GreaterThanOrEqual |
| Contains | X => X.Contains(Y) | ct | ExpressionOperator.Contains |
| Contains On Value | X => Y.Contains(X) | cov | ExpressionOperator.ContainsOnValue |
| Starts With | X => X.StartsWith(Y) | sw | ExpressionOperator.StartsWith |
| Ends With | X => X.EndsWith(Y) | ew | ExpressionOperator.EndsWith |

### Compose Operators

| Operator | Symbol | Query | Expression Builder |
| --- | --- | --- | --- |
| And | && | +AND+ | fullExp = exp1.**And**(exp2) |
| Or | \|\| | +OR+ | fullExp = exp1.**Or**(exp2) |

### Data Types

| Type | Supported | Signed/Unsigned | Nullable Support |
| --- | --- | --- | --- |
| string | ✅ | N/A | N/A |
| bool | ✅ | N/A | ✅ |
| char | ✅ | N/A | ✅ |
| byte | ✅ | ✅ | ✅ |
| short | ✅ | ✅ | ✅ |
| int | ✅ | ✅ | ✅ |
| long | ✅ | ✅ | ✅ |
| float | ✅ | N/A | ✅ |
| double | ✅ | N/A | ✅ |
| decimal | ✅ | N/A | ✅ |
| DateTime | ✅ | N/A | ✅ |
| TimeSpan | ✅ | N/A | ✅ |

### Keywords

| Value | Query | Expression Builder |
| --- | --- | --- |
| null | !\$NULL\$! | null |

## 5. License

[MIT License (MIT)](./LICENSE)
