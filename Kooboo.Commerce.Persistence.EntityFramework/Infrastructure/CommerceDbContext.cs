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
    public class CommerceDbContext : DbContext
    {

        public CommerceDbContext()
            : base()
        {
            //禁用延迟加载
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public CommerceDbContext(string connStr)
            : base(connStr)
        {
            //禁用延迟加载
            //this.Configuration.LazyLoadingEnabled = false;
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
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
