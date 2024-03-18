using AutoMapper;
using Cqrs_Mediator.Application.Features.Product.Commands.CreateProduct;
using Cqrs_Mediator.Application.Features.Product.Commands.DeleteProduct;
using Cqrs_Mediator.Application.Features.Product.Commands.UpdateProduct;
using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;
using Cqrs_Mediator_Domain.Entities;
namespace Cqrs_Mediator.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products,GetAllProductListDto>().ReverseMap();
            CreateMap<Products, AddProductDto>().ReverseMap();
            CreateMap<Products, AddProductCommand>().ReverseMap();
            CreateMap<Products, UpdateProductDto>().ReverseMap();
            CreateMap<Products, UpdateProductCommand>().ReverseMap();
            CreateMap<Products, DeleteProductCommand>().ReverseMap();
        }

    }
}
