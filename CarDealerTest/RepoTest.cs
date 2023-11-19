using CarDealer.Contexts;
using CarDealer.Entitys;
using CarDealer.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace CarDealerTest
{
    public class CarDealerTest
    {
        private static async Task<DataContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            await databaseContext.Database.EnsureCreatedAsync();

            return databaseContext;

        }

        public class CreateAsyncTest()
        {
            [Fact]
            public async Task MakerRepository_Add_New_ReturnMakerEntity()
            {
                // Arrange
                var maker = new MakerEntity()
                {
                    Maker = "Tesla"
                };

                var dbContext = await GetDbContext();
                var makerRepository = new MakerRepository(dbContext);

                // Act
                var result = await makerRepository.CreateAsync(maker);

                // assert
                Assert.IsType<MakerEntity>(result);
            }

            [Fact]
            public async Task MakerRepository_Add_New_ReturnsNotNulll()
            {
                // Arrange
                var maker = new MakerEntity()
                {

                };

                var dbContext = await GetDbContext();
                var makerRepository = new MakerRepository(dbContext);

                // Act
                var result = await makerRepository.CreateAsync(maker);

                // assert
                Assert.Null(result);
            }
        }
        public class ReadAsyncTest()
        {
            [Fact]
            public async Task ReadTest_Should_ReturnEmptyCollection()
            {
                // Act
                var result = await new MakerRepository(await GetDbContext()).GetAllAsync();

                // Assert
                Assert.Empty(result);
            }

            [Fact]
            public async Task ReadTest_Should_ReturnCollectionWithOne()
            {
                // Arrange
                var maker = new MakerEntity { Maker = "Tesla" };
                var makerRepository = new MakerRepository(await GetDbContext());

                // Act
                await makerRepository.CreateAsync(maker);
                var result = await makerRepository.GetAllAsync();

                // Assert
                Assert.Single(result);
            }

        }
        public class UpdateAsync()
        {
            [Fact]
            public async Task UpdateTest_Should_returnNullAndEqual()
            {
                // Arrange
                var dbContext = await GetDbContext();
                var makerRepository = new MakerRepository(dbContext);

                // Skapa en ny MakerEntity och lägg till den i databasen
                var maker = new MakerEntity { Maker = "Tesla" };
                await makerRepository.CreateAsync(maker);

                // Ändra något i entiteten
                maker.Maker = "UpdatedMaker";

                // Act
                var updatedMaker = await makerRepository.UpdateAsync(maker);

                // Assert
                Assert.NotNull(updatedMaker);
                Assert.Equal("UpdatedMaker", updatedMaker.Maker);

                // Hämta entiteten igen från databasen för att verifiera att ändringarna har sparats
                var fetchedMaker = await dbContext.Set<MakerEntity>().FindAsync(updatedMaker.Id);
                Assert.NotNull(fetchedMaker);
                Assert.Equal("UpdatedMaker", fetchedMaker.Maker);
            }

        }
        public class DeleteAsync()
        {
            [Fact]
            public async Task DeleteTest_Should_RemoveEntityFromDatabase()
            {
                // Arrange
                var maker = new MakerEntity { Maker = "Tesla" };
                var makerRepository = new MakerRepository(await GetDbContext());
                await makerRepository.CreateAsync(maker);

                // Act
                var deleteResult = await makerRepository.DeleteAsync(maker);
                var existsAfterDelete = await makerRepository.ExistAsync(x => x.Maker == maker.Maker);

                // Assert
                Assert.True(deleteResult); // Kontrollera att borttagningen var framgångsrik
                Assert.False(existsAfterDelete); // Kontrollera att entiteten inte längre existerar i databasen
            }
            [Fact]
            public async Task DeleteTest_ShouldNot_RemoveEntityFromDatabase()
            {
                // Arrange
                var maker = new MakerEntity { Maker = "Tesla" };
                var makir = new MakerEntity { Maker = "Nissan" };
                var makerRepository = new MakerRepository(await GetDbContext());
                await makerRepository.CreateAsync(maker);

                // Act
                var deleteResult = await makerRepository.DeleteAsync(makir);
                var existsAfterDelete = await makerRepository.ExistAsync(x => x.Maker == maker.Maker);

                // Assert
                Assert.False(deleteResult); // Kontrollera att borttagningen var framgångsrik
                Assert.True(existsAfterDelete); // Kontrollera att entiteten inte längre existerar i databasen
            }

        }
        public class ExistAsync()
        {
            [Fact]
            public async Task ExistAsync_Should_ReturnTrueIfInDatabase()
            {
                // Arrange
                var maker = new MakerEntity()
                {
                    Maker = "Tesla"
                };
                var dbContext = await GetDbContext();
                var makerRepository = new MakerRepository(dbContext);
                await makerRepository.CreateAsync(maker);

                // Act
                var result = await makerRepository.ExistAsync(x => x.Maker == maker.Maker);

                // assert
                Assert.True(result);
            }

            [Fact]
            public async Task ExistAsync_Should_ReturnFalseIfNotInDatabase()
            {
                // Arrange
                var maker = new MakerEntity()
                {
                    Maker = "Tesla"
                };
                var dbContext = await GetDbContext();
                var makerRepository = new MakerRepository(dbContext);
                
                // Act
                var result = await makerRepository.ExistAsync(x => x.Maker == maker.Maker);

                // assert
                Assert.False(result);
            }
        }
    }
}