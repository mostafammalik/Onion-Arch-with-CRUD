using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IGenericRepository<TEntity>
    { 
        public  Task<TEntity> CreatAsync(TEntity entity);
        public  Task<TEntity> UpdateAsync(TEntity entity);
        public  Task<TEntity> DeleteAsync(TEntity entity);
        public  Task<IQueryable<TEntity>> GetAllAsync();
        public  Task<TEntity> GetOneAsync(int Id);
               
    }
}
