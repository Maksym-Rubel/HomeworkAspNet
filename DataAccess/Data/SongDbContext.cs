using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class SongDbContext : IdentityDbContext<User>
    {

        public SongDbContext()
        {
            //Database.EnsureCreated();
        }
        public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemWeekDay> ItemWeekDays { get; set; }

        public DbSet<HomeWorkItem> homeWorkItems { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
            .HasMany(m => m.Days)
            .WithMany(m => m.Items);

            modelBuilder.Entity<HomeWorkItem>()
            .HasOne(m=>m.Item)
            .WithMany(m=> m.HomeWorkItems)
            .HasForeignKey(m => m.ItemId)
            .OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<Item>()
           // .HasMany(m => m.ItemWeekDays)
           // .WithOne(m => m.Item)
           // .OnDelete(DeleteBehavior.NoAction);
           // modelBuilder.Entity<WeekDay>()
           //.HasMany(m => m.ItemWeekDays)
           //.WithOne(m => m.Days)
           //.OnDelete(DeleteBehavior.NoAction);

        }

    }
}
