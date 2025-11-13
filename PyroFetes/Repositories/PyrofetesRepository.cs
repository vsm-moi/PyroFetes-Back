using System.Linq.Expressions;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Plainquire.Page;

namespace PyroFetes.Repositories;

public class PyrofetesRepository<T>(DbContext databaseContext, AutoMapper.IMapper mapper) : RepositoryBase<T>(databaseContext) where T : class
{
    private readonly DbContext _databaseContext = databaseContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Set<T>().AsQueryable().FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> FirstAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Set<T>().AsQueryable().FirstAsync(cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> SingleAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).SingleAsync(cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> SingleAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Set<T>().AsQueryable().SingleAsync(cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="selector"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<decimal> SumAsync(
        ISpecification<T> specification,
        Expression<Func<T, decimal>> selector,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).SumAsync(selector, cancellationToken);
    }

    // /// <summary>
    // /// 
    // /// </summary>
    // /// <param name="specification"></param>
    // /// <param name="selector"></param>
    // /// <param name="cancellationToken"></param>
    // /// <returns></returns>
    // public async Task<int> SumAsync(
    //     ISpecification<T> specification,
    //     Expression<Func<T, int>> selector,
    //     CancellationToken cancellationToken = default)
    // {
    //     return await ApplySpecification(specification).SumAsync(selector, cancellationToken);
    // }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="postProcessor"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<TResult?> ProjectToSingleOrDefaultAsync<TResult>(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="postProcessor"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<TResult?> ProjectToSingleOrDefaultAsync<TResult>(
        ISpecification<T> specification,
        Action<TResult?> postProcessor,
        CancellationToken cancellationToken = default)
    {
        TResult? result = await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        postProcessor(result);
        return result;
    }

    // /// <summary>
    // /// 
    // /// </summary>
    // /// <param name="cancellationToken"></param>
    // /// <typeparam name="TResult"></typeparam>
    // /// <returns></returns>
    // public async Task<TResult?> ProjectToSingleOrDefaultAsync<TResult>(
    //     CancellationToken cancellationToken = default)
    // {
    //     return await _databaseContext.Set<T>().AsQueryable().ProjectTo<TResult>(mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken: cancellationToken);
    // }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<TResult> ProjectToSingleAsync<TResult>(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="postProcessor"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<TResult> ProjectToSingleAsync<TResult>(
        ISpecification<T> specification,
        Action<TResult?> postProcessor,
        CancellationToken cancellationToken = default)
    {
        TResult result = await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
        postProcessor(result);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<TResult> ProjectToSingleAsync<TResult>(
        CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Set<T>()
            .AsQueryable()
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Set<T>()
            .AsQueryable()
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="postProcessor"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        Action<List<TResult>> postProcessor,
        CancellationToken cancellationToken = default)
    {
        List<TResult> results = await _databaseContext.Set<T>()
            .AsQueryable()
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
        postProcessor(results);
        return results;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="postProcessor"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        ISpecification<T> specification,
        Action<List<TResult>> postProcessor,
        CancellationToken cancellationToken = default)
    {
        List<TResult> results = await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
        postProcessor(results);
        return results;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="page"></param>
    /// <param name="postProcessor"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        ISpecification<T> specification,
        EntityPage page,
        Action<List<TResult>> postProcessor,
        CancellationToken cancellationToken = default)
    {
        List<TResult> results = await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .Page(page)
            .ToListAsync(cancellationToken: cancellationToken);
        postProcessor(results);
        return results;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="page"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> ProjectToListAsync<TResult>(
        ISpecification<T> specification,
        EntityPage page,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .Page(page)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="selector"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> SelectManyAsync<TResult>(
        ISpecification<T> specification,
        Expression<Func<T, IEnumerable<TResult>>> selector,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).SelectMany(selector).ToListAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="selector"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<List<TResult>> SelectAsync<TResult>(
        ISpecification<T> specification,
        Expression<Func<T, TResult>> selector,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).Select(selector).ToListAsync(cancellationToken: cancellationToken);
    }
}