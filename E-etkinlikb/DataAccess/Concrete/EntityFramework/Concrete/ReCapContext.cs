using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class ReCapContext : DbContext, IEntity
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4ESB2ND; Database=E-etkinlik; Trusted_Connection=true");
        }

        public DbSet<Activity> Activitys { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<PriceType> PriceType { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Join> Join { get; set; }
        public DbSet<UserImage> ActivityImage { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    }
}
