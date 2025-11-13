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
using PyroFetes.DTO.User.Response;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.MappingProfiles;

public class EntityToDtoMappings : Profile
{
    public EntityToDtoMappings()
    {
        CreateMap<Deliverer, GetDelivererDto>();
        
        CreateMap<DeliveryNote, GetDeliveryNoteDto>();
        
        CreateMap<Price, GetPriceDto>();
        
        CreateMap<Product, GetProductDto>();
        
        CreateMap<ProductDelivery, GetProductDeliveryDto>();
        
        CreateMap<PurchaseOrder, GetPurchaseOrderDto>();
        
        CreateMap<PurchaseProduct, GetPurchaseProductDto>();
        
        CreateMap<Quotation, GetQuotationDto>();
        
        CreateMap<QuotationProduct, GetQuotationProductDto>();
        
        CreateMap<Setting, GetSettingDto>();
        
        CreateMap<User, GetUserDto>();

        CreateMap<WarehouseProduct, GetWareHouseProductDto>();
    }
}