using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [Route("api/foo")]
    public class FooController : ControllerBase
    {
        private readonly IFooRepository fooRepository;

        public FooController(IFooRepository fooRepository)
        {
            this.fooRepository = fooRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public Foo Get(int id)
        {
            return fooRepository.Get(id);
        }

        [HttpPost]
        public Foo Create([FromBody] Foo foo)
        {
            return fooRepository.Create(foo);
        }

        [HttpPut]
        public Foo Update([FromBody] Foo foo)
        {
            return fooRepository.Update(foo);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            return fooRepository.Delete(id) ? Ok() : (IActionResult)BadRequest();
        }
    }
}