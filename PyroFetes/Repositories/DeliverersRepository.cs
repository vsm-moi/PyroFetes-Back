using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class DeliverersRepository(PyroFetesDbContext lmdContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Deliverer>(lmdContext, mapper);
