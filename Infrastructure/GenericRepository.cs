using Application.Contract;
using AutoMapper;
using Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
       
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> dbset;

        public GenericRepository(DbContext context )
        {
            
            _context = context;
     
            dbset = _context.Set<T>();

        }


        public async Task<T> CreatAsync(T entity)
        { 
      
            var SavedEntity = (await dbset.AddAsync(entity)).Entity; 
           
            _context.SaveChangesAsync();
            return SavedEntity;
        }

        public async  Task<T> DeleteAsync(T entity)
        {  
           
            var deletedEntity = dbset.Remove(entity).Entity;
            _context.SaveChangesAsync();
            return deletedEntity;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return  dbset.Select(p => p);///////here
        }

        public async Task<T> GetOneAsync(int Id)
        {
            return await  dbset.FindAsync(Id);
        }

        public async  Task<T> UpdateAsync(T entity)
        {
            //return  await dbset.Update(entity);  
            var updatedEntity = dbset.Update(entity).Entity;
            _context.SaveChangesAsync();
            return updatedEntity;
        }
    }
}
