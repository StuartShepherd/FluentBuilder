using System;
using static Builder.Builder;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fluent Builder design pattern example");
            Console.WriteLine("Builder is a creational design pattern, which allows constructing complex objects step by step.");
            Console.WriteLine();                       

            // the client code creates a builder object, passes it to the director and then initiates the construction process. 
            // the end result is retrieved from the builder object.
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // remember, the builder pattern can be used without a director class.
            Console.WriteLine("Custom product:");
            builder
                .BuildPartA()
                .BuildPartC();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
