using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TomesRUs.Models;

namespace TomesRUs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TomesRUs.Models.Author> Author { get; set; }
        public DbSet<TomesRUs.Models.Book> Book { get; set; }
    }
}
