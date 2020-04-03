using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntityDataAccessLayer
{
    class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=StudentCourse;Integrated Security=True");
        }

        public DbSet<StudentPoco> Student { get; set; }
        public DbSet<BookPoco> books { get; set; }

    }
}
