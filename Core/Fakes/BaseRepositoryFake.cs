using Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Core.Mocks
{
    public class BaseRepositoryFake<T> where T : DomainBase
    {
        private List<T> stubs = new List<T>();

        public BaseRepositoryFake(List<T> stubs)
        {
            this.stubs = stubs;
        }

        public T Create(T stub)
        {
            var id = stubs.Max(s => s.Id) + 1;
            stub.Id = id;
            stubs.Add(stub);
            return Get(stub.Id);
        }

        public bool Delete(int id)
        {
            var stub = Get(id);
            return stub == null ? false : stubs.Remove(stub);
        }

        public T Get(int id)
        {
            return stubs.SingleOrDefault(f => f.Id == id);
        }

        public T Update(T stub)
        {
            Delete(stub.Id);
            return Create(stub);
        }
    }
}