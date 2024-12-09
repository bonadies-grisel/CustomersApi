using customers.data;
using customers.domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Clase genérica de repositorio para manejar operaciones CRUD y consultas adicionales.
/// </summary>
/// <typeparam name="T">Tipo de entidad que hereda de Generic32.</typeparam>
public class Repository<T> : IRepository<T> where T : Generic32
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Inicializa una nueva instancia de la clase Repository.
    /// </summary>
    /// <param name="context">El contexto de base de datos.</param>
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtiene una entidad por su ID.
    /// </summary>
    /// <param name="id">El ID de la entidad a buscar.</param>
    /// <returns>La entidad correspondiente si existe y está activa.</returns>
    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id && e.Active);

        if (entity == null)
        {
            throw new KeyNotFoundException($"La entidad {typeof(T).Name} con id {id} no se pudo encontrar.");
        }

        return entity;
    }

    /// <summary>
    /// Obtiene una lista de todas las entidades activas.
    /// </summary>
    /// <returns>Una lista de entidades activas.</returns>
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().Where(e => e.Active).ToListAsync();
    }

    /// <summary>
    /// Agrega una nueva entidad al contexto de la base de datos.
    /// </summary>
    /// <param name="entity">La entidad a agregar.</param>
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    ///// <summary>
    ///// Busca entidades cuyo nombre contenga el texto especificado.
    ///// </summary>
    ///// <param name="searchText">Texto parcial a buscar en el nombre de las entidades.</param>
    ///// <returns>Lista de entidades activas que contienen el texto buscado.</returns>
    //public async Task<List<T>> SearchAsync(string searchText)
    //{
    //    if (string.IsNullOrWhiteSpace(searchText))
    //    {
    //        throw new ArgumentException("El texto de búsqueda no puede estar vacío o solo contener espacios en blanco.", nameof(searchText));
    //    }

    //    return await _context.Set<T>()
    //        .Where(e => EF.Functions.Like(e.Name, $"%{searchText}%") && e.Active)
    //        .ToListAsync();
    //}

    /// <summary>
    /// Actualiza una entidad existente en el contexto.
    /// </summary>
    /// <param name="entity">La entidad con los valores actualizados.</param>
    public async Task UpdateAsync(T entity)
    {
        var existingEntity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == entity.Id && e.Active);

        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"La entidad {typeof(T).Name} con id {entity.Id} no se pudo encontrar.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        _context.Entry(existingEntity).State = EntityState.Modified;
    }

    /// <summary>
    /// Marca una entidad como inactiva, simulando su eliminación.
    /// </summary>
    /// <param name="entity">La entidad a marcar como inactiva.</param>
    public void Remove(T entity)
    {
        entity.Active = false;
        _context.Set<T>().Update(entity);
    }

    /// <summary>
    /// Guarda los cambios pendientes en la base de datos.
    /// </summary>
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
