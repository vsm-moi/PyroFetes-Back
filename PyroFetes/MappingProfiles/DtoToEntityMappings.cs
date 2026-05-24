using AutoMapper;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.WareHouseProduct.Request;
using PyroFetes.Models;

namespace PyroFetes.MappingProfiles;

public class DtoToEntityMappings : Profile
{
    public DtoToEntityMappings()
    {
        CreateMap<CreateDelivererDto, Deliverer>();
        CreateMap<UpdateDelivererDto, Deliverer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CreateDeliveryNoteDto, DeliveryNote>();
        CreateMap<UpdateDeliveryNoteDto, DeliveryNote>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchDeliveryNoteRealDeliveryDateDto, DeliveryNote>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CreatePriceDto, Price>();
        CreateMap<PatchPriceSellingPriceDto, Price>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.SupplierId, opt => opt.Ignore());

        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchProductMinimalStockDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<CreatePurchaseOrderDto, PurchaseOrder>();
        CreateMap<PatchPurchaseOrderPurchaseConditionsDto,PurchaseOrder>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<CreatePurchaseProductDto, PurchaseProduct>();
        CreateMap<PatchPurchaseProductQuantityDto, PurchaseProduct>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.PurchaseOrderId, opt => opt.Ignore());
        
        CreateMap<PatchQuotationConditionsSaleDto, Quotation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchQuotationMessageDto, Quotation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<CreateProductQuotationDto, Quotation>();

        CreateMap<AddQuotationProductDto, QuotationProduct>();
        CreateMap<PatchQuotationProductQuantityDto, QuotationProduct>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.QuotationId, opt => opt.Ignore());
        
        CreateMap<CreateSettingDto, Setting>();
        CreateMap<PatchSettingElectronicSignatureDto, Setting>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchSettingLogoDto, Setting>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<CreateSupplierDto, Supplier>();
        CreateMap<UpdateSupplierDto, Supplier>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchSupplierDeliveryDelayDto, Supplier>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PatchUserPasswordDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<PatchWareHouseProductQuantityDto, WarehouseProduct>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.WarehouseId, opt => opt.Ignore());
    }
}