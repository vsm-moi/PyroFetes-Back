using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class InvoiceProductsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<InvoiceProduct>(pyrofetesContext, mapper);