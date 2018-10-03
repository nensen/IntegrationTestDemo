using Core.Domain;
using System;

namespace Core.Repository
{
    /// <summary>
    /// This repository is used in non-test environment
    /// </summary>
    public class FooRepository : IFooRepository
    {
        public Foo Create(Foo foo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Foo Get(int id)
        {
            throw new NotImplementedException();
        }

        public Foo Update(Foo foo)
        {
            throw new NotImplementedException();
        }
    }
}