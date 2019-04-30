using AspnetRunAngular.Application.Models;
using AspnetRunAngular.Core.Entities;
using AutoMapper;

namespace AspnetRunAngular.Application.Mapper
{
    public class ObjectMapper
    {
        public static IMapper Mapper => AutoMapper.Mapper.Instance;

        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>().ReverseMap();
                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
                cfg.CreateMap<ProductStatus, ProductStatusModel>().ReverseMap();
            });
        }
    }
}
