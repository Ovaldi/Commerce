using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Kooboo.Commerce.Models.Orders;
using Kooboo.Commerce.Models.Catalog;
using Kooboo.Commerce.Persistence.EntityFramework.Mapping;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace Kooboo.Commerce.Persistence.Infrastructure
{
    public class CommerceDbContext:DbContext
    {

        public CommerceDbContext()
            : base()
        {

        }

        public CommerceDbContext(string connStr)
            : base(connStr)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new OrderMap());
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; } 

    }
}
