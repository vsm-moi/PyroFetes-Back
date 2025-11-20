using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class QuotationsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Quotation>(pyrofetesContext, mapper);