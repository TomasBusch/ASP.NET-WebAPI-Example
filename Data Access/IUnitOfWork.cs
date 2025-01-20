using Microsoft.EntityFrameworkCore;
using WebAPI.Data_Access.Database;

namespace WebAPI.Data_Access
{
    public interface IUnitOfWork
    {
        ////Start the database Transaction
        //void CreateTransaction();

        ////Commit the database Transaction
        //void Commit();

        ////Rollback the database Transaction
        //void Rollback();

        //DbContext Class SaveChanges method
        void Save();
    }
}
