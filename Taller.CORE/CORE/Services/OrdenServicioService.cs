using Taller.CORE.Core.Entities;
using Taller.CORE.Core.Interfaces;

namespace Taller.CORE.Core.Services;

public class OrdenServicioService : IOrdenServicioService
{
    private readonly IOrdenServicioRepository _repository;

    public OrdenServicioService(IOrdenServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OrdenServicio?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<OrdenServicio> AddAsync(OrdenServicio ordenServicio)
    {
        return await _repository.AddAsync(ordenServicio);
    }

    public async Task<bool> UpdateAsync(int id, OrdenServicio ordenServicio)
    {
        if (id != ordenServicio.Id)
        {
            return false;
        }

        return await _repository.UpdateAsync(ordenServicio);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}