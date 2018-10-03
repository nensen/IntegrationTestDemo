using Core.Domain;
using Core.Repository;
using Core.Stubs;
using System.Collections.Generic;

namespace Core.Mocks
{
    public class FooRepositoryFake : BaseRepositoryFake<Foo>, IFooRepository
    {
        public FooRepositoryFake() : base(FooStubs.Foos)
        { }
    }
}