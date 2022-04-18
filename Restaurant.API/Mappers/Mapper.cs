using AutoMapper;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Food, FoodDto>().ReverseMap();
        }
    }
}
