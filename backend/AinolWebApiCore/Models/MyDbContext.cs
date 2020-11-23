using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AinolWebApiCore.Models
{
    public class MyDbContext:DbContext
    {

        public DbSet<Note> Notes {get; set;}


        public MyDbContext(DbContextOptions options) : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>(e =>
            {

                e.HasKey(k => k.IdNote).HasName("Note_PK");
                e.Property(p => p.Title).HasMaxLength(50);
                e.Property(p => p.Text).IsRequired();   

            });

        }



        }
    }
