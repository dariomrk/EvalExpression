# eval-expression

![Top language](https://img.shields.io/github/languages/top/dariomrk/eval-expression)
![Build & test workflow](https://img.shields.io/github/actions/workflow/status/dariomrk/eval-expression/build-and-test.yaml)
![GitHub issues](https://img.shields.io/github/issues/dariomrk/eval-expression)
![GitHub pull requests](https://img.shields.io/github/issues-pr/dariomrk/eval-expression)
![GitHub](https://img.shields.io/github/license/dariomrk/eval-expression)

An arithmetic expression evaluator built using .NET

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/vs/community/) or other IDE

## Getting started

- Clone this repo `git clone https://github.com/dariomrk/eval-expression.git`
- The source (`/src`) is comprised of four projects:
  - `Lexer`: converts the string expression representation into tokens
  - `Parser`: builds an abstract syntax tree
  - `Interpreter`: evaluates the tree
  - `Core`: wraps the evaluation pipeline with the `Evaluate(...)` method
- The code is tested with unit & integration tests (`/test`)
  - Run them with `dotnet test` or using the integrated test explorer of your IDE

## Usage sample

```csharp
// ...
var result = Core.Core.Evaluate("5+3*(4/2)-7");
Console.WriteLine(result); // will output 4
// ...
```
- Using a debugger you can observe the different steps of evaluating this expression.
- The parser should output an AST like this:
```mermaid
flowchart TD
    %% Nodes
    root[Subtract]
    root_left[Add]
    root_right((7))
    add_left((5))
    add_right[Multiply]
    multiply_left((3))
    multiply_right[Divide]
    divide_left((4))
    divide_right((2))

    %% Connections
    root --> root_left
    root --> root_right
    root_left --> add_left
    root_left --> add_right
    add_right --> multiply_left
    add_right --> multiply_right
    multiply_right --> divide_left
    multiply_right --> divide_right

    %% Styling
    style root fill:tomato
    style root_left fill:tomato
    style add_right fill:mediumseagreen
    style multiply_right fill:mediumseagreen
    style root_right fill:royalblue
    style add_left fill:royalblue
    style multiply_left fill:royalblue
    style divide_left fill:royalblue
    style divide_right fill:royalblue
```