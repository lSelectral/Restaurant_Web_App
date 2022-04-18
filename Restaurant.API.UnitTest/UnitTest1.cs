using Moq;
using Restaurant_Web_API.Commands.Food.FoodInsert;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;
using Restaurant_Web_API.Queries.FoodQueries.GetAll;
using Restaurant_Web_API.Repositories.FoodRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.API.UnitTest
{
    public class FoodRepositoryTest
    {
        public FoodGetAllQueryHandler FoodGetAllQueryHandler { get; set; }
        public Mock<IFoodRepository> FoodRepositoryMock { get; set; }

        public FoodRepositoryTest()
        {
            FoodRepositoryMock = new Mock<IFoodRepository>();
            FoodGetAllQueryHandler = new FoodGetAllQueryHandler(FoodRepositoryMock.Object);
        }

        [Fact]
        public async void GetAllFoods_Return_200()
        {
            FoodRepositoryMock.Setup(x => x.GetFoods()).Returns(Task.FromResult(new List<Food>() { }));

            var actualValue = await FoodGetAllQueryHandler.Handle(new FoodGetAllQuery(), 
                new System.Threading.CancellationToken());

            Assert.Equal(200, actualValue.StatusCode);
        }
    }
}