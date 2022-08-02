using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SalesApi.Infrastructure;

namespace SalesApi.Tests.Services
{
    public class BaseServiceTest : IDisposable
    {
        private const string salesTestDbName = "SalesTestDb";

        protected readonly SalesDbContext _dbContext;
        protected readonly Fixture _fixture;
        protected readonly Mapper _mapper;

        public BaseServiceTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<SalesDbContext>()
                .UseInMemoryDatabase(salesTestDbName, new InMemoryDatabaseRoot())
                .Options;
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));

            _dbContext = new SalesDbContext(dbContextOptions);
            _fixture = new Fixture();
            _mapper = new Mapper(mapperConfig);

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
