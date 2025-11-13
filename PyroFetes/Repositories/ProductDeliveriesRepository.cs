using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class ProductDeliveriesRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<ProductDelivery>(pyrofetesContext, mapper);