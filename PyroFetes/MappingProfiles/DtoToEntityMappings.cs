using AutoMapper;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.ProductDelivery.Request;
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
        CreateMap<UpdateDelivererDto, Deliverer>();

        CreateMap<CreateDeliveryNoteDto, DeliveryNote>();
        CreateMap<UpdateDeliveryNoteDto, DeliveryNote>();
        CreateMap<PatchDeliveryNoteRealDeliveryDateDto, DeliveryNote>();

        CreateMap<CreatePriceDto, Price>();
        CreateMap<UpdatePriceDto, Price>();
        CreateMap<PatchPriceSellingPriceDto, Price>();

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<PatchProductMinimalStockDto, Product>();

        CreateMap<CreateProductDeliveryDto, ProductDelivery>();
        CreateMap<UpdateProductDeliveryDto, ProductDelivery>();
        
        CreateMap<CreatePurchaseOrderDto, PurchaseOrder>();
        CreateMap<PatchPurchaseOrderPurchaseConditionsDto,PurchaseOrder>();
        
        CreateMap<CreatePurchaseProductDto, PurchaseProduct>();
        CreateMap<UpdatePurchaseProductDto, PurchaseProduct>();
        CreateMap<PatchPurchaseProductQuantityDto, PurchaseProduct>();
        
        CreateMap<PatchQuotationConditionsSaleDto, Quotation>();
        CreateMap<PatchQuotationMessageDto, Quotation>();
        CreateMap<CreateProductQuotationDto, Quotation>();

        CreateMap<CreateQuotationProductDto, QuotationProduct>();
        CreateMap<UpdateQuotationProductDto, QuotationProduct>();
        CreateMap<PatchQuotationProductQuantityDto, QuotationProduct>();
        
        CreateMap<CreateSettingDto, Setting>();
        CreateMap<PatchSettingElectronicSignatureDto, Setting>();
        CreateMap<PatchSettingLogoDto, Setting>();
        
        CreateMap<CreateSupplierDto, Supplier>();
        CreateMap<UpdateSupplierDto, Supplier>();
        CreateMap<PatchSupplierDeliveryDelayDto, Supplier>();
        
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<PatchUserPasswordDto, User>();

        CreateMap<PatchWareHouseProductQuantityDto, WarehouseProduct>();
    }
}