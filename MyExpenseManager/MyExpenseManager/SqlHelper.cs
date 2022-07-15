using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using MyExpenseManager.Models;

namespace MyExpenseManager
{



    public class SqlHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SqlHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Emodel>();
        }
        public Task<int> CreateE(Emodel emp1)
        {

            return db.InsertAsync(emp1);

        }
        public Task<int> UpdateE(Emodel emp1)
        {

            return db.UpdateAsync(emp1);
        }

        public Task<List<Emodel>> ReadE()
        {


            return db.Table<Emodel>().ToListAsync();
        }

        public Task<int> DeleteE(Emodel emp1)
        {
            return db.DeleteAsync(emp1);
        }
    }
}
