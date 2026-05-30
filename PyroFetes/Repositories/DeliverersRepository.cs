using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class DeliverersRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Deliverer>(pyrofetesContext, mapper);