using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class SettingsRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<Setting>(pyrofetesContext, mapper);