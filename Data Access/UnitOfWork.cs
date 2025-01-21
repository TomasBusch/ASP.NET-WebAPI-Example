using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebAPI.Data_Access.Database;
using WebAPI.Models;

//TODO Add DB transaction support
namespace WebAPI.Data_Access
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private AppDbContext _Context;
        private ILogger _Logger;

        private IGenericRepository<Cart> _cartRepository;
        private IGenericRepository<Tag> _tagRepository;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<WishList> _wishlistRepository;

        public IGenericRepository<Cart> CartRepository
        { 
            get
            {
                if (this._cartRepository == null)
                {
                    this._cartRepository = new GenericRepository<Cart>(_Context);
                }
                return _cartRepository;
            }
        }
        public IGenericRepository<Tag> TagRepository
        {
            get
            {
                if (this._tagRepository == null)
                {
                    this._tagRepository = new GenericRepository<Tag>(_Context);
                }
                return _tagRepository;
            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(_Context);
                }
                return _categoryRepository;
            }
        }
        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new GenericRepository<Order>(_Context);
                }
                return _orderRepository;
            }
        }
        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_Context);
                }
                return _productRepository;
            }
        }
        public IGenericRepository<WishList> WishlistRepository
        {
            get
            {
                if (this._wishlistRepository == null)
                {
                    this._wishlistRepository = new GenericRepository<WishList>(_Context);
                }
                return _wishlistRepository;
            }
        }

        public UnitOfWork(ILogger<UnitOfWork> logger, AppDbContext context)
        {
            _Context = context;
            _Logger = logger;
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
