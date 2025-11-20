using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class UsersRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<User>(pyrofetesContext, mapper);