using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using UserBase.Entities;

namespace UserBase.DataAccess.Repositories
{
    public class UserRepository :  IRepository<User>
    {
        SQLiteAsyncConnection _database;

        public UserRepository()
        {
            _database = DatabaseManager.Database;
        }

        public async Task Add(User entity)
        {
            await _database.InsertAsync(entity);
        }

        public async Task Delete(User entity)
        {
            await _database.DeleteAsync<User>(entity.ID);
        }

        public async Task DeleteAll()
        {
            await _database.DeleteAllAsync<User>();
        }

        public async Task Edit(User entity)
        {
            await _database.UpdateAsync(entity);
        }

        public async Task<IList<User>> GetAll()
        {
           return await _database.Table<User>().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();

        }
    }
}
