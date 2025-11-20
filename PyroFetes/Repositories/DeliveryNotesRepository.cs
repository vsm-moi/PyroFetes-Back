using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class DeliveryNotesRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<DeliveryNote>(pyrofetesContext, mapper);