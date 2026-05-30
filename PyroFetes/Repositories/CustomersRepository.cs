using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class CustomersRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Customer>(pyrofetesContext, mapper);