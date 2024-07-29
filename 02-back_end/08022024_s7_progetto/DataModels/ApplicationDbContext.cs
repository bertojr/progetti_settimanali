using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.DataModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt)
        : base(opt)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}

