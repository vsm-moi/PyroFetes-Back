using AutoMapper;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.DTO.Price.Response;
using PyroFetes.DTO.Product.Response;
using PyroFetes.DTO.ProductDelivery.Response;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.DTO.User.Response;
using PyroFetes.DTO.WareHouse.Response;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.MappingProfiles;

public class EntityToDtoMappings : Profile
{
    public EntityToDtoMappings()
    {
        CreateMap<Deliverer, GetDelivererDto>();

        CreateMap<Supplier, GetSupplierDto>();

        CreateMap<DeliveryNote, GetDeliveryNoteDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductDeliveries));

        CreateMap<Price, GetPriceDto>();

        CreateMap<Product, GetProductDto>()
            .ForMember(dest => dest.References, opt => opt.MapFrom(src => src.Reference));

        CreateMap<ProductDelivery, GetProductDeliveryDto>();

        CreateMap<PurchaseOrder, GetPurchaseOrderDto>()
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier!.Name))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.PurchaseProducts));

        CreateMap<PurchaseProduct, GetPurchaseProductDto>()
            .ForMember(dest => dest.ProductPrice,
                opt => opt.MapFrom(src =>
                    src.Product!.Prices.Where(x => x.SupplierId == src.PurchaseOrder!.SupplierId && x.ProductId == src.ProductId).Select(x => x.SellingPrice).FirstOrDefault()));

        CreateMap<Quotation, GetQuotationDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.QuotationProducts));

        CreateMap<QuotationProduct, GetQuotationProductDto>()
            .ForMember(dest => dest.ProductPrice,
                opt => opt.MapFrom(src =>
                    src.Product!.Prices.Where(x => x.SupplierId == src.Quotation!.SupplierId && x.ProductId == src.ProductId).Select(x => x.SellingPrice).FirstOrDefault()));
        
        CreateMap<Setting, GetSettingDto>();

        CreateMap<User, GetUserDto>();

        CreateMap<WarehouseProduct, GetWareHouseProductDto>();

        CreateMap<Warehouse, GetWareHouseDto>();
    }
}