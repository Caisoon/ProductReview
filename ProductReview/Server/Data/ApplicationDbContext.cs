using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductReview.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductReview.Client.Pages;
using ProductReview.Shared.Domain;
using ProductReview.Server.Configurations.Entities;

namespace ProductReview.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shared.Domain.Comment> Comments { get; set; }

        public DbSet<Shared.Domain.Review> Reviews { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GenreSeedConfiguration());
        }
    }
}
