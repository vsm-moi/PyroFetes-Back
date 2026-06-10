using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class InvoicesRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Invoice>(pyrofetesContext, mapper);