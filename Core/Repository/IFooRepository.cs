using Core.Domain;

namespace Core.Repository
{
    public interface IFooRepository
    {
        Foo Get(int id);

        Foo Create(Foo foo);

        Foo Update(Foo foo);

        bool Delete(int id);
    }
}