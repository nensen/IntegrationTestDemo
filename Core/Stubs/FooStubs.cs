using Core.Domain;
using System.Collections.Generic;

namespace Core.Stubs
{
    public static class FooStubs
    {
        public static List<Foo> Foos { get; } = new List<Foo>()
        {
            new Foo() { Id = 1, Name = "Arabica" },
            new Foo() { Id = 2, Name = "Robusta" },
        };

        public static bool Matches(Foo f1, Foo f2)
        {
            return
                f1.Name == f2.Name &&
                f1.Desc == f2.Desc;
        }
    }
}