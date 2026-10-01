using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Scope_India.DATA;
using Scope_India.DAL;

namespace Scope_India.DATA.Context
{
    public class Scope_IndiaDbContext : DbContext
    {
        public Scope_IndiaDbContext(DbContextOptions<Scope_IndiaDbContext> options) : base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course>  Courses { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        
    }
}
