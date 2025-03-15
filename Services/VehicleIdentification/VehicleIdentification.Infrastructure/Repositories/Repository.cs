using System;
using System.Linq.Expressions;
using DigiToll.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using VehicleIdentification.Infrastructure.Persistence;

namespace VehicleIdentification.Infrastructure.Repositories;

public class Repository<TEntity>(VehicleDbContext Context) : IRepository<TEntity> where TEntity : class
{
    protected readonly VehicleDbContext _context = Context;

public void Add(TEntity entity)
{
	_context.Set<TEntity>().Add(entity);
}

public void AddRange(IEnumerable<TEntity> entities)
{
	_context.Set<TEntity>().AddRange(entities);
}

public bool Any(Expression<Func<TEntity, bool>> predicate)
{
	return _context.Set<TEntity>().Any(predicate);
}

public int Count(Expression<Func<TEntity, bool>> predicate)
{
	return _context.Set<TEntity>().Count(predicate);
}

public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
{
	return _context.Set<TEntity>().Where(predicate);
}

public TEntity Find(int? id)
{
	return _context.Set<TEntity>().Find(id)!;
}

public TEntity Find(string id)
{
	return _context.Set<TEntity>().Find(id)!;
}

public TEntity Get(Expression<Func<TEntity, bool>> predicate)
{
	return _context.Set<TEntity>().FirstOrDefault(predicate)!;
}

public IQueryable<TEntity> GetAll()
{
	return _context.Set<TEntity>();
}

public void Remove(TEntity entity)
{
	_context.Set<TEntity>().Remove(entity);
}

public void RemoveRange(IEnumerable<TEntity> entities)
{
	_context.Set<TEntity>().RemoveRange(entities);
}

public void Update(TEntity entity)
{
	_context.Entry(entity).State = EntityState.Modified;
}

public void UpdateRange(IEnumerable<TEntity> entities)
{
	foreach (var entity in entities)
	{
		Update(entity);
	}
}

public int Save()
{
	return _context.SaveChanges();
}
}
