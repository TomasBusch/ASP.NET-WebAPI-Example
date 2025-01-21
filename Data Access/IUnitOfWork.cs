using Microsoft.EntityFrameworkCore;
using WebAPI.Data_Access.Database;
using WebAPI.Models;

namespace WebAPI.Data_Access
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Cart> CartRepository { get; }

        public IGenericRepository<Tag> TagRepository { get; }
        
        public IGenericRepository<Category> CategoryRepository { get; }
        
        public IGenericRepository<Order> OrderRepository { get; }
        
        public IGenericRepository<Product> ProductRepository { get; }
        
        public IGenericRepository<WishList> WishlistRepository { get; }
        

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
