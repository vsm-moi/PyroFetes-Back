using PyroFetes.Models;

namespace PyroFetes.Repositories;

public class PurchaseOrdersRepository(PyroFetesDbContext pyrofetesContext, AutoMapper.IMapper mapper) : PyrofetesRepository<PurchaseOrder>(pyrofetesContext, mapper);