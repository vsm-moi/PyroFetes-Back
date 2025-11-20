using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class WarehouseProductsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<WarehouseProduct>(pyrofetesContext, mapper);