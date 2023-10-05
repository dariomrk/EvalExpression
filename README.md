# EvalExpression

![Top language](https://img.shields.io/github/languages/top/dariomrk/eval-expression)
![Build & test workflow](https://img.shields.io/github/actions/workflow/status/dariomrk/eval-expression/build-and-test.yaml)
![GitHub issues](https://img.shields.io/github/issues/dariomrk/eval-expression)
![GitHub pull requests](https://img.shields.io/github/issues-pr/dariomrk/eval-expression)
![GitHub](https://img.shields.io/github/license/dariomrk/eval-expression)

An arithmetic expression evaluator built using .NET

## Supports:

- Integers, decimal numbers
  - `420`, `1.23`
- Addition, Subtraction, Multiplication, Division, Exponentiation
  - `+`, `-`, `*`, `/`, `^`
- Negative numbers
  - `-(2)`, `-2`
- Parenthesized expressions
  - `2*(1+3)`
- Implicit multiplication
  - `-2(3+1)`
- Extendability
  - `Parser` implemented as a [recursive descent parser](https://en.wikipedia.org/wiki/Recursive_descent_parser)

## Usage sample:

- **Calculate the result on an expression:**

  ```csharp
  using EvalExpression.Extensions;
  using @eval = EvalExpression.EvalExpression;

  var expression = "-(1-(2.5+3*2)^(4/2))";

  var result = @eval
      .Build(expression) // builds the AST
      .Evaluate(); // evaluates the AST

  // Will output: Expression '-(1-(2.5+3*2)^(4/2))' resolves to: 71.25
  Console.WriteLine($"Expression '{expression}' resolves to: {result}");
  ```

- **Convert the AST to JSON:**

  ```csharp
  using EvalExpression.Extensions;
  using @eval = EvalExpression.EvalExpression;

  var result = @eval
      .Build("-(1-(2.5+3*2)^(4/2))")
      .ToJsonString(); // serializes to JSON
  ```

## Prerequisites:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/vs/community/) or other IDE

## Getting started:

- Clone this repo `git clone https://github.com/dariomrk/eval-expression.git`
- The source (`/src`) is comprised of four projects:
  - `Lexer`: converts the string expression into tokens
  - `Parser`: builds an abstract syntax tree
  - `Interpreter`: evaluates the tree
  - `EvalExpression`: provides an easy to use API
- The code is tested with unit & integration tests (`/test`)
  - Run them with `dotnet test` or using the integrated test explorer of your IDE
