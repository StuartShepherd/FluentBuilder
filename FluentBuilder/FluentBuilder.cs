using System.Collections.Generic;

namespace Builder
{
    public class Builder
    {
        // the Builder interface specifies methods for creating the different parts of the product objects.
        public interface IBuilder
        {
            ConcreteBuilder BuildPartA();

            ConcreteBuilder BuildPartB();

            ConcreteBuilder BuildPartC();
        }

        // the concrete builder classes follow the builder interface and provide specific implementations of the building steps. 
        // your program may have several variations of builders, implemented differently.
        public class ConcreteBuilder : IBuilder
        {
            private Product _product = new Product();

            // a fresh builder instance should contain a blank product object, which is used in further assembly.
            public ConcreteBuilder()
            {
                this.Reset();
            }

            public void Reset()
            {
                this._product = new Product();
            }

            // all production steps work with the same product instance.
            public ConcreteBuilder BuildPartA()
            {
                this._product.Add("PartA1");
                return this;
            }

            public ConcreteBuilder BuildPartB()
            {
                this._product.Add("PartB1");
                return this;
            }

            public ConcreteBuilder BuildPartC()
            {
                this._product.Add("PartC1");
                return this;
            }

            // concrete builders are supposed to provide their own methods for retrieving results. 
            // that's because various types of builders may create entirely different products that don't follow the same interface. 
            // therefore, such methods cannot be declared in the base builder interface (at least in a statically typed programming language).

            // usually, after returning the end result to the client, a builder instance is expected to be ready to start producing another product.
            // that's why it's a usual practice to call the reset method at the end of the `GetProduct` method body. However, this behavior is not
            // mandatory, and you can make your builders wait for an explicit reset call from the client code before disposing of the previous result.
            public Product GetProduct()
            {
                Product result = this._product;
                this.Reset();
                return result;
            }
        }

        // it makes sense to use the builder pattern only when your products are quite complex and require extensive configuration.

        // unlike in other creational patterns, different concrete builders can produce unrelated products. 
        // in other words, results of various builders may not always follow the same interface.
        public class Product
        {
            private List<object> _parts = new List<object>();

            public void Add(string part)
            {
                this._parts.Add(part);
            }

            public string ListParts()
            {
                string str = string.Empty;

                for (int i = 0; i < this._parts.Count; i++)
                {
                    str += this._parts[i] + ", ";
                }

                str = str.Remove(str.Length - 2); // removing last ",c"

                return "Product parts: " + str + "\n";
            }
        }

        // the director is only responsible for executing the building steps in a particular sequence. 
        // it is helpful when producing products according to a specific order or configuration. 
        // strictly speaking, the director class is optional, since the client can control builders directly.
        public class Director
        {
            private IBuilder _builder;

            public IBuilder Builder
            {
                set { _builder = value; }
            }

            // the director can construct several product variations using the same building steps.
            public void BuildMinimalViableProduct()
            {
                this._builder.BuildPartA();
            }

            public void BuildFullFeaturedProduct()
            {
                this._builder
                    .BuildPartA()
                    .BuildPartB()
                    .BuildPartC();
            }
        }
    }
}