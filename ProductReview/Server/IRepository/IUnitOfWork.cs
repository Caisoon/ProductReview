using ProductReview.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReview.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Comment> Comments { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Review> Reviews { get; }
    }
}