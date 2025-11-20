using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class PurchaseProductsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<PurchaseProduct>(pyrofetesContext, mapper);