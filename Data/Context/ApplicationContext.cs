using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyProjectCursovay.Data.Models;
using MyProjectCursovay.Sourse;

namespace MyProjectCursovay.Data.Context
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Healf> Healfs { get; set; }
        public DbSet<Mana> Manas { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Level> Levels { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connect.GetConnectionStringSqlServer());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
