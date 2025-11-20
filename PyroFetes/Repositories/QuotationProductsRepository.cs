using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class QuotationProductsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<QuotationProduct>(pyrofetesContext, mapper);
