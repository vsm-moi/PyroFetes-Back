using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class WareHouseRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Warehouse>(pyrofetesContext, mapper);