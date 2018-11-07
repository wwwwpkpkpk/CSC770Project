using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MysqlTest.Models;

namespace MysqlTest.DataAccess
{
    public class mysqlContext_test : IdentityDbContext<testApplicationUser>
    {
        public mysqlContext_test(DbContextOptions<mysqlContext_test> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
