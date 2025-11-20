using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class PricesRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Price>(pyrofetesContext, mapper);