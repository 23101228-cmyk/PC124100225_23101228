using Taller.CORE.Core.Entities;

namespace Taller.CORE.Core.Interfaces;

public interface IOrdenServicioRepository
{
    Task<IEnumerable<OrdenServicio>> GetAllAsync();
    Task<OrdenServicio?> GetByIdAsync(int id);
    Task<OrdenServicio> AddAsync(OrdenServicio ordenServicio);
    Task<bool> UpdateAsync(OrdenServicio ordenServicio);
    Task<bool> DeleteAsync(int id);
}