using Dapper;
using DapperProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperProject.Data.Service
{
    public class LibroRepository : Repository<Libros>, ILibroRepository
    {
        public LibroRepository(DatabaseSettings dbSettings)
            : base(dbSettings) { }
     

        public async Task<bool> DeleteLibrosAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Libros> GetFilterLibros(Expression<Func<Libros, bool>> filter)
        {
            return await GetFilter(filter);
        }

        public async Task<List<Libros>> GetFilterLibrosAll(Expression<Func<Libros, bool>> filter)
        {
            return await GetFilterAll(filter);
        }

        public async Task<IEnumerable<Libros>> GetLibrosAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Libros> GetLibrosByIdAsync(int id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<bool> InsertLibrosAsync(Libros Libros)
        {
            return await CreateAsync(Libros);
        }

        public async Task<bool> UpdateLibrosAsync(Libros Libros)
        {
            return await UpdateAsync(Libros);
        }

        public async Task<int> LibrosStoredProcedure(string storedProcedure, DynamicParameters dynamicParameters)
        {
            return await GetStoredProcedure(storedProcedure, dynamicParameters);
        }

        public async Task<List<Libros>> GetQueryLibros(string query)
        {
            return await GetQueryAll(query);
        }
    }
}
