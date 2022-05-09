using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TodoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-S2IRCOD; database=udemyBlogToDo; integrated security=true;");

            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new ISMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new RaporMAp());
            modelBuilder.ApplyConfiguration(new VaciblikMaps());
            modelBuilder.ApplyConfiguration(new BildirimMap());

            base.OnModelCreating(modelBuilder);
        }

      
        public DbSet<Is> Isler { get; set; }

        public DbSet<Vaciblik> Vacibliks { get; set; }

        public DbSet<Rapor> Rapors { get; set; }
        public DbSet<Bildiris> Bildirises { get; set; }
    }
}
