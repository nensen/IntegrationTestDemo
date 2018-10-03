using Core.Domain;
using Core.Stubs;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests
{
    public class FooControllerTest
    {
        protected readonly HttpClient client;

        protected readonly CustomWebApplicationFactory<Api.Startup> factory =
            new CustomWebApplicationFactory<Api.Startup>();

        private readonly string apiBaseUrl = "/api/foo";

        public FooControllerTest()
        {
            this.client = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldGetCorrectFooById()
        {
            // Arrange
            var expectedFoo = FooStubs.Foos[0];
            var url = $"{apiBaseUrl}/{expectedFoo.Id}";

            // Act
            var response = await client.GetAsync(url);
            var foo = await response.GetResponseContent<Foo>();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.True(FooStubs.Matches(expectedFoo, foo));
        }

        [Fact]
        public async Task ShouldCreateFoo()
        {
            // Arrange
            var expectedFoo = new Foo()
            {
                Name = "Lorem ipsum",
            };
            var fooToBeCreated = expectedFoo.GetAsSerializedString();

            // Act
            var response = await client.PostAsync(apiBaseUrl, fooToBeCreated);
            var createdFoo = await response.GetResponseContent<Foo>();

            // Assert
            Assert.True(FooStubs.Matches(expectedFoo, createdFoo));
        }

        [Fact]
        public async Task ShouldUpdateFoo()
        {
            // Arrange
            var expectedFoo = FooStubs.Foos[0];
            expectedFoo.Name = "UpdatedName";
            var fooToBeUpdated = expectedFoo.GetAsSerializedString();

            // Act
            var response = await client.PutAsync(apiBaseUrl, fooToBeUpdated);
            var updatedFoo = await response.GetResponseContent<Foo>();

            // Assert
            Assert.True(FooStubs.Matches(expectedFoo, updatedFoo));
        }

        [Fact]
        public async Task ShouldDeleteFoo()
        {
            // Arrange
            var fooId = FooStubs.Foos[0].Id;
            var url = $"{apiBaseUrl}/{fooId}";

            // Act
            var response = await client.DeleteAsync(url);

            // Assert 
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}