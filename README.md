# Fluent Builder Design Pattern Example
Fluent builder is a creational design pattern, which allows constructing complex objects step by step.

Fluent builder pattern is a style of coding which force the developer to create the object in sequence by calling each setter method one after the another until all required attributes are set.

Unlike other creational patterns, Builder doesn’t require products to have a common interface. That makes it possible to produce different products using the same construction process.

## Usage examples
The Builder pattern is a well-known pattern in C# world. It’s especially useful when you need to create an object with lots of possible configuration options.

## Identification
* The Builder pattern can be recognized in class, which has a single creation method and several methods to configure the resulting object. Builder methods often support chaining (for example, someBuilder->setValueA(1)->setValueB(2)->create()).

## Applicability
Use the Builder pattern to get rid of a “telescopic constructor”.

Use the Builder pattern when you want your code to be able to create different representations of some product (for example, stone and wooden houses).

Use the Builder to construct Composite trees or other complex objects.

## Getting Started

### Prerequisites

[.NET Core 3.1 SDK or later](https://dotnet.microsoft.com/download/dotnet-core/3.1)
