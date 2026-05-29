using Microsoft.EntityFrameworkCore;
using Taller.CORE.Core.Entities;
using Taller.CORE.Core.Interfaces;
using Taller.CORE.Infraestructura.Data;

namespace Taller.CORE.Infraestructura.Repositories;

public class OrdenServicioRepository : IOrdenServicioRepository
{
    private readonly TallerMecanicoDbContext _context;

    public OrdenServicioRepository(TallerMecanicoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
    {
        return await _context.OrdenServicios
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .ToListAsync();
    }

    public async Task<OrdenServicio?> GetByIdAsync(int id)
    {
        return await _context.OrdenServicios
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<OrdenServicio> AddAsync(OrdenServicio ordenServicio)
    {
        _context.OrdenServicios.Add(ordenServicio);
        await _context.SaveChangesAsync();
        return ordenServicio;
    }

    public async Task<bool> UpdateAsync(OrdenServicio ordenServicio)
    {
        _context.Entry(ordenServicio).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ordenServicio = await _context.OrdenServicios.FindAsync(id);

        if (ordenServicio == null)
        {
            return false;
        }

        _context.OrdenServicios.Remove(ordenServicio);
        await _context.SaveChangesAsync();

        return true;
    }
}