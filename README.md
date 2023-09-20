# eval-expression

![Top language](https://img.shields.io/github/languages/top/dariomrk/eval-expression)
![Build & test workflow](https://img.shields.io/github/actions/workflow/status/dariomrk/eval-expression/build-and-test.yaml)
![GitHub issues](https://img.shields.io/github/issues/dariomrk/eval-expression)
![GitHub pull requests](https://img.shields.io/github/issues-pr/dariomrk/eval-expression)
![GitHub](https://img.shields.io/github/license/dariomrk/eval-expression)

An arithmetic expression evaluator built using .NET

## Prerequisites:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/vs/community/) or other IDE

## Getting started:

- Clone this repo `git clone https://github.com/dariomrk/eval-expression.git`
- The source (`/src`) is comprised of four projects:
  - `Lexer`: converts the string expression into tokens
  - `Parser`: builds an abstract syntax tree
  - `Interpreter`: evaluates the tree
  - `Core`: wraps the evaluation pipeline with the `Evaluate(...)` method
- The code is tested with unit & integration tests (`/test`)
  - Run them with `dotnet test` or using the integrated test explorer of your IDE

## Usage sample:

```csharp
using EvalExpression.Extensions;
using @eval = EvalExpression.EvalExpression;

var expression = "-(1-(2.5+3*2)^(4/2))";

var result = eval
    .Build(expression) // builds the AST
    .Evaluate(); // evaluates the AST

// Will output: Expression "-(1-(2.5+3*2)^(4/2))" resolves to: 71.25
Console.WriteLine($"Expression \"{expression}\" resolves to: {result}");
```
- Using a debugger you can observe the different steps of evaluating this expression
- The parser should output an AST like this:
```mermaid
graph TD
  classDef unary fill:tomato
  classDef binary fill:royalblue
  classDef numericLiteral fill:mediumseagreen

  negative["UnaryNode
  Negative"]
  subtract["BinaryNode
  Subtract"]
  exponentiate["BinaryNode
  Exponentiate"]
  add["BinaryNode
  Add"]
  multiply["BinaryNode
  Multiply"]
  divide["BinaryNode
  Divide"]

  subtract_left[1]
  add_left[2.5]
  multiply_left[3]
  multiply_right[2]
  divide_left[4]
  divide_right[2]
  
  subgraph Root
    negative:::unary -- Next --> subtract:::binary
  end

  subgraph Depth 1
    subtract -- Left --> subtract_left:::numericLiteral
    subtract -- Right --> exponentiate:::binary
  end

  subgraph Depth 2
    exponentiate -- Left --> add:::binary
    exponentiate -- Right --> divide:::binary
  end

  subgraph Depth 3
    add -- Left --> add_left:::numericLiteral
    add -- Right --> multiply:::binary
    divide -- Left --> divide_left:::numericLiteral
    divide -- Right --> divide_right:::numericLiteral
  end

  subgraph Depth 4
    multiply -- Left --> multiply_left:::numericLiteral
    multiply -- Right --> multiply_right:::numericLiteral
  end
```

## Supports:
- Integers, decimal numbers
  - `420`, `1.23`, etc.
- Addition, Subtraction, Multiplication, Division, Exponentiation
  - `+`, `-`, `*`, `/`, `^`
- Explicit negative numbers
  - `-(2)`
- Parenthesized expressions
  - `2*(1+3)`