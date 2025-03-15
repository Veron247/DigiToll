using System;
using DigiToll.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using VehicleIdentification.Domain.Aggregates;

namespace VehicleIdentification.Infrastructure.Persistence;

public class UnitOfWork(VehicleDbContext _context, IServiceProvider _serviceProvider) : IUnitOfWork, IDisposable
{
    private IDbContextTransaction _transaction;

    public IVehicleRepository VehicleRepository => _serviceProvider.GetRequiredService<IVehicleRepository>();

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        if(_transaction != null)
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async Task CommitAsync()
    {
        try 
        {
            await Save();
            await _transaction.CommitAsync();
        } 
        catch 
        {
            await _transaction.RollbackAsync();
            throw;
        }   
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }   
    }

    public void Dispose()
    {
       _transaction.Dispose();
    }
}
