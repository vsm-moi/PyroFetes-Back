using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class SuppliersRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Supplier>(pyrofetesContext, mapper);