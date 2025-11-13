using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class ProductsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Product>(pyrofetesContext, mapper);